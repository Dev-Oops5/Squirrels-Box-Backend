namespace MiBand.API.Resources
{
    public class SaveSharedResource
    {
        public int OwnerId { get; set; }
        public int ReceiverId { get; set; }
        public int BoxId { get; set; }
        public string Role { get; set; }

        public bool Active { get; set; }
    }
}
