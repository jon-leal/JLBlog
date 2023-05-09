using System.Net.Mail;
using System.Net;

namespace JLBlog.Service
{
    public class EmailSender
    {
        public bool SendMail(string email, string message1)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            message.From = new MailAddress("yourFrom@email.com");
            message.To.Add("to@email.com");
            message.Subject = "Confirm Your Email";
            message.IsBodyHtml = true;
            message.Body = "<a href='" + message1 + "'>Click here to confirm your email</a>";
            smtpClient.Port = 587;
            smtpClient.Host = "sandbox.smtp.mailtrap.io";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("37a1e98a67a2df", "37b2a915c2af2b");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(message);
            return true;
        }

    }
}
