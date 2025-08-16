using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSystem.Models
{
    public class UserAccount
    {
        [Key, ForeignKey("userInformation")]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public UserInformation? userInformation { get; set; }
    }
}
