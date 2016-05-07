using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [DisplayName("Login")]
        public string Login { get; set; }

        [DisplayName("Hasło")]
        public string Password { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Imię")]
        public string Name { get; set; }
    }
}