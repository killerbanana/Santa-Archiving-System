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
            AddAppropriation addAppropriation = new AddAppropriation();
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
    }
}
