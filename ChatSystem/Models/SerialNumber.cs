using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSystem.Models
{
    public class SerialNumber
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public int? itemId { get; set; }

        [ForeignKey("itemId")]
        public Item? item { get; set; }
    }
}
