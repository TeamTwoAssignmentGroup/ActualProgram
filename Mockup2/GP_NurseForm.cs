using Mockup2.PatientForms;
using Mockup2.PrescriptionForms;
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
    public partial class GP_NurseForm : Form
    {
        bool isNurse;
        public GP_NurseForm(bool isNurse)
        {
            InitializeComponent();
            this.isNurse = isNurse;
            if (this.isNurse)
            {
                this.authorizeRepeatButton.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new IssuePrescriptionForm().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new IssuePrescriptionForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ViewMedicalHistoryForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ViewTestHistoryForm().Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
