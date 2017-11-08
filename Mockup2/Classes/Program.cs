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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm(dbCon));
            dbCon.Close();
            QueryBuilder.DumpLog();
            Console.ReadLine();
        }

        public static void Test(DBConnection dbCon)
        {
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.PRESCRIPTION_TABLE.IssueDate)
                .From(Tables.PATIENT_TABLE, Tables.PRESCRIPTION_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.ID,Tables.PRESCRIPTION_TABLE.PatientID));
            CustomTable ct = ctf.GetCustomTable(b);

            foreach(Dictionary<Column,object> dic in ct.GetRows())
            {
                Console.WriteLine("{0} | {1} | {2}", dic[Tables.PATIENT_TABLE.FirstName],dic[Tables.PATIENT_TABLE.LastName],dic[Tables.PRESCRIPTION_TABLE.IssueDate]);
            }
        }
    }
}
