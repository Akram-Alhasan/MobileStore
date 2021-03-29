using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MobileStore.Services.Identity.Application.Commands;
using MobileStore.Services.Identity.Domain.Entities;
using MobileStore.Services.Identity.WebApi.InputModel;

namespace MobileStore.Services.Identity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMediator _mediator;  

        public AuthController(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator; 
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var result = await _mediator.Send(registerCommand);
            if(result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result =await  _mediator.Send(command);
            if(result.Succeeded)
            {
                return Ok(new
                {
                    token = result.Payload
                });
            }
            return BadRequest(result.Errors);
        }
    }
}
