using Mockup2.AppointmentForms;
using Mockup2.Factories;
using Mockup2.PatientForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2
{
    public partial class ReceptionistForm : Form
    {
        DBConnection dbCon;
        PatientFactory infoFac;
        public ReceptionistForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            infoFac = new PatientFactory(dbCon);
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            this.Load += ReceptionistForm_Load;
        }

        private void ReceptionistForm_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime date = new DateTime(today.Year,today.Month,today.Day);
            List<Appointment> apps = new AppointmentFactory(dbCon).GetAppointmentsByDate(date);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new AddAppointmentForm().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new AddAppointmentForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegisterNewPatientForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new RegisterNewPatientForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SeeStaffListForm().Show();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextbox.Text;
            string lastName = lastNameTextbox.Text;
            List<Patient> patient = infoFac.GetPatientsByName(firstName,lastName);
            dataGridView1.Rows.Clear();
            foreach(Patient p in patient)
            {
                
                dataGridView1.Rows.Add(p.ID,p.NHSNumber,p.FirstName,p.LastName,p.Address,p.Postcode,p.NextOfKin,p.DOB,p.Gender,p.Religion,p.Email,p.Phone);
            }
        }

        private void LoadAllPatients()
        {
            List<Patient> patient = infoFac.GetPatients();
            dataGridView1.Rows.Clear();
            foreach (Patient p in patient)
            {

                dataGridView1.Rows.Add(p.ID, p.NHSNumber, p.FirstName, p.LastName, p.Address, p.Postcode, p.NextOfKin, p.DOB, p.Gender, p.Religion, p.Email, p.Phone);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells["firstName"].Value.ToString();
                string value2 = row.Cells["lastName"].Value.ToString();
                firstNameTextbox.Text = value1;
                lastNameTextbox.Text = value2;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadAllPatients();
        }
    }
}
