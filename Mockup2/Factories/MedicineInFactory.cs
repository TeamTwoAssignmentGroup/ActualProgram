using Mockup2.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Factories
{
    class MedicineInFactory :AbstractFactory
    {
        DBConnection con;
            public MedicineInFactory(DBConnection dbCon) : base(dbCon)
            {
            
        }

            public List<MedicationInstance> GetMedicationID(QueryBuilder b)
            {
                MedicationInstance a = new MedicationInstance();
                List<MedicationInstance> result = new List<MedicationInstance>();
                MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                
                
                   Mockup2.Tables.MedicationInstanceTable pt = Tables.MEDICATIONINSTANCE_TABLE;
                    a.Id = GetInt(reader[pt.ID.Name]);
                    a.MedicationId = GetInt(reader[pt.MedicationID.Name]);
                    a.PrescriptionId = GetInt(reader[pt.PrescriptionID.Name]);
                    a.Instruction = GetString(reader[pt.Instructions.Name]);
                    result.Add(a);

                }
              
                reader.Close();
                reader.Dispose();
                return result;

            }


        //prescription
            public List<MedicationInstance> GetMedicineIdByPrescription(int prescriptionId)
            {
                QueryBuilder b = new QueryBuilder();
                b.Select(Tables.ALL).From(Tables.MEDICATIONINSTANCE_TABLE).Where(b.IsEqual(Tables.MEDICATIONINSTANCE_TABLE.PrescriptionID, prescriptionId));
                return GetMedicationID(b);
            }



        public List<Medication> GetMedicneNameById(int medicineId)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICATION_TABLE).Where(b.IsEqual(Tables.MEDICATION_TABLE.ID,medicineId));
            return GetMedicationName(b);
        }



        public List<Medication> GetMedicationName(QueryBuilder b)
        {
            Medication a = new Medication();
            List<Medication> result = new List<Medication>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {


                Mockup2.Tables.MedicationTable pt = Tables.MEDICATION_TABLE;
                a.ID = GetInt(reader[pt.ID.Name]);
                a.CommercialName = GetString(reader[pt.CommercialName.Name]);
                a.Manufacturer = GetString(reader[pt.Manufacturer.Name]);
                a.ScientificName = GetString(reader[pt.ScientificName.Name]);
                result.Add(a);

            }

            reader.Close();
            reader.Dispose();
            return result;

        }





    }
    }
