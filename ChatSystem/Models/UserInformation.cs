using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSystem.Models
{
    public class UserInformation
    {
        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string? extensionName { get; set; }
        public string sex { get; set; }
        public DateOnly birthday { get; set; }

        public UserAccount? userAccount { get; set; }
    }
}
