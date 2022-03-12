using Santa_Archiving_System.screens.mainPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.auth
{
    public partial class UserSettings : Form
    {
        Thread th;
        MainPanel main = new MainPanel();
       
        public UserSettings()
        {
            InitializeComponent();
        }

        private void opennewform(object obj)
        {
            Application.Run(new Login());
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {

            MainPanel obj = (MainPanel)Application.OpenForms["MainPanel"];
            obj.Close(); //close application
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

           
        }
    }
}
