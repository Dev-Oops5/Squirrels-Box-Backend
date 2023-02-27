using MiBand.API.Domain.Models.Base;
using Microsoft.VisualBasic;

namespace MiBand.API.Domain.Models
{
    public class Spec : StateModel
    {
        public string VariableType { get; set; }
        public string Content { get; set; }
        public double? Currency { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
