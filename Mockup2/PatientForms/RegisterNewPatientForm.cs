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
        Patient p;
        PatientFactory pf;
        public RegisterNewPatientForm(Patient p,PatientFactory pf)
        {
            InitializeComponent();
            this.p = p;
            this.pf = pf;

            if (p != null)
            {
                nhsNumbertextBox1.Text = p.NHSNumber;
                patientFirstNameTextBox.Text = p.FirstName;
                patientLastNameTextBox.Text = p.LastName;
                patientAddressTextBox.Text = p.Address;
                postcodetextBox2.Text = p.Postcode;
                patientNextOfKinTextBox.Text = p.NextOfKin;
                dateTimePicker1.Value = p.DOB;
                maleradioButton1.Checked = p.Gender.Contains("Male");
                religiontextBox3.Text = p.Religion;
                patientEmailTextBox.Text = p.Email;
                patientContactNumberTextBox.Text = p.Phone;
                
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(p is null)
            {
                p = new Patient();
                p.NHSNumber = nhsNumbertextBox1.Text;
                p.FirstName = patientFirstNameTextBox.Text;
                p.LastName = patientLastNameTextBox.Text;
                p.Address = patientAddressTextBox.Text;
                p.Postcode = postcodetextBox2.Text;
                p.NextOfKin = patientNextOfKinTextBox.Text;
                p.DOB = dateTimePicker1.Value;
                p.Gender = maleradioButton1.Checked ? "Male" : "Female";
                p.Religion = religiontextBox3.Text;
                p.Phone = patientContactNumberTextBox.Text;
                p.Email = patientEmailTextBox.Text;
                
                pf.InsertPatient(p);
            }
            else
            {
                p.NHSNumber = nhsNumbertextBox1.Text;
                p.FirstName = patientFirstNameTextBox.Text;
                p.LastName = patientLastNameTextBox.Text;
                p.Address = patientAddressTextBox.Text;
                p.Postcode = postcodetextBox2.Text;
                p.NextOfKin = patientNextOfKinTextBox.Text;
                p.DOB = dateTimePicker1.Value;
                p.Gender = maleradioButton1.Checked ? "Male" : "Female";
                p.Religion = religiontextBox3.Text;
                p.Phone = patientContactNumberTextBox.Text;
                p.Email = patientEmailTextBox.Text;
                pf.UpdatePatient(p);
            }
            this.Close();
        }

        private void RegisterNewPatientForm_Load(object sender, EventArgs e)
        {
        }

        private void maleradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            femaleradioButton2.Checked = !maleradioButton1.Checked;
        }

        private void femaleradioButton2_CheckedChanged(object sender, EventArgs e)
        {
            maleradioButton1.Checked = !femaleradioButton2.Checked;
        }
    }
}
