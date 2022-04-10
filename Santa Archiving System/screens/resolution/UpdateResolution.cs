using Santa_Archiving_System.models;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.resolution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.resolution
{
    public partial class UpdateResolution : Form
    {
        Resolution resolution;
        String path = "";
        string username;
        public UpdateResolution(Resolution data, string user)
        {
            this.username = user;
            this.resolution = data;
            InitializeComponent();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {

            ResoluionEncode resoluionEncode = (ResoluionEncode)Application.OpenForms["ResoluionEncode"];
            if (fileName.Text == string.Empty || resolutionNumber.Text == string.Empty || series.Text == string.Empty)
            {
                MessageBox.Show("Fill all required fields!");
                return;
            }
            else
            {
                loading1.Visible = true;
                if (ControlsServices.CheckIfOnline())
                {
                    await Resolutions.UpdateResolution(
                        resolution.Id.ToString(),
                    resolutionNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text, 
                    fileName.Text);

                    await Resolutions.UpdateResolutionOnline(
                        resolution.Id.ToString(),
                    resolutionNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text, 
                    fileName.Text);

                    await Resolutions.SaveResolutionHistory(
                       resolutionNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text,
                    resolution.Created,
                    DateTime.Now.ToLongDateString(),
                    username,
                    resolution.Type
                        );

                    MessageBox.Show("Successfully updated!");
                    this.Close();
                    await resoluionEncode.LoadDataTableOnline();
                }
                loading1.Visible = false;
            }
        }

        private async void UpdateResolution_Load(object sender, EventArgs e)
        {
            ampm.SelectedIndex = 0;
            if (ControlsServices.CheckIfOnline())
            {
                path = await Resolutions.CreateNewFileOnline(resolution.Id.ToString(), resolution.Type);
            }
            else
            {
                path = await Resolutions.CreateNewFile(resolution.Id.ToString(), resolution.Type);
            }
            fileName.Text = path;
            string[] subs = resolution.Time.Split(' ');
            resolutionNumber.Text = resolution.ResolutionNo;
            series.Text = resolution.Series;
            date.Text = resolution.Date;
            time.Text = subs[0];
            title.Text = resolution.Title;
            author.Text = resolution.Author;
            tag.Text = resolution.Tag;
            reading_cb.Text = resolution.Reading;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }

     
    }
}
