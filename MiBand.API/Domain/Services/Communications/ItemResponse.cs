using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class ItemResponse : BaseResponse<Item>
    {
        public ItemResponse(Item resource) : base(resource)
        {
        }

        public ItemResponse(string message) : base(message)
        {
        }
    }
}
