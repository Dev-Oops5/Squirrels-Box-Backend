using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class SharedResponse : BaseResponse<Shared>
    {
        public SharedResponse(Shared resource) : base(resource)
        {
        }

        public SharedResponse(string message) : base(message)
        {
        }
    }
}
