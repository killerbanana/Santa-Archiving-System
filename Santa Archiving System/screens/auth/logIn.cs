using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Santa_Archiving_System.screens.mainPanel;

namespace Santa_Archiving_System.screens.auth
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainPanel mainPanel = new MainPanel();
            this.Hide();
            mainPanel.ShowDialog();
        }
    }
}
