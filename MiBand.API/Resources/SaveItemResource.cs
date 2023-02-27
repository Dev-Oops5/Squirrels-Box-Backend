namespace MiBand.API.Resources
{
    public class SaveItemResource
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Color { get; set; }

        public string Description { get; set; }
        public int Amount { get; set; }
        public string ItemPhoto { get; set; }

        public int SectionId { get; set; }

        public bool Active { get; set; }
    }
}
