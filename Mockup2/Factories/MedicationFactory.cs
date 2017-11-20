
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
    class MedicationFactory:AbstractFactory
    {


        public MedicationFactory(DBConnection dbCon) : base(dbCon)
        {
        }






        /// <summary>
        /// returns a medication id from the database by name
        /// </summary>
        /// <param name = "scientificName" ></ param >
        /// < returns ></ returns >
       private int md(QueryBuilder b)
        {

            int i = 0;
           
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                MedicationTable medicaiontb = Tables.MEDICATION_TABLE;
                Medication med = new Medication();

                med.ID = GetInt(reader[medicaiontb.ID.Name]);
                med.CommercialName = GetString(reader[medicaiontb.CommercialName.Name]);
                med.ScientificName = GetString(reader[medicaiontb.ScientificName.Name]);
                med.Manufacturer = GetString(reader[medicaiontb.Manufacturer.Name]);
                i = med.ID;
            }
            reader.Close();
            reader.Dispose();

            return i;


        }

        public int getMedicationID(string scientificName)
        {
            QueryBuilder qb = new QueryBuilder();
            qb.Select(Tables.ALL).From(Tables.MEDICATION_TABLE).Where(qb.IsEqual(Tables.MEDICATION_TABLE.ScientificName, scientificName));

            return md(qb);
        }


    }
}
