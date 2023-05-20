using System.ComponentModel.DataAnnotations;

namespace Demo.Pl.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required!")]
        [MinLength(5,ErrorMessage ="Password must be more than 5 characters!")]
        public string NewPassword { get; set; } = null!;


      
        [Compare("NewPassword" , ErrorMessage ="ConfirmPassword does not match new password!")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
