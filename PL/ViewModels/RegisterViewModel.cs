using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Email Is Required")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
		[MinLength(5 , ErrorMessage ="Minimum Password Length Is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare("Password" , ErrorMessage ="Confirmed Password Does Not Match Password")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        public bool IsAgree { get; set; }


    }
}
