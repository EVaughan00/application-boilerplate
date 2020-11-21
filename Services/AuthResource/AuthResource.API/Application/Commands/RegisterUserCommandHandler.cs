using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common.Events;
using BuildingBlocks.Common;
using AuthResource.Infrastructure;
using AuthResource.Domain.Aggregates;
using AuthResource.API.DTO;
using AuthResource.API.Utils;
using AuthResource.Domain.Events;
using MediatR;

namespace AuthResource.API.Commands
{
    public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, UserTokenResponseDTO>
    {

        private readonly ILogger<RegisterUserCommandHandler> _logger;
        private readonly IUserRepository _users;
        private readonly JwtGenerator _jwtGenerator;

        public RegisterUserCommandHandler(ILogger<RegisterUserCommandHandler> logger, IUserRepository users, JwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
            _users = users;
            _logger = logger;
        }

        public override async Task<UserTokenResponseDTO> Handle(RegisterUserCommand command, CancellationToken token)
        {

            await Task.CompletedTask;

            _logger.LogInformation("Registering new user: " + command.username);

            var jwt = _jwtGenerator.Generate(command.username, "user");

            _users.Create(new User(command.username, command.password, command.email));

            var user = _users.GetById(command.username);

            if (user == null)
            {
                _logger.LogInformation("Could not register user: " + command.username);
                throw new System.Exception("Could not create user");
            }

            user.AddDomainEvent(new UserCreatedDomainEvent() { Username = command.username });

            _users.Update(user);

            return new UserTokenResponseDTO() { token = jwt };
        }
    }
}