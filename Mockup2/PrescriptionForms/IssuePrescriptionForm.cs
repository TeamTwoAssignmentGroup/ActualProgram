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
    public partial class IssuePrescriptionForm : Form
    {
        public IssuePrescriptionForm()
        {
            InitializeComponent();
        }

        private void IssuePrescriptionForm_Load(object sender, EventArgs e)
        {
            // Sets the size of the form upon loading
            this.Size = new Size(600, 700);
            // Prevents the form from being re sized
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
