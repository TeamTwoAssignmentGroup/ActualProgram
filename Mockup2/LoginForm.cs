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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object cbi = this.staffJobComboBox.SelectedItem;
            Console.Out.WriteLine("Object: " + cbi);
            switch (cbi)
            {
                case "Admin":AdminForm af = new AdminForm();
                    af.WindowState = FormWindowState.Maximized;
                    af.Show();
                    break;

                case "GP": GPNurse gpnf = new GPNurse();
                    gpnf.WindowState = FormWindowState.Maximized;
                    gpnf.Show();
                    break;

                case "Nurse": GPNurse gpnf2= new GPNurse();
                    gpnf2.WindowState = FormWindowState.Maximized;
                    gpnf2.Show();
                    break;

                case "Receptionist": ReceptionistForm rf = new ReceptionistForm();
                    rf.WindowState = FormWindowState.Maximized;
                    rf.Show();
                    break;
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
