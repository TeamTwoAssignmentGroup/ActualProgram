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

namespace Mockup2
{
    public partial class AdminForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        public AdminForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addStaffButton_Click(object sender, EventArgs e)
        {
            new EditStaffForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MessagePatientForm(dbCon).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ResetPasswordForm().Show();
        }

        private void editStaffButton_Click(object sender, EventArgs e)
        {
            new EditStaffForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b = new QueryBuilder();
            object[] pass = new object[14];
            int staffID = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                pass = DataSet(i).Item1;
                staffID = DataSet(i).Item2;
                b.Update(Tables.ROTA_TABLE).Set(pass).Where(b.IsEqual(Tables.ROTA_TABLE.StaffID, staffID));
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            List<Staff> staff = new StaffFactory(dbCon).GetStaff();
            PopulateAdminFormStaff();
            PopulateAdminFormRota();
        }

        private void PopulateAdminFormStaff()
        {
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

        private Tuple<object[], int> DataSet(int rowNumber)
        {
            object[] pass = new object[14];
            int staffID = Convert.ToInt32(dataGridView1[rowNumber, 0].Value);
            pass[0] = Tables.ROTA_TABLE.Mon;
            pass[1] = Convert.ToInt32(dataGridView1[rowNumber, 1].Value);
            pass[2] = Tables.ROTA_TABLE.Tue;
            pass[3] = Convert.ToInt32(dataGridView1[rowNumber, 2].Value);
            pass[4] = Tables.ROTA_TABLE.Wed;
            pass[5] = Convert.ToInt32(dataGridView1[rowNumber, 3].Value);
            pass[6] = Tables.ROTA_TABLE.Thur;
            pass[7] = Convert.ToInt32(dataGridView1[rowNumber, 4].Value);
            pass[8] = Tables.ROTA_TABLE.Fri;
            pass[9] = Convert.ToInt32(dataGridView1[rowNumber, 5].Value);
            pass[10] = Tables.ROTA_TABLE.Sat;
            pass[11] = Convert.ToInt32(dataGridView1[rowNumber, 6].Value);
            pass[12] = Tables.ROTA_TABLE.Sun;
            pass[13] = Convert.ToInt32(dataGridView1[rowNumber, 7].Value);
            Tuple<object[], int> rotaData = new Tuple<object[], int>(pass, staffID);
            return rotaData;
        }

        private void PopulateAdminFormRota()
        {
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            b = new QueryBuilder();
            b.Select(Tables.ROTA_TABLE.StaffID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.ROTA_TABLE.Mon, Tables.ROTA_TABLE.Tue, Tables.ROTA_TABLE.Wed,
                Tables.ROTA_TABLE.Thur, Tables.ROTA_TABLE.Fri, Tables.ROTA_TABLE.Sat, Tables.ROTA_TABLE.Sun).From(Tables.ROTA_TABLE, Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.ID, Tables.ROTA_TABLE.StaffID));
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

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
