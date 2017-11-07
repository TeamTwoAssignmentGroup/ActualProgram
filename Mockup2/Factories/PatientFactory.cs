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
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.FirstName,firstName),b.And(),b.IsEqual(Tables.PATIENT_TABLE.LastName, lastName));
            return GetPatients(b);
        }


        public Patient GetPatientsByID(int ID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.ID, ID));
            return GetPatientByIdNumber(b);

        }




        public Patient GetPatientByIdNumber(QueryBuilder q)
        {
            
            
                DBConnection connect;
                connect = this.con;

                Patient result = new Patient();
                MySqlCommand query = new MySqlCommand(q.ToString(), connect.GetConnection());
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
