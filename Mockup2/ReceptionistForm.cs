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
        StaffFactory sf;
        AppointmentFactory af;
        List<Appointment> selectedAppointments;
        List<Patient> patients;
        QueryBuilder latestAppointmentQuery;

        public bool searchByName = false;
        public string fName;
        public string lName;
        public DateTime d1;
        public DateTime d2;
        public ReceptionistForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            infoFac = new PatientFactory(dbCon);
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            this.Load += ReceptionistForm_Load;
            this.selectedAppointments = new List<Appointment>();
            af = new AppointmentFactory(dbCon);
            foreach(string s in af.GetTimeslots())
            {
                Console.WriteLine(s);
            }
            sf = new StaffFactory(dbCon);
        }

        public void RefreshPatients()
        {
            button8_Click(null, null);
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
            selectedAppointments.Clear();
            selectedAppointments = af.GetAppointmentsByDateRange(d1, d2);
            //DateTime today = DateTime.Today;
            //DateTime date = new DateTime(today.Year, today.Month, today.Day);
            //DateTime date2 = date.AddDays(1);

            DateTime date = new DateTime(d1.Year,d1.Month,d1.Day);
            DateTime date2 = new DateTime(d2.Year, d2.Month, d2.Day); ;

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
            b.Select(Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.APPOINTMENT_TABLE.AppointmentDate, Tables.APPOINTMENT_TABLE.AppointmentTime,Tables.APPOINTMENT_TABLE.Status,Tables.APPOINTMENT_TABLE.Cause)
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
            int patientID = infoFac.GetPatientsByName(firstName, lastName)[0].ID;
            selectedAppointments.Clear();
            QueryBuilder b2 = new QueryBuilder();
            b2.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE).Where(b2.IsEqual(Tables.APPOINTMENT_TABLE.PatientID, patientID));
            selectedAppointments = af.GetAppointments(b2);
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.APPOINTMENT_TABLE.AppointmentDate, Tables.APPOINTMENT_TABLE.AppointmentTime,Tables.APPOINTMENT_TABLE.Status,Tables.APPOINTMENT_TABLE.Cause)
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
            new AddAppointmentForm(dbCon,0,0,null,this).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (appointmentDataGridView.SelectedRows.Count > 0)
            {
                int rowNum = appointmentDataGridView.CurrentCell.RowIndex;
                string docFName = appointmentDataGridView.Rows[rowNum].Cells[0].Value.ToString();
                string docLName = appointmentDataGridView.Rows[rowNum].Cells[1].Value.ToString();
                string patFName = appointmentDataGridView.Rows[rowNum].Cells[2].Value.ToString();
                string patLName = appointmentDataGridView.Rows[rowNum].Cells[3].Value.ToString();

                StaffFactory sf = new StaffFactory(dbCon);
                PatientFactory pf = new PatientFactory(dbCon);
                int staffID = sf.GetStaffByName(docFName, docLName)[0].ID;
                int patientID = pf.GetPatientsByName(patFName, patLName)[0].ID;
                AddAppointmentForm aaf = new AddAppointmentForm(dbCon,staffID,patientID,selectedAppointments[rowNum],this);

                //aaf.staffIDTextBox.Text = docFName + " " + docLName;
                //aaf.patientIDTextBox.Text = patFName + " " + patLName;
                //aaf.staffIDTextBox.Enabled = false;
                //aaf.patientIDTextBox.Enabled = false;

                aaf.dateTimePicker1.Value = (DateTime) appointmentDataGridView.Rows[rowNum].Cells[4].Value;
               // aaf.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                //aaf.dateTimePicker2.CustomFormat = "HH:mm tt";
               // aaf.dateTimePicker2.Value = aaf.dateTimePicker2.Value.Date + (TimeSpan) appointmentDataGridView.Rows[rowNum].Cells[5].Value;
                Console.WriteLine("Time object is: " + appointmentDataGridView.Rows[rowNum].Cells[5].Value);
                aaf.statusComboBox.Text = appointmentDataGridView.Rows[rowNum].Cells[6].Value.ToString();
                //aaf.causeTextBox.Text = appointmentDataGridView.Rows[0].Cells[7].Value.ToString();
                Console.WriteLine("Index of selected timeslot is: " + aaf.timeslotcomboBox1.Items.IndexOf(appointmentDataGridView.Rows[rowNum].Cells[5].Value));
                aaf.timeslotcomboBox1.SelectedIndex = aaf.timeslotcomboBox1.FindStringExact(appointmentDataGridView.Rows[rowNum].Cells[5].Value.ToString());
                aaf.ValidateTimeslots();
                aaf.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegisterNewPatientForm(null,infoFac,this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowNum = dataGridView1.CurrentCell.RowIndex;
                Patient p = patients[rowNum];
                new RegisterNewPatientForm(p,infoFac,this).Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SeeStaffListForm(seerotadateTimePicker1.Value,dbCon).Show();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextbox.Text;
            string lastName = lastNameTextbox.Text;
            List<Patient> patient = infoFac.GetPatientsByName(firstName,lastName);
            patients = patient;
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (appointmentDataGridView.SelectedRows.Count > 0)
            {
                int num = appointmentDataGridView.CurrentCell.RowIndex;

                DataGridViewRow row = appointmentDataGridView.Rows[num];
                string sfn = row.Cells[0].Value.ToString();
                string sln = row.Cells[1].Value.ToString();
                string pfn = row.Cells[2].Value.ToString();
                string pln = row.Cells[3].Value.ToString();
                DateTime d = (DateTime)row.Cells[4].Value;
                //DateTime t = (DateTime)row.Cells[5].Value;
                string date = d.ToString("yyyy-MM-dd");
                string time = row.Cells[5].Value.ToString();

                Appointment a = GetAppointmentBy(sfn, sln, pfn, pln, date, time);
                Console.WriteLine("Row index is: " + num + " Appointment is: " + a);
                af.DeleteAppointment(a);
                selectedAppointments.Remove(a);
                appointmentDataGridView.Rows.RemoveAt(num);
            }
        }

        private Appointment GetAppointmentBy(string sfn,string sln,string pfn, string pln,string date,string time)
        {
            int patientID = infoFac.GetPatientsByName(pfn,pln)[0].ID;
            int staffID = sf.GetStaffByName(sfn, sln)[0].ID;
            Console.WriteLine("Finding appointment that matches: {0} {1} {2} {3}",staffID,patientID,date,time);
            foreach(Appointment a in selectedAppointments)
            {
                if (a.PatientId == patientID && a.StaffId == staffID && a.AppointmentDate.ToString("yyyy-MM-dd") == date && a.AppointmentTime.ToString("HH:mm:ss") == time)
                {
                    return a;
                }
            }
            return null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int num = dataGridView1.CurrentCell.RowIndex;
                Patient p = patients[num];
                infoFac.DeletePatient(p);
                dataGridView1.Rows.RemoveAt(num);
            }
        }
    }
}
