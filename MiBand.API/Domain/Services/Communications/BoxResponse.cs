using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class BoxResponse : BaseResponse<Box>
    {
        public BoxResponse(Box resource) : base(resource)
        {
        }

        public BoxResponse(string message) : base(message)
        {
        }
    }
}
