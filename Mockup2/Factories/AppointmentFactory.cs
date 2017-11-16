using Mockup2.Classes;
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
    public class AppointmentFactory : AbstractFactory
    {
        private static int nextAvailableAppointmentID;

        public AppointmentFactory(DBConnection dbCon) : base(dbCon)
        {
            SetNextAvailableAppointmentID();
        }

        /// <summary>
        /// Returns the next available appointment id. 
        /// </summary>
        /// <returns>Next available appointment id.</returns>
        private int GetNextAvailableAppointmentID()
        {
            return ++nextAvailableAppointmentID;
        }

        /// <summary>
        /// Sets the next available appointment id by pulling the last listed
        /// Appointment from the database. Should only be called once.
        /// </summary>
        private void SetNextAvailableAppointmentID()
        {
            if (nextAvailableAppointmentID <= 0)
            {
                QueryBuilder b = new QueryBuilder();
                b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE).OrderBy(true, Tables.APPOINTMENT_TABLE.ID).Limit(1);
                nextAvailableAppointmentID= GetAppointments(b)[0].Id;
            }
        }

        /// <summary>
        /// Returns a list of formatted strings to be used as timeslots when booking an appointment.
        /// Timeslot increment is given as 10 minutes.
        /// </summary>
        /// <returns>A list of strings formatted in the following way: hh:mm:ss, for example: 09:40:00</returns>
        public List<string> GetTimeslots()
        {
            List<string> result = new List<string>();
            for(int i = 9; i < 17; i++)
            {
                string s = "";
                if (i < 10)
                {
                    s = "0" + i+":";
                }
                else
                {
                    s = "" + i+":";
                }
                for(int j = 0; j < 60; j+=10)
                {
                    string s2 = s;
                    if (j < 10)
                    {
                        s2 += "0" + j+":00";
                    }
                    else
                    {
                        s2 += j+":00";
                    }
                    result.Add(s2);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a list of Appointments that match the critera given by the QueryBuilder.
        /// In order to get sensible results, the first part of the query should be:
        /// SELECT * FROM Appointment
        /// with only the Where changing.
        /// </summary>
        /// <param name="b">The QueryBuilder to use as the SQL query.</param>
        /// <returns>A list of Appointments that match the SQL query.</returns>
        public List<Appointment> GetAppointments(QueryBuilder b)
        {
            List<Appointment> result = new List<Appointment>();
            MySqlCommand query = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Appointment a = new Appointment();
                AppointmentTable pt = Tables.APPOINTMENT_TABLE;
                a.Id = GetInt(reader[pt.ID.Name]);
                a.StaffId = GetInt(reader[pt.StaffID.Name]);
                a.PatientId = GetInt(reader[pt.PatientID.Name]);
                a.AppointmentTime = GetDateTime(reader[pt.AppointmentTime.Name]);
                a.AppointmentDate = GetDateTime(reader[pt.AppointmentDate.Name]);
                a.Cause = GetString(reader[pt.Cause.Name]);
                a.Status = GetString(reader[pt.Status.Name]);
                result.Add(a);
            }
            reader.Close();
            reader.Dispose();
            return result;
        }

        /// <summary>
        /// Convenience method to return all appointments, with no matching criteria, ie everything.
        /// </summary>
        /// <returns>Every appointment in the database.</returns>
        public List<Appointment> GetAppointments()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE);
            return GetAppointments(b);
        }

        /// <summary>
        /// Conveience method that gets all appointments on a given date.
        /// </summary>
        /// <param name="date">The date to match appointments to.</param>
        /// <returns>A list of appointments booked for the date given.</returns>
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            DateTime date2 = date.AddDays(1);
            return GetAppointmentsByDateRange(date, date2);
        }

        /// <summary>
        /// Convenience method that gets all appointments booked between the given dates.
        /// </summary>
        /// <param name="date1">The minimum bound date to look for.</param>
        /// <param name="date2">The maximum bound date to look for.</param>
        /// <returns>A list of appointments that fall between the given dates.</returns>
        public List<Appointment> GetAppointmentsByDateRange(DateTime date1, DateTime date2)
        {
            QueryBuilder b = new QueryBuilder();
            string date1String = date1.ToString("yyyy-MM-dd");
            string date2String = date2.ToString("yyyy-MM-dd");
            b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE).Where(b.IsBetweenDate(Tables.APPOINTMENT_TABLE.AppointmentDate,date1,date2));
            return GetAppointments(b);
        }

        /// <summary>
        /// Updates an existing appointment in the database, based on the information provided
        /// in the Appointment object.
        /// </summary>
        /// <param name="a">The Appointment to pull data from.</param>
        public void UpdateAppointment(Appointment a)
        {
            QueryBuilder b = new QueryBuilder();
            b.Update(Tables.APPOINTMENT_TABLE).Set(
                Tables.APPOINTMENT_TABLE.StaffID, a.StaffId,
                Tables.APPOINTMENT_TABLE.PatientID, a.PatientId,
                Tables.APPOINTMENT_TABLE.AppointmentDate, a.AppointmentDate.ToString("yyyy-MM-dd"),
                Tables.APPOINTMENT_TABLE.AppointmentTime, a.AppointmentTime.ToString("HH:mm tt"),
                Tables.APPOINTMENT_TABLE.Cause, a.Cause,
                Tables.APPOINTMENT_TABLE.Status, a.Status
                ).Where(b.IsEqual(Tables.APPOINTMENT_TABLE.ID, a.Id));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
            SendConfirmationEmail(a);
        }

        /// <summary>
        /// Sends a confirmation email to the patient linked to the appointment given.
        /// </summary>
        /// <param name="a">The appointment to notify the patient abour.</param>
        private void SendConfirmationEmail(Appointment a)
        {
            StaffFactory sf = new StaffFactory(dbCon);
            PatientFactory pf = new PatientFactory(dbCon);
            Staff staff = sf.GetStaffByID(a.StaffId)[0];
            DateTime date = a.AppointmentDate;
            DateTime time = a.AppointmentTime;
            string email = pf.GetPatientsByID(a.PatientId)[0].Email;

            Emailer.SendAppointmentEmail(email, staff, date, time);
        }

        /// <summary>
        /// Inserts a new appointment into the database, using information pulled from the given Appointment object.
        /// 
        /// </summary>
        /// <param name="a">The appointment object to pull data from.</param>
        public void InsertAppointment(Appointment a)
        {
            a.Id = GetNextAvailableAppointmentID();
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.APPOINTMENT_TABLE).Values(a.Id, a.StaffId, a.PatientId, a.AppointmentDate.ToString("yyyy-MM-dd"), a.AppointmentTime.ToString("HH:mm tt"), a.Cause, a.Status);
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
            SendConfirmationEmail(a);
        }

        /// <summary>
        /// Deletes an appointment from the database based on information given in the supplied Appointment.
        /// </summary>
        /// <param name="a">The appointment object to delete.</param>
        public void DeleteAppointment(Appointment a)
        {
            QueryBuilder b = new QueryBuilder();
            b.Delete(Tables.APPOINTMENT_TABLE).Where(b.IsEqual(Tables.APPOINTMENT_TABLE.ID, a.Id));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
