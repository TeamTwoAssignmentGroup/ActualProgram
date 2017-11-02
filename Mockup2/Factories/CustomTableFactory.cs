using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2.Factories
{
    class CustomTableFactory : AbstractFactory
    {
        public CustomTableFactory(DBConnection dbCon) : base(dbCon)
        {
        }

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
                    dic[c] = reader[c.Name];
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
