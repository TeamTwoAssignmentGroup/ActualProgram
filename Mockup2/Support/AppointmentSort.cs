using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Support
{
    class AppointmentSort
    {

        DBConnection connection;
        AppointmentFactory select;
        Appointment next = new Appointment();
        List<Appointment> sort = new List<Appointment>();
        Appointment placement = new Appointment();
      
      
       

        public AppointmentSort(DBConnection dbcon)
        {
            this.connection = dbcon;
            
            select = new AppointmentFactory(connection);
            initSet();


        }


        public void initSet()
        {
           
                
                sort = select.GetAppointmentsByDate(DateTime.Now);
               
            
            
        }

        public void runSort()
        {
          
            //get todays list
           
            //sort them into order now to farthest
           
            for (int outer = 0; outer < sort.Count; outer++)//this nested for loop is the main tool to do the sorting
            {
                for (int inner = 0; inner < sort.Count - 1; inner++)
                {
                    if (sort[inner].AppointmentTime > sort[inner + 1].AppointmentTime)//comparison statement
                    {
                        placement = sort[inner + 1];
                        sort[inner + 1] = sort[inner];
                        sort[inner] = placement;//switching done

                    }
                }
            }
          


        }


        public void removeExpired()
        {
            try {

                for (int i = 0; i < sort.Count; i++)
                {


                   

                    if (sort[i].AppointmentTime.AddMinutes(10) < DateTime.Now)
                    {
                        sort.RemoveAt(i);
                        i--;

                    }

                }

                }catch (ArgumentOutOfRangeException ex) { }  
                
                
               
            
        }








        public Appointment getNextAppointment()
        {
            try
            {
             
                removeExpired();
                runSort();
                next = sort[0];
            }
            catch (ArgumentOutOfRangeException ex) { }
            
            return next;
        }






        public void removeAppointment()
        {
            try
            {
                sort.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException ex) { }
           


        }
           

        

       










    }
}
