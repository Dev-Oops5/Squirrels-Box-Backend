using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Resources
{
    public class SessionResource : AuditableModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
