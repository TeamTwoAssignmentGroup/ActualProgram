using Mockup2.Factories;
using MySql.Data.MySqlClient;
using Octokit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.DatabaseClasses
{
    static class Program
    {
        public static readonly bool ENFORCE_LOGIN = true;
        public static readonly bool SEND_TEXTS = false;
        public static readonly bool SEND_EMAILS = true;
        public static string AUTH_TOKEN= "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AUTH_TOKEN = args[0];
            Console.WriteLine(AUTH_TOKEN);
            DBConnection dbCon = new DBConnection();
            Console.WriteLine(new PrescriptionFactory(dbCon).GetNextAvailablePrescriptionID());
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new loginForm(dbCon));
            dbCon.Close();
            QueryBuilder.DumpLog();
            Console.ReadLine();
        }  
        
        public static string GetHashedString(string input)
        {
            SHA256 hashProvider = new SHA256CryptoServiceProvider();
            byte[] hashedData = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();

            foreach (byte b in hashedData)
            {
                sb.Append(b.ToString("x2").ToUpper());
            }

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

    }
}
