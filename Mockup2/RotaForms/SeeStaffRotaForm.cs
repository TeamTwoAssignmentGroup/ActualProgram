using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mockup2.DatabaseClasses.Tables;

namespace Mockup2.RotaForms
{
    public partial class SeeStaffRotaForm : Form
    {
        private string firstName, lastName;
        private DBConnection dbCon;
        public SeeStaffRotaForm(string firstName,string lastName,DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            this.firstName = firstName;
            this.lastName = lastName;
            this.Load += SeeStaffRotaForm_Load;
        }

        private void SeeStaffRotaForm_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
        }

        private void PopulateDataGrid()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.FirstName,Tables.STAFF_TABLE.LastName,Tables.STAFF_TABLE.JobRole,
                Tables.ROTA_TABLE.Mon, Tables.ROTA_TABLE.Tue, Tables.ROTA_TABLE.Wed, Tables.ROTA_TABLE.Thur, Tables.ROTA_TABLE.Fri, Tables.ROTA_TABLE.Sat, Tables.ROTA_TABLE.Sun)
                .From(Tables.ROTA_TABLE,Tables.STAFF_TABLE)
                .Where(b.IsEqual(Tables.STAFF_TABLE.ID,Tables.ROTA_TABLE.StaffID),b.And(),
                b.IsEqual(Tables.STAFF_TABLE.FirstName,firstName),b.And(),b.IsEqual(Tables.STAFF_TABLE.LastName,lastName));
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            CustomTable ct = ctf.GetCustomTable(b);

            if (ct.GetRows().Count == 0)
            {
                MessageBox.Show("No staff member found using those names.", "No Staff Member");
                this.Close();
                this.Dispose();
                return;
            }

            Dictionary<Tables.Column, object> row = ct.GetRows()[0];

            List<string> resultRow = new List<string>();
            foreach(Column c in b.GetSelectedColumns())
            {
                string s = "";
                try
                {
                    int i = int.Parse(row[c].ToString());
                    s = (i == 1) ? "On" : "Off";
                }catch(FormatException e)
                {
                    s = row[c].ToString();
                }
                resultRow.Add(s);
            }
            dataGridView1.Rows.Add(resultRow.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
