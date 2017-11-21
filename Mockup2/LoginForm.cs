using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2
{
    public partial class loginForm : Form
    {
        DBConnection dbCon;
        private Dictionary<int, int> incorrectLoginAttempts;
        public loginForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            this.incorrectLoginAttempts = new Dictionary<int, int>();
            this.staffPasswordtextBox2.KeyUp += StaffPasswordtextBox2_KeyUp;
        }

        private void StaffPasswordtextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object cbi = this.staffJobComboBox.SelectedItem;
            if (Program.ENFORCE_LOGIN)
            {
                int staffID = int.Parse(staffIDtextBox1.Text);
                string password = staffPasswordtextBox2.Text;
                string hashedPassword = Program.GetHashedString(password);
                Console.WriteLine("Searching for ID:{0} Password:{1}",staffID,password);
                StaffFactory sf = new StaffFactory(dbCon);
                List<Staff> s = sf.GetStaffByID(staffID);
                if (s.Count > 0)
                {
                    if (s[0].Password == hashedPassword)
                    {
                        cbi = s[0].JobRole;
                    }
                    else
                    {
                        MessageBox.Show("Password is not correct. Please contact an Admin if you need a password reset.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ID not recognized. Contact an Admin if you have forgotten your ID.");
                    return;
                }
            }
            Console.Out.WriteLine("Object: " + cbi);
            switch (cbi)
            {
                case "Admin":AdminForm af = new AdminForm(dbCon);
                    af.WindowState = FormWindowState.Maximized;
                    af.Show();
                    break;

                case "Doctor": GPNurse gpnf = new GPNurse(dbCon,true);
                    gpnf.WindowState = FormWindowState.Maximized;
                    gpnf.Show();
                    break;

                case "Nurse": GPNurse gpnf2= new GPNurse(dbCon,false);
                    gpnf2.WindowState = FormWindowState.Maximized;
                    gpnf2.Show();
                    break;

                case "Receptionist": ReceptionistForm rf = new ReceptionistForm(dbCon);
                    rf.WindowState = FormWindowState.Maximized;
                    rf.Show();
                    break;
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            staffJobLabel.Visible = !Program.ENFORCE_LOGIN;
            staffJobComboBox.Visible = !Program.ENFORCE_LOGIN;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.nhs.uk/pages/home.aspx");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://kiralee.ddns.net/TTAG");
        }
    }
}
