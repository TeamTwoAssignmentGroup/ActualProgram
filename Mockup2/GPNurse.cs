﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mockup2.Factories;
using Mockup2.Support;
using Mockup2.DatabaseClasses;

namespace Mockup2
{
    public partial class GPNurse : Form
    {


        /**
         * Objects and variables used on the page
        */
        private DBConnection dbCon;
        private PatientFactory infoFac;
        private AddPrescription PrescriptonForm;
        private Patient currentPatient;
        private Patient found;
        private Patient nextPatient;
        private DatabaseConverter converter;
        private bool TestresultController;
        private bool PrescriptionListController;
        private int editIndex;
        private string timeIs;
        private string name;
        private List<string> history = new List<string>();
        private List<string> prescriptions = new List<string>();
        private List<string> testresults = new List<string>();
        private List<string> patientDetails = new List<string>();
        private List<string> notes = new List<string>();
        private List<Prescription> prescriptionList = new List<Prescription>();
        private List<TestResult> testresultsList = new List<TestResult>();
        private bool isDoctor;





        /**
         * initialises constructor 
         * include time,database components
         * */
        public void Init(DBConnection dbCon)

        {

            this.dbCon = dbCon;
            infoFac = new PatientFactory(dbCon);
            Timer timer1 = new Timer();
            timer1.Start();
         
            converter = new DatabaseConverter(dbCon);
            PrescriptonForm= new AddPrescription(dbCon);
        }




        /**
         * Form 
         * Initialises a next patient and database components
         * */
        public GPNurse(DBConnection dbCon,bool isDoctor)
        {
            this.isDoctor = isDoctor;

            //database compontent
            Init(dbCon);

            //default
            InitializeComponent();

            //nextpatient who is colsest to current time
            getNextPatient();


            allow.Visible = false;
            decline.Visible = false;

        
        }




        /**
         * This button returns one patient from the database as an object
         * can be by name or nhs number
         * */
        private void OK_Click(object sender, EventArgs e)
        {
            //local string
            string firstName = firstText.Text;
            string lastName = lastText.Text;

            //get patient from the database (find method)
            found = converter.findPatientByName(firstName, lastName);

            //add patient details to the search box
            searchBox.Items.Add(found.FirstName + " " + found.LastName);
            textBoxCleaner(firstText);
            textBoxCleaner(lastText);

        }




        /**
         * This method is created to clear the from from data
         * */
        public void cleanAll()
        {

            textBoxCleaner(detailsBox);
            textBoxCleaner(historyBox);
            ListBoxCleaner(prescriptiptionsListBox);
            ListBoxCleaner(searchBox);
            ListBoxCleaner(testResultsListBox);
            ListBoxCleaner(prescriptiptionsListBox);
            textBoxCleaner(firstText);
            textBoxCleaner(lastText);

        }




        /**
         * This button (Viev this patient details) loads in selected patient details on the page
         * */
        private void loadCurrentPatient()
        {

            cleanAll();


            if (currentPatient != null)
            {

                DatabaseConverter convert = new DatabaseConverter(dbCon, currentPatient);

                convert.loadList();
                history = convert.HistoryData();
                prescriptions = convert.PrescriptionData();
                prescriptionList = convert.GetPrescription();
                testresultsList = convert.getTestResults();
                testresults = convert.TestResults();
                ListBoxWriter(prescriptions,prescriptiptionsListBox);
                textBoxWriter(history, historyBox);
                ListBoxWriter(testresults, testResultsListBox);
                detailsBox.Text = currentPatient.FirstName + " " + currentPatient.LastName + " " + currentPatient.DOB + "\nGender: " + currentPatient.Gender + "\nNext of kin: " + currentPatient.NextOfKin + "\nAddress " + currentPatient.Address;
                PrescriptonForm.initCurrentPatient(currentPatient);

            }
            else
            {

                MessageBox.Show("Select patient");

            }

        }




        /**
         * This function returns all prescription details that belongs to the current patient
         * */
        public string getPrescriptionNameIssueDate()
        {   
            foreach (string s in prescriptions) { return s; }
            return "";

        }




        /**
         * This function returns prescription object that is currently loaded with current patient
         * this function is specific and return a specific value
         * */
        public string getPrescriptions()
        {

            foreach (Prescription p in prescriptionList) { return p.IssueDate.ToString(); }

            return "";
        }


        public List<string> getPrescriptionsAsString()
        {
            List<string> prescriptionString = new List<string>();
            foreach (Prescription p in prescriptionList) { prescriptionString.Add(p.IssueDate.ToString()); }

            return prescriptionString;
        }

        /**
         * This function reads the testresults from the object list and returns it as a string
         * This function is not global but specified to test name and testdate
         * */
        public string getTestresults()
        {
           
            foreach (TestResult p in testresultsList) { return p.TestName.ToString() + " " + p.TestDate.ToString(); }

            return "";
        }




        /**
         * This function initialises current patient to the patient who has been searched and selecet in the searchbox
         * */
        public void foundPatientObject()
        {

            currentPatient = found;

        }




        /**
         * This function swaps the current patient to the next patient
         * from next or from search
         * */
        public void swapPatient(Patient o)
        {
            currentPatient = o;

        }




        /**
         * Prinitg any list <string></string> data into the textbox
         * */
        public void textBoxWriter(List<string> s, RichTextBox r)
        {

            for (int i = 0; i < s.Count(); i++)
            {


                r.AppendText("\n" + s[i]);

            }


        }




        /**
        * Prinitg any list <string></string> data into the textbox
        * */
        public void ListBoxWriter(List<string> s, ListBox lb)
        {

            for (int i = 0; i < s.Count(); i++)
            {

                string bd = s[i];

                lb.Items.Add(bd);

            }


        }




        /**
         * This function initalises the next patient when an appointment is booked for the day
         * */
        public void getNextPatient()
        {

            nextPatient = converter.InitNextPatient();
            converter.removeAppointment();
            string appointment = converter.nextPatientAppointment().AppointmentTime.ToString();
            name = nextPatient.FirstName + " " + nextPatient.LastName + "\n" + appointment;

        }




        /**
         * Clears selected textbox
         * */
        public void textBoxCleaner(RichTextBox r)
        {

            r.Clear();

        }




        /**
         * Clears selected textbox
         * */
        public void textBoxCleaner(TextBox t)
        {

            t.Clear();

        }




        /**
        * Clears selected textbox
        * */
        public void ListBoxCleaner(ListBox l)
        {

            l.Items.Clear();

        }




        /**
         * This function clears all the listboxes present on this form
         * */
        private void clear_Click(object sender, EventArgs e, ListBox o)
        {
            ListBoxCleaner(o);
        }




        /**
         * This method displays the note in the medical history box after added
         * */
        public void addNote()
        {
            textBoxCleaner(historyBox);
            textBoxWriter(history, historyBox);

            string s = "";
            s = noteBox.Text;
            if (!s.Equals(""))
            {
                notes.Add(s);
                textBoxWriter(notes, historyBox);
            }
            else
            {
                MessageBox.Show("Please write a note!");
            }

        }




        /**
         * Saves the note into a string array that prepares the note to be saved in the database
         * changes only apply when the current patient changes are saved through save() method
         * */
        private void save_Click(object sender, EventArgs e)
        {


            addNote();
            textBoxCleaner(noteBox);
        }




        /**
         * This is the removes modified changes from the medical history that has been added currently
         * */
        private void undo_Click(object sender, EventArgs e)
        {
            try
            {
                int i = notes.Count();
                i = i - 1;
                notes.RemoveAt(i);
            }
            catch (ArgumentOutOfRangeException r)
            {
                MessageBox.Show("No history!\n" + r);
            }

            textBoxCleaner(noteBox);
            textBoxCleaner(historyBox);

            textBoxWriter(history, historyBox);
            textBoxWriter(notes, historyBox);


        }




        /**
         * prompting the user to save their work (curently loaded patient)
         * */
        public void saveChanges()
        {

            if (currentPatient != null)
            {


                DatabaseConverter manager = new DatabaseConverter(dbCon);
                DialogResult result;

                result = MessageBox.Show("Save changes for current patient?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    manager.insertPatientNote(currentPatient, notes);

                }

                if (result == System.Windows.Forms.DialogResult.No)
                {

                }
                notes.Clear();
            }


            else { }

        }




        /**
         * Loads the next patient who has been labeled by this button 
         * this button also saves the currently loaded patient before the next patient loaded onto the form
         * */
        private void nextButton_Click(object sender, EventArgs e)
        {


            saveChanges();
            swapPatient(nextPatient);
            getNextPatient();
            loadCurrentPatient();


        }




        /**
         * The exit button leaves the form and asks to save a patient who currently loaded onto the form
         * */
        private void exitButton_Click(object sender, EventArgs e)
        {
            saveChanges();
            this.Close();
        }




        /**
         * gets the date and time now but only shows current time of the system
         * */
        public string timeNow()
        {

            timeIs = DateTime.Now.ToString("hh:mm");
            return timeIs;

        }




        /**
         * Initialised a clock on the form
         * */
        private void TimeLabel_Click(object sender, EventArgs e)
        {
            TimeLabel.BackColor = System.Drawing.Color.Transparent;
        }




        /**
         * Timer is running ad refreshing the form (checks for patient when time passes)
         * */
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            getNextPatient();
       
        }




        /**
      * Timer action 
      * update time and next patient
      * */
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeNow();
            try
            {
                
                TimeLabel.Text = timeIs;
                nextLabel.Text = name;
            }
            catch (NullReferenceException ex) { nextLabel.Text = "no patient "; }
        }




        /**
         * Allows double clik on the patient who has been searched from the database
         * when double clik action occurs then the patient will be loaded onto the form
         * */
        private void searchBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //swap patient to load in if secected
            foundPatientObject();

            //show this patient information
            loadCurrentPatient();
        }




        /**
         * Double click on the testresults box allows to read a prescription object with more detail
         * */
        private void testResultsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (TestresultController == false)
            {
                string name = "";
                int index = testResultsListBox.Items.IndexOf(testResultsListBox.Text);
                name = testResultsListBox.SelectedItem.ToString();
                testResultsListBox.Items.Clear();
                testResultsListBox.Items.Add(name);
                testResultsListBox.Items.Add(testresultsList[index].TestName);
                testResultsListBox.Items.Add (testresultsList[index].TestName);
                testResultsListBox.Items.Add (testresultsList[index].StaffID);
                TestresultController = true;
            }
            else
            {
                testResultsListBox.Items.Clear();
                TestresultController = false;
                ListBoxWriter(testresults, testResultsListBox);
            }
        }




        /**
         * allows prescription management
         * double click to read object
         * */
        private void prescriptionsListBox_DoubleClick(object sender, EventArgs e)
        {
            
            if (PrescriptionListController == false)
            {
                string name = "";
                int index = prescriptiptionsListBox.Items.IndexOf(prescriptiptionsListBox.Text);
                editIndex = index;
                name = prescriptiptionsListBox.SelectedItem.ToString();
                prescriptiptionsListBox.Items.Clear();
                prescriptiptionsListBox.Items.Add(name);
                prescriptiptionsListBox.Items.Add(prescriptionList[index].IsRepeatable);
                prescriptiptionsListBox.Items.Add(prescriptionList[index].RepeatRequested);
                prescriptiptionsListBox.Items.Add(prescriptionList[index].StaffId);
                PrescriptionListController = true;
            }
            else
            {
                prescriptiptionsListBox.Items.Clear();
                PrescriptionListController = false;
                ListBoxWriter(prescriptions, prescriptiptionsListBox);
            }
        }


    
       
        /**
         * Allow prescription in the prescrioption list to be repeated
         * */
        private void allow_Click(object sender, EventArgs e)
        {   

            if (allow.Visible = true) { allow.Visible = false; decline.Visible = false; }
            prescriptionList[editIndex].IsRepeatable = true;
            saveModifiedPrescription();
           
        }

       


        /**
         * Changes the is repeateable to false
         * repeate not allowed
         * */
        private void decline_Click(object sender, EventArgs e)
        {

            if (decline.Visible = true) { decline.Visible = false; allow.Visible = false; }
            prescriptionList[editIndex].IsRepeatable = false;
            saveModifiedPrescription();

        }




        /**
         * saves the modified prescrioption
         * */
        private void saveModifiedPrescription()
        {

            PrescriptonForm.modified(prescriptionList);

        }



        /**
         * Changes the true or false where the prescription is repeatable
         * */
        private void editButton_Click_1(object sender, EventArgs e)
        {
            allow.Visible = true;
            decline.Visible = true;
        }




        /**
         * AddButton
         * calls the prescription form to create a new prescirption
         * */
        private void button3_Click(object sender, EventArgs e)
        {
            PrescriptonForm.Show();
   
        }



      








        //end                  //end                         //end                      //end                          //end               //end                                        //end

    }
}