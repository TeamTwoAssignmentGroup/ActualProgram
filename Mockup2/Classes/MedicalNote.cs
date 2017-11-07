using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    class MedicalNote
    {
        private int id;
        private int patientID;
        private DateTime writtenDate;
        private string notes;

        public int ID {
            get { return this.id; }
            set { this.id = value; }
        }
        public int PatientID {
            get { return this.patientID; }
            set { this.patientID = value; }
        }
        public DateTime WrittenDate {
            get { return this.writtenDate; }
            set { this.writtenDate = value; }
        }
        public string Notes {
            get { return this.notes; }
            set { this.notes = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3}",id,patientID,writtenDate,notes);
        }
    }
}
