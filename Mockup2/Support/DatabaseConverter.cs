using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Support
{
    public class DatabaseConverter
    {

        /**
         * Objecst and datasets used in this class
         * */
        private DBConnection dbCon;
        private PatientFactory infoFac;
        private Patient currentPatient;
        private Patient nextPatientret;
        private PrescriptionFactory prescriptionFactory;
        private MedicalNoteFactory medicalNote;
        private MedicineInFactory medicationFactory;
        private TestResultFactory test;
        private Appointment appointment = new Appointment();
        private AppointmentSort appointmentClass;

        private List<MedicalNotes> history;
        private List<Prescription> prescription;
        private List<TestResult> testresults;
        private List<MedicationInstance> medicationList;
        private List<Medication> medication;
        private List<Prescription> prescriptionList = new List<Prescription>();
        private List<TestResult> testresult = new List<TestResult>();
        private List<string> listPrescription = new List<string>();
        private List<string> listHistory = new List<string>();
        private List<string> listTestResults = new List<string>();


       


        /// <summary>
        /// Constructor takes a database and a patient object
        /// loads the patient object onto the GPNurse form
        /// </summary>
        /// <param name="dbCon"></param>
        /// <param name="patientObject"></param>
        public DatabaseConverter(DBConnection dbCon, Patient patientObject)
        {

            InitClass(dbCon);
            
            load(patientObject);
        
        }



        /// <summary>
        /// Constructor
        /// Constructor takes a database connection (manage class without stating a patient)
        /// </summary>
        /// <param name="dbCon"></param>
        public DatabaseConverter(DBConnection dbCon)
        {
            InitClass(dbCon);
            
        }




        /// <summary>
        /// </summary>
        /// <returns>patient prescriptions as string</returns>
        public List<Prescription> getPrescription()
        {

            return prescription;

        }




        /// <summary>
        /// Returns prescriptions for the current patient as object(managable)
        /// </summary>
        /// <returns></returns>
        public List<Prescription> GetPrescription()
        {
            return prescriptionList;

        }




        /// <summary>
        /// patient test results as an object (managable)
        /// </summary>
        /// <returns></returns>
        public List<TestResult> getTestResults()
        {

            return testresult;

        }



        /// <summary>
        /// </summary>
        /// <returns>medical history for the current patient</returns>
        public List<string> HistoryData()
        {

            return listHistory;

        }




        /// <summary>
        /// This function initialises this class(important)
        /// </summary>
        /// <param name="dbCon"></param>
        public void InitClass(DBConnection dbCon)
        {

            this.dbCon = dbCon;
            medicalNote = new MedicalNoteFactory(dbCon);
            infoFac = new PatientFactory(dbCon);
            prescriptionFactory = new PrescriptionFactory(dbCon);
            test = new TestResultFactory(dbCon);
            medicationFactory = new MedicineInFactory(dbCon);
            appointmentClass = new AppointmentSort(dbCon);

        }




        /// <summary>
        /// </summary>
        /// <returns> returns prescription data for current patient as string</returns>
        public List<string> PrescriptionData()
        {

            return listPrescription;

        }



        /// <summary>
        /// </summary>
        /// <returns>patient test results as string </returns>
        public List<string> TestResults()
        {

            return listTestResults;
        }





        /// <summary>
        /// Takes two arguements to return a patient object by first and last name
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public Patient findPatientByName(string s1, string s2)
        {

            currentPatient = infoFac.getAPatient(s1, s2);

            return currentPatient;

        }




        /// <summary>
        /// removes an appointment from the currrent list until next update, NOT FROM THE DATABASE
        /// </summary>
        public void removeAppointment()
        {

            appointment = appointmentClass.getNextAppointment();
            nextPatientret = infoFac.GetAPatientByID(appointment.PatientId);
            appointmentClass.removeAppointment();

        }




        /// <summary>
        /// loads medical history, prescriptions and test results for the current patient
        /// (Current patient is who has been initialised by load(Patient o))
        /// </summary>
        public void loadList()
        {

            history = medicalNote.GetMedicalNotes(currentPatient.ID);
            prescription = prescriptionFactory.GetPrescriptions(currentPatient.ID);
            testresults = test.GetTestResults(currentPatient.ID);
                   
        }

      


        /// <summary>
        /// This method fills up datasets for a selected patient 
        /// therefore lists can return recent updates as current patient
        /// </summary>
        /// <param name="o"></param>
        public void load(Patient o)
        {
            try
            {
                currentPatient = o;
                loadList();

                foreach (MedicalNotes m in history) { listHistory.Add(m.ID + " " + m.PatientID + " " + m.Notes + " " + m.WrittenDate.ToShortDateString() + "\n"); }

                foreach (Prescription p in prescription)
                {

                    medicationList = medicationFactory.GetMedicineIdByPrescription(p.Id);

                    foreach (MedicationInstance m in medicationList)
                    {

                        medication = medicationFactory.GetMedicneNameById(m.MedicationId);

                        foreach (Medication me in medication)
                        {

                            listPrescription.Add(me.ScientificName + " " + p.IssueDate.ToShortDateString());

                        }
                    }
                }
                prescriptionList = prescriptionFactory.GetPrescriptions(currentPatient.ID);
                testresult = test.GetTestResults(currentPatient.ID);
                foreach (TestResult tr in testresult) { listTestResults.Add(tr.TestName.ToString() + " " + tr.TestDate.ToString()); }

                
            }
            catch (NullReferenceException ne) { Log.WriteLine("no object " + ne); }

        }




        /// <summary>
        /// this function allows patinet notes to be modified
        /// </summary>
        /// <param name="p"></param>
        /// <param name="newNotes"></param>
        public void insertPatientNote(Patient p,List<string>newNotes)
        {

            medicalNote.InsertPatientNote(p, newNotes);

        }




        /// <summary>
        /// This function allows a prescription to be override
        /// </summary>
        /// <param name="pre"></param>
        public void editPrescription(List<Prescription> pre)
        {

            prescriptionFactory.InsertEditedPrescription(pre);

        }





        /// <summary>
        /// This function allows a prescription removal from the database
        /// </summary>
        /// <param name="pre"></param>
        public void removePrescription(Prescription pre)
        {

            prescriptionFactory.DeletePrescription(pre);

        }




        /// <summary>
        /// This function adds a new prescription to the database
        /// </summary>
        /// <param name="pre"></param>
        public void addPrescription(Prescription pre)
        {
            prescriptionFactory.addPrescription(pre);
        }

       


        /// <summary>
        /// This method prepares the next patient object from the appointment
        /// </summary>
        /// <returns></returns>
        public  Patient InitNextPatient()
        {
          
            appointment = appointmentClass.getNextAppointment();
            nextPatientret = infoFac.GetAPatientByID(appointment.PatientId);
            return nextPatientret;

        }




        /// <summary>
        /// This method returns next appintment
        /// </summary>
        /// <returns></returns>
        public Appointment nextPatientAppointment()
        {
            
            
            return appointment;

        }






    }  
}
//end               //end               //end               //end               //end                  //end
