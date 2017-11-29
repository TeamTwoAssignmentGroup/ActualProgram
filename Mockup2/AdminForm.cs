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
using Mockup2.AdminForms;

namespace Mockup2
{
    /// <summary>
    /// Main parent form that oversees all Admin related use cases. Spawns child forms when necessary.
    /// </summary>
    public partial class AdminForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        StaffFactory sf;

        public AdminForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            sf = new StaffFactory(dbCon);
            this.button3.Click += button3_Click;
        }

        private void addStaffButton_Click(object sender, EventArgs e)
        {
            int staffID = 0;
            this.Hide();
            new EditStaffForm(dbCon, staffID).ShowDialog();
            this.Show();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            PopulateAdminFormRota();
            PopulateAdminFormStaff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MessagePatientForm(dbCon).ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ResetPasswordForm(dbCon).ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                //validate
            }
            int rowNumber = Convert.ToInt32(dataGridView1.SelectedRows[0].Index);
            object[] pass = DataSet(rowNumber).Item1;
            object[] staffName = DataSet(rowNumber).Item2;
            int staffID = DataSet(rowNumber).Item3;

            Console.WriteLine(rowNumber + "\t" + staffID);

            this.Hide();
            new UpdateStaff(dbCon, pass, staffName, staffID).ShowDialog();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            PopulateAdminFormRota();
            this.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            PopulateAdminFormStaff();
            PopulateAdminFormRota();
        }

        private void PopulateAdminFormStaff()
        {
            dataGridView2.Rows.Clear();
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.ID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.STAFF_TABLE.JobRole, 
                Tables.STAFF_TABLE.Email, Tables.STAFF_TABLE.Address, Tables.STAFF_TABLE.Postcode).From(Tables.STAFF_TABLE);

            CustomTable ct = ctf.GetCustomTable(b);

            foreach (var row in ct.GetRows())
            {
                foreach (var value in row.Values)
                {

                    Console.Write(value + " | ");
                }
                dataGridView2.Rows.Add(row.Values.ToArray());
                Console.WriteLine();
            }
        }

        private Tuple<object[], object[], int, string> DataSet(int rowNumber)
        {
            object[] pass = new object[14];
            object[] staffName = new object[2];
            int staffID = Convert.ToInt32(dataGridView1[0, rowNumber].Value);
            string staffJob = Convert.ToString(dataGridView1[3, rowNumber].Value);
            staffName[0] = Convert.ToString(dataGridView1[1, rowNumber].Value);
            staffName[1] = Convert.ToString(dataGridView1[2, rowNumber].Value);
            pass[0] = Tables.ROTA_TABLE.Mon;
            pass[1] = Convert.ToInt32(dataGridView1[4, rowNumber].Value);
            pass[2] = Tables.ROTA_TABLE.Tue;
            pass[3] = Convert.ToInt32(dataGridView1[5, rowNumber].Value);
            pass[4] = Tables.ROTA_TABLE.Wed;
            pass[5] = Convert.ToInt32(dataGridView1[6, rowNumber].Value);
            pass[6] = Tables.ROTA_TABLE.Thur;
            pass[7] = Convert.ToInt32(dataGridView1[7, rowNumber].Value);
            pass[8] = Tables.ROTA_TABLE.Fri;
            pass[9] = Convert.ToInt32(dataGridView1[8, rowNumber].Value);
            pass[10] = Tables.ROTA_TABLE.Sat;
            pass[11] = Convert.ToInt32(dataGridView1[9, rowNumber].Value);
            pass[12] = Tables.ROTA_TABLE.Sun;
            pass[13] = Convert.ToInt32(dataGridView1[10, rowNumber].Value);
            Tuple<object[], object[], int, string> rotaData = new Tuple<object[], object[], int, string>(pass, staffName, staffID, staffJob);
            return rotaData;
        }

        private void PopulateAdminFormRota()
        {
            dataGridView1.Rows.Clear();
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            b = new QueryBuilder();
            b.Select(Tables.ROTA_TABLE.StaffID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.STAFF_TABLE.JobRole,
                Tables.ROTA_TABLE.Mon, Tables.ROTA_TABLE.Tue, Tables.ROTA_TABLE.Wed,
                Tables.ROTA_TABLE.Thur, Tables.ROTA_TABLE.Fri, Tables.ROTA_TABLE.Sat, Tables.ROTA_TABLE.Sun)
                .From(Tables.ROTA_TABLE, Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.ID, Tables.ROTA_TABLE.StaffID));
            CustomTable ct = ctf.GetCustomTable(b);
            foreach (var row in ct.GetRows())
            {
                foreach (var value in row.Values)
                {
                    Console.Write(value + " | ");
                }
                dataGridView1.Rows.Add(row.Values.ToArray());
                Console.WriteLine();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reportBug_Click(object sender, EventArgs e)
        {
            new ReportBugForm().ShowDialog();
        }
        private void editStaffButton_Click(object sender, EventArgs e)
        {
            int staffID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            // StaffID.ValueFromGrid
            this.Hide();
            new EditStaffForm(dbCon, staffID).ShowDialog();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            PopulateAdminFormStaff();
            PopulateAdminFormRota();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RotaPrinter rp = new RotaPrinter(dataGridView1, "Staff Rota");
            rp.PrintForm();
        }

        private void removeStaffButton_Click(object sender, EventArgs e)
        {
            int staffID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            sf.RemoveStaffByID(staffID);
            PopulateAdminFormStaff();
            PopulateAdminFormRota();
        }
    }
}
