using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class User : AuditableModel
    {
        public DateTime Birthday { get; set; }
        public int BoxCounter { get; set; }

        public int SessionId { get; set; }
        public List<Box> Boxes { get; set; }
    }
}
