using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class LoginResponse : BaseResponse<Session>
    {
        public LoginResponse(Session resource) : base(resource)
        {
        }

        public LoginResponse(string message) : base(message)
        {
        }
    }
}
