using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockup2.DatabaseClasses;
using Mockup2.Factories;

namespace UnitTests
{
    [TestClass]
    public class Shaun
    {
        DBConnection dbCon = new DBConnection();
        /// <summary>
        /// Tests that <see cref="Mockup2.Factories.PatientFactory"/> returns correct information.
        /// By pulling a <see cref="Mockup2.DatabaseClasses.Patient"/> by the ID of 200,
        /// the first name should be 'Trenna' and the last name should be 'Clayfield'.
        /// </summary>
        [TestMethod]
        public void TestPatientFactory()
        {
            PatientFactory pf = new PatientFactory(dbCon);
            Patient p = pf.GetPatientsByID(200)[0];
            Assert.AreEqual(p.FirstName, "Trenna");
            Assert.AreEqual(p.LastName, "Clayfield");
        }

        /// <summary>
        /// Tests <see cref="Mockup2.DatabaseClasses.QueryBuilder"/> to ensure it builds correctly formatted
        /// and ordered strings.
        /// Here we are looking for the string to be 'SELECT * FROM Patient;'.
        /// </summary>
        [TestMethod]
        public void TestQueryBuilder()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE);
            Assert.AreEqual(b.ToString(), "SELECT * FROM Patient;");
        }

        /// <summary>
        /// Tests <see cref="Mockup2.DatabaseClasses.QueryBuilder"/> to ensure it builds correctly formatted
        /// and ordered strings.
        /// Here we are looking for the string to be 'SELECT Staff.firstName AS Staff_firstName,Staff.lastName AS Staff_lastName FROM Staff WHERE Staff.id = 100;'.
        /// </summary>
        [TestMethod]
        public void TestQueryBuilderWhere()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName).From(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.ID,100));
            Assert.AreEqual(b.ToString(), "SELECT Staff.firstName AS Staff_firstName,Staff.lastName AS Staff_lastName FROM Staff WHERE Staff.id = 100;");
        }

        /// <summary>
        /// Tests <see cref="Mockup2.DatabaseClasses.QueryBuilder"/> to see if it throws a <see cref="Mockup2.DatabaseClasses.QueryBuilder.MalformedUpdateQueryException"/> when an Update
        /// statement is used without an accompanying Where statement.
        /// </summary>
        [TestMethod]
        public void TestQueryBuilderException()
        {
            Assert.ThrowsException<QueryBuilder.MalformedUpdateQueryException>(delegate{
                QueryBuilder b = new QueryBuilder();
                b.Update(Tables.STAFF_TABLE).Set(Tables.STAFF_TABLE.FirstName, "John");
                b.ToString();
            });
        }

        /// <summary>
        /// Tests that <see cref="Mockup2.DatabaseClasses.DBConnection"/> correctly throws exceptions when given incorrect login information.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (MySql.Data.MySqlClient.MySqlException),"Connection details were invalid")]
        public void TestDBConnection()
        {
            DBConnection dbCon = new DBConnection("localhost","wrongDB","nouser","nullpassword");
        }

        /// <summary>
        /// Tests that the default constructor of <see cref="DBConnection"/> does not throw an exception.
        /// </summary>
        [TestMethod]
        public void TestDBConnection2()
        {
            DBConnection dbCon = new DBConnection();
        }
    }
}
