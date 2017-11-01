using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2
{
    class Staff
    {

        int id;
        string firstName;
        string lastName;
        string jobrole;
        string email;
        string password;
      



        

        public int ID
        {
            set { id = value; }
            get { return id; }
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

        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string JobRole
        {
            set { jobrole = value; }
            get { return jobrole; }
        }
       
        public string Email
        {
            set { email = value; }
            get { return email; }
        }


        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5}",id,firstName,lastName,jobrole,password,email);
        }

    }
}
