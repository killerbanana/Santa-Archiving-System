using Santa_Archiving_System.common;
using Santa_Archiving_System.services.resolution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.resolution
{
    public partial class ResoluionEncode : Form
    {
        public ResoluionEncode()
        {
            InitializeComponent();
        }

        private async void ResoluionEncode_Load(object sender, EventArgs e)
        {
            loading.Visible = true;
            guna2DataGridView1.DataSource = await Resolutions.getList();
            loading.Visible = false;
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            await Resolutions.ImportResolutions();
        }
    }
}
