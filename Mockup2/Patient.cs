using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    class Patient
    {


        int id;
        string nhsumber;
        string firstName;
        string lastName;
        string address;
        string postcode;
        string nextOfKin;
        DateTime dob;
        string gender;
        string religion;
        string email;
        string phone;



        public DateTime DOB
        {
            set { dob = value; }
            get { return dob; }
        }


        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public string NHSNumber
        {
            set { nhsumber = value; }
            get { return nhsumber; }
        }

        public string FirstName
        {
            set { firstName = value; }
            get { return firstName; }
        }

        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }

        public string Address
        {
            set { address = value; }
            get { return address; }
        }

        public string Postcode
        {
            set { postcode = value; }
            get { return postcode; }
        }

        public string NextOfKin
        {
            set { nextOfKin = value; }
            get { return nextOfKin; }
        }

        public string Gender
        {
            set { gender = value; }
            get { return gender; }
        }

        public string Religion
        {
            set { religion = value; }
            get { return religion; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public string Phone
        {
            set { phone = value; }
            get { return phone; }
        }




    }
}
