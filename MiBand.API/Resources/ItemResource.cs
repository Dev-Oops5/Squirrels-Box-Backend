using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Resources
{
    public class ItemResource : StateModel
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public string ItemPhoto { get; set; }

        public int SectionId { get; set; }
    }
}
