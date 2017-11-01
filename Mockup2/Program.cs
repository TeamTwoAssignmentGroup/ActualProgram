using Mockup2.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnection dbCon = new DBConnection();

            //Test
            
            DateTime date = new DateTime(2008, 12, 22);
            DateTime date2 = new DateTime(2017, 01, 01);

            DateTime today = new DateTime(date.Year, date.Month, date.Day);
            PrescriptionFactory pFac = new PrescriptionFactory(dbCon);
            foreach(Prescription a in pFac.GetPrescriptions(10))
            {
                Console.WriteLine(a);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm(dbCon));
            dbCon.Close();
            QueryBuilder.DumpLog();
            Console.ReadLine();
        }
    }
}
