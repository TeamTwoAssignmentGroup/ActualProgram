using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.AppointmentForms
{
    public partial class AddAppointmentForm : Form
    {
        private DBConnection dbCon;
        private PatientFactory pf;
        private StaffFactory sf;
        private AppointmentFactory af;
        int staffID, patientID;
        Appointment app;
        ReceptionistForm parent;
        CustomTableFactory ctf;
        List<Patient> patients;
        List<Staff> staff;

        public AddAppointmentForm(DBConnection dbCon,int staffID,int patientID,Appointment app,ReceptionistForm parent)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            this.pf = new PatientFactory(dbCon);
            this.sf = new StaffFactory(dbCon);
            this.af = new AppointmentFactory(dbCon);
            this.staffID = staffID;
            this.patientID = patientID;
            this.app = app;
            this.parent = parent;
            this.KeyUp += AddAppointmentForm_KeyUp;

            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.JobRole,"Doctor"),b.Or(),b.IsEqual(Tables.STAFF_TABLE.JobRole,"Nurse"));
            patients = pf.GetPatients();
            staff = sf.GetStaff(b);

            if (staffID >0)
            {
                staff = sf.GetStaffByID(staffID);
            }

            if (patientID > 0)
            {
                patients = pf.GetPatientsByID(patientID);
            }

            ctf = new CustomTableFactory(dbCon);
            this.statusComboBox.SelectedIndex = 0;

            PopulateComboBoxes();
        }

        private void AddAppointmentForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            staffcomboBox1.Enabled = true;
        }

        private void PopulateComboBoxes()
        {
            patientcomboBox2.Items.Clear();
            staffcomboBox1.Items.Clear();
            foreach(Patient p in patients)
            {
                this.patientcomboBox2.Items.Add(string.Format("{0} {1}, {2}",p.FirstName,p.LastName,p.DOB.ToShortDateString()));
            }
            foreach(Staff s in staff)
            {
                this.staffcomboBox1.Items.Add(string.Format("{0} {1}, {2}",s.FirstName,s.LastName,s.JobRole));
            }
            patientcomboBox2.SelectedIndex = 0;
            staffcomboBox1.SelectedIndex = 0;
        }

        public void ValidateTimeslots()
        {
            staffcomboBox1_SelectedIndexChanged(null, null);
        }

        private void staffcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int staffID = staff[staffcomboBox1.SelectedIndex].ID;
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.APPOINTMENT_TABLE.AppointmentTime).From(Tables.APPOINTMENT_TABLE).Where(b.IsEqual(Tables.APPOINTMENT_TABLE.StaffID, staffID),b.And(),b.IsBetweenDate(Tables.APPOINTMENT_TABLE.AppointmentDate,dateTimePicker1.Value,dateTimePicker1.Value));
            
            List<string> allTimeslots = af.GetTimeslots();
            foreach(var row in ctf.GetCustomTable(b).GetRows())
            {
                Console.WriteLine(row[Tables.APPOINTMENT_TABLE.AppointmentTime].ToString());
                allTimeslots.Remove(row[Tables.APPOINTMENT_TABLE.AppointmentTime].ToString());
            }
            timeslotcomboBox1.Items.Clear();
            timeslotcomboBox1.Items.AddRange(allTimeslots.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = firstnametextBox1.Text;
            string lname = lastnametextBox2.Text;
            patients = pf.GetPatientsByName(fname, lname);
            PopulateComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (app is null)
            {
                app = new Appointment();
                app.StaffId = staff[staffcomboBox1.SelectedIndex].ID;
                app.PatientId = patients[patientcomboBox2.SelectedIndex].ID;
                app.AppointmentDate = dateTimePicker1.Value;
                app.AppointmentTime = DateTime.ParseExact(timeslotcomboBox1.SelectedItem.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                app.Cause = causeTextBox.Text;
                app.Status = statusComboBox.SelectedItem.ToString();
                af.InsertAppointment(app);
            }
            else
            {
                app.StaffId = staffID;
                app.PatientId = patientID;
                app.AppointmentDate = dateTimePicker1.Value;
                if (timeslotcomboBox1.SelectedItem != null)
                {
                    app.AppointmentTime = DateTime.ParseExact(timeslotcomboBox1.SelectedItem.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                }
                app.Cause = causeTextBox.Text;
                app.Status = statusComboBox.SelectedItem.ToString();
                af.UpdateAppointment(app);
            }

            if (parent.searchByName)
            {
                parent.PopulateAppointments(parent.fName, parent.lName);
            }
            else
            {
                parent.PopulateAppointments(parent.d1, parent.d2);
            }
            this.Close();
        }
    }
}
