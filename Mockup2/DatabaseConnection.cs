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
            con = new MySqlConnection(connectionString);
            Test();
        }

        public DBConnection():this("kiralee.ddns.net", "OverSurgery", "TeamTwo", "ttag")
        {
            
        }

        private void Test()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Staff";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("id | firstName | lastName | jobRole | password | email");
                while (reader.Read())
                {
                    string id = reader["id"]+"";
                    string firstName = reader["firstName"]+"";
                    string lastName = reader["lastName"] + "";
                    string jobRole = reader["jobRole"] + "";
                    string password = reader["password"] + "";
                    string email = reader["email"] + "";
                    Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}",id,firstName,lastName,jobRole,password,email);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
