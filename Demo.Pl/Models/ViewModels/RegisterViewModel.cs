using System.ComponentModel.DataAnnotations;

namespace Demo.Pl.Models.ViewModels
{
	public class RegisterViewModel
	{
		[EmailAddress(ErrorMessage ="Email is not Valid!")]
		[Required(ErrorMessage ="Email is Required!")]
        public string Email { get; set; } = null!;

		[Required(ErrorMessage = "Password is Required!")]
		[MinLength(5,ErrorMessage ="Password must be more than 5 Characters")]
		public string Password { get; set; } = null!;

		[Required(ErrorMessage = "ConfirmPassword is Required!")]
		[Compare("Password", ErrorMessage = "ConfirmPassword does not match Password!")]
		public string ConfirmPassword { get; set; } = null!;

        public bool IsAgree { get; set; }


    }
}
