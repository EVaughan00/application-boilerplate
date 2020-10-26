using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using AuthResource.Infrastructure;
using AuthResource.Domain.Aggregates;
using AuthResource.API.DTO;
using AuthResource.API.Utils;

namespace AuthResource.API.Commands
{
    public class LoginUserCommandHandler : CommandHandler<LoginUserCommand, UserTokenResponseDTO>
    {

        private readonly ILogger<LoginUserCommandHandler> _logger;
        private readonly IUserRepository _users;
        private readonly JwtGenerator _jwtGenerator;

        public LoginUserCommandHandler(ILogger<LoginUserCommandHandler> logger, IUserRepository users, JwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
            _users = users;
            _logger = logger;
        }

        public override async Task<UserTokenResponseDTO> Handle(LoginUserCommand command, CancellationToken token)
        {

            await Task.CompletedTask;

            _logger.LogInformation("Logging in user: " + command.username);

            var user = _users.GetById(command.username);

            if (user.Password != command.password) {

                _logger.LogInformation("Incorrect password for user: " + command.username);
                throw new System.Exception("Incorrect username or password");

            } else {

                var jwt = _jwtGenerator.Generate(command.username, "user");

                return new UserTokenResponseDTO() { token = jwt };
            }
        }
    }
}