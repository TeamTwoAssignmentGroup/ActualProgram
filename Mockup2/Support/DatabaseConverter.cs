using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Support
{
    class DatabaseConverter
    {

        DBConnection dbCon;
        PatientFactory infoFac;
        Patient currentPatient;
        Patient nextPatientret;
        PrescriptionFactory prescriptionFactory;
        MedicalNoteFactory medicalNote;
        MedicineInFactory medicationFactory;
        TestResultFactory test;
        Appointment appointment = new Appointment();
        AppointmentSort appointmentClass;
        List<MedicalNotes> history;
        List<Prescription> prescription;
        List<TestResult> testresults;
        List<MedicationInstance> medicationList;
        List<Medication> medication;
        List<Prescription> prescriptionList = new List<Prescription>();
        List<TestResult> testresult = new List<TestResult>();




        List<string> listPrescription = new List<string>();
        List<string> listHistory = new List<string>();
        List<string> listTestResults = new List<string>();


       



        public DatabaseConverter(DBConnection dbCon, Patient patientObject)
        {

            InitClass(dbCon);
            
            load(patientObject);
        
        }




        public DatabaseConverter(DBConnection dbCon)
        {
            InitClass(dbCon);
            
        }





        public List<Prescription> getPrescription()
        {
            return prescription;

        }

        public List<TestResult> getTestResults()
        {


            return testresult;

        }










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





        public Patient findPatientByName(string s1, string s2)
        {

            currentPatient = infoFac.getAPatient(s1, s2);

            return currentPatient;

        }

        public void removeAppointment()
        {

            appointment = appointmentClass.getNextAppointment();
            nextPatientret = infoFac.GetAPatientByID(appointment.PatientId);
            appointmentClass.removeAppointment();

        }




        public void loadList()
        {

            history = medicalNote.GetMedicalNotes(currentPatient.ID);
            prescription = prescriptionFactory.GetPrescriptions(currentPatient.ID);
            testresults = test.GetTestResults(currentPatient.ID);
            
          
        }

        public List<Prescription> GetPrescription()
        {
            return prescriptionList;

        }


        public void load(Patient o)
        {
            try
            {
                currentPatient = o;
                loadList();

                foreach (MedicalNotes m in history) { listHistory.Add(m.ID + " " + m.PatientID + " " + m.Notes + " " + m.WrittenDate + "\n"); }

                foreach (Prescription p in prescription)
                {

                    medicationList = medicationFactory.GetMedicineIdByPrescription(p.Id);

                    foreach (MedicationInstance m in medicationList)
                    {

                        medication = medicationFactory.GetMedicneNameById(m.MedicationId);

                        foreach (Medication me in medication)
                        {

                            listPrescription.Add(me.ScientificName + " " + p.IssueDate);

                        }
                    }
                }
                prescriptionList = prescriptionFactory.GetPrescriptions(currentPatient.ID);
                testresult = test.GetTestResults(currentPatient.ID);
                foreach (TestResult tr in testresult) { listTestResults.Add(tr.TestName.ToString() + " " + tr.TestDate.ToString()); }

                
            }
            catch (NullReferenceException ne) { Console.WriteLine("no object " + ne); }

        }















        public List<string> HistoryData()
        {

            return listHistory;

        }





        public List<string> PrescriptionData()
        {

            return listPrescription;

        }





        public List<string> TestResults()
        {

            return listTestResults;
        }



        public void insertPatientNote(Patient p,List<string>newNotes)
        {

            medicalNote.InsertPatientNote(p, newNotes);

        }



        public void editPrescription(List<Prescription> pre)
        {

            prescriptionFactory.InsertEditedPrescription(pre);

        }

        public void removePrescription(Prescription pre)
        {
            prescriptionFactory.DeletePrescription(pre);

        }

        public void addPrescription(Prescription pre)
        {
            prescriptionFactory.addPrescription(pre);
        }

       

        public  Patient InitNextPatient()
        {
          
            appointment = appointmentClass.getNextAppointment();
            nextPatientret = infoFac.GetAPatientByID(appointment.PatientId);
            
            return nextPatientret;


        }

        public Appointment nextPatientAppointment()
        {
            
            
            return appointment;

        }


    }
    
}
