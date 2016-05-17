using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [MinLength(6, ErrorMessage = "{0} musi mieć co najmniej {1} znaków długości.")]       
        public string Password { get; set; }

        [Required]
        [Display(Name = "Potwierdź Hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string Name { get; set; }
    }
}