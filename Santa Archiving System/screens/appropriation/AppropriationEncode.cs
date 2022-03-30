using Santa_Archiving_System.models;
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
    public partial class AppropriationEncode : Form
    {
        Appropriation appropriation;
        public AppropriationEncode(Appropriation data)
        {
            this.appropriation = data;
            InitializeComponent();
        }

        private async Task LoadDataTable()
        {
            guna2DataGridView1.DataSource = await Appropriations.getList();
        }

        private async Task LoadDataTableOnline()
        {
            guna2DataGridView1.DataSource = await Appropriations.getListOnline();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Appropriation appropriation = new Appropriation();
            AddAppropriation addAppropriation = new AddAppropriation(appropriation);
            addAppropriation.ShowDialog();
        }

        private async void AppropriationEncode_Load(object sender, EventArgs e)
        {
            if (ControlsServices.CheckIfOnline())
            {
                loading1.Visible = true;
                try
                {
                    switch (appropriation.Reading)
                    {
                        case "PDF":
                            guna2DataGridView1.DataSource = await Appropriations.getPdfOnline(".pdf");
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
                switch (appropriation.Reading)
                {
                    case "PDF":
                        guna2DataGridView1.DataSource = await Appropriations.getPdf(".pdf");
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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
            {
                appropriation = new Appropriation()
                {
                    Id = int.Parse(item.Cells[0].Value.ToString()),
                    AppropriationNo = item.Cells[1].Value.ToString(),
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
            if (String.IsNullOrWhiteSpace(appropriation.Id.ToString()) || appropriation.Id == 0)
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
                        await Appropriations.DeleteAppropriation(appropriation.Id.ToString(), appropriation.AppropriationNo, appropriation.Series);
                        await Appropriations.DeleteAppropriationOnline(appropriation.Id.ToString());
                        MessageBox.Show("File Deleted");
                        await LoadDataTableOnline();
                        loading1.Visible = false;
                    }
                }
            }
        }
    }
}
