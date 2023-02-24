using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Box : StateModel
    {
        public string BoxType { get; set; }
        public string PrivateLink { get; set; }
        public bool Download { get; set; }

        public int UserId { get; set; }

        public int SessionId { get; set; }
        public List<Section> Sections { get; set; }
    }   
}
