﻿using Mockup2.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.DatabaseClasses
{
    /// <summary>
    /// A helper class for wrapping a <see cref="MySqlConnection"/>, providing a default constructor that automatically
    /// connects to our OverSurgery database.
    /// </summary>
    public class DBConnection
    {
        string server;
        string database;
        string username;
        string password;
        string connectionString;
        MySqlConnection con;

        /// <summary>
        /// Creates the underlying <see cref="MySqlConnection"/> based on the input parameters, and then attempts to open the connection.
        /// Failure outputs the exception to Console and rethrows it for testing purposes.
        /// </summary>
        /// <param name="server">Server hostname.</param>
        /// <param name="database">Database to use once connected.</param>
        /// <param name="username">Username to login with.</param>
        /// <param name="password">Password to use.</param>
        public DBConnection(string server, string database, string username, string password)
        {
            this.server = server;
            this.database = database;
            this.username = username;
            this.password = password;
            this.connectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3}",server,database,username,password);
            try
            {
                con = new MySqlConnection(connectionString);
                con.Open();
            }catch(Exception e){
                Log.WriteLine(e);
                throw e;
            }
        }

        /// <summary>
        /// Ensures the connection is closed cleanly to prevent memory leaks.
        /// Closes and disposes the underlying <see cref="MySqlConnection"/>.
        /// </summary>
        public void Close()
        {
            con.Close();
            con.Dispose();
        }

        /// <summary>
        /// Overloaded constructor for convenience of connecting to a particular database,
        /// our database.
        /// </summary>
        public DBConnection():this("kiralee.ddns.net", "OverSurgery", "TeamTwo", "ttag")
        {
            
        }

        /// <summary>
        /// Gets the underlying <see cref="MySqlConnection"/> for processes that require it.
        /// </summary>
        /// <returns>The underlying <see cref="MySqlConnection"/>.</returns>
        public MySqlConnection GetConnection()
        {
            return con;
        }
    }
}
