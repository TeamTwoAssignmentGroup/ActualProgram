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
            PopulateAppointments(DateTime.Today,DateTime.Today);
        }

        public void PopulateAppointments(DateTime d1, DateTime d2)
        {
            appointmentDataGridView.Rows.Clear();
            //DateTime today = DateTime.Today;
            //DateTime date = new DateTime(today.Year, today.Month, today.Day);
            //DateTime date2 = date.AddDays(1);

            DateTime date = new DateTime(d1.Year,d1.Month,d1.Day);
            DateTime date2 = new DateTime(d2.Year,d2.Month,d2.Day).AddDays(1);

            string date1String = date.ToString("yyyy-MM-dd");
            string date2String = date2.ToString("yyyy-MM-dd");
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            //QueryBuilder b = new QueryBuilder();
            //b.Select(Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.APPOINTMENT_TABLE.AppointmentDate, Tables.APPOINTMENT_TABLE.AppointmentTime)
            //    .From(Tables.STAFF_TABLE, Tables.PATIENT_TABLE, Tables.APPOINTMENT_TABLE)
            //    .Where(b.IsEqual(Tables.APPOINTMENT_TABLE.StaffID, Tables.STAFF_TABLE.ID), b.And(),
            //    b.IsEqual(Tables.APPOINTMENT_TABLE.PatientID, Tables.PATIENT_TABLE.ID), b.And(),
            //    b.IsMoreThanEqual(Tables.APPOINTMENT_TABLE.AppointmentDate,date1String),b.And(),
            //    b.IsLessThan(Tables.APPOINTMENT_TABLE.AppointmentDate,date2String));
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.APPOINTMENT_TABLE.AppointmentDate, Tables.APPOINTMENT_TABLE.AppointmentTime)
                .From(Tables.STAFF_TABLE, Tables.PATIENT_TABLE, Tables.APPOINTMENT_TABLE)
                .Where(b.IsEqual(Tables.APPOINTMENT_TABLE.StaffID, Tables.STAFF_TABLE.ID), b.And(),
                b.IsEqual(Tables.APPOINTMENT_TABLE.PatientID, Tables.PATIENT_TABLE.ID), b.And(),
                b.IsBetweenDate(Tables.APPOINTMENT_TABLE.AppointmentDate,date,date2));
            CustomTable ct = ctf.GetCustomTable(b);
            foreach(var row in ct.GetRows())
            {
                foreach(var value in row.Values)
                {

                    Console.Write(value + " | ");
                }
                appointmentDataGridView.Rows.Add(row.Values.ToArray());
                Console.WriteLine();
            }
            
        }

        public void PopulateAppointments(string firstName,string lastName)
        {
            appointmentDataGridView.Rows.Clear();
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.APPOINTMENT_TABLE.AppointmentDate, Tables.APPOINTMENT_TABLE.AppointmentTime)
                .From(Tables.STAFF_TABLE, Tables.PATIENT_TABLE, Tables.APPOINTMENT_TABLE)
                .Where(b.IsEqual(Tables.APPOINTMENT_TABLE.StaffID, Tables.STAFF_TABLE.ID), b.And(),
                b.IsEqual(Tables.APPOINTMENT_TABLE.PatientID, Tables.PATIENT_TABLE.ID), b.And(),
                b.IsEqual(Tables.PATIENT_TABLE.FirstName, firstName),b.And(),
                b.IsEqual(Tables.PATIENT_TABLE.LastName,lastName));
            CustomTable ct = ctf.GetCustomTable(b);
            foreach (var row in ct.GetRows())
            {
                foreach (var value in row.Values)
                {

                    Console.Write(value + " | ");
                }
                appointmentDataGridView.Rows.Add(row.Values.ToArray());
                Console.WriteLine();
            }
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

        private void ReceptionistForm_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void findAppointmentButton_Click(object sender, EventArgs e)
        {
            new FindAppointmentForm(this).Show();
        }
    }
}
