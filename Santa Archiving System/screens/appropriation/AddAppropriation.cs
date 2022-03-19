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
    public partial class AddAppropriation : Form
    {
        public AddAppropriation()
        {
            InitializeComponent();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            
            if (fileName.Text == string.Empty || appropriationNumber.Text == string.Empty || series.Text == string.Empty)
            {
                MessageBox.Show("Fill all required fields!");
                return;
            }
            loading1.Visible = true;
            if (ControlsServices.CheckIfOnline())
            {
                await Appropriations.SaveAppropriationData(
                    appropriationNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);

                await Appropriations.SaveAppropriationDataOnline(
                    appropriationNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text);
            }
            else
            {
                await Appropriations.SaveAppropriationData(
                    appropriationNumber.Text,
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

        private void AddAppropriation_Load(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToString();
        }
    }
}
