using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Mockup2
{
    class PatientFactory
    {
        DBConnection con;
        public PatientFactory(DBConnection con)
        {
            this.con = con;
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

        public List<Patient> GetPatientsByName(string firstName,string lastName)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.FirstName,firstName),b.And(),b.IsEqual(Tables.PATIENT_TABLE.LastName,lastName));
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







        public Patient getAPatient(string s1 , string s2)
        {
            QueryBuilder q = new QueryBuilder();
            q.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(q.IsEqual(Tables.PATIENT_TABLE.FirstName, s1), q.And(), q.IsEqual(Tables.PATIENT_TABLE.LastName, s2));

            return getPatient(s1,s2,q);
        }




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
