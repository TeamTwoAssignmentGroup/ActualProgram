using Mockup2.Classes;
using Mockup2.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mockup2.Tables;

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
            //Test(dbCon);
            MedicalNotes mn = new MedicalNotes();
            QueryBuilder qb = new QueryBuilder();
            qb.Insert(Tables.MEDICALNOTES_TABLE).Values(mn.ID, mn.PatientID, mn.WrittenDate.ToString("yyyy-MM-dd"), mn.Notes);
            Console.WriteLine(qb);
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm(dbCon));
            dbCon.Close();
            QueryBuilder.DumpLog();
            Console.ReadLine();
        }

        public static void Test(DBConnection dbCon)
        {
            PrescriptionFactory pf = new PrescriptionFactory(dbCon);
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("New prescription id would be: "+pf.GetNextAvailablePrescriptionID());
            }
        }
    }
}
