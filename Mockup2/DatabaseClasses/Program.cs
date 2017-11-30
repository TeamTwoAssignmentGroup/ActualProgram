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
        public static readonly bool SEND_TEXTS = true;
        public static readonly bool SEND_EMAILS = true;
        public static string AUTH_TOKEN= "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AUTH_TOKEN = args[0];
            DBConnection dbCon = new DBConnection();
            
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            loginForm loginForm = new loginForm(dbCon);
            System.Windows.Forms.Application.Run(loginForm);
            dbCon.Close();

            QueryBuilder.DumpLog();
            loginForm.DumpIncorrectLogins();
            Console.ReadLine();
        }

        /// <summary>
        /// (Taken from <see href="https://stackoverflow.com/a/6839784"/> but tweaked slightly)
        /// Helper method to reliable generate hashed strings in an easily reproducably manner.
        /// Uses <see cref="System.Security.Cryptography.SHA256CryptoServiceProvider"/> for hashing.
        /// </summary>
        /// <param name="input">The string to be hashed.</param>
        /// <returns>The SHA256 hash value of the given string.</returns>
        public static string GetHashedString(string input)
        {
            SHA256 hashProvider = new SHA256CryptoServiceProvider();
            byte[] hashedData = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();

            foreach (byte b in hashedData)
            {
                // Not sure what this x2 is all about, but it works so *shrug*
                sb.Append(b.ToString("x2").ToUpper());
            }

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

    }
}
