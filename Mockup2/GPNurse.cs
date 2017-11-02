using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mockup2.AppointmentForms;
using Mockup2.Factories;
using Mockup2.PatientForms;


namespace Mockup2
{
    public partial class GPNurse : Form
    {

        DBConnection dbCon;
        PatientFactory infoFac;

        public GPNurse(DBConnection dbCon)
        {
            this.dbCon = dbCon;
            infoFac = new PatientFactory(dbCon);
         
           
                   
            InitializeComponent();
        }



     



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells["firstName"].Value.ToString();
                string value2 = row.Cells["lastName"].Value.ToString();
                searchBox1.Text = value1;
                searchBox2.Text = value2;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string firstName = searchBox1.Text;
            string lastName = searchBox2.Text;
            List<Patient> patient = infoFac.GetPatientsByName(firstName, lastName);
            dataGridView1.Rows.Clear();
            foreach (Patient p in patient)
            {

                dataGridView1.Rows.Add(p.ID, p.NHSNumber, p.FirstName, p.LastName, p.Address, p.Postcode, p.DOB, p.Gender);
            }

        }

        private void GPNurse_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}