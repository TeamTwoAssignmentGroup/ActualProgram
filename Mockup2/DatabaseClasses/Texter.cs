using Mockup2.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Mockup2.DatabaseClasses
{
    /// <summary>
    /// Helper class to send text message confirmation of <see cref="Appointment"/>s to <see cref="Patient"/>s.
    /// </summary>
    public class Texter
    {
        private static readonly string ACCOUNT_ID = "ACc61d941344d37a0efdda7427c39d50c2";
        private static readonly string AUTH_KEY = "63935b8e3706ab423407a9c8ca314a4f";

        /// <summary>
        /// Sends a text confirmation of an appointment to the supplied number, utilising the
        /// <a href="https://www.nuget.org/packages/Twilio/">Twilio NuGet package</a> and <a href="https://www.twilio.com/">Web API backend</a>. The message includes appointment date and time,
        /// as well as the name and job role of the <see cref="Staff"/> member being seen.
        /// This method expects the mobile number to be properly formatted and have the
        /// leading +44 intact; this is a requirement of the Twilio backend.
        /// 
        /// (It should be noted that at current, all texts are received by one phone number - mine. This
        /// is a restriction in Twilio's free trial service. Please don't abuse my phone number :D )
        /// </summary>
        /// <param name="number">The mobile phone number to send texts to.</param>
        /// <param name="staff">The member of <see cref="Mockup2.DatabaseClasses.Staff"/> being seen.</param>
        /// <param name="appointmentDate">The date of the <see cref="Mockup2.DatabaseClasses.Appointment"/>.</param>
        /// <param name="appointmentTime">The time of the <see cref="Mockup2.DatabaseClasses.Appointment"/>.</param>
        public static void SendAppointmentText(string number, Staff staff, DateTime appointmentDate,DateTime appointmentTime)
        {
            if (!Program.SEND_TEXTS)
            {
                Log.WriteLine("You're attempting to send a text but they are disabled in Program. Please do not" +
                    " enable them until we are ready to present!");
                return;
            }
            TwilioClient.Init(ACCOUNT_ID, AUTH_KEY);
            
                // Send a new outgoing SMS by POSTing to the Messages resource
                MessageResource.Create(
                    from: new PhoneNumber("+441133207078"), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+447792195466"), // To number, if using Sandbox see note above
                                                     // Message content
                    body: string.Format("You have an appointment booked on {0} at {1}{2} to see {3} {4} {5}{6} If you cannot attend please contact reception.",
                    appointmentDate.ToShortDateString(),appointmentTime.ToShortTimeString(),System.Environment.NewLine,
                    staff.JobRole,staff.FirstName,staff.LastName,System.Environment.NewLine));


                Log.WriteLine("Message successfully sent.");
            
        }
    }
}
