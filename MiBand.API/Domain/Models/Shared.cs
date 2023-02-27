using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Shared : AuditableModel
    {
        public int OwnerId { get; set; }
        public int ReceiverId { get; set; }
        public int BoxId { get; set; }
        public string Role { get; set; }

        public User Owner { get; set; }
        public Box Box { get; set; }
        public User Receiver { get; set; }
    }
}
    