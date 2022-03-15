using Santa_Archiving_System.models;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.ordinance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.ordinance
{
    public partial class OrdinaceEncode : Form
    {
        Ordinance ordinance;
        public OrdinaceEncode(Ordinance data)
        {
            this.ordinance = data;
            InitializeComponent();
        }

        private async Task LoadDataTable()
        {
            guna2DataGridView1.DataSource = await Ordinances.getListOrdinance();
        }

        private async Task LoadDataTableOnline()
        {
            guna2DataGridView1.DataSource = await Ordinances.getListOrdinanceOnline();
        }
        private async Task LoadDataTableReading(string reading)
        {
            guna2DataGridView1.DataSource = await Ordinances.getReading(reading);
        }
        private async Task LoadDataTableReadingOnline(string reading)
        {
            guna2DataGridView1.DataSource = await Ordinances.getReadingOnline(reading);
        }

        private async void OrdinaceEncode_Load(object sender, EventArgs e)
        {
            if (ControlsServices.CheckIfOnline())
            {
                loading1.Visible = true;
                try
                {
                    switch (ordinance.Reading)
                    {
                        case "First Reading":
                            await LoadDataTableReadingOnline("1st Reading");
                            break;
                        case "Second Reading":
                            await LoadDataTableReadingOnline("2nd Reading");
                            break;
                        case "Third Reading":
                            await LoadDataTableReadingOnline("3rd Reading");
                            break;
                        case "PDF":

                            break;
                        default:
                            await LoadDataTableOnline();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                loading1.Visible = false;
                return;
            }
            loading1.Visible = true;
            try
            {
                switch (ordinance.Reading)
                {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            loading1.Visible = false;

        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to download backup from cloud? This process make up some time.", "Download", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;
                await Ordinances.ImportOrdinances();
                await LoadDataTable();
                loading1.Visible = false;
            }
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to execute a backup? This process may take up some time.", "Upload", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;
                await Ordinances.ExportOrdinances();
                await LoadDataTable();
                loading1.Visible = false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddOrdinance addOrdinance = new AddOrdinance(ordinance);
            addOrdinance.ShowDialog();
        }

     
    }
}
