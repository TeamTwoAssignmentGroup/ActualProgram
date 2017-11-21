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


    public class MedicineInFactory :AbstractFactory
    {

         DBConnection con;



            /// <summary>
            /// Class inherits from the Abstract Factory class
            /// </summary>
            /// <param name="dbCon"></param>
            public MedicineInFactory(DBConnection dbCon) : base(dbCon)
            {
            
            }



            /// <summary>
            /// This method returns a list of medications from the database
            /// Takes a querybuilder as arguement
            /// </summary>
            /// <param name="b"></param>
            /// <returns></returns>
            public List<MedicationInstance> GetMedicationID(QueryBuilder b)
            {
                MedicationInstance a = new MedicationInstance();
                List<MedicationInstance> result = new List<MedicationInstance>();
                MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                
                
                    Tables.MedicationInstanceTable pt = Tables.MEDICATIONINSTANCE_TABLE;
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




            /// <summary>
            /// This function returns a list of medication instances that belongs to a prescription
            /// This function only relevant from database connection and to assign a new prescription
            /// </summary>
            /// <param name="prescriptionId"></param>
            /// <returns></returns>
            public List<MedicationInstance> GetMedicineIdByPrescription(int prescriptionId)
            {
                QueryBuilder b = new QueryBuilder();
                b.Select(Tables.ALL).From(Tables.MEDICATIONINSTANCE_TABLE).Where(b.IsEqual(Tables.MEDICATIONINSTANCE_TABLE.PrescriptionID, prescriptionId));
                return GetMedicationID(b);
            }




        /// <summary>
        /// This method returns a list of medications when medication id entered
        /// </summary>
        /// <param name="medicineId"></param>
        /// <returns></returns>
        public List<Medication> GetMedicneNameById(int medicineId)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.MEDICATION_TABLE).Where(b.IsEqual(Tables.MEDICATION_TABLE.ID,medicineId));
            return GetMedicationName(b);
        }




        /// <summary>
        /// This method returns a medication list based on the query executed
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public List<Medication> GetMedicationName(QueryBuilder b)
        {
            Medication a = new Medication();
            List<Medication> result = new List<Medication>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                    
                
                    Tables.MedicationTable pt = Tables.MEDICATION_TABLE;
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




        /// <summary>
        /// This method returns all the medications which are available in the database
        /// </summary>
        /// <returns></returns>
        public List<Medication>  getAllMedication()
        {

            QueryBuilder qb = new QueryBuilder();
            qb.Select(Tables.ALL).From(Tables.MEDICATION_TABLE);
            return GetAllMedicationAvailable(qb);
        }



        //DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE
        /// <summary>
        /// This methos returns a list of medications 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public List<Medication> GetAllMedicationAvailable(QueryBuilder b)
        {
            Medication a = new Medication();
            List<Medication> result = new List<Medication>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {

                Medication med = new Medication();
                Tables.MedicationTable pt = Tables.MEDICATION_TABLE;
                med.ID = GetInt(reader[pt.ID.Name]);
                med.CommercialName = GetString(reader[pt.CommercialName.Name]);
                med.Manufacturer = GetString(reader[pt.Manufacturer.Name]);
                med.ScientificName = GetString(reader[pt.ScientificName.Name]);
                result.Add(med);

            }

            reader.Close();
            reader.Dispose();
            return result;

        }




        /// <summary>
        /// This mehtod creates a connection in the database between two tables by entering medication instance table data
        /// </summary>
        /// <param name="instance"></param>
        public void addmedicationInstance(MedicationInstance instance)
        {
 
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.MEDICATIONINSTANCE_TABLE).Values
                (
                null,
                instance.PrescriptionId,
                instance.MedicationId,               
                instance.Instruction
                
                );

                MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
                cmd.ExecuteNonQuery();

        }







    }
}
//end               //end               //end               //end               //end
