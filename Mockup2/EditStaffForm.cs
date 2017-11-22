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

namespace Mockup2
{
    public partial class EditStaffForm : Form
    {
        DBConnection dbCon;
        QueryBuilder b;
        int m_staffID;

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

        public EditStaffForm(DBConnection dbCon, int staffID)
        {
            InitializeComponent();
            this.dbCon = dbCon;
            StaffID = staffID;
        }

        private void populateEditInfomation()
        {
            //Query

            textBox2.Text = "lel";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void EditStaffForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
