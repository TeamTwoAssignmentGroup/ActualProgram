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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (app is null)
            {
                app = new Appointment();
                app.StaffId = int.Parse(staffIDTextBox.Text);
                app.PatientId = int.Parse(patientIDTextBox.Text);
                app.AppointmentDate = dateTimePicker1.Value;
                app.AppointmentTime = dateTimePicker2.Value;
                app.Cause = causeTextBox.Text;
                app.Status = statusComboBox.SelectedItem.ToString();
                af.InsertAppointment(app);
            }
            else
            {
                app.StaffId = staffID;
                app.PatientId = patientID;
                app.AppointmentDate = dateTimePicker1.Value;
                app.AppointmentTime = dateTimePicker2.Value;
                app.Cause = causeTextBox.Text;
                app.Status = statusComboBox.SelectedItem.ToString();
                af.UpdateAppointment(app);
            }

            this.Close();
        }
    }
}
