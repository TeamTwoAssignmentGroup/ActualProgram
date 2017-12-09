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


        /// <summary>
        /// Tests that <see cref="Mockup2.Factories.StaffFactory"/> returns correct information.
        /// By pulling a <see cref="Mockup2.DatabaseClasses.Staff"/> by the ID of 2,
        /// the first name should be 'King' and the last name should be 'Vernay'.
        /// </summary>
        [TestMethod]
        public void TestStaffFactory()
        {
            Staff s = sf.GetStaffByID(2)[0];
            Assert.AreEqual(s.FirstName, "King");
            Assert.AreEqual(s.LastName, "Vernay");
        }


        /// <summary>
        /// Tests that <see cref="Mockup2.Factories.StaffFactory"/> returns correct information.
        /// By pulling a <see cref="Mockup2.DatabaseClasses.Staff"/> by the next available StaffID in the database for use.
        /// the first name should be 'King' and the last name should be 'Vernay'.
        /// </summary>
        [TestMethod]
        public void TestStaffFactory2()
        {
            int s = sf.GetNextAvailableStaffID();
            Assert.AreEqual(s, 404);
        }

        [TestMethod]
        public void TestStaffFactory3()
        {
            

        }
    }
}
