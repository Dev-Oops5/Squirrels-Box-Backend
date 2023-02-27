using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Item : StateModel
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public string ItemPhoto { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
        public ICollection<Spec> Specs { get; set; }
    }
}
