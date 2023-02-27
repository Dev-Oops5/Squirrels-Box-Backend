namespace MiBand.API.Resources
{
    public class SaveSectionResource
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Color { get; set; }

        public int BoxId { get; set; }

        public bool Active { get; set; }
    }
}
