using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mockup2.DatabaseClasses;
using MySql.Data.MySqlClient;

namespace Mockup2.Factories
{
    /// <summary>
    /// Convenience class for inserting a member of <see cref="Staff"/> into the Rota table, defaulting all work days to 0 (off).
    /// </summary>
    public class RotaFactory : AbstractFactory
    {
        /// <summary>
        /// Sets base dbCon
        /// </summary>
        /// <param name="dbCon"></param>
        public RotaFactory(DBConnection dbCon) : base(dbCon)
        {
        }

        /// <summary>
        /// Inserts the <see cref="Staff"/> member into the Rota table, defaulting all days to 0 (entire week off).
        /// </summary>
        /// <param name="staff">The <see cref="Staff"/> member to insert.</param>
        public void InsertStaff(Staff staff)
        {
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.ROTA_TABLE).Values(null, staff.ID, 0, 0, 0, 0, 0, 0, 0);
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
