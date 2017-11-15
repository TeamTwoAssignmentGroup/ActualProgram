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
        PrescriptionFactory prescriptionFactory;
        MedicalNoteFactory medicalNote;
        MedicineInFactory medicationL;
        TestResultFactory test;

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





        public void InitClass(DBConnection dbCon)
        {

            this.dbCon = dbCon;
            medicalNote = new MedicalNoteFactory(dbCon);
            infoFac = new PatientFactory(dbCon);
            prescriptionFactory = new PrescriptionFactory(dbCon);
            test = new TestResultFactory(dbCon);
            medicationL = new MedicineInFactory(dbCon);

        }





        public Patient findPatientByName(string s1, string s2)
        {

            currentPatient = infoFac.getAPatient(s1, s2);

            return currentPatient;

        }




        




        public void load(Patient o)
        {
            try
            {
                currentPatient = o;

                List<MedicalNotes> hist = medicalNote.GetMedicalNotes(currentPatient.ID);
                List<Prescription> pre = prescriptionFactory.GetPrescriptions(currentPatient.ID);
                List<TestResult> tesR = test.GetTestResults(currentPatient.ID);
                List<MedicationInstance> medicationList;
                List<Medication> medication;


                foreach (MedicalNotes m in hist) { listHistory.Add(m.ID + " " + m.PatientID + " " + m.Notes + " " + m.WrittenDate + "\n"); }

                foreach (Prescription p in pre)
                {

                    medicationList = medicationL.GetMedicineIdByPrescription(p.Id);

                    foreach (MedicationInstance m in medicationList)
                    {

                        medication = medicationL.GetMedicneNameById(m.MedicationId);

                        foreach (Medication me in medication)
                        {

                            listPrescription.Add(me.ScientificName + " " + me.CommercialName + " " + p.IssueDate + "\n");

                        }
                    }
                }

                foreach (TestResult t in tesR) { listTestResults.Add(t.TestName + " " + t.Results + " " + t.TestDate + "\n"); }
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

    }
    
}
