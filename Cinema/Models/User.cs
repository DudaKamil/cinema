using System.ComponentModel.DataAnnotations;
using Cinema.Services;

namespace Cinema.Models
{
    public class User
    { 
        [Key]
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }


}