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
                            guna2DataGridView1.DataSource = await Ordinances.getPdfOnline(".pdf");
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
                    case "PDF":
                        guna2DataGridView1.DataSource = await Ordinances.getPdf(".pdf");
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
                if (ControlsServices.CheckIfOnline())
                {
                    loading1.Visible = true;
                    await Ordinances.ImportOrdinances();
                    await LoadDataTable();
                    loading1.Visible = false;
                    await LoadDataTableOnline();
                }
                else
                {
                    MessageBox.Show("Error. Please Connect to Internet to complete the process.");
                }
            }
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to execute a backup? This process may take up some time.", "Upload", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ControlsServices.CheckIfOnline())
                {
                    loading1.Visible = true;
                    await Ordinances.ExportOrdinances();
                    await LoadDataTable();
                    loading1.Visible = false;
                    await LoadDataTableOnline();
                }
                else
                {
                    MessageBox.Show("Error. Please Connect to Internet to complete the process.");
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddOrdinance addOrdinance = new AddOrdinance(ordinance);
            addOrdinance.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(ordinance.Id.ToString()) || ordinance.Id == 0)
            {

            }
            else
            {
                UpdateOrdinance updateResolution = new UpdateOrdinance(ordinance);
                updateResolution.ShowDialog();
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
            {
                ordinance = new Ordinance()
                {
                    Id = int.Parse(item.Cells[0].Value.ToString()),
                    OrdinanceNo = item.Cells[1].Value.ToString(),
                    Series = item.Cells[2].Value.ToString(),
                    Date = item.Cells[5].Value.ToString(),
                    Title = item.Cells[3].Value.ToString(),
                    Author = item.Cells[4].Value.ToString(),
                    Time = item.Cells[6].Value.ToString(),
                    Type = item.Cells[7].Value.ToString(),
                    Tag = item.Cells[8].Value.ToString(),
                    Reading = item.Cells[10].Value.ToString(),
                };
            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(ordinance.Id.ToString()) || ordinance.Id == 0)
            {

            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this Data?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ControlsServices.CheckIfOnline())
                    {
                        loading1.Visible = true;
                        await Ordinances.DeleteOrdinance(ordinance.Id.ToString(), ordinance.OrdinanceNo, ordinance.Series);
                        await Ordinances.DeleteOrdinanceOnline(ordinance.Id.ToString());
                        MessageBox.Show("File Deleted");
                        loading1.Visible = false;
                    }
                }
            }
        }
    }
}
