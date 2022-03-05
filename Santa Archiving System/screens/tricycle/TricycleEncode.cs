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

        private async Task LoadDataTable()
        {
            guna2DataGridView1.DataSource = await Tricycles.GetTricycleData();
        }

        private async void TricycleEncode_Load(object sender, EventArgs e)
        {
            await LoadDataTable();
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to import Data from cloud?", "Import", MessageBoxButtons.YesNo);
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
    }
}
