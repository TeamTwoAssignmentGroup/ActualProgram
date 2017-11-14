using Mockup2.DatabaseClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.DatabaseClasses.Tables;

namespace Mockup2.Factories
{
    /// <summary>
    /// Convenience method to handle returning, updating, and inserting Prescription objects into the database.
    /// </summary>
    class PrescriptionFactory : AbstractFactory
    {
        private static int nextAvailablePrescriptionID;
        public PrescriptionFactory(DBConnection dbCon) : base(dbCon)
        {
            if (nextAvailablePrescriptionID <=0)
            {
                nextAvailablePrescriptionID = GetLastPrescriptionID();
            }
        }

        /// <summary>
        /// Returns the next available prescription id.
        /// </summary>
        /// <returns>Next available prescription id.</returns>
        public int GetNextAvailablePrescriptionID()
        {
            return ++nextAvailablePrescriptionID;
        }

        /// <summary>
        /// Gets a list of Prescriptions from the database based on search critera provided by the QueryBuilder.
        /// </summary>
        /// <param name="b">QueryBuilder containing the SQL code.</param>
        /// <returns>A list of Prescriptions.</returns>
        public List<Prescription> GetPrescriptions(QueryBuilder b)
        {
            List<Prescription> result = new List<Prescription>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Prescription a = new Prescription();
                PrescriptionTable pt = Tables.PRESCRIPTION_TABLE;
                a.Id = GetInt(reader[pt.ID.Name]);
                a.StaffId = GetInt(reader[pt.IssuingStaffID.Name]);
                a.PatientId = GetInt(reader[pt.PatientID.Name]);
                a.IsRepeatable = GetBool(reader[pt.IsRepeatable.Name]);
                a.IssueDate = GetDateTime(reader[pt.IssueDate.Name]);
                a.RepeatRequested = GetBool(reader[pt.RepeatRequested.Name]);
                result.Add(a);
            }
            reader.Close();
            reader.Dispose();
            return result;
        }

        /// <summary>
        /// Convenience method to get all prescriptions.
        /// </summary>
        /// <returns></returns>
        public List<Prescription> GetPrescriptions()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PRESCRIPTION_TABLE);
            return GetPrescriptions(b);
        }

        /// <summary>
        /// Convenience method to get all prescriptions based on the patient id they belong to.
        /// </summary>
        /// <param name="patientID">ID of the patient to find prescriptions for.</param>
        /// <returns>A list of Prescriptions.</returns>
        public List<Prescription> GetPrescriptions(int patientID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PRESCRIPTION_TABLE).Where(b.IsEqual(Tables.PRESCRIPTION_TABLE.PatientID,patientID));
            return GetPrescriptions(b);
        }

        /// <summary>
        /// Gets the last available prescription id currently in the database.
        /// </summary>
        /// <returns>The last available prescription id.</returns>
        private int GetLastPrescriptionID()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PRESCRIPTION_TABLE).OrderBy(true, Tables.PRESCRIPTION_TABLE.ID).Limit(1);
            return GetPrescriptions(b)[0].Id;
        }








    }
}
