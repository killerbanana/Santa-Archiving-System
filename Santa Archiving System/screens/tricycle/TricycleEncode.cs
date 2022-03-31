using Santa_Archiving_System.models;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.tricycle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.tricycle
{
    public partial class TricycleEncode : Form
    {
        public TricycleEncode()
        {
            InitializeComponent();
        }

        Tricycle tricycle;

        private async Task LoadDataTable()
        {
            guna2DataGridView1.DataSource = await Tricycles.GetTricycleData();
        }

        private async Task LoadDataTableOnline()
        {
            guna2DataGridView1.DataSource = await Tricycles.GetTricycleDataOnline();
        }

        private async void TricycleEncode_Load(object sender, EventArgs e)
        {
            loading1.Visible = true;
            if (ControlsServices.CheckIfOnline())
            {
                await LoadDataTableOnline();
                loading1.Visible = false;
                return;
            }
            await LoadDataTable();
            loading1.Visible = false;
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to download backup from cloud? This process make up some time.", "Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await Tricycles.ImportTricyData();
                await LoadDataTable();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddFranchise addFranchise = new AddFranchise();
            addFranchise.ShowDialog();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
            {
                tricycle = new Tricycle()
                {
                    Id = int.Parse(item.Cells[0].Value.ToString()),
                    Name = item.Cells[1].Value.ToString(),
                    Barangay = item.Cells[2].Value.ToString(),
                    CStatus = item.Cells[3].Value.ToString(),
                    Reason = item.Cells[4].Value.ToString(),
                    Make = item.Cells[5].Value.ToString(),
                    Motor = item.Cells[6].Value.ToString(),
                    Chassis = item.Cells[7].Value.ToString(),
                    Plate = item.Cells[8].Value.ToString(),
                    Units = item.Cells[9].Value.ToString(),
                    Franchise = item.Cells[10].Value.ToString(),
                    TaxCert = item.Cells[11].Value.ToString(),
                    OR = item.Cells[12].Value.ToString(),
                    Date = item.Cells[13].Value.ToString(),
                    Status = item.Cells[14].Value.ToString()
                };
            }
            
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to execute a backup? This process make up some time.", "Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await Tricycles.ExportTricyData();
                await LoadDataTable();
            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tricycle.Id.ToString()) || tricycle.Id == 0)
            {
                MessageBox.Show("Select File to Delete");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this Data?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ControlsServices.CheckIfOnline())
                    {
                        loading1.Visible = true;
                        await Tricycles.DeletTricyData(tricycle.Id.ToString());
                        await Tricycles.DeletTricyDataOnline(tricycle.Id.ToString());
                        MessageBox.Show("File Deleted");
                        loading1.Visible = false;
                        await LoadDataTableOnline();
                    }
                }
            }
        }
    }
}
