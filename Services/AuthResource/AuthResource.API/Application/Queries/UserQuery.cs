using BuildingBlocks.Common;
using AuthResource.API.DTO;
using System.Collections.Generic;

namespace AuthResource.API.Queries
{
    public class UserQuery : Query<List<UserResponseDTO>>
    {
        public string username { get; set; }

    }
}