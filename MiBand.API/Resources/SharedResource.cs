using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Resources
{
    public class SharedResource : AuditableModel
    {
        public int OwnerId { get; set; }
        public int ReceiverId { get; set; }
        public int BoxId { get; set; }
        public string Role { get; set; }
    }
}
