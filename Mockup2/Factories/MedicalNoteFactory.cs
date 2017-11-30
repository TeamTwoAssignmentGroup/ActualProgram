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
    /// Helper class to pull whole MedicalNote objects from the database based on various critera.
    /// </summary>
    public class MedicalNoteFactory : AbstractFactory
    {
        public MedicalNoteFactory(DBConnection dbCon) : base(dbCon)
        {
        }
        
        /// <summary>
        /// Gets all <see cref="MedicalNotes"/> objects that match the given SQL query criteria contained in the <see cref="QueryBuilder"/>.
        /// </summary>
        /// <param name="b"><see cref="QueryBuilder"/> containing the SQL query.</param>
        /// <returns>A <see cref="List{MedicalNotes}"/>.</returns>
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
        /// Convenience method to get all <see cref="MedicalNotes"/> for a particular patient, keyed by their id.
        /// </summary>
        /// <param name="patientID">ID of the <see cref="Patient"/> to get <see cref="MedicalNotes"/> for.</param>
        /// <returns>A <see cref="List{MedicalNotes}"/> for the <see cref="Patient"/> given by ID.</returns>
        public List<MedicalNotes> GetMedicalNotes( int patientID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE).Where(b.IsEqual(Tables.MEDICALNOTES_TABLE.PatientID,patientID));
            return GetMedicalNotes(b);
        }

        /// <summary>
        /// Convenience method to get all the <see cref="MedicalNotes"/> in the database.
        /// </summary>
        /// <returns>A <see cref="List{MedicalNotes}"/> containing all <see cref="MedicalNotes"/> in the database.</returns>
        public List<MedicalNotes> GetMedicalNotes()
        { 
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE);
            return GetMedicalNotes(b);
        }

        /// <summary>
        /// Convenience method to insert a new <see cref="List{MedicalNotes}"/> objects into the database, linked to a <see cref="Patient"/>.
        /// </summary>
        /// <param name="o">The <see cref="Patient"/> to link the notes to.</param>
        /// <param name="notes">A <see cref="List{string}"/> that are the notes needing to be added. </param>
        public void InsertPatientNote(Patient o, List<string>notes)
        {
            List<MedicalNotes> getID = GetMedicalNotes(o.ID);
            MedicalNotes newEntry;
            QueryBuilder qb = new QueryBuilder();


            foreach (string s in notes)
            {
                newEntry = new MedicalNotes();
                newEntry.Notes = s;
                newEntry.PatientID = o.ID;
                newEntry.WrittenDate = DateTime.Now;




                qb.Insert(Tables.MEDICALNOTES_TABLE).Values
                    (null,
                    newEntry.PatientID,
                    newEntry.WrittenDate.ToString("yyyy-MM-dd"),
                    newEntry.Notes);


                MySqlCommand cmd = new MySqlCommand(qb.ToString(), dbCon.GetConnection());
                cmd.ExecuteNonQuery();
            }
        }

    }
}
