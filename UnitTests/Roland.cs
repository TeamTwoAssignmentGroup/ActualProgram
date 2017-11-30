using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2.DatabaseClasses;
using Mockup2.Support;
using Mockup2.Factories;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class Roland
    {
        DBConnection dbCon = new DBConnection();
        Appointment appointment = new Appointment();
        AppointmentSort appointmentClass;
        PatientFactory infoFac;
        Patient nextPatientret;
        DatabaseConverter convert;

        [TestMethod]
        [ExpectedException ( typeof ( NullReferenceException ) )]
        public void RunNullExecptiontestoPass()
        {

            appointmentClass = new AppointmentSort ( dbCon );
            infoFac = new PatientFactory (dbCon);

            appointment = null;
            nextPatientret = infoFac.GetAPatientByID ( appointment.PatientId );
            appointmentClass.removeAppointment ();
           

        }


       


        [TestMethod]
        [ExpectedException ( typeof ( NullReferenceException ) )]
        public void patientToPass ( )
        {

            Patient patient = new Patient();
            patient.Address = "";         
            patient.DOB =DateTime.Today;
            patient.Email= "";
            patient.FirstName= "";
            patient.Gender= "";
            patient.ID= 2;
            patient.LastName = "";
            patient.NextOfKin= "";
            patient.NHSNumber= "";
            patient.Phone= "";
            patient.Postcode= "";
            patient.Religion= "";

            convert.load ( patient );



        }

        [TestMethod]
        [ExpectedException ( typeof ( NullReferenceException ) )]
        public void patientToFail ( )
        {
            
            convert.load ( null);

        }

        

    









    }
}
