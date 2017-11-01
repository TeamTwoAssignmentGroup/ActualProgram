using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2.Factories
{
    class StaffFactory
    {
        DBConnection dbCon;
        public StaffFactory(DBConnection dbCon)
        {
            this.dbCon = dbCon;
        }

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
                result.Add(p);
            }
            reader.Close();
            reader.Dispose();
            return result;
        }

        public List<Staff> GetStaffByName(string firstName, string lastName)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE).Where(b.IsEqual(Tables.STAFF_TABLE.FirstName, firstName), b.And(), b.IsEqual(Tables.STAFF_TABLE.LastName, lastName));
            return GetStaff(b);
        }

        public List<Staff> GetStaff()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.STAFF_TABLE);
            return GetStaff(b);
        }

        private int GetInt(object o)
        {
            return int.Parse(o + "");
        }

        private string GetString(object o)
        {
            return o + "";
        }
    }
}
