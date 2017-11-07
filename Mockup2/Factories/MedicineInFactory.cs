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

            public List<MedicationInstance> GetMedication(QueryBuilder b)
            {
                MedicationInstance a = new MedicationInstance();
                List<MedicationInstance> result = new List<MedicationInstance>();
                MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                try
                {
                    Mockup2.Tables.MedicationInstanceTable pt = Tables.MEDICATIONINSTANCE_TABLE;
                    a.Id = GetInt(reader[pt.ID.Name]);
                    a.MedicationId = GetInt(reader[pt.MedicationID.Name]);
                    a.PrescriptionId = GetInt(reader[pt.PrescriptionID.Name]);
                    a.Instruction = GetString(reader[pt.Instructions.Name]);
                }
                catch (Exception e) { }
                }
                reader.Close();
                reader.Dispose();
                return result;

            }

            public List<MedicationInstance> GetMedicnePatient(int patientID)
            {
                QueryBuilder b = new QueryBuilder();
                b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE).Where(b.IsEqual(Tables.MEDICALNOTES_TABLE.PatientID, patientID));
                return GetMedication(b);
            }

            public List<MedicationInstance> GetAllMedicine()
            {
                QueryBuilder b = new QueryBuilder();
                b.Select(Tables.ALL).From(Tables.MEDICALNOTES_TABLE);
                return GetMedication(b);
            }




        }
    }
