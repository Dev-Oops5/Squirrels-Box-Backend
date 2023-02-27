using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Resources
{
    public class UserResource : AuditableModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserPhoto { get; set; }
        public string Birthday { get; set; }
        public int BoxCounter { get; set; }
        public int SessionId { get; set; }
    }
}
