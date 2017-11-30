using Mockup2.DatabaseClasses;
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

namespace Mockup2.PatientForms
{
    public partial class RegisterNewPatientForm : Form
    {
        Patient p;
        PatientFactory pf;
        ReceptionistForm parent;
        TextBox[] compulsoryFields = new TextBox[7];
        public RegisterNewPatientForm(Patient p,PatientFactory pf,ReceptionistForm parent)
        {
            InitializeComponent();
            this.p = p;
            this.pf = pf;
            this.parent = parent;

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

                this.Text = "Edit Patient Details";


            }

            compulsoryFields[0] = nhsNumbertextBox1;
            compulsoryFields[1] = patientFirstNameTextBox;
            compulsoryFields[2] = patientLastNameTextBox;
            compulsoryFields[3] = patientAddressTextBox;
            compulsoryFields[4] = postcodetextBox2;
            compulsoryFields[5] = patientNextOfKinTextBox;
            compulsoryFields[6] = patientContactNumberTextBox;
        }

        public bool AreCompulsoryFieldsFilled()
        {
            foreach(TextBox tb in compulsoryFields)
            {
                if (tb.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == DateTime.Now || !AreCompulsoryFieldsFilled())
            {
                MessageBox.Show("All fields except religion and email are compulsory, please fill them in.",
                    "Insufficient Details");
                return;
            }
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
            parent.firstNameTextbox.Text = patientFirstNameTextBox.Text;
            parent.lastNameTextbox.Text = patientLastNameTextBox.Text;

            parent.RefreshPatients();
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
