using HackYeah.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HackYeah.Application.Commands
{
    public class RegisterUserCommand : IRequest
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }

    public class RegisterPasswordCommandHandler : IRequestHandler<RegisterUserCommand> 
    {
        private readonly UserManager<User> _userManager;

        public RegisterPasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return _userManager.CreateAsync(new User
            {
                UserName = request.UserName
            }, request.Password);
        }
    }
}
