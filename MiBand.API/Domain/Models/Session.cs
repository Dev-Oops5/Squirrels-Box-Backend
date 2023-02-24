using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Domain.Models
{
    public class Session : AuditableModel
    {
        public int Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        
        public User User { get; set; }
    }
}
