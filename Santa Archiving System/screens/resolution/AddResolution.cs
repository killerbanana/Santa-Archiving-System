using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.resolution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.resolution
{
    public partial class AddResolution : Form
    {
        Resolution resolution;
        public AddResolution(Resolution data)
        {
            this.resolution = data;
            InitializeComponent();
        }
    
        

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            if (fileName.Text == string.Empty || resolutionNumber.Text == string.Empty || series.Text == string.Empty)
            {
                MessageBox.Show("Fill all required fields!");
                return;
            }
            loading1.Visible = true;
            if (ControlsServices.CheckIfOnline())
            {
                await Resolutions.SaveResolutionData(
                    resolutionNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);

                await Resolutions.SaveResolutionDataOnline(
                    resolutionNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);
            }
            else {
                await Resolutions.SaveResolutionData(
                    resolutionNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);
            }
                

            loading1.Visible = false;
            MessageBox.Show("Successfully Added");
        }

        private void AddResolution_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }

      
    }
}
