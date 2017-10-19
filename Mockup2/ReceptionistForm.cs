using Mockup2.AppointmentForms;
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
        public ReceptionistForm()
        {
            InitializeComponent();
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
    }
}
