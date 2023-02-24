using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class SectionResponse : BaseResponse<Section>
    {
        public SectionResponse(Section resource) : base(resource)
        {
        }

        public SectionResponse(string message) : base(message)
        {
        }
    }
}
