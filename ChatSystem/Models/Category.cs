namespace ChatSystem.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Item>? items { get; set; }
    }
}
