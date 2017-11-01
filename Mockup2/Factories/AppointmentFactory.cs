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
            string date2String = date2.ToString("yyyy-MM-dd");
            b.Select(Tables.ALL).From(Tables.APPOINTMENT_TABLE).Where(b.IsMoreThanEqual(Tables.APPOINTMENT_TABLE.AppointmentDate, date1String), b.And(), b.IsLessThan(Tables.APPOINTMENT_TABLE.AppointmentDate, date2String));
            return GetAppointments(b);
        }
    }
}
