﻿using Mockup2.DatabaseClasses;
using Mockup2.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using static Mockup2.DatabaseClasses.Tables;

namespace Mockup2.Factories
{
    /// <summary>
    /// Convenience class to handle pulling Patients from, and inserting Patients into, the database. As well as updating them.
    /// </summary>
    public class PatientFactory : AbstractFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        public PatientFactory(DBConnection con) : base(con)
        {
        }

        /// <summary>
        /// Inserts the given <see cref="Mockup2.DatabaseClasses.Patient"/> information into the database.
        /// </summary>
        /// <param name="p">The <see cref="Mockup2.DatabaseClasses.Patient"/> to pull information from.</param>
        public void InsertPatient(Patient p)
        {
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.PATIENT_TABLE).Values(null,p.NHSNumber,p.FirstName,p.LastName,p.Address,p.Postcode,p.NextOfKin,p.DOB.ToString("yyyy-MM-dd"),p.Gender,p.Religion,p.Email,p.Phone);
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates the given <see cref="Mockup2.DatabaseClasses.Patient"/> information in the database.
        /// </summary>
        /// <param name="p">The <see cref="Mockup2.DatabaseClasses.Patient"/> to get updated information from.</param>
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
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Returns a list of <see cref="Mockup2.DatabaseClasses.Patient"/>s based on certain search criteria, provided
        /// by the QueryBuilder SQL code.
        /// </summary>
        /// <param name="b">QueryBuilder containing the SQL query to run.</param>
        /// <returns>A list of <see cref="Mockup2.DatabaseClasses.Patient"/> objects.</returns>
        public List<Patient> GetPatients(QueryBuilder b)
        {

            List<Patient> result = new List<Patient>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Patient p = new Patient();
                PatientTable pt = Tables.PATIENT_TABLE;
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

        /// <summary>
        /// Delete an entry from the Patient table in the database,
        /// based on information given by the <see cref="Mockup2.DatabaseClasses.Patient"/> object.
        /// </summary>
        /// <param name="p"><see cref="Mockup2.DatabaseClasses.Patient"/> representation of information to delete.</param>
        public void DeletePatient(Patient p)
        {
            QueryBuilder b = new QueryBuilder();
            b.Delete(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.ID, p.ID));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Conveience method to get all <see cref="Mockup2.DatabaseClasses.Patient"/>s by their first and last name.
        /// Most of the time, this method is expected to return a list containing
        /// only one value. However, this cannot be guranteed as name collisions
        /// cannot be prevented. Similarly, it shouln't be assumed this method will
        /// always return at least one entry - sometimes it doesn't, if the patient cannot be found.
        /// </summary>
        /// <param name="firstName">Patient's first name.</param>
        /// <param name="lastName">Patient's last name.</param>
        /// <returns>A list of <see cref="Mockup2.DatabaseClasses.Patient"/>s that have the first and last name provided. Size of the list may be more than 1, or 0.</returns>
        public List<Patient> GetPatientsByName(string firstName,string lastName)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.FirstName,firstName),b.And(),b.IsEqual(Tables.PATIENT_TABLE.LastName, lastName));
            return GetPatients(b);
        }

        /// <summary>
        /// Returns a <see cref="Mockup2.DatabaseClasses.Patient"/> by their Id number.
        /// </summary>
        /// <param name="ID">The ID to search for.</param>
        /// <returns>A list of <see cref="Mockup2.DatabaseClasses.Patient"/>s that match the ID. Should have a size of 1 almost always, but is a list just in case.</returns>
        public List<Patient> GetPatientsByID(int ID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.ID, ID));
            return GetPatients(b);

        }

        /// <summary>
        /// This method returns a singel patient object from the database by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Patient GetAPatientByID(int ID)
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE).Where(b.IsEqual(Tables.PATIENT_TABLE.ID, ID));
            return GetPatientByIdNumber(b);

        }

        /// <summary>
        /// This method returns a single patient from the database
        /// Takes a querybuilder
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public Patient GetPatientByIdNumber(QueryBuilder q)
        {
            
            
                DBConnection connect;
                connect = this.dbCon;

                Patient result = new Patient();
                MySqlCommand query = new MySqlCommand(q.ToString(), connect.GetConnection());
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {

                    Prescription a = new Prescription();
                    Patient p = new Patient();
                    PatientTable pt = Tables.PATIENT_TABLE;

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
        
        /// <summary>
        /// Convenience method to return all <see cref="Mockup2.DatabaseClasses.Patient"/>s currently stored in the database.
        /// </summary>
        /// <returns>A list of all <see cref="Mockup2.DatabaseClasses.Patient"/>s.</returns>
        public List<Patient> GetPatients()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.PATIENT_TABLE);
            return GetPatients(b);
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
            connect = this.dbCon;

            Patient result = new Patient();
            MySqlCommand query = new MySqlCommand(qb.ToString(), connect.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();
          
           while (reader.Read())
                   {
                   
                    Prescription a = new Prescription();
                 
                    Patient p = new Patient();
                    PatientTable pt = Tables.PATIENT_TABLE;
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
//end           //end               //end               //end
