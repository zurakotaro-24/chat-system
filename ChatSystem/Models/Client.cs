namespace ChatSystem.Models
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public List<ItemClient>? itemClients { get; set; }

    }
}
