using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
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

        private async Task LoadDataTable() {
            guna2DataGridView1.DataSource = await Resolutions.getList();
        }

        private async void ResoluionEncode_Load(object sender, EventArgs e)
        {
            loading.Visible = true;
            await LoadDataTable();
            loading.Visible = false;
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            loading.Visible = true;
            await Resolutions.ImportResolutions();
            await LoadDataTable();
            loading.Visible = false;
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to saave these Data to cloud?", "Export", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading.Visible = true;
                await Resolutions.ExportData();
                await LoadDataTable();
                loading.Visible = false;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {


            }
            else
            {
                (guna2DataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Resolution No] LIKE '%{0}%' OR [Series] LIKE '%{0}%'  OR [Date] LIKE '%{0}%' OR  [Title] LIKE '%{0}%'", guna2TextBox1.Text);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Ordinance data = new Ordinance();

            data.Reading = "First Reading";
            AddResolution addResolution = new AddResolution();
            addResolution.ShowDialog();

        }
    }
}
