using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2.Factories
{
    /// <summary>
    /// Convenience class to handle returning, updating, and inserting TestResult objects into the database.
    /// </summary>
    class TestResultFactory : AbstractFactory
    {
        public TestResultFactory(DBConnection dbCon) : base(dbCon)
        {
        }

        /// <summary>
        /// Get a list of TestResult objects based on search criteria given the QueryBuilder.
        /// </summary>
        /// <param name="b">QueryBuilder object.</param>
        /// <returns>A list of TestResult objects.</returns>
        public List<TestResult> GetTestResults(QueryBuilder b)
        {

            List<TestResult> result = new List<TestResult>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

           
                while (reader.Read())
                {
               
                    TestResult a = new TestResult();
                    TestResultTable pt = Tables.TESTRESULT_TABLE;
                    a.ID = GetInt(reader[pt.ID.Name]);
                    a.StaffID = GetInt(reader[pt.IssuingStaffID.Name]);
                    a.PatientID = GetInt(reader[pt.PatientID.Name]);
                    a.TestName = GetString(reader[pt.TestName.Name]);
                    a.TestDate = GetDateTime(reader[pt.TestDate.Name]);
                    a.TestTime = GetDateTime(reader[pt.TestTime.Name]);
                    a.Results = GetString(reader[pt.Results.Name]);
                    result.Add(a);


                 }

                reader.Close();
                reader.Dispose();
                return result;


        }

        /// <summary>
        /// Convenience method to get all 
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public List<TestResult> GetTestResults(int patientID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.TESTRESULT_TABLE).Where(b.IsEqual(Tables.TESTRESULT_TABLE.PatientID,patientID));
            return GetTestResults(b);
        }
        public List<TestResult> GetTestResults()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.TESTRESULT_TABLE);
            return GetTestResults(b);
        }
    }
}
