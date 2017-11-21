using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2.DatabaseClasses;
using Mockup2.Support;

namespace RolandsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            DBConnection con = new DBConnection();
            DatabaseConverter test = new DatabaseConverter(con,new Patient());

            Patient p = test.findPatientByName("as", "as");

            Assert.AreEqual(p.ID, 210);

        }
    }
}
