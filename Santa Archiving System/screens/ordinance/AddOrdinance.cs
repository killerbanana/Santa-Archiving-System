using Santa_Archiving_System.common;
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
    public partial class AddOrdinance : Form
    {
        Ordinance ordinane;
        public AddOrdinance(Ordinance data)
        {
            this.ordinane = data;
            InitializeComponent();
        }


        private async void btn_add_Click(object sender, EventArgs e)
        {
            OrdinaceEncode ordiEncode = (OrdinaceEncode)Application.OpenForms["OrdinaceEncode"];
            if (fileName.Text == string.Empty || ordinanceNumber.Text == string.Empty || series.Text == string.Empty)
            {
                MessageBox.Show("Fill all required fields!");
                return;
            }
            loading1.Visible = true;
            if (ControlsServices.CheckIfOnline())
            {
                await Ordinances.SaveOrdinanceData(
                    ordinanceNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);
                await Ordinances.SaveOrdinanceDataOnline(
                    ordinanceNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);
                loading1.Visible = false;
                MessageBox.Show("Successfully Added");
                this.Close();
                await ordiEncode.LoadDataTableOnline();
            }
            else {
                await Ordinances.SaveOrdinanceData(
                    ordinanceNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);
                loading1.Visible = false;
                MessageBox.Show("Successfully Added");
                this.Close();
                await ordiEncode.LoadDataTable();
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }

        private void AddOrdinance_Load(object sender, EventArgs e)
        {
            reading_cb.SelectedIndex = 0;
        }
    }
}
