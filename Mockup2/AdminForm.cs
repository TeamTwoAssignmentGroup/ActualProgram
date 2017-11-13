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

namespace Mockup2
{
    public partial class AdminForm : Form
    {
        DBConnection dbCon;
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
            new MessagePatientForm().Show();
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

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            List<Staff> staff = new StaffFactory(dbCon).GetStaff();
            PopulateAdminFormStaff();
        }

        private void PopulateAdminFormStaff()
        {
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.ID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.STAFF_TABLE.Address, Tables.STAFF_TABLE.Postcode, Tables.STAFF_TABLE.JobRole).From(Tables.STAFF_TABLE);

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

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
