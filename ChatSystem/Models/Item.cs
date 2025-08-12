using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSystem.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public double price { get; set; }
        public int? serialNumberId { get; set; }
        public SerialNumber? serialNumber { get; set; }

        public int? categoryId { get; set; }

        [ForeignKey("categoryId")]
        public Category? category { get; set; }

        public List<ItemClient>? itemClients { get; set; }
    }
}
