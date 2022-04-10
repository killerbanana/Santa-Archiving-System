using Santa_Archiving_System.services.resolution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.resolution
{
    public partial class ResolutionHistory : Form
    {
        public ResolutionHistory()
        {
            InitializeComponent();
        }

        private async void ResolutionHistory_Load(object sender, EventArgs e)
        {
            loading1.Visible = true;
            guna2DataGridView1.DataSource = await Resolutions.getHistoryOnline();
            loading1.Visible = false;
        }
    }
}
