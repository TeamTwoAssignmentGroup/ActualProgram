using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mockup2.Factories;
using Mockup2.DatabaseClasses;
using MySql.Data.MySqlClient;
using Mockup2.Support;

namespace Mockup2
{
    public partial class ResetPasswordForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        public ResetPasswordForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            this.textBox2.KeyUp += TextBox2_KeyUp;
        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            PopulatePassword();
            this.Text = "Reset Password";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int staffID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string password = textBox2.Text;
            password = Program.GetHashedString(password);

            if(textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Passwords do not match.", "Incorrect Details");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

            if(textBox1.Text=="" || textBox2.Text == "")
            {
                MessageBox.Show("One or both of the password fields are blank. Please fill them both in.", "Incorrect Details");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }

            b = new QueryBuilder();
            b.Update(Tables.STAFF_TABLE).Set(Tables.STAFF_TABLE.Password,password).Where(b.IsEqual(Tables.STAFF_TABLE.ID,staffID));
            MySqlCommand command = new MySqlCommand(b.ToString(),dbCon.GetConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Password changed successfully.", "Password Change");
            this.Close();
        }

        private void PopulatePassword()
        {
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.ID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, 
                Tables.STAFF_TABLE.JobRole, Tables.STAFF_TABLE.Password).From(Tables.STAFF_TABLE);

            CustomTable ct = ctf.GetCustomTable(b);

            foreach (var row in ct.GetRows())
            {
                foreach (var value in row.Values)
                {

                    Console.Write(value + " | ");
                }
                dataGridView1.Rows.Add(row.Values.ToArray());
                Log.WriteLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
