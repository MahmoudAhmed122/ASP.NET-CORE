using System.ComponentModel.DataAnnotations;

namespace Demo.Pl.Models.ViewModels
{
    public class LoginViewModel
    {
       
		[EmailAddress(ErrorMessage = "Email is not Valid!")]
        [Required(ErrorMessage = "Email is Required!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required!")]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }

    }
}
