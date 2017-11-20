using Mockup2.Factories;
using MySql.Data.MySqlClient;
using Octokit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.DatabaseClasses
{
    static class Program
    {
        public static readonly bool ENFORCE_LOGIN = false;
        public static readonly bool SEND_TEXTS = false;
        public static readonly bool SEND_EMAILS = true;
        public static readonly string AUTH_TOKEN= "821b44cbb0b72c06e97bca25f0d399d2d9a869fb";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnection dbCon = new DBConnection();
            Console.WriteLine(new PrescriptionFactory(dbCon).GetNextAvailablePrescriptionID());
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new loginForm(dbCon));
            dbCon.Close();
            QueryBuilder.DumpLog();
            Console.ReadLine();
        }        

    }
}
