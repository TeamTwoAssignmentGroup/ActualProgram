using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    class Appointment
    {
        int id;
        int staffid;
        int patientid;
        DateTime appoint;
        string cause;
        string status;
      


        public DateTime AppointmentTime
        {
            set { appoint = value; }
            get { return appoint; }
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

        public string Status
        {
            set { status=value; }
            get { return status; }
        }

        public string Cause
        {
            set { cause = value; }
            get { return cause; }
        }

        

   

    }
}
