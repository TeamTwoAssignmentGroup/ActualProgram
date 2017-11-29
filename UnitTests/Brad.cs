using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2.DatabaseClasses;
using Mockup2.Factories;

namespace UnitTests
{
    [TestClass]
    public class Brad
    {
        static DBConnection dbCon = new DBConnection();
        StaffFactory sf = new StaffFactory(dbCon);

        [TestMethod]
        public void TestStaffFactory()
        {
            /// <summary>
            /// Tests that <see cref="Mockup2.Factories.StaffFactory"/> returns correct information.
            /// By pulling a <see cref="Mockup2.DatabaseClasses.Staff"/> by the ID of 2,
            /// the first name should be 'King' and the last name should be 'Vernay'.
            /// </summary>

            Staff s = sf.GetStaffByID(2)[0];
            Assert.AreEqual(s.FirstName, "King");
            Assert.AreEqual(s.LastName, "Vernay");

        }

        [TestMethod]
        public void TestStaffFactory2()
        {

            //sf = new StaffFactory(dbCon);
            int s = sf.GetNextAvailableStaffID();
            Assert.AreEqual(s, 403);

        }

        [TestMethod]
        public void TestStaffFactory3()
        {
        
        }
    }
}
