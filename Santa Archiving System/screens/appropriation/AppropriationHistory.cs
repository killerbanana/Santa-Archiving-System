using Santa_Archiving_System.services.appropriation;
using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.appropriation
{
    public partial class AppropriationHistory : Form
    {
        public AppropriationHistory()
        {
            InitializeComponent();
        }

        private async void AppropriationHistory_Load(object sender, EventArgs e)
        {
            if (ControlsServices.CheckIfOnline())
            {
                loading1.Visible = true;
                guna2DataGridView1.DataSource = await Appropriations.getHistoryOnline();
                loading1.Visible = false;
            }
        }
    }
}
