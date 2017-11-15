﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mockup2.Factories;

namespace Mockup2
{
    public partial class MessagePatientForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        public MessagePatientForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new OpenFileDialog().ShowDialog();
        }

        private void MessagePatientForm_Load(object sender, EventArgs e)
        {
            // Sets the size of the form upon loading
            this.Size = new Size(800, 800);
            // Prevents the form from being re sized
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //List<Staff> staff = new StaffFactory(dbCon).GetStaff();
           PopulateAdminMessage();


        }
        private void PopulateAdminMessage()
        {
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            b = new QueryBuilder();
            b.Select(Tables.PATIENT_TABLE.ID, Tables.PATIENT_TABLE.FirstName, Tables.PATIENT_TABLE.LastName, Tables.PATIENT_TABLE.Email).From(Tables.PATIENT_TABLE);

            CustomTable ct = ctf.GetCustomTable(b);

            foreach (var row in ct.GetRows())
            {
                foreach (var value in row.Values)
                {

                    Console.Write(value + " | ");
                }
                dataGridView1.Rows.Add(row.Values.ToArray());
                Console.WriteLine();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Emailer.SendEmail(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), textBox1.Text, textBox2.Text);
        }
    }
}
