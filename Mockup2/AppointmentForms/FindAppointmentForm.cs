﻿using Mockup2.Support;
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
            this.lastNameTextBox.KeyUp += LastNameTextBox_KeyUp;
            this.Load += FindAppointmentForm_Load;
            this.nameGroupBox.Enabled = true;
        }

        private void LastNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
            }
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
                if (firstNameTextBox.Text == "" || lastNameTextBox.Text == "")
                {
                    MessageBox.Show("Please enter both a first and last name.", "Incorrect Details");
                    return;
                }
                parent.PopulateAppointments(firstNameTextBox.Text, lastNameTextBox.Text);
                parent.searchByName = true;
                parent.fName = firstNameTextBox.Text;
                parent.lName = lastNameTextBox.Text;

            }
            if (dateRadioButton.Checked)
            {
                if (dateTimePicker1.Value == null || dateTimePicker2.Value == null)
                {
                    MessageBox.Show("Please choose two dates to see appointments between.", "Incorrect Dates");
                }
                if(dateTimePicker1.Value > dateTimePicker2.Value)
                {
                    MessageBox.Show("Minimum date cannot be further in future than maximum date.", "Incorrect Dates");
                    return;
                }
                parent.PopulateAppointments(dateTimePicker1.Value, dateTimePicker2.Value);
                parent.searchByName = false;
                parent.d1 = dateTimePicker1.Value;
                parent.d2 = dateTimePicker2.Value;
            }
            this.Close();
            this.Dispose();
        }

        private void FindAppointmentForm_Load(object sender, EventArgs e)
        {
            Log.WriteLine("Hello this is the form loader");
            Log.WriteLine("Focusing the textbox was successful: "+this.firstNameTextBox.Focus());
        }
    }
}
