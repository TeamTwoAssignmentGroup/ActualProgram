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

        public EditStaffForm(DBConnection dbCon)
        {
            InitializeComponent();
            this.dbCon = dbCon;
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
