using BuildingBlocks.Common;
using AuthResource.API.DTO;

namespace AuthResource.API.Commands
{
    public class RegisterUserCommand : Command<UserTokenResponseDTO>
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

    }
}