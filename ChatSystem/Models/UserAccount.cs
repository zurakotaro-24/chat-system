using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatSystem.Models
{
    public class UserAccount
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [ForeignKey("id")]
        public UserInformation? userInformation { get; set; }
    }
}
