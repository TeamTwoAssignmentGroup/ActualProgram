using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addStaffButton_Click(object sender, EventArgs e)
        {
            new EditStaffForm().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MessagePatientForm().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ResetPasswordForm().Show();
        }

        private void editStaffButton_Click(object sender, EventArgs e)
        {
            new EditStaffForm().Show();        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
