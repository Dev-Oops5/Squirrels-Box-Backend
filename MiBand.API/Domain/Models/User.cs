using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class User : AuditableModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        public string Birthday { get; set; }
        public int BoxCounter { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
        public ICollection<Box> Boxes { get; set; }

        public List<Shared> Shareds { get; set; }
    }
}
