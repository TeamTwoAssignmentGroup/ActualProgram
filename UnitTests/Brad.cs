using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2.DatabaseClasses;
using Mockup2.Factories;

namespace UnitTests
{
    [TestClass]
    public class Brad
    {
        [TestMethod]
        public void TestStaffFactory()
        {
            DBConnection dbCon = new DBConnection();
            /// <summary>
            /// Tests that <see cref="Mockup2.Factories.StaffFactory"/> returns correct information.
            /// By pulling a <see cref="Mockup2.DatabaseClasses.Staff"/> by the ID of 2,
            /// the first name should be 'King' and the last name should be 'Vernay'.
            /// </summary>

            StaffFactory pf = new StaffFactory(dbCon);
            Staff p = pf.GetStaffByID(2)[0];
            Assert.AreEqual(p.FirstName, "King");
            Assert.AreEqual(p.LastName, "Vernay");


        }
    }
}
