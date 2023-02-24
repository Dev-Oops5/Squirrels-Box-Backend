using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Item : StateModel
    {
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Picture { get; set; }

        public int SectionId { get; set; }
        public List<Spec> Specs { get; set; }
    }
}
