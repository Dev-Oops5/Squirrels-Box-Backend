namespace MiBand.API.Domain.Models.Base
{
    public class AuditableModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
    }
}
