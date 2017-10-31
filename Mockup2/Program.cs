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
            Console.WriteLine("SELECT {0},{1} FROM {2},{3} WHERE {4} = {5}",Tables.APPOINTMENT_TABLE.PatientID,Tables.PATIENT_TABLE.ID,Tables.APPOINTMENT_TABLE,Tables.PATIENT_TABLE,Tables.APPOINTMENT_TABLE.PatientID,Tables.STAFF_TABLE.ID);
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE, Tables.PATIENT_TABLE).Where(
                b.IsEqual(Tables.APPOINTMENT_TABLE.PatientID, Tables.PATIENT_TABLE.ID), b.And(), b.IsEqual(Tables.PATIENT_TABLE.FirstName,"Hello"),
                b.Or(),b.IsEqual(Tables.PATIENT_TABLE.FirstName,Tables.PATIENT_TABLE.FirstName));
            Console.WriteLine(b);
            DBConnection dbCon = new DBConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm());
        }
    }
}
