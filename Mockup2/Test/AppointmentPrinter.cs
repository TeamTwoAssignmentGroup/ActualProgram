using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using Mockup2.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.Test
{
    class AppointmentPrinter
    {
        Appointment a;
        DBConnection dbCon;
        int offsetX, offsetY;
        public void Print(Appointment a,DBConnection dbCon)
        {
            this.a = a;
            this.dbCon = dbCon;
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == DialogResult.OK)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings = pd.PrinterSettings;
                printDocument.PrintPage += PrintDocument_PrintPage;
                offsetX = printDocument.PrinterSettings.DefaultPageSettings.Margins.Left;
                offsetY = printDocument.PrinterSettings.DefaultPageSettings.Margins.Top;
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Resources.logo1, new Point(offsetX, offsetY));
            int titleOffset = offsetX;
            Font font = new Font("Arial",20);
            Brush brush = Brushes.Black;
            //g.DrawString("Over Surgery", font, brush, titleOffset, offsetY);

            float imageHeightPrint =  Resources.logo1.Height /
                         Resources.logo1.VerticalResolution * 100;

            offsetY += (int)imageHeightPrint;

            font = new Font("Arial", 16);
            int stringHeight = (int)g.MeasureString("Over Surgery", font).Height;

            StaffFactory sf = new StaffFactory(dbCon);
            PatientFactory pf = new PatientFactory(dbCon);

            Staff s = sf.GetStaffByID(a.StaffId)[0];
            Patient p = pf.GetPatientsByID(a.PatientId)[0];

            string s1 = "You have an appointment booked to see: ";
            string s2 = $"{s.JobRole} {s.FirstName} {s.LastName} on ";
            string s3 = $"{a.AppointmentDate.ToShortDateString()} at {a.AppointmentTime.ToShortTimeString()}";
            string s4 = "If you cannot attend please contact reception to cancel.";

            AddAllStringsTo(g, font, brush, titleOffset, offsetY, stringHeight, s1, s2, s3, s4);
        }

        private void AddAllStringsTo(Graphics g, Font f, Brush b, int x,int startY, int stringHeight, params string[] strings)
        {
            foreach(string s in strings)
            {
                g.DrawString(s, f, b, x, startY += stringHeight);
            }
        }
    }
}
