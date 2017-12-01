using Mockup2.Classes;
using Mockup2.DatabaseClasses;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.AdminForms
{
    public partial class ReportBugForm : Form
    {
        public ReportBugForm()
        {
            InitializeComponent();
        }

        private void ReportBugForm_Load(object sender, EventArgs e)
        {
            this.Text = "Report A Bug";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void sendReportButton_Click(object sender, EventArgs e)
        {
            EmailBug(reportDate.Value, reportTime.Value, reportSubject.Text, reportMessage.Text);
            CreateBug(reportDate.Value, reportTime.Value, reportSubject.Text, reportMessage.Text);
            this.Close();
            this.Dispose();
        }

        private void EmailBug(DateTime date,DateTime time,string subject, string message)
        {
            string crlf = System.Environment.NewLine;
            string emailSubject = "Bug Report";
            string emailMessage = string.Format("Date: {0} Time: {1}{2}Subject: {3}{4}Message: {5}",date.ToShortDateString(),time.ToShortTimeString(),crlf,subject,crlf,message);

            // Create attachment object from a list of strings from QueryBuilder
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.WriteLine("[# Of calls to query] : [query]");
            foreach(string s in QueryBuilder.GetPastQueriesLog())
            {
                sw.WriteLine(s);
            }
            sw.Flush();
            ms.Position = 0;

            Attachment a = new Attachment(ms,"querylog.txt");
            Emailer.SendEmailWithAttachments("shaunsupra@googlemail.com",emailSubject,emailMessage,a);
            
        }

        private async void CreateBug(DateTime date, DateTime time, string subject, string message)
        {
            try
            {
                WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                Credentials credentials = new Credentials(Program.AUTH_TOKEN);
                GitHubClient gh = new GitHubClient(new ProductHeaderValue("ActualProgram"));
                gh.Credentials = credentials;
                NewIssue issue = new NewIssue(subject);
                issue.Body = "[Auto sent from OverSurgery application] "+System.Environment.NewLine+"[Date: "+date.ToShortDateString()+" Time: "+time.ToShortTimeString()+" ]"+System.Environment.NewLine+message;
                Issue sentIssue = await gh.Issue.Create("TeamTwoAssignmentGroup", "ActualProgram", issue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
