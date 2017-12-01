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

        private PrescriptionFactory managePrescription;
        private Prescription currentPrescription = new Prescription();
        private MedicineInFactory getMedications;
        private MedicationFactory medFact;
        private Patient patient;
        private DBConnection dbCon;
        private List<Medication> medications = new List<Medication>();
        private MedicationInstance medicationAndPrescription = new MedicationInstance();
        private int index;
        private bool ticked;
        private GPNurse controlGP;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="form"></param>
        public AddPrescription(DBConnection connection,GPNurse form)
        {

            this.dbCon = connection;
            getMedications = new MedicineInFactory(dbCon);
            managePrescription = new PrescriptionFactory(dbCon);
            medFact = new MedicationFactory(dbCon);
            controlGP = form;
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




        /// <summary>
        /// savescreate and save a prescription into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prescribeButton_Click(object sender, EventArgs e)
        {

            

            DatabaseConverter manager = new DatabaseConverter(dbCon);
            DialogResult result;

            result = MessageBox.Show("Do you want to prescribe this medication ?", "",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {


                createNewPrescription(medications[index].ScientificName.ToString());
                this.Hide();
                controlGP.loadCurrentPatient ( );
                controlGP.refreshPrescriptionList ( );
               
               
            }

            if (result == System.Windows.Forms.DialogResult.No)
            {
            }

            
        }




        /// <summary>
        /// This method selects the selected medication and prepares a medication to be saves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medicationsListBox_MouseClick(object sender, MouseEventArgs e)
        {
            string name = "";
            index= listBox1.Items.IndexOf(listBox1.Text);
            name = listBox1.SelectedItem.ToString();
            selectedTextBox.Text = medications[index].CommercialName.ToString();

            
        }




        /// <summary>
        /// Creates a new prescription and medication object
        /// Medication instance and prescription
        /// </summary>
        /// <param name="name"></param>
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




        /// <summary>
        /// saves the prescription into the database
        /// </summary>
        /// <param name="pre"></param>
        public void modified(List<Prescription> pre)
        {

            managePrescription.InsertEditedPrescription(pre);

        }





    }
}
