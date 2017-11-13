using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Mockup2.Classes
{
    /// <summary>
    /// Static help class to send an email. Uses the Gmail smtp server, which requires an authorized user to send emails.
    /// One was created specifically for this project.
    /// </summary>
    public static class Emailer
    {
        /// <summary>
        /// Sends an email message to the supplied email address, using the supplied subject and message.
        /// </summary>
        /// <param name="email">Email address of the recipient.</param>
        /// <param name="subject">Subject of the email message.</param>
        /// <param name="message">The email message itself.</param>
        public static void SendEmail(string email,string subject,string message)
        {
            Console.WriteLine("Attempting to send email with subject: {0} message: {1} to: {2}", subject, message, email);
            MailMessage mail = new MailMessage("noreply.oversurgery@gmail.com", email);
            SmtpClient client = new SmtpClient();
            
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("noreply.oversurgery@gmail.com", "qaz123456789");
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }
    }
}
