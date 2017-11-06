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
using Mockup2.PrescriptionForms;

namespace Mockup2
{
    public partial class GPNurse : Form
    {

        DBConnection dbCon;
        PatientFactory infoFac;
        Patient currentPatient;
        PrescriptionFactory prescriptionFactory;

        public GPNurse(DBConnection dbCon)
        {
            this.dbCon = dbCon;
            infoFac = new PatientFactory(dbCon);
            prescriptionFactory = new PrescriptionFactory(dbCon);
         



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

        /***
         * This button returns one patient from the database as an object
         * */
        private void button9_Click(object sender, EventArgs e)
        {
            string firstName = searchBox1.Text;
            string lastName = searchBox2.Text;
            currentPatient = infoFac.getAPatient(firstName, lastName);
            
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(currentPatient.ID, currentPatient.NHSNumber, currentPatient.FirstName,currentPatient.LastName, currentPatient.Address, currentPatient.Postcode, currentPatient.DOB, currentPatient.Gender);

        }

        private void GPNurse_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Console.WriteLine(prescriptionDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                int prescriptionID = int.Parse(prescriptionDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                ViewPrescription vp = new ViewPrescription(prescriptionID,dbCon);
                vp.Show();
            }
        }

        private void selectSearch_Click(object sender, EventArgs e)
        {
            Prescription currentPrescription;
            currentPrescription = prescriptionFactory.getAPatientPrescription(currentPatient);
            prescriptionDataGridView.Rows.Add(currentPrescription.Id,currentPrescription.PatientId,currentPrescription.IssueDate,currentPrescription.IsRepeatable,currentPrescription.IssueDate,currentPrescription.RepeatRequested);
        }

        private void prescriptionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}