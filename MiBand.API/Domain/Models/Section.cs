using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Section : StateModel
    {
        public int BoxId { get; set; }
        public List<Item> Items { get; set; }
    }
}
