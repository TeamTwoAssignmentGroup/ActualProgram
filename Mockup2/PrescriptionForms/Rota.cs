using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.PrescriptionForms
{
    class Rota
    {

        int id;
        int staffID;
        string mon;
        string tur;
        string wed;
        string thur;
        string fri;
        string sat;
        string sun;

        public string Mon { set { mon = value;}get { return mon; } }
        public string Tur { set { tur = value; } get { return tur; } }
        public string Wed { set { wed = value; } get { return wed; } }
        public string Thur { set { thur = value; } get { return thur; } }
        public string Fri { set { fri = value; } get { return fri; } }
        public string Sat { set { sat = value; } get { return sat; } }
        public string Sun { set { sun = value; } get { return sun; } }
        public int Id { set { id = value; }get { return id; } }
        public int StaffId { set { staffID = value; } get { return staffID; } }




    }
}
