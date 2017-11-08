using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mockup2.AppointmentForms;
using Mockup2.Factories;
using Mockup2.PatientForms;
using Mockup2.PrescriptionForms;
using Mockup2.Classes;

namespace Mockup2
{
    public partial class GPNurse : Form
    {

        DBConnection dbCon;
        PatientFactory infoFac;
        Patient currentPatient;
        PrescriptionFactory prescriptionFactory;
        MedicalNoteFactory medicalNote;
        MedicineInFactory medicationL;   
        TestResultFactory test;
       
        public GPNurse(DBConnection dbCon)
        {
            this.dbCon = dbCon;
         
            medicalNote = new MedicalNoteFactory(dbCon);
            infoFac = new PatientFactory(dbCon);
            prescriptionFactory = new PrescriptionFactory(dbCon);
            test = new TestResultFactory(dbCon);
            medicationL = new MedicineInFactory(dbCon);
        


         



            InitializeComponent();
        }



     



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string value1 = row.Cells["firstName"].Value.ToString();
                string value2 = row.Cells["lastName"].Value.ToString();
                searchBox1.Text = value1;
                searchBox2.Text = value2;
            }
        }

        /***
         * This button returns one patient from the database as an object
         * */
        private void button9_Click(object sender, EventArgs e)
        {

            int byId = 0;
            string firstName = searchBox1.Text;
            string lastName = searchBox2.Text;
            string id = searchID.Text;
            try { byId = Int32.Parse(id); } catch (FormatException f) {  }
            { }
            if (id.Equals(null) || byId == 0)
            {

                currentPatient = infoFac.getAPatient(firstName, lastName);
            }

            else { currentPatient = infoFac.GetPatientsByID(byId); }
           
           
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(currentPatient.ID, currentPatient.NHSNumber, currentPatient.FirstName,currentPatient.LastName, currentPatient.Address, currentPatient.Postcode, currentPatient.DOB, currentPatient.Gender);

        }

        private void GPNurse_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Console.WriteLine(preGrid.SelectedRows[0].Cells[0].Value.ToString());
                int prescriptionID = int.Parse(preGrid.SelectedRows[0].Cells[0].Value.ToString());
                ViewPrescription vp = new ViewPrescription(prescriptionID,dbCon);
                vp.Show();
            }
        }

        private void selectSearch_Click(object sender, EventArgs e)
        {
            historyGrid.Rows.Clear();
            preGrid.Rows.Clear();
            testGrid.ClearSelection();
            List <MedicalNotes> hist  = medicalNote.GetMedicalNotes(currentPatient.ID);
            List<Prescription> pre = prescriptionFactory.GetPrescriptions(currentPatient.ID);
            List<TestResult> tesR = test.GetTestResults(currentPatient.ID);
            List<MedicationInstance> medicationList;
            List<Medication> medication;


            foreach (MedicalNotes m in hist ) { historyGrid.Rows.Add(m.ID,m.PatientID,m.Notes,m.WrittenDate); }




            foreach (Prescription p in pre)
            {



                 medicationList= medicationL.GetMedicineIdByPrescription(p.Id);
                



                foreach (MedicationInstance m in medicationList)
                {



                    medication = medicationL.GetMedicneNameById(m.MedicationId);
                    foreach (Medication me in medication)
                    {

                        preGrid.Rows.Add(me.ScientificName, me.CommercialName, p.IssueDate);

                    }


                }



            }










            foreach (TestResult t in tesR) { testGrid.Rows.Add(t.TestName,t.Results,t.TestDate); }
            detailsBox.Text = currentPatient.FirstName + " " + currentPatient.LastName + "   date of birth: " + currentPatient.DOB + "\n" + currentPatient.Address + " " + currentPatient.Postcode + "\n" + currentPatient.Phone;


        }

        private void prescriptionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}