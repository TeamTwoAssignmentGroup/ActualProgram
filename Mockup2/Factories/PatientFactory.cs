using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mockup2
{
    public class PatientFactory
    {

        DBConnection con;

        public PatientFactory(DBConnection con)
        {

            this.con = con;

        }

        public void InsertPatient(Patient p)
        {
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.PATIENT_TABLE).Values(null,p.NHSNumber,p.FirstName,p.LastName,p.Address,p.Postcode,p.NextOfKin,p.DOB.ToString("yyyy-MM-dd"),p.Gender,p.Religion,p.Email,p.Phone);
            MySqlCommand cmd = new MySqlCommand(b.ToString(), con.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public void UpdatePatient(Patient p)
        {
            QueryBuilder b = new QueryBuilder();
            b.Update(Tables.PATIENT_TABLE).Set(
                Tables.PATIENT_TABLE.NHSNumber,p.NHSNumber,
                Tables.PATIENT_TABLE.FirstName,p.FirstName,
                Tables.PATIENT_TABLE.LastName,p.LastName,
                Tables.PATIENT_TABLE.Address,p.Address,
                Tables.PATIENT_TABLE.PostCode,p.Postcode,
                Tables.PATIENT_TABLE.NextOfKin,p.NextOfKin,
                Tables.PATIENT_TABLE.DOB,p.DOB.ToString("yyyy-MM-dd"),
                Tables.PATIENT_TABLE.Gender,p.Gender,
                Tables.PATIENT_TABLE.Religion,p.Religion,
                Tables.PATIENT_TABLE.Email,p.Email,
                Tables.PATIENT_TABLE.Phone,p.Phone
                ).Where(b.IsEqual(Tables.PATIENT_TABLE.ID,p.ID));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), con.GetConnection());
            cmd.ExecuteNonQuery();
        }
       

        public List<Patient> GetPatients(QueryBuilder b)
        {

            List<Patient> result = new List<Patient>();
            MySqlCommand query = new MySqlCommand(b.ToString(), con.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Patient p = new Patient();
                Mockup2.Tables.PatientTable pt = Tables.PATIENT_TABLE;
                p.ID = GetInt(reader[pt.ID.Name]);
                p.NHSNumber = GetString(reader[pt.NHSNumber.Name]);
                p.FirstName = GetString(reader[pt.FirstName.Name]);
                p.LastName = GetString(reader[pt.LastName.Name]);
                p.Address = GetString(reader[pt.Address.Name]);
                p.Postcode = GetString(reader[pt.PostCode.Name]);
                p.NextOfKin = GetString(reader[pt.NextOfKin.Name]);
                DateTime temp;
                DateTime.TryParse(GetString(reader[pt.DOB.Name]),out temp);
                p.DOB = temp;
                p.Gender = GetString(reader[pt.Gender.Name]);
                p.Religion = GetString(reader[pt.Religion.Name]);
                p.Email = GetString(reader[pt.Email.Name]);
                p.Phone = GetString(reader[pt.Phone.Name]);
                result.Add(p);
            }

            reader.Close();
            reader.Dispose();
            return result;

        }

        public void DeletePatient(Patient p)
        {
            QueryBuilder b = new QueryBuilder();
            b.Delete(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.ID, p.ID));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), con.GetConnection());
            cmd.ExecuteNonQuery();
        }



        public List<Patient> GetPatientsByName(string firstName,string lastName)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.FirstName,firstName),b.And(),b.IsEqual(Tables.PATIENT_TABLE.LastName, lastName));
            return GetPatients(b);
        }




        public List<Patient> GetPatients()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE);
            return GetPatients(b);
        }




        private int GetInt(object o)
        {
            return int.Parse(o+"");
        }




        private string GetString(object o)
        {
            return o + "";
        }


        /**
         * returns a patient object by finding it in the database by first and last name
         * */
        public Patient getAPatient(string firstName , string lastName)
        {
            QueryBuilder q = new QueryBuilder();
            q.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(q.IsEqual(Tables.PATIENT_TABLE.FirstName, firstName), q.And(), q.IsEqual(Tables.PATIENT_TABLE.LastName, lastName));

            return getPatient(firstName,lastName,q);
        }



        /**
         * Executes query in the database to return details to getAPatient() method
         * */
        public Patient getPatient(string firstName,string lastName,QueryBuilder qb)
        {
            DBConnection connect;
            connect = this.con;

            Patient result = new Patient();
            MySqlCommand query = new MySqlCommand(qb.ToString(), connect.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();
          
           while (reader.Read())
                   {
                   
                    Prescription a = new Prescription();
                 
                    Patient p = new Patient();
                    Mockup2.Tables.PatientTable pt = Tables.PATIENT_TABLE;
                    p.ID = GetInt(reader[pt.ID.Name]);
                    p.NHSNumber = GetString(reader[pt.NHSNumber.Name]);
                    p.FirstName = GetString(reader[pt.FirstName.Name]);
                    p.LastName = GetString(reader[pt.LastName.Name]);
                    p.Address = GetString(reader[pt.Address.Name]);
                    p.Postcode = GetString(reader[pt.PostCode.Name]);
                    p.NextOfKin = GetString(reader[pt.NextOfKin.Name]);
                    DateTime temp;
                    DateTime.TryParse(GetString(reader[pt.DOB.Name]), out temp);
                    p.DOB = temp;
                    p.Gender = GetString(reader[pt.Gender.Name]);
                    p.Religion = GetString(reader[pt.Religion.Name]);
                    p.Email = GetString(reader[pt.Email.Name]);
                    p.Phone = GetString(reader[pt.Phone.Name]);

                    result = p;                 
                  
             
            }
            reader.Close();
            reader.Dispose();
            return result;

        }



    }
}
