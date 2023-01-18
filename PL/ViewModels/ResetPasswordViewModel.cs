using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class ResetPasswordViewModel
    {

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
