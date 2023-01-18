using DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace PL.Helpers
{
	public static class EmailSettings
	{
		public static void Send(Email email)
		{
			var smtp = new SmtpClient("smtp.gmail.com", 587);
			smtp.EnableSsl = true; // Encrypted
			smtp.Credentials = new NetworkCredential("hossammariam1995@gmail.com", "kdhfkhgorjuuwatw");
			smtp.Send("hossammariam1995@gmail.com", email.To , email.Subject , email.Body );
 
        }
	}
}
