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
    public partial class UpdateOrdinance : Form
    {
        Ordinance ordinance;
        String path = "";
        public UpdateOrdinance(Ordinance data)
        {
            this.ordinance = data;
            InitializeComponent();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            OrdinaceEncode ordiEncode = (OrdinaceEncode)Application.OpenForms["OrdinaceEncode"];
            if (fileName.Text == string.Empty || ordinanceNumber.Text == string.Empty || series.Text == string.Empty)
            {
                MessageBox.Show("Fill all required fields!");
                return;
            }
            else
            {
                loading1.Visible = true;
                if (ControlsServices.CheckIfOnline())
                {
                    await Ordinances.UpdateOrdinance(
                        ordinance.Id.ToString(),
                    ordinanceNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text,
                    fileName.Text);

                    await Ordinances.UpdateOrdinanceOnline(
                        ordinance.Id.ToString(),
                    ordinanceNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text,
                    fileName.Text);

                    MessageBox.Show("Successfully Updated");
                    this.Close();
                    await ordiEncode.LoadDataTableOnline();
                }
                loading1.Visible = false;
            }
        }

        private async void UpdateOrdinance_Load(object sender, EventArgs e)
        {
            ampm.SelectedIndex = 0;
            if (ControlsServices.CheckIfOnline())
            {
                loading1.Visible = true;
                path = await Ordinances.CreateNewFileOnline(ordinance.Id.ToString(), ordinance.Type);
            }
            else
            {
                loading1.Visible = true;
                path = await Ordinances.CreateNewFile(ordinance.Id.ToString(), ordinance.Type);
            }
            fileName.Text = path;
            string[] subs = ordinance.Time.Split(' ');
            ordinanceNumber.Text = ordinance.OrdinanceNo;
            series.Text = ordinance.Series;
            date.Text = ordinance.Date;
            time.Text = subs[0];
            title.Text = ordinance.Title;
            author.Text = ordinance.Author;
            tag.Text = ordinance.Tag;
            reading_cb.Text = ordinance.Reading;
            loading1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }

     
    }
}
