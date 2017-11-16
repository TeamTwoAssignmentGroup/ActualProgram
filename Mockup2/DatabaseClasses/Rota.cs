using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.DatabaseClasses
{
    public class Rota
    {

        int id;
        int staffID;
        string mon;
        string tue;
        string wed;
        string thur;
        string fri;
        string sat;
        string sun;



        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public int StaffID
        {
            set { staffID = value; }
            get { return staffID; }
        }

        public string Mon
        {
            set { mon = value; }
            get { return mon; }
        }

        public string Tue
        {
            set { tue = value; }
            get { return tue; }
        }

        public string Wed
        {
            set { wed = value; }
            get { return wed; }
        }

        public string Thur
        {
            set { thur = value; }
            get { return thur; }
        }

        public string Fri
        {
            set { fri = value; }
            get { return fri; }
        }

        public string Sat
        {
            set { sat = value; }
            get { return sat; }
        }

        public string Sun
        {
            set { sun = value; }
            get { return sun; }
        }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9}",id,staffID,mon,tue,wed,thur,fri,sat,sun);
        }
    }
}
