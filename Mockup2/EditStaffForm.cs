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
using MySql.Data.MySqlClient;
using Mockup2.DatabaseClasses;

namespace Mockup2
{
    public partial class EditStaffForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        StaffFactory sf;
        RotaFactory rf;
        Staff s;
        int m_staffID;

        public int StaffID
        {
            get
            {
                return m_staffID;
            }
            set
            {
                m_staffID = value;
            }
        }

        public EditStaffForm(DBConnection dbCon, int staffID)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            StaffID = staffID;
            if (StaffID != 0)
            {
                label8.Visible = false;
                textBox7.Visible = false;
                populateEditInfomation();
            }
            else
            {
                AddStaff();
            }
        }

        private void populateEditInfomation()
        {
            //Lable Button
            this.Text = button1.Text = "Update Staff Member";
            //Query
            sf = new StaffFactory(dbCon);
            List<Staff> staffMember = sf.GetStaffByID(StaffID);

            textBox2.Text = staffMember.ElementAtOrDefault(0).FirstName;
            textBox3.Text = staffMember.ElementAtOrDefault(0).LastName;
            textBox4.Text = staffMember.ElementAtOrDefault(0).Address;
            textBox6.Text = staffMember.ElementAtOrDefault(0).Postcode;
            textBox5.Text = staffMember.ElementAtOrDefault(0).Email;
            comboBox1.Text = staffMember.ElementAtOrDefault(0).JobRole;
        }

        private void AddStaff()
        {
            //Lable Window
            //Lable Button
            this.Text = button1.Text = "Add Staff Member";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new QueryBuilder();
            rf = new RotaFactory(dbCon);
            s = new Staff();
            bool validatePassed;
            switch (StaffID)
            {
                case 0:
                    object[] valuesToInput = new object[8];
                    //ID
                    sf = new StaffFactory(dbCon);
                    int id = sf.GetNextAvailableStaffID();
                    valuesToInput[0] = id;
                    //first Name
                    valuesToInput[1] = textBox2.Text;
                    //Last Name
                    valuesToInput[2] = textBox3.Text;
                    //Job Role
                    valuesToInput[3] = comboBox1.Text;
                    //Password
                    valuesToInput[4] = textBox7.Text.Equals(null) ? null : Program.GetHashedString(textBox7.ToString());
                    //Email
                    valuesToInput[5] = textBox5.Text;
                    //Address
                    valuesToInput[6] = textBox4.Text;
                    //Post Code
                    valuesToInput[7] = textBox6.Text;

                    validatePassed = ValidateInput(valuesToInput, 1);
                    if (validatePassed)
                    {
                        b.Insert(Tables.STAFF_TABLE).Values(valuesToInput);
                        MySqlCommand cmdAdd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                        cmdAdd.ExecuteNonQuery();

                        s.ID = id;
                        rf.InsertStaff(s);

                        MessageBox.Show("Staff Add Successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You have not entered all the data, please fill out the form to continue.");
                    }
                    break;
                default:
                    //Update Staff
                    object[] valuesToInsert = new object[12];
                    valuesToInsert[0] = Tables.STAFF_TABLE.FirstName;
                    valuesToInsert[1] = textBox2.Text;
                    valuesToInsert[2] = Tables.STAFF_TABLE.LastName;
                    valuesToInsert[3] = textBox3.Text;
                    valuesToInsert[4] = Tables.STAFF_TABLE.Address;
                    valuesToInsert[5] = textBox4.Text;
                    valuesToInsert[6] = Tables.STAFF_TABLE.Email;
                    valuesToInsert[7] = textBox5.Text;
                    valuesToInsert[8] = Tables.STAFF_TABLE.Postcode;
                    valuesToInsert[9] = textBox6.Text;
                    valuesToInsert[10] = Tables.STAFF_TABLE.JobRole;
                    valuesToInsert[11] = comboBox1.Text;

                    validatePassed = ValidateInput(valuesToInsert, 2);

                    if (validatePassed)
                    {
                        b.Update(Tables.STAFF_TABLE).Set(valuesToInsert).Where(b.IsEqual(Tables.STAFF_TABLE.ID, StaffID));
                        MySqlCommand cmdEdit = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                        cmdEdit.ExecuteNonQuery();
                        MessageBox.Show("Staff Edit Successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You have not entered all the data, please fill out the form to continue.");
                    }
                    break;
            }
        }
        private bool ValidateInput(object[] dataToValidate, int varToSwitch)
        {
            int step = 0, count = 0;
            bool flg = true;
            switch(varToSwitch)
            {
                case 1:
                    // step of 1
                    step = 0;
                    count = 1;
                    break;
                case 2:
                    //step of 2
                    step = 1;
                    count = 2;
                    break;
            }
            // Doing Stuff
            for (int i = step; i < dataToValidate.Length; i+= count)
            {
                if ((dataToValidate[i] == null) || (dataToValidate[i].ToString() == ""))
                {
                    flg = false;
                }
            }
            return flg;
        }

        private void EditStaffForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
