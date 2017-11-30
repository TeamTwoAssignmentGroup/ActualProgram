using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mockup2.Factories;
using Mockup2.DatabaseClasses;
using MySql.Data.MySqlClient;

namespace Mockup2
{
    public partial class UpdateStaff : Form
    {
        DBConnection dbCon;
        QueryBuilder b;

        object[] m_pass;
        object[] m_staffName;
        int m_staffID;

        public object[] Pass
        {
            get
            {
                return m_pass;
            }
            set
            {
                m_pass = value;
            }
        }
        public object[] StaffName
        {
            get
            {
                return m_staffName;
            }
            set
            {
                m_staffName = value;
            }
        }
        public int StaffID
        {
            get
            {
                return m_staffID;
            }
            set
            {
                m_staffID = value;
            }
        }

        public UpdateStaff(DBConnection dbCon, object[] pass, object[] staffName, int staffID)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            Pass = pass;
            StaffName = staffName;
            StaffID = staffID;
            UpdateRotaDays();
            this.Text = "Update Staff Details";
        }
        private void UpdateRotaDays()
        {
            int i, j;
            Console.WriteLine("var  " + StaffID.ToString() + '\t' + StaffName[0].ToString() + '\t' + StaffName[1].ToString());
            dataGridView1.Rows.Add(StaffID, StaffName[0], StaffName[1]);
            for (i = 1, j = 0; i < 14; i += 2, j++)
            {
                chkLDays.SetItemChecked(j, Convert.ToBoolean(Pass[i]));
            }
        }

        private void updateStaff_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            UpdateRotaDays();
        }

        private void populateUpdateStaff()
        { 
            CustomTableFactory ctf = new CustomTableFactory(dbCon);
            b = new QueryBuilder();
            b.Select(Tables.STAFF_TABLE.ID, Tables.STAFF_TABLE.FirstName, Tables.STAFF_TABLE.LastName).From(Tables.STAFF_TABLE);

            CustomTable ct = ctf.GetCustomTable(b);

            foreach (var row in ct.GetRows())
            {
                foreach (var value in row.Values)
                {

                    //Console.Write(value + " | ");
                }
                dataGridView1.Rows.Add(row.Values.ToArray());
                Console.WriteLine();
            }
        }

        private void SaveRota()
        {
            for (int i = 1, j = 0; i < 14; i += 2, j++)
            {
                Pass[i] = Convert.ToInt32(chkLDays.GetItemChecked(j));
                b = new QueryBuilder();
            }
            Console.WriteLine(b.Update(Tables.ROTA_TABLE).Set(Pass).Where(b.IsEqual(Tables.ROTA_TABLE.StaffID, StaffID)));
            b.Update(Tables.ROTA_TABLE).Set(Pass).Where(b.IsEqual(Tables.ROTA_TABLE.StaffID, StaffID));
            MySqlCommand cmd = new MySqlCommand(b.ToString(), dbCon.GetConnection());
            cmd.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveRota();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
