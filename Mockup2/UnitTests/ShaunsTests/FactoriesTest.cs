using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2;
using System.Collections.Generic;
using Mockup2.DatabaseClasses;
using Mockup2.Factories;

namespace ShaunsTests
{
    [TestClass]
    public class FactoriesTest
    {
        DBConnection con = new DBConnection();
        /// <summary>
        /// Asserts that PatientFactory returns the correct amount of Patient objects.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            PatientFactory pf = new PatientFactory(con);
            List<Patient> patients = pf.GetPatients();
            Assert.AreEqual(patients.Count, 200);
        }

        /// <summary>
        /// Asserts that the patient id of 200 belongs to Trenna Clayfield.
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            PatientFactory pf = new PatientFactory(con);
            Patient p = pf.GetPatientsByID(200)[0];
            Assert.AreEqual(p.FirstName, "Trenna");
            Assert.AreEqual(p.LastName, "Clayfield");
        }
    }
}
