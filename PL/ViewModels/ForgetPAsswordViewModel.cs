using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
	public class ForgetPAsswordViewModel
	{
		[Required (ErrorMessage ="Email Address Is Required")]
		[EmailAddress (ErrorMessage ="Invalid Email")]
		public string Email { get; set; }
	}
}
