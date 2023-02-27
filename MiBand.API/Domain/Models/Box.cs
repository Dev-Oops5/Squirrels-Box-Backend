using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Box : StateModel
    {
        public string BoxType { get; set; }
        public string PrivateLink { get; set; }
        public bool Download { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Shared> Shareds { get; set; }
    }   
}
