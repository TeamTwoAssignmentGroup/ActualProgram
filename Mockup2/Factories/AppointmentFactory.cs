using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mockup2.Tables;

namespace Mockup2.Factories
{
    class AppointmentFactory : AbstractFactory
    {
        //DBConnection dbCon;

        public AppointmentFactory(DBConnection dbCon) : base(dbCon)
        {
        }

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

        public List<Appointment> GetAppointments()
        {
            QueryBuilder b = new QueryBuilder();
            b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE);
            return GetAppointments(b);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            DateTime date2 = date.AddDays(1);
            return GetAppointmentsByDateRange(date, date2);
        }

        public List<Appointment> GetAppointmentsByDateRange(DateTime date1, DateTime date2)
        {
            QueryBuilder b = new QueryBuilder();
            string date1String = date1.ToString("yyyy-MM-dd");
            string date2String = date2.AddDays(1).ToString("yyyy-MM-dd");
            b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE).Where(b.IsMoreThanEqual(Tables.APPOINTMENT_TABLE.AppointmentDate, date1String), b.And(), b.IsLessThan(Tables.APPOINTMENT_TABLE.AppointmentDate, date2String));
            return GetAppointments(b);
        }

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
        }

        public void InsertAppointment(Appointment a)
        {
            QueryBuilder b = new QueryBuilder();
            b.Insert(Tables.APPOINTMENT_TABLE).Values(null, a.StaffId, a.PatientId, a.AppointmentDate.ToString("yyyy-MM-dd"), a.AppointmentTime.ToString("HH:mm tt"), a.Cause, a.Status);
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public void DeleteAppointment(Appointment a)
        {
            QueryBuilder b = new QueryBuilder();
            b.Delete(Tables.APPOINTMENT_TABLE).Where(b.IsEqual(Tables.APPOINTMENT_TABLE.ID, a.Id));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }
    }
}
