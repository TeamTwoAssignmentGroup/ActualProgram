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
    public partial class FindAppointmentForm : Form
    {
        ReceptionistForm parent;
        public FindAppointmentForm(ReceptionistForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.nameRadioButton.Checked = true;
        }

        private void nameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (nameRadioButton.Checked)
            {
                dateRadioButton.Checked = false;
                dateGroupBox.Enabled = false;
                nameGroupBox.Enabled = true;
            }
        }

        private void dateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dateRadioButton.Checked)
            {
                nameRadioButton.Checked = false;
                nameGroupBox.Enabled = false;
                dateGroupBox.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (nameRadioButton.Checked)
            {
                parent.PopulateAppointments(firstNameTextBox.Text, lastNameTextBox.Text);
                parent.searchByName = true;
                parent.fName = firstNameTextBox.Text;
                parent.lName = lastNameTextBox.Text;

            }
            if (dateRadioButton.Checked)
            {
                parent.PopulateAppointments(dateTimePicker1.Value, dateTimePicker2.Value);
                parent.searchByName = false;
                parent.d1 = dateTimePicker1.Value;
                parent.d2 = dateTimePicker2.Value;
            }
            this.Close();
            this.Dispose();
        }
    }
}
