using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Classes
{
    class MedicationInstance
    {

        int id;
        int prescid;
        int medicationid;
        string instructions;
          
        public int Id { set { id = value; }get { return id; } }
        public int PrescriptionId { set { prescid = value; }get { return prescid; } }
        public int MedicationId { set { medicationid = value; } get { return medicationid; } }
        public string Instruction { set { instructions = value; }get { return instructions; } }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5}", id,medicationid, prescid,instructions);
        }

    }
}
