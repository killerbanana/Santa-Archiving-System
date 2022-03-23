using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.services.committee;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.Officials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.sbOfficial
{
    public partial class SbAddOfficials : Form
    {
        private List<String> committeeList = new List<String>();
        private string image;
        public SbAddOfficials()
        {

            InitializeComponent();
        }
        private async Task getCommittee()
        {
            string term = cb_from.Text + " " + "-" + " " + cb_to.Text;

            loading1.Visible = true;

            if (ControlsServices.CheckIfOnline())
            {
                await Committee.getCommitteeOnline(term);
            }
            else
            {
                await Committee.getCommitteeOffline(term);
            }

            loading1.Visible = false;


        }

        private async void enable()
        {
            if (cb_from.Text != string.Empty && cb_to.Text != string.Empty)
            {
                tb_firstName.Enabled = true;
                tb_middleName.Enabled = true;
                tb_suffix.Enabled = true;
                tb_lastName.Enabled = true;
                cb_gender.Enabled = true;
                dt_birthday.Enabled = true;
                tb_address.Enabled = true;
                tb_contactNo.Enabled = true;
                tb_title.Enabled = true;
                cb_position.Enabled = true;
                cb_rank.Enabled = true;

                await getCommittee();
            }
        }
        private async void disable()
        {
            if (cb_from.Text == string.Empty && cb_to.Text == string.Empty)
            {
                await getCommittee();
                tb_firstName.Enabled = false;
                tb_middleName.Enabled = false;
                tb_suffix.Enabled = false;
                tb_lastName.Enabled = false;
                cb_gender.Enabled = false;
                dt_birthday.Enabled = false;
                tb_address.Enabled = false;
                tb_contactNo.Enabled = false;
                tb_title.Enabled = false;
                cb_position.Enabled = false;
                cb_rank.Enabled = false;

            }
        }

        private void SbAddOfficials_Load(object sender, EventArgs e)
        {
            image = Constants.imagePath;
            for (int year = 2015; year <= DateTime.UtcNow.Year; ++year)
            {
                cb_from.Items.Add(year);
                cb_to.Items.Add(year);
            }

        }



        private void tb_firstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_firstName.Text))
            {
                lbl_firstName.Visible = true;
            }
            else
            {
                lbl_firstName.Visible = false;
            }
        }

        private void tb_middleName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_middleName.Text))
            {
                lbl_middleName.Visible = true;
            }
            else
            {
                lbl_middleName.Visible = false;
            }
        }

        private void tb_lastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_lastName.Text))
            {
                lbl_lastName.Visible = true;
            }
            else
            {
                lbl_lastName.Visible = false;
            }
        }

        private void cb_from_SelectedIndexChanged(object sender, EventArgs e)
        {

            enable();
        }

        private void cb_to_SelectedIndexChanged(object sender, EventArgs e)
        {

            enable();
        }

        private void pb_profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();

            opf.Title = "Choose Image File";
            opf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            opf.Multiselect = false;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pb_profile.Image = Image.FromFile(opf.FileName);
                    image = opf.FileName;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

        private async void btn_create_Click(object sender, EventArgs e)
        {
            string terms = cb_from.Text + " " + "-" + " " + cb_to.Text;

            if (string.IsNullOrWhiteSpace(tb_firstName.Text) ||
               string.IsNullOrWhiteSpace(tb_middleName.Text) ||
               string.IsNullOrWhiteSpace(tb_lastName.Text) ||
               lbl_rank.Visible == true
               )
            {
                MessageBox.Show("Please fill all required fields!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {


                this.UseWaitCursor = true;
                if (ControlsServices.CheckIfOnline())
                {
                    await Officials.SaveOfficialsOnline
                        (
                        tb_firstName.Text,
                        tb_middleName.Text,
                        tb_lastName.Text,
                        tb_suffix.Text,
                        tb_title.Text,
                        cb_position.Text,
                        cb_gender.Text,
                        dt_birthday.Text,
                        tb_address.Text,
                        tb_contactNo.Text,
                        terms,
                        image,
                        cb_rank.Text
                        );
                    await Officials.SaveOfficialsOffline
                         (
                         tb_firstName.Text,
                         tb_middleName.Text,
                         tb_lastName.Text,
                         tb_suffix.Text,
                         tb_title.Text,
                         cb_position.Text,
                         cb_gender.Text,
                         dt_birthday.Text,
                         tb_address.Text,
                         tb_contactNo.Text,
                         terms,
                         image,
                         cb_rank.Text
                         );
                }
                else
                {
                    await Officials.SaveOfficialsOffline
                         (
                         tb_firstName.Text,
                         tb_middleName.Text,
                         tb_lastName.Text,
                         tb_suffix.Text,
                         tb_title.Text,
                         cb_position.Text,
                         cb_gender.Text,
                         dt_birthday.Text,
                         tb_address.Text,
                         tb_contactNo.Text,
                         terms,
                         image,
                        cb_rank.Text
                         );
                }
                MessageBox.Show("Successfully created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pb_profile.Image = Image.FromFile(Constants.imagePath);
                tb_firstName.Text = String.Empty;
                tb_middleName.Text = String.Empty;
                tb_lastName.Text = String.Empty;
                tb_title.Text = String.Empty;
                tb_address.Text = String.Empty;
                tb_contactNo.Text = String.Empty;
                cb_from.SelectedIndex = -1;
                cb_to.SelectedIndex = -1;
                cb_position.SelectedIndex = 0;
                cb_rank.SelectedIndex = -1;
                image = Constants.imagePath;
                try
                {
                    disable();


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                SbOfficialEncode obj = (SbOfficialEncode)Application.OpenForms["SbOfficialEncode"];
                if (ControlsServices.CheckIfOnline())
                {
                    await obj.LoadDataTableOnline();
                    await obj.getBatch();
                }
                else
                {
                    await obj.LoadDataTableOffline();
                    await obj.getBatch();
                }
                this.UseWaitCursor = false;
            }
        }

        private void tb_contactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cb_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_position.SelectedIndex == 1)
            {
                cb_rank.Enabled = true;
                lbl_rank.Visible = true;
            }
            else
            {
                cb_rank.Enabled = false;
                lbl_rank.Visible = false;
            }

        }

        private void cb_rank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_rank.SelectedIndex >= 0)
            {
                lbl_rank.Visible = false;
            }
        }
    }
}
