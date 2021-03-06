﻿using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using Mockup2.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2
{
    public partial class loginForm : Form
    {
        DBConnection dbCon;
        private Dictionary<string, int> incorrectLoginAttempts;
        public loginForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            this.incorrectLoginAttempts = new Dictionary<string, int>();
            this.staffPasswordtextBox2.KeyDown += StaffPasswordtextBox2_KeyUp;
            this.staffPasswordtextBox2.GotFocus += StaffPasswordtextBox2_GotFocus;
        }

        private void StaffPasswordtextBox2_GotFocus(object sender, EventArgs e)
        {
            this.staffPasswordtextBox2.SelectAll();
        }

        private void StaffPasswordtextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                e.Handled = true;
            }
        }

        public void DumpIncorrectLogins()
        {
            if (incorrectLoginAttempts.Count == 0)
            {
                return;
            }
            Log.WriteLine("Incorrect login attempts:");
            foreach(KeyValuePair<string,int> kvp in incorrectLoginAttempts)
            {
                Log.WriteLine($"[{kvp.Key}] : [{kvp.Value}]");
            }
            Log.WriteLine("This could be an attempt to break into the system!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object cbi = this.staffJobComboBox.SelectedItem;
            if (Program.ENFORCE_LOGIN)
            {
                if(staffIDtextBox1.Text=="" || staffPasswordtextBox2.Text == "")
                {
                    MessageBox.Show("Please enter both your ID and password.");
                    return;
                }
                int staffID;
                try
                {
                    staffID = int.Parse(staffIDtextBox1.Text);
                }catch(FormatException exc1)
                {
                    MessageBox.Show("Your Staff ID should be a number. Contact an Admin if you have forgotten your ID.", "Incorrect Details");
                    return;
                }
                string password = staffPasswordtextBox2.Text;

                // After grabbing the password we have to hash it
                string hashedPassword = Program.GetHashedString(password);
                Log.WriteLine("Searching for ID:{0} Password:{1}",staffID,password);

                StaffFactory sf = new StaffFactory(dbCon);
                List<Staff> s = sf.GetStaffByID(staffID);

                // If count is more than 1 we have found a person
                if (s.Count > 0)
                {
                    // If the passwords match, we set their job role
                    if (s[0].Password == hashedPassword)
                    {
                        cbi = s[0].JobRole;
                        read();
                    }
                    else
                    {
                        MessageBox.Show("Password is not correct. Please contact an Admin if you need a password reset.","Incorrect Details");
                        string key = s[0].FirstName + " " + s[0].LastName;
                        if (!incorrectLoginAttempts.ContainsKey(key))
                        {
                            incorrectLoginAttempts.Add(key, 0);
                        }
                        incorrectLoginAttempts[key]++;
                        read();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ID not recognized. Contact an Admin if you have forgotten your ID.","Incorrect Details");
                    return;
                }
            }
            Console.Out.WriteLine("Object: " + cbi);

            // Depending on which job role was returned, we create the appropriate form
            this.Hide();
            switch (cbi)
            {
                case "Admin":AdminForm af = new AdminForm(dbCon);
                    af.WindowState = FormWindowState.Maximized;
                    af.ShowDialog();
                    break;

                case "Doctor": GPNurse gpnf = new GPNurse(dbCon,true);
                    gpnf.WindowState = FormWindowState.Maximized;
                    gpnf.ShowDialog();
                    break;

                case "Nurse": GPNurse gpnf2= new GPNurse(dbCon,false);
                    gpnf2.WindowState = FormWindowState.Maximized;
                    gpnf2.ShowDialog();
                    break;

                case "Receptionist": ReceptionistForm rf = new ReceptionistForm(dbCon);
                    rf.WindowState = FormWindowState.Maximized;
                    rf.ShowDialog();
                    break;
            }
            this.staffIDtextBox1.Text = "";
            this.staffPasswordtextBox2.Text = "";
            this.Show();
            this.staffIDtextBox1.Focus();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            // These controls are for debug. So we hide them for the presentation
            staffJobLabel.Visible = !Program.ENFORCE_LOGIN;
            staffJobComboBox.Visible = !Program.ENFORCE_LOGIN;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.nhs.uk/pages/home.aspx");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("http://kiralee.ddns.net/TTAG");
        }


        public void read()
        {

           // MessageBox.Show("NO one puts baby in the corner");

        }

    }
}
