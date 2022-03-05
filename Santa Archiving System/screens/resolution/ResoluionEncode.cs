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
        Resolution ord;
        public ResoluionEncode(Resolution data)
        {
            this.ord = data;
            InitializeComponent();
        }

        private async Task LoadDataTable() {
            guna2DataGridView1.DataSource = await Resolutions.getList();
        }

        private async Task LoadDataTableReading(string reading)
        {
            guna2DataGridView1.DataSource = await Resolutions.getReading(reading);
        }
        private async void ResoluionEncode_Load(object sender, EventArgs e)
        {
            loading1.Visible = true;
            try {
                switch (ord.Reading) {
                    case "First Reading":
                        await LoadDataTableReading("1st Reading");
                        break;
                    case "Second Reading":
                        await LoadDataTableReading("2nd Reading");
                        break;
                    case "Third Reading":
                        await LoadDataTableReading("3rd Reading");
                        break;
                    default:
                        await LoadDataTable();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            loading1.Visible = false;
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to download backup from cloud?", "Download", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;
                await Resolutions.ImportResolutions();
                await LoadDataTable();
                loading1.Visible = false;
            }
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to download backup from cloud? This process make up some time.", "Upload", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;
                await Resolutions.ExportData();
                await LoadDataTable();
                loading1.Visible = false;
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
            
            AddResolution addResolution = new AddResolution(ord);
            addResolution.ShowDialog();

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
            {

            }
         }
    }
}
