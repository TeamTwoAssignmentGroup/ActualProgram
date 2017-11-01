using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2
{
    public class DBConnection
    {
        string server;
        string database;
        string username;
        string password;
        string connectionString;
        MySqlConnection con;
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
                Console.WriteLine(e);
            }
        }

        public void Close()
        {
            con.Close();
            con.Dispose();
        }

        public DBConnection():this("kiralee.ddns.net", "OverSurgery", "TeamTwo", "ttag")
        {
            
        }

        public MySqlConnection GetConnection()
        {
            return con;
        }
    }
}
