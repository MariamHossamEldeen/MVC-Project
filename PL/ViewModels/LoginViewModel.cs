using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(5, ErrorMessage = "Minimum Password Length Is 5")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

 

        public bool RemmemberMe { get; set; }
    }
}
