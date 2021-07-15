using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MobileStore.BuildingBlocks.Shared.Shared.Models.Results;
using MobileStore.Services.Identity.Application.Settings;
using MobileStore.Services.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStore.Services.Identity.Application.Commands
{
    public class LoginCommand : IRequest<GResult<string>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public class Handler : IRequestHandler<LoginCommand , GResult<string>>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IOptions<JwtSettings> _jwtSettings; 

            public Handler(UserManager<User> userManager , SignInManager<User> signInManager, IOptions<JwtSettings> jwtSettings)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtSettings = jwtSettings; 
            }

            public async Task<GResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = _userManager.Users.SingleOrDefault(u => u.UserName == request.Email);
                if (user is null)
                {
                    return GResult<string>.Failed(new GError
                    {
                        Code = 400,
                        ErrorMessage = "Email or password incorrect."
                    });
                }

                //var userSigninResult = await _userManager.CheckPasswordAsync(user, request.Password);
                //var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberLogin, lockoutOnFailure: true);

                var userSignInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password , true);

                if (userSignInResult.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    return GResult<string>.Success(GenerateJwt(user,roles));
                }
                return GResult<string>.Failed(new GError
                {
                    Code = 400,
                    ErrorMessage = "Email or password incorrect."
                });
                
            }
            private string GenerateJwt(User user, IList<string> roles)
            {

                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

                var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
                claims.AddRange(roleClaims);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.Value.ExpirationInDays));

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Value.Issuer,
                    audience: _jwtSettings.Value.Issuer,
                    claims,
                    expires: expires,
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
}
