using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class SpecResponse : BaseResponse<Spec>
    {
        public SpecResponse(Spec resource) : base(resource)
        {
        }

        public SpecResponse(string message) : base(message)
        {
        }
    }
}
