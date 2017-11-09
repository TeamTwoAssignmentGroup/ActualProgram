using Mockup2.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mockup2.Tables;

namespace Mockup2
{
    public partial class SeeStaffListForm : Form
    {
        DateTime date;
        DBConnection dbCon;
        List<Dictionary<Column, object>> rotaRows;
        public SeeStaffListForm(DateTime date, DBConnection dbCon)
        {
            InitializeComponent();
            this.date = date;
            this.dbCon = dbCon;

            PopulateRotaRows();
            DisplayRotaRows();
        }

        private void PopulateRotaRows()
        {
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            QueryBuilder b = new QueryBuilder();
            Column dayColumn = GetDayColumnForDay(date.DayOfWeek);
            b.Select(Tables.STAFF_TABLE.ID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName, Tables.STAFF_TABLE.JobRole).From(Tables.STAFF_TABLE, Tables.ROTA_TABLE).Where(
                b.IsEqual(Tables.STAFF_TABLE.ID,Tables.ROTA_TABLE.StaffID),b.And(),b.IsEqual(dayColumn,1)
                );
            CustomTable ct = ctf.GetCustomTable(b);
            rotaRows = ct.GetRows();
        }

        private void DisplayRotaRows()
        {
            foreach(var row in rotaRows)
            {
                dataGridView1.Rows.Add(row.Values.ToArray());
            }
        }

        private Column GetDayColumnForDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:return Tables.ROTA_TABLE.Mon;
                case DayOfWeek.Tuesday: return Tables.ROTA_TABLE.Tue;
                case DayOfWeek.Wednesday: return Tables.ROTA_TABLE.Wed;
                case DayOfWeek.Thursday: return Tables.ROTA_TABLE.Thur;
                case DayOfWeek.Friday: return Tables.ROTA_TABLE.Fri;
                case DayOfWeek.Saturday: return Tables.ROTA_TABLE.Sat;
                case DayOfWeek.Sunday: return Tables.ROTA_TABLE.Sun;
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeeStaffListForm_Load(object sender, EventArgs e)
        {
        }
    }
}
