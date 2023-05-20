using System.ComponentModel.DataAnnotations;

namespace Demo.Pl.Models.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Email is not Valid!")]
        [Required(ErrorMessage = "Email is Required!")]
        public string Email { get; set; } = null!;
    }
}
