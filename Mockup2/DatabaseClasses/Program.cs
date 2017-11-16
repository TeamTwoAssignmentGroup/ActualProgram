using Mockup2.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.DatabaseClasses
{
    static class Program
    {
        public static readonly bool ENFORCE_LOGIN = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnection dbCon = new DBConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginForm(dbCon));
            dbCon.Close();
            QueryBuilder.DumpLog();
            Console.ReadLine();
        }
        
    }
}
