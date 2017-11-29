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
    /// Convenience class to handle returning, updating, and inserting Staff objects into the database.
    /// </summary>
    public class StaffFactory : AbstractFactory
    {
        private static int nextAvailableStaffID = 0;
        public StaffFactory(DBConnection dbCon) : base(dbCon)
        {
            GetLatestStaffID();
        }

        /// <summary>
        /// Removes the <see cref="Staff"/> member associated with the given Staff ID.
        /// </summary>
        /// <param name="id">An integer ID of the staff member to remove.</param>
        public void RemoveStaffByID(int id)
        {
            QueryBuilder b = new QueryBuilder();
            b.Delete(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.ID,id));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Sets the next available staff ID.
        /// </summary>
        private void GetLatestStaffID()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.ID).From(Tables.STAFF_TABLE).OrderBy(true, Tables.STAFF_TABLE.ID).Limit(1);
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            CustomTable ct = ctf.GetCustomTable(b);
            int id = GetInt(ct.GetRows()[0][Tables.STAFF_TABLE.ID]);
            if (id > nextAvailableStaffID)
            {
                nextAvailableStaffID = id;
            }
        }

        /// <summary>
        /// Gets the next available staff ID. Useful when you need to know the staff ID before pushing
        /// the staff object into the database, for example when you are adding a new staff member to both the
        /// staff table and the rota table. Otherwise, you would have to push the staff member
        /// into the staff table, then pull them out again to see which ID the database assigned them.
        /// </summary>
        /// <returns>An integer automatically set to be a valid staff ID that doesn't clash.</returns>
        public int GetNextAvailableStaffID()
        {
            return ++nextAvailableStaffID;
        }
        
        /// <summary>
        /// Gets a list of Staff by their ID number. This method should only return a list of size one, but
        /// that is not guranteed.
        /// </summary>
        /// <param name="id">ID of the staff member to look for.</param>
        /// <returns>A list of Staff.</returns>
        public List<Staff> GetStaffByID(int id)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.ID,id));
            return GetStaff(b);
        }
        
        /// <summary>
        /// Returns a list of Staff objects based on search critera given the QueryBuilder.
        /// </summary>
        /// <param name="b">QueryBuilder containing the SQL code.</param>
        /// <returns>A list of staff.</returns>
        public List<Staff> GetStaff(QueryBuilder b)
        {
            List<Staff> result = new List<Staff>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Staff p = new Staff();
                StaffTable pt = Tables.STAFF_TABLE;
                p.ID = GetInt(reader[pt.ID.Name]);
                p.FirstName = GetString(reader[pt.FirstName.Name]);
                p.LastName = GetString(reader[pt.LastName.Name]);
                p.JobRole = GetString(reader[pt.JobRole.Name]);
                p.Password = GetString(reader[pt.Password.Name]);
                p.Email = GetString(reader[pt.Email.Name]);
                p.Address = GetString(reader[pt.Address.Name]);
                p.Postcode = GetString(reader[pt.Postcode.Name]);
                result.Add(p);
            }
            reader.Close();
            reader.Dispose();
            return result;
        }
        
        /// <summary>
        /// Return a list of Staff members by their first and last name.
        /// </summary>
        /// <param name="firstName">First name to look for.</param>
        /// <param name="lastName">Last name to look for.</param>
        /// <returns>A list of Staff objects.</returns>
        public List<Staff> GetStaffByName(string firstName, string lastName)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.FirstName, firstName), b.And(), b.IsEqual(Tables.STAFF_TABLE.LastName, lastName));
            return GetStaff(b);
        }
        
        /// <summary>
        /// Convenience method to get all Staff members from the database.
        /// </summary>
        /// <returns>A list of all Staff</returns>
        public List<Staff> GetStaff()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE);
            return GetStaff(b);
        }




    }
}
//end               //end               //end               //end
