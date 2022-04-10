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
    public partial class UpdateAppropriation : Form
    {
        Appropriation appropriation;
        string username;
        String path = "";
        public UpdateAppropriation(Appropriation data, string username)
        {
            this.username = username;
            this.appropriation = data;
            InitializeComponent();
        }

        private async void btn_add_Click(object sender, EventArgs e)
        {
            AppropriationEncode ordiEncode = (AppropriationEncode)Application.OpenForms["AppropriationEncode"];
            if (fileName.Text == string.Empty || appropriationNumber.Text == string.Empty || series.Text == string.Empty)
            {
                MessageBox.Show("Fill all required fields!");
                return;
            }
            else
            {
                loading1.Visible = true;
                if (ControlsServices.CheckIfOnline())
                {
                    await Appropriations.UpdateAppropriation(
                        appropriation.Id.ToString(),
                    appropriationNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text,
                    fileName.Text);

                    await Appropriations.SaveAppropriationDataOnlineHistory(
                        appropriationNumber.Text,
                    series.Text,
                    date.Text,
                    title.Text,
                    author.Text,
                    time.Text,
                    ampm.Text,
                    tag.Text,
                    reading_cb.Text,
                    appropriation.Created,
                    DateTime.Now.ToLongDateString(),
                    username,
                    appropriation.Type
                        );

                    await Appropriations.UpdateAppropriationOnline(
                        appropriation.Id.ToString(),
                    appropriationNumber.Text,
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

        private async void UpdateAppropriation_Load(object sender, EventArgs e)
        {
           // MessageBox.Show(account);
            ampm.SelectedIndex = 0;
            if (ControlsServices.CheckIfOnline())
            {
                loading1.Visible = true;
                path = await Appropriations.CreateNewFileOnline(appropriation.Id.ToString(), appropriation.Type);
            }
            else
            {
                loading1.Visible = true;
                path = await Appropriations.CreateNewFile(appropriation.Id.ToString(), appropriation.Type);
            }
            fileName.Text = path;
            string[] subs = appropriation.Time.Split(' ');
            appropriationNumber.Text = appropriation.AppropriationNo;
            series.Text = appropriation.Series;
            date.Text = appropriation.Date;
            time.Text = subs[0];
            title.Text = appropriation.Title;
            author.Text = appropriation.Author;
            tag.Text = appropriation.Tag;
            reading_cb.Text = appropriation.Reading;
            loading1.Visible = false;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            var filename = ControlsServices.OpenFileDialog();
            fileName.Text = filename;
        }
    }
}
