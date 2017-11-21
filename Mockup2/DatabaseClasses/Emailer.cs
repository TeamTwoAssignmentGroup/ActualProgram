using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Mime;
using Mockup2.DatabaseClasses;

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
        /// <param name="attachments">A variable list of <see cref="System.Net.Mail.Attachment"/>s to send along with the email.</param>
        public static void SendEmailWithAttachments(string email, string subject, string message, params Attachment[] attachments)
        {
            if (!Program.SEND_EMAILS)
            {
                Console.WriteLine("You're attempting to send an email, but they're disabled in Program.");
                return;
            }
            new Thread(() => {
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
                mail.IsBodyHtml = true;
                foreach(Attachment a in attachments)
                {
                    mail.Attachments.Add(a);
                }
                client.Send(mail);
            }).Start();
            
        }

        /// <summary>
        /// Convenience method to send email using strings of local file names as attachments.
        /// </summary>
        /// <param name="email">Email address to send email to.</param>
        /// <param name="subject">Subject of the email.</param>
        /// <param name="message">Message body of the email.</param>
        /// <param name="fileNamesToAttach">A fixed length array of strings representing local file names to be used as attachments.</param>
        public static void SendEmail(string email, string subject, string message, params string[] fileNamesToAttach)
        {
            List<Attachment> attachments = new List<Attachment>();
            if (fileNamesToAttach != null)
            {
                foreach (string s in fileNamesToAttach)
                {
                    attachments.Add(new Attachment(s));
                }
            }
            Emailer.SendEmailWithAttachments(email, subject, message, attachments.ToArray());
        }

        /// <summary>
        /// Sends a preformatted HTML email to the supplied email address, which should be a Patient's, detailing their appointment date and time
        /// as well as the member of staff they will be seeing.
        /// </summary>
        /// <param name="email">Email address of patient.</param>
        /// <param name="staff">The Staff object that representing the member of staff that the patient will be seeing.</param>
        /// <param name="date">The date of the appointment.</param>
        /// <param name="time">The time of the appointment.</param>
        public static void SendAppointmentEmail(string email, Staff staff, DateTime date,DateTime time)
        {
            if (!Program.SEND_EMAILS)
            {
                Console.WriteLine("You're attempting to send an email, but they're disabled in Program.");
                return;
            }
            string staffString = staff.JobRole + " " + staff.FirstName + " " + staff.LastName;
            string dateString = date.ToString("dd/MM/yyyy");
            string timeString = time.ToString("HH:mm");
            new Thread(() => {
                string bodyString = string.Format(Properties.Resources.formattedemail, DateTime.Now.ToShortDateString(), staffString, dateString, timeString);
                MailMessage mail = new MailMessage("noreply.oversurgery@gmail.com", email);
                SmtpClient client = new SmtpClient();

                // Images
                // NHS
                Bitmap logo = Properties.Resources.logo;
                MemoryStream logoMS = new MemoryStream();
                logo.Save(logoMS, ImageFormat.Jpeg);
                logoMS.Position = 0;
                Attachment logoAttachment = new Attachment(logoMS, "", MediaTypeNames.Image.Jpeg);
                logoAttachment.ContentId = "logo.images.oversurgery";
                logoAttachment.ContentDisposition.Inline = true;
                logoAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                // NHS
                Bitmap nhs = Properties.Resources.favicon;
                MemoryStream nhsMS = new MemoryStream();
                nhs.Save(nhsMS, ImageFormat.Jpeg);
                nhsMS.Position = 0;
                Attachment nhsAttachment = new Attachment(nhsMS, "", MediaTypeNames.Image.Jpeg);
                nhsAttachment.ContentId = "nhs.images.oversurgery";
                nhsAttachment.ContentDisposition.Inline = true;
                nhsAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                // Success
                Bitmap success = Properties.Resources.okok;
                MemoryStream successMS = new MemoryStream();
                success.Save(successMS, ImageFormat.Gif);
                successMS.Position = 0;
                Attachment successAttachment = new Attachment(successMS,"",MediaTypeNames.Image.Gif);
                successAttachment.ContentId = "success.images.oversurgery";
                successAttachment.ContentDisposition.Inline = true;
                successAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                // Facebook
                Bitmap facebook = Properties.Resources.facebook_2x;
                MemoryStream facebookMS = new MemoryStream();
                facebook.Save(facebookMS, ImageFormat.Png);
                facebookMS.Position = 0;
                Attachment facebookAttachment = new Attachment(facebookMS, "", MediaTypeNames.Image.Jpeg);
                facebookAttachment.ContentId = "facebook.images.oversurgery";
                facebookAttachment.ContentDisposition.Inline = true;
                facebookAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                // Twitter
                Bitmap twitter = Properties.Resources.twitter_2x;
                MemoryStream twitterMS = new MemoryStream();
                twitter.Save(twitterMS, ImageFormat.Png);
                twitterMS.Position = 0;
                Attachment twitterAttachment = new Attachment(twitterMS, "", MediaTypeNames.Image.Jpeg);
                twitterAttachment.ContentId = "twitter.images.oversurgery";
                twitterAttachment.ContentDisposition.Inline = true;
                twitterAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                // Google
                Bitmap google = Properties.Resources.googleplus_2x;
                MemoryStream googleMS = new MemoryStream();
                google.Save(googleMS, ImageFormat.Png);
                googleMS.Position = 0;
                Attachment googleAttachment = new Attachment(googleMS, "", MediaTypeNames.Image.Jpeg);
                googleAttachment.ContentId = "google.images.oversurgery";
                googleAttachment.ContentDisposition.Inline = true;
                googleAttachment.ContentDisposition.DispositionType = DispositionTypeNames.Inline;

                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("noreply.oversurgery@gmail.com", "qaz123456789");
                mail.Subject = "Booked Appointment";
                mail.IsBodyHtml = true;
                mail.Body = bodyString;
                mail.Attachments.Add(successAttachment);
                mail.Attachments.Add(facebookAttachment);
                mail.Attachments.Add(twitterAttachment);
                mail.Attachments.Add(googleAttachment);
                mail.Attachments.Add(nhsAttachment);
                mail.Attachments.Add(logoAttachment);

                client.Send(mail);
            }).Start();
        }
    }
}