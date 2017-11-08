using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2.Factories
{
    class MedicalNoteFactory : AbstractFactory
    { 
        public MedicalNoteFactory(DBConnection dbCon) : base(dbCon)
        {
        }

        public List<MedicalNotes> GetMedicalNotes(QueryBuilder b)
        {

            List<MedicalNotes> result = new List<MedicalNotes>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                MedicalNotes a = new MedicalNotes();
                MedicalNotesTable pt = Tables.MEDICALNOTES_TABLE;
                a.ID = GetInt(reader[pt.ID.Name]);
                a.PatientID = GetInt(reader[pt.PatientID.Name]);
                a.WrittenDate = GetDateTime(reader[pt.WrittenDate.Name]);
                a.Notes = GetString(reader[pt.Notes.Name]);
                result.Add(a);
            }
            reader.Close();
            reader.Dispose();
            return result;

        }

        public List<MedicalNotes> GetMedicalNotes( int patientID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE).Where(b.IsEqual(Tables.MEDICALNOTES_TABLE.PatientID,patientID));
            return GetMedicalNotes(b);
        }

        public List<MedicalNotes> GetMedicalNotes()
        { 
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE);
            return GetMedicalNotes(b);
        }




    }
}
