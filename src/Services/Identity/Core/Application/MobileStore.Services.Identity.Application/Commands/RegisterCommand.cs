using MediatR;
using Microsoft.AspNetCore.Identity;
using MobileStore.BuildingBlocks.Shared.Shared.Models.Results;
using MobileStore.Services.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStore.Services.Identity.Application.Commands
{
    public class RegisterCommand : IRequest<GResult>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public class Handler : IRequestHandler<RegisterCommand, GResult>
        {
            private readonly UserManager<User> _userManager;
            public Handler(UserManager<User> userManager)
            {
                _userManager = userManager;
            }
            public async Task<GResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                
                User user = new User
                {
                    Email = request.Email,
                    UserName = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };

                var userCreateResult = await _userManager.CreateAsync(user, request.Password);

                if (userCreateResult.Succeeded)
                {
                    return GResult.Success; 
                }
                var errorslist = new List<GError>();
                foreach (var error in userCreateResult.Errors)
                {
                    errorslist.Add(new GError
                    {
                        Code = 400,
                        ErrorMessage = error.Description
                    });
                }
                return GResult.Failed(errorslist.ToArray()); 
            }
        }
    }
}
