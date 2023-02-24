namespace MiBand.API.Domain.Models.Base
{
    public class StateModel : AuditableModel
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Color { get; set; }
    }
}
