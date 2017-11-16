using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2;
using Mockup2.DatabaseClasses;

namespace ShaunsTests
{
    [TestClass]
    public class QueryBuilderTest
    {
        /// <summary>
        /// Asserts that QueryBuilder returns the query:
        /// SELECT * FROM Patient;
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE);
            Assert.AreEqual(b.ToString(), "SELECT * FROM Patient;");
        }

        /// <summary>
        /// Asserts that QueryBuilder returns the query:
        /// SELECT * FROM Staff WHERE Staff.id = 5;
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.ID,5));
            Assert.AreEqual(b.ToString(), "SELECT * FROM Staff WHERE Staff.id = 5;");
        }
    }
}
