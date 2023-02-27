using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Resources
{
    public class BoxResource : StateModel
    {
        public string BoxType { get; set; }
        public string PrivateLink { get; set; }
        public bool Download { get; set; }

        public int UserId { get; set; }
    }
}
