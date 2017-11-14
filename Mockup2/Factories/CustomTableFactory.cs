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
    class CustomTableFactory : AbstractFactory
    {
        public CustomTableFactory(DBConnection dbCon) : base(dbCon)
        {
        }

        /// <summary>
        /// Retrieves the stored query from the QueryBuilder and executes it against the database
        /// provided by the dbCon. The results are stored as a list of dictionary objects keyed to a Column.
        /// The value is an object. Each dictionary represents a row in table.
        /// </summary>
        /// <param name="b">The QueryBuilder object containing the SQL query to invoke against the database.</param>
        /// <returns>A CustomTable that has the resulting 'table' as a list of <code>Dictionary&lt;Column, object&gt;</code></returns>
        public CustomTable GetCustomTable(QueryBuilder b)
        {
            List<Dictionary<Column, object>> result = new List<Dictionary<Column, object>>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Dictionary<Column, object> dic = new Dictionary<Column, object>();
                foreach(Column c in b.GetSelectedColumns())
                {
                    dic[c] = reader[c.GetAs()];
                }
                result.Add(dic);
            }
            reader.Close();
            reader.Dispose();
            CustomTable ct = new CustomTable(result);
            return ct;
        }
    }
}
