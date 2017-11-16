using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.DatabaseClasses
{
    public class Medication
    {
        int id;
        
        string scientificname;
        string commercialname;
        string manufacturer;
      


      

        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public string ScientificName
        {
            set {scientificname = value; }
            get { return scientificname; }
        }

        public string CommercialName
        {
            set { commercialname = value; }
            get { return commercialname; }
        }

        public string Manufacturer
        {
            set { manufacturer = value; }
            get { return manufacturer; }
        }

      
      

    }
}
