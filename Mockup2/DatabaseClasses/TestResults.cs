using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    class TestResult
    {
        private int id;
        private int patientID;
        private int staffID;
        private string testName;
        private DateTime testDate;
        private DateTime testTime;
        private string results;

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int PatientID
        {
            get { return this.patientID;}
            set { this.patientID = value; }
        }

        public int StaffID
        {
            get { return this.staffID; }
            set { this.staffID = value; }
        }

        public string TestName
        {
            get { return this.testName; }
            set { this.testName = value; }
        }

        public DateTime TestDate
        {
            get { return this.testDate; }
            set { this.testDate = value; }
        }

        public DateTime TestTime
        {
            get { return this.testTime; }
            set { this.testTime= value; }
        }

        public string Results
        {
            get { return this.results; }
            set { this.results = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6}",id,patientID,staffID,testName,testDate,testTime,results);
        }

    }
}
