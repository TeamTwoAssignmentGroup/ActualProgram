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
            StaffID = staffID;
            if (StaffID != 0)
            {
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
            button1.Text = "Update Staff Member";
            //Query
            StaffFactory sf = new StaffFactory(dbCon);
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
            //Lable Button
            button1.Text = "Add Staff Member";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new QueryBuilder();
            switch(StaffID)
            {
                case 0:
                    string[] valuesToInput = new string[8];
                    //ID
                    valuesToInput[0] = null;
                    //first Name
                    valuesToInput[1] = textBox2.Text;
                    //Last Name
                    valuesToInput[2] = textBox3.Text;
                    //Job Role
                    valuesToInput[3] = comboBox1.Text;
                    //Password
                    valuesToInput[4] = textBox7.Text;
                    //Email
                    valuesToInput[5] = textBox5.Text;
                    //Address
                    valuesToInput[6] = textBox4.Text;
                    //Post Code
                    valuesToInput[7] = textBox6.Text;

                    b.Insert(Tables.STAFF_TABLE).Values(valuesToInput);
                    MySqlCommand cmdAdd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                    cmdAdd.ExecuteNonQuery();
                    MessageBox.Show("Staff Add Successful");
                    this.Close();
                    break;
                default:
                    //Update Staff
                    object[] valuesToInsert = new object[14];
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
                    //valuesToInsert[12] = Tables.STAFF_TABLE.Password;
                    //valuesToInsert[13] = textBox7.Text;
                    b.Update(Tables.STAFF_TABLE).Set(valuesToInsert).Where(b.IsEqual(Tables.STAFF_TABLE.ID, StaffID));
                    MySqlCommand cmdEdit = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                    cmdEdit.ExecuteNonQuery();
                    MessageBox.Show("Staff Edit Successful");
                    this.Close();
                    break;
            }
        }

        private void EditStaffForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
