using System;
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
using Mockup2.DatabaseClasses;
using Mockup2.Classes;

namespace Mockup2
{
    public partial class MessagePatientForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        string[] attachments;
        public MessagePatientForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Multiselect = true;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                attachments = opf.FileNames;
            }
        }

        private void MessagePatientForm_Load(object sender, EventArgs e)
        {
            // Sets the size of the form upon loading
            this.Size = new Size(1000, 800);
            // Prevents the form from being re sized
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

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
            Emailer.SendEmail(dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), textBox1.Text, textBox2.Text,attachments);
            this.Close();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
