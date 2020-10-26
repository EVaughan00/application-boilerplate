using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using AuthResource.Infrastructure;
using AuthResource.Domain.Aggregates;
using AuthResource.API.DTO;
using AuthResource.API.Utils;
using System.Collections.Generic;

namespace AuthResource.API.Queries
{
    public class UserQueryHandler : QueryHandler<UserQuery, List<UserResponseDTO>>
    {

        private readonly ILogger<UserQueryHandler> _logger;
        private readonly IUserRepository _users;

        public UserQueryHandler(ILogger<UserQueryHandler> logger, IUserRepository users)
        {
            _users = users;
            _logger = logger;
        }

        public override async Task<List<UserResponseDTO>> Handle(UserQuery query, CancellationToken token)
        {

            await Task.CompletedTask;

            var users = new List<UserResponseDTO>();

            foreach (User user in _users.GetAll()) {
                users.Add(new UserResponseDTO() { username = user.Username });
            }

            if (users == null) {
                _logger.LogInformation("Could not retrieved users");
                return null;
            }

            _logger.LogInformation("Retrieved users");

            return users;
        }
    }
}