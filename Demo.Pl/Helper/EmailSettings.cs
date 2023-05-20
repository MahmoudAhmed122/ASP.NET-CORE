using Demo.DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace Demo.Pl.Helper
{
    public static class EmailSettings
    {

        public static void SendEmail(Email email) {
            var client = new SmtpClient("smtp.sendgrid.net", 587); ///Application UnSecure We Use SendGrid 
            client.EnableSsl = true;  /// Encrypted
            client.Credentials = new NetworkCredential("apikey", "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"); ///UserName , Password
            client.Send("tayarcoo66@gmail.com", email.To, email.Title, email.Body);
        }
    }
}
