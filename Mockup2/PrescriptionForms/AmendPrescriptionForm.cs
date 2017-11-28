using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockup2.PrescriptionForms
{
    public partial class AmendPrescriptionForm : Form
    {
        public AmendPrescriptionForm()
        {
            InitializeComponent();
        }

        private void AmendPrescriptionForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
    }
}
