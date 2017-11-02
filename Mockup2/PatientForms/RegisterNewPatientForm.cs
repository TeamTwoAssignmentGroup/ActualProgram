using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.PatientForms
{
    public partial class RegisterNewPatientForm : Form
    {
        public RegisterNewPatientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterNewPatientForm_Load(object sender, EventArgs e)
        {
            // Sets the size of the form upon loading
            this.Size = new Size(600, 700);
            // Prevents the form from being re sized
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
