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
        /**
         * Dataset and factory for the appointments
         * */
        private DBConnection connection;
        private AppointmentFactory select;
        private Appointment next = new Appointment();
        private List<Appointment> sort = new List<Appointment>();
        private Appointment placement = new Appointment();
      
      
       
        /// <summary>
        /// Constructor takes a database connection
        /// </summary>
        /// <param name="dbcon"></param>
        public AppointmentSort(DBConnection dbcon)
        {
            this.connection = dbcon;
            
            select = new AppointmentFactory(connection);
            initSet();


        }



        /// <summary>
        /// Initialises the appointments list from the database (Today)
        /// </summary>
        public void initSet()
        {
        
                sort = select.GetAppointmentsByDate(DateTime.Now);
        }




        /// <summary>
        /// Boublesort algorithm
        /// </summary>
        public void runSort()
        {
          
            for (int outer = 0; outer < sort.Count; outer++)
            {
                for (int inner = 0; inner < sort.Count - 1; inner++)
                {
                    if (sort[inner].AppointmentTime > sort[inner + 1].AppointmentTime)
                    {
                        placement = sort[inner + 1];
                        sort[inner + 1] = sort[inner];
                        sort[inner] = placement;

                    }
                }
            }
          


        }




        /// <summary>
        /// This method removes the expired appointments from the list (can be set by hardcode)
        /// </summary>
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

                }catch (ArgumentOutOfRangeException ex) { Console.WriteLine(ex); }  
                
        }



        /// <summary>
        /// This method return next appointment object
        /// catching if the list is empty
        /// </summary>
        /// <returns></returns>
        public Appointment getNextAppointment()
        {
            try
            {        
                removeExpired();
                runSort();
                next = sort[0];
            }
            catch (ArgumentOutOfRangeException ex) { Console.WriteLine(ex); }
            
            return next;
        }



        /// <summary>
        /// This method is used to remove appointment before the next sort
        /// only used when the appointment is skipped or served
        /// </summary>
        public void removeAppointment()
        {
            try
            {
                sort.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException ex) { Console.WriteLine(ex); }
  
        }
           

        

  

    }
}

//end               //end               //end               //end
