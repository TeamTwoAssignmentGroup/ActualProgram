using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mockup2.Factories;
using Mockup2.Support;
using Mockup2.DatabaseClasses;

namespace Mockup2
{
    public partial class AddPrescription : Form
    {

        PrescriptionFactory managePrescription;
        Prescription currentPrescription = new Prescription();
        MedicineInFactory getMedications;
        MedicationFactory medFact;
        Patient patient;
        DBConnection dbCon;
        List<Medication> medications = new List<Medication>();
        MedicationInstance medicationAndPrescription = new MedicationInstance();
        
        int index;

        bool ticked;

        public AddPrescription(DBConnection connection)
        {
            this.dbCon = connection;
            getMedications = new MedicineInFactory(dbCon);
            managePrescription = new PrescriptionFactory(dbCon);
            medFact = new MedicationFactory(dbCon);
            InitializeComponent();
            showMedications();


        }


        public void showMedications()
        {
            

            medications = getMedications.getAllMedication();
            foreach (Medication md in medications)
            {

                listBox1.Items.Add("Commercial Name: " + md.CommercialName.ToString());

            }



        }


       public void initCurrentPatient(Patient o)
        {

            patient = o;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            

            DatabaseConverter manager = new DatabaseConverter(dbCon);
            DialogResult result;

            result = MessageBox.Show("Do you want to prescribe this medication ?", "",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {


                createNewPrescription(medications[index].ScientificName.ToString());
                this.Hide();

               


            }
            if (result == System.Windows.Forms.DialogResult.No)
            {
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string name = "";
            index= listBox1.Items.IndexOf(listBox1.Text);
            name = listBox1.SelectedItem.ToString();
            selectedTextBox.Text = medications[index].CommercialName.ToString();

            
        }



        private void createNewPrescription(string name)
        {


            currentPrescription.StaffId = 2;
            currentPrescription.PatientId = patient.ID;
            currentPrescription.IsRepeatable = ticked;
            currentPrescription.RepeatRequested = false;
            currentPrescription.IssueDate = DateTime.Now;
            managePrescription.InsertPrescription(currentPrescription);



            medicationAndPrescription.Instruction = instructionTextBox.Text;
            medicationAndPrescription.MedicationId =medFact.getMedicationID(name);
            int id = managePrescription.returnLastPrescriptionID();
            medicationAndPrescription.PrescriptionId = id;
            getMedications.addmedicationInstance(medicationAndPrescription);
           









        }


    }
}
