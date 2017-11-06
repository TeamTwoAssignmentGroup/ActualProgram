using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2.Factories
{
    class PrescriptionFactory : AbstractFactory
    {
        public PrescriptionFactory(DBConnection dbCon) : base(dbCon)
        {
        }

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

        public List<Prescription> GetPrescriptions()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PRESCRIPTION_TABLE);
            return GetPrescriptions(b);
        }

        public List<Prescription> GetPrescriptions(int patientID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PRESCRIPTION_TABLE).Where(b.IsEqual(Tables.PRESCRIPTION_TABLE.PatientID,patientID));
            return GetPrescriptions(b);
        }








    }
}
