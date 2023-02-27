namespace MiBand.API.Resources
{
    public class SaveSpecResource
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Color { get; set; }

        public string VariableType { get; set; }
        public string Content { get; set; }
        public double? Currency { get; set; }

        public int ItemId { get; set; }

        public bool Active { get; set; }
    }
}
