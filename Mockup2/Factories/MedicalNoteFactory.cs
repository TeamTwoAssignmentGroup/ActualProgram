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
    /// Helper class to pull whole MedicalNote objects from the database based on various critera.
    /// </summary>
    class MedicalNoteFactory : AbstractFactory
    { 
        public MedicalNoteFactory(DBConnection dbCon) : base(dbCon)
        {
        }

        /// <summary>
        /// Gets all MedicalNote objects that match the given SQL query criteria contained in the QueryBuilder.
        /// </summary>
        /// <param name="b">QueryBuilder containing the SQL query.</param>
        /// <returns>A list of MedicalNote objects.</returns>
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

        /// <summary>
        /// Convenience method to get all MedicalNotes for a particular patient, keyed by their id.
        /// </summary>
        /// <param name="patientID">ID of the patient to get MedicalNotes for.</param>
        /// <returns>A list of MedicalNotes for the Patient given by id.</returns>
        public List<MedicalNotes> GetMedicalNotes( int patientID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE).Where(b.IsEqual(Tables.MEDICALNOTES_TABLE.PatientID,patientID));
            return GetMedicalNotes(b);
        }

        /// <summary>
        /// Convenience method to get all the MedicalNotes in the database.
        /// </summary>
        /// <returns>A list of all MedialNotes in the database.</returns>
        public List<MedicalNotes> GetMedicalNotes()
        { 
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE);
            return GetMedicalNotes(b);
        }

        /// <summary>
        /// Convenience method to insert a new MedicalNotes object into the database.
        /// </summary>
        /// <param name="mn">The MedicalNotes object to pull data from.</param>
        public void InsertMedicalNote(MedicalNotes mn)
        {
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.MEDICALNOTES_TABLE).Values(null, mn.PatientID, mn.WrittenDate.ToString("yyyy-MM-dd"), mn.Notes);
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }




    }
}
