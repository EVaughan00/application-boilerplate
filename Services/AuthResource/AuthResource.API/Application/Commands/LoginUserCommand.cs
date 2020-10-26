using BuildingBlocks.Common;
using AuthResource.API.DTO;

namespace AuthResource.API.Commands
{
    public class LoginUserCommand : Command<UserTokenResponseDTO>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}