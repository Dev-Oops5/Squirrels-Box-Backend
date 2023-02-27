using MiBand.API.Domain.Models.Base;

namespace MiBand.API.Resources
{
    public class SpecResource : StateModel
    {
        public string VariableType { get; set; }
        public string Content { get; set; }
        public double? Currency { get; set; }

        public int ItemId { get; set; }
    }
}
