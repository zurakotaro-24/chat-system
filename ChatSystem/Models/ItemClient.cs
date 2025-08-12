namespace ChatSystem.Models
{
    public class ItemClient
    {
        public int itemId { get; set; }
        public Item item { get; set; }
        public int clientId { get; set; }
        public Client client { get; set; }
    }
}
