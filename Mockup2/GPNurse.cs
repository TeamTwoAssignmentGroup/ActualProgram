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
using Mockup2.Support;
using Mockup2.DatabaseClasses;

namespace Mockup2
{
    public partial class GPNurse : Form
    {

        DBConnection dbCon;
        PatientFactory infoFac;
        Patient currentPatient;
        Patient found;
        Patient nextPatient;
        DatabaseConverter converter;
        
        string timeIs;
        string name;


















        List<string> history= new List<string>();
        List<string> prescription =new List<string>();
        List<string> testresults= new List<string>();
        List<string> patient = new List<string>();
        List<string> note = new List<string>();
        List<Prescription> prescriptionList = new List<Prescription>();














        public void Init(DBConnection dbCon)

        {

            this.dbCon = dbCon;
            infoFac = new PatientFactory(dbCon);
            Timer timer1 = new Timer();
            timer1.Start();
            converter = new DatabaseConverter(dbCon);
           



        }






















        public GPNurse(DBConnection dbCon)
        {
            Init(dbCon);
            InitializeComponent();
            getNextPatient();
        }




















        /**
         * This button returns one patient from the database as an object
         * can be by name or nhs number
         * */
        private void OK_Click(object sender, EventArgs e)
        { 

          
           
            string firstName = firstText.Text;
            string lastName = lastText.Text;
           


          
            found=converter.findPatientByName(firstName, lastName);
            foundPatientObject();
          
            searchBox.Items.Add(found.FirstName + " " + found.LastName);
           
            textBoxCleaner(firstText);
            textBoxCleaner(lastText);
          
            

        }













        public void cleanAll()
        {

            textBoxCleaner(detailsBox);
            textBoxCleaner(historyBox);
            ListBoxCleaner(listBox1);
            ListBoxCleaner(searchBox);
            textBoxCleaner(prescriptionsBox);
            ListBoxCleaner(listBox1);
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
                prescription = convert.PrescriptionData();
                testresults = convert.TestResults();
                prescriptionList = convert.GetPrescription();

                listBox1.Items.Add (getPrescriptions());
                textBoxWriter(history, historyBox);
                textBoxWriter(prescription, prescriptionsBox);
            
                
              
                detailsBox.Text = currentPatient.FirstName + " " + currentPatient.LastName + " " + currentPatient.DOB + "\nGender: " + currentPatient.Gender + "\nNext of kin: " + currentPatient.NextOfKin + "\nAddress " + currentPatient.Address;
            }
            else { MessageBox.Show("Select patient"); }
          
            
            }



        public string getPrescriptions()
        {

            foreach (Prescription p in prescriptionList) { return p.IssueDate.ToString(); }

            return "null";
        }

















        public void foundPatientObject()
        {
            //clearnote
         
                currentPatient = found;
           
           

        }













        public void swapPatient(Patient o)
        {
            currentPatient = o;

        }















            /**
             * Prinitg any list <string></string> data into the textbox
             * */
            public void textBoxWriter(List<string> s,RichTextBox r)
            {

                for (int i = 0;i<s.Count();i++)
                {

                
                r.AppendText("\n"+s[i]);

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

















        public void getNextPatient()
        {
            
            nextPatient = converter.InitNextPatient();
            converter.removeAppointment();
            string appointment = converter.nextPatientAppointment().AppointmentTime.ToString();
            name = nextPatient.FirstName + " " + nextPatient.LastName+"\n"+appointment;

           
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


















        private void clear_Click(object sender, EventArgs e,ListBox o)
        {
            ListBoxCleaner(o);
        }



















        public void addNote()
        {
            textBoxCleaner(historyBox);
            textBoxWriter(history, historyBox);
            
            string s = "";
            s=noteBox.Text;
            if (!s.Equals(""))
            {
                note.Add(s);
                textBoxWriter(note, historyBox);
            }
            else
            {
                MessageBox.Show("Please write a note!");
            }
        
        }
























        private void save_Click(object sender, EventArgs e)
        {

           
            addNote();
            textBoxCleaner(noteBox);
        }





















        private void remove_Click(object sender, EventArgs e)
        {
            try
            {
                int i = note.Count();
                i = i - 1;
                note.RemoveAt(i);
            }
            catch (ArgumentOutOfRangeException r)
            {
                MessageBox.Show("No history!\n" + r);
            }

            textBoxCleaner(noteBox);
            textBoxCleaner(historyBox);

            textBoxWriter(history, historyBox);
            textBoxWriter(note, historyBox);


        }
























        /**
         * prompting the user to save their work
         * */
        public void saveChanges()
        {

            if (currentPatient != null )
            {
               
                  
                    DatabaseConverter manager = new DatabaseConverter(dbCon);
                    DialogResult result;

                    result = MessageBox.Show("Save changes for current patient?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
            
                        manager.insertPatientNote(currentPatient, note);
                        


                    }
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        
                    }
                    note.Clear();
                }
                
            
            else { }

        }
























        private void nextButton_Click(object sender, EventArgs e)
        {


            
            swapPatient(nextPatient);
          
            getNextPatient();
            loadCurrentPatient();
            
           
        }



























        private void exitButton_Click(object sender, EventArgs e)
        {
            saveChanges();
            this.Close();
        }

        private void searchBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





























        private void timer1_Tick(object sender, EventArgs e)
        {
            timeNow();
            try
            {


                TimeLabel.Text = timeIs;
                nextLabel.Text = name;
            }
            catch (NullReferenceException ex) { nextLabel.Text = "no patient  for 10 mins"; }
        }





























        public string timeNow()
        {

            timeIs = DateTime.Now.ToString("hh:mm");
            return timeIs;

        }
















        private void TimeLabel_Click(object sender, EventArgs e)
        {
            TimeLabel.BackColor = System.Drawing.Color.Transparent;
        }

















        private void timer2_Tick(object sender, EventArgs e)
        {
            getNextPatient();
        }

        private void searchBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            loadCurrentPatient();
        }
    }
}