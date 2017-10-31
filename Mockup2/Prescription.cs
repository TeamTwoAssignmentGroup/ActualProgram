using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    class Prescription
    {

        int id;
        int staffid;
        int patientid;
        DateTime issuedate;
        string isRepeatable;
        string repeatedRequest;



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

        public string IsRepaetavle
        {
            set { isRepeatable = value; }
            get { return isRepeatable; }
        }

        public string RepeatedRequest
        {
            set { repeatedRequest= value; }
            get { return repeatedRequest; }
        }



    }
}
