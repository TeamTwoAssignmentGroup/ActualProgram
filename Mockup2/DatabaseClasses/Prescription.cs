using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.DatabaseClasses
{
    class Prescription
    {

        int id;
        int staffid;
        int patientid;
        DateTime issuedate;
        bool isRepeatable;
        bool repeatedRequest;



        public DateTime IssueDate
        {
            set { issuedate= value; }
            get { return issuedate; }
        }


        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public int PatientId
        {
            set { patientid = value; }
            get { return patientid; }
        }

        public int StaffId
        {
            set { staffid = value; }
            get { return staffid; }
        }

        public bool IsRepeatable
        {
            set { isRepeatable = value; }
            get { return isRepeatable; }
        }

        public bool RepeatRequested
        {
            set { repeatedRequest= value; }
            get { return repeatedRequest; }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5}",id,patientid,staffid,IsRepeatable,issuedate,repeatedRequest);
        }

    }
}
