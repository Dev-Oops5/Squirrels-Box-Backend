using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class SessionResponse : BaseResponse<Session>
    {
        public SessionResponse(Session resource) : base(resource)
        {
        }

        public SessionResponse(string message) : base(message)
        {
        }
    }
}
