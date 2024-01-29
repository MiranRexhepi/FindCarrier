using FindCarrier.Domain.Entities;
using FindCarrier.HttpResponses;
using FindCarrier.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindCarrier.Commands.Authenticate
{
    public class Register
    {
        public class Command : IRequest<Response>
        {
            public ApplicationUserViewModel Model { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Response>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public CommandHandler(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
            { 
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var userExists = await _userManager.FindByNameAsync(request.Model.Email);

                if (userExists != null)
                    return new Response 
                    { 
                        Status = "Error", 
                        Message = "User already exists!" 
                    };

                var createUser = await _userManager.CreateAsync(new ApplicationUser
                {
                    Email = request.Model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Model.Email
                }, request.Model.Password);

                if (!createUser.Succeeded)
                    return new Response 
                    { 
                        Status = "Error", 
                        Message = "User creation failed! Please check user details and try again."
                    };

                if (!await _roleManager.RoleExistsAsync("admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                }
                await _userManager.AddToRoleAsync(new ApplicationUser
                {
                    Email = request.Model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Model.Email
                }, "admin");
                return new Response 
                { 
                    Status = "Success", 
                    Message = "User created successfully!" 
                };
            }
        }
    }
}