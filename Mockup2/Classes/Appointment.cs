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
        DateTime appointDate;
        DateTime appointTime;
        string cause;
        string status;
      


        public DateTime AppointmentDate
        {
            set { appointDate = value; }
            get { return appointDate; }
        }

        public DateTime AppointmentTime
        {
            set { appointTime = value; }
            get { return appointTime; }
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

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6}",id,staffid,patientid,appointDate,appointTime,cause,status);
        }




    }
}
