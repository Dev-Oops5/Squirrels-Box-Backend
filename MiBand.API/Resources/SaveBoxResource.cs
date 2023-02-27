namespace MiBand.API.Resources
{
    public class SaveBoxResource
    {
        public string Name { get; set; }
        public string Favourite { get; set; }
        public string Color { get; set; }

        public string BoxType { get; set; }
        public string PrivateLink { get; set; }
        public bool Download { get; set; }

        public int UserId { get; set; }

        public bool Active { get; set; }
    }
}
