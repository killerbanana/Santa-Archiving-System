using Santa_Archiving_System.models;
using Santa_Archiving_System.services.committee;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.Officials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.sbOfficial
{
    public partial class SbUpdateOfficials : Form
    {
        private List<String> committeeList = new List<String>();
        private string image;
        Sb updateOfficials;
        public SbUpdateOfficials(Sb data)
        {
            this.updateOfficials = data;
            InitializeComponent();
        }
        private async Task getCommittee()
        {
           
            loading1.Visible = true;

            if (ControlsServices.CheckIfOnline())
            {
                await Committee.getCommitteeOnline(updateOfficials.terms);
            }
            else
            {
                await Committee.getCommitteeOnline(updateOfficials.terms);
            }

            List<String> list = Committee.committeeList;

            list.ForEach(delegate (string s)
            {
                clb_committee.Items.Add(s);
             
            });

            if (clb_committee.Items.Count == 0)
            {
                clb_committee.Visible = false;
                lbl_info.Text = "No Datas to show";
            }
            else
            {
                clb_committee.Visible = true;
                clb_committee.HorizontalScrollbar = true;
            }
            for (int year = 2015; year <= DateTime.UtcNow.Year; ++year)
            {
                cb_from.Items.Add(year);
                cb_to.Items.Add(year);

            }
            tb_firstName.Text = updateOfficials.firstName;
            tb_middleName.Text = updateOfficials.middleName;
            tb_lastName.Text = updateOfficials.lastName;
            tb_suffix.Text = updateOfficials.suffix;
            tb_title.Text = updateOfficials.title;
            cb_position.Text = updateOfficials.position;
            cb_gender.Text = updateOfficials.gender;
            dt_birthday.Text = updateOfficials.birthday;
            tb_address.Text = updateOfficials.address;
            cb_rank.Text = updateOfficials.rank;
            pb_profile.Image = System.Drawing.Image.FromStream(updateOfficials.image);
            string str = updateOfficials.terms;
            List<String> subs = str.Split(' ').ToList();
            cb_from.Text = subs[0];
            cb_to.Text = subs[2];
           

            loading1.Visible = false;


        }
        private async void SbUpdateOfficials_Load(object sender, EventArgs e)
        {
           
            this.UseWaitCursor = true;
            try
            {
                await getCommittee();
                List<String> list = updateOfficials.committee;
                if (updateOfficials.committee != null)
                {
                    for (int i = 0; i < clb_committee.Items.Count; i++)
                    {
                      
                        list.ForEach(delegate (string s) {
                          
                            if (clb_committee.Items[i].ToString().Contains(s))
                            {
                               
                                clb_committee.SetItemChecked(i, true);

                            }

                        });
                    }


                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.UseWaitCursor = false;
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

        private async void btn_update_Click(object sender, EventArgs e)
        {
            string terms = cb_from.Text + " " + "-" + " " + cb_to.Text;
            try
            {
                foreach (var item in clb_committee.CheckedItems)
                {
                    committeeList.Add(item.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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
           
                    await Officials.UpdateOfficialsOnline
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
                        committeeList,
                        terms,
                        cb_rank.Text,
                        updateOfficials.Id
                        );
                    await Officials.UpdateOfficialsOffline
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
                        committeeList,
                        terms,
                        cb_rank.Text,
                        updateOfficials.Id         
                        );
                }
                else
                {
                    await Officials.UpdateOfficialsOffline
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
                        committeeList,
                        terms,
                        cb_rank.Text,
                        updateOfficials.Id
                          );
                }
                MessageBox.Show("Successfully updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                committeeList.Clear();
                updateOfficials.Id = string.Empty;
                updateOfficials.firstName = string.Empty;
                updateOfficials.middleName = string.Empty;
                updateOfficials.lastName = string.Empty;
                updateOfficials.suffix = string.Empty;
                updateOfficials.title = string.Empty;
                updateOfficials.committee.Clear();
                updateOfficials.position = string.Empty;
                updateOfficials.gender = string.Empty;
                updateOfficials.birthday = string.Empty;
                updateOfficials.address = string.Empty;
                updateOfficials.contactNo = string.Empty;
                updateOfficials.terms = string.Empty;
                updateOfficials.rank = string.Empty;
               
                SbOfficialEncode obj = (SbOfficialEncode)Application.OpenForms["SbOfficialEncode"];

                if (ControlsServices.CheckIfOnline())
                {
                    await obj.LoadDataTableOnline();

                }
                else
                {
                    await obj.LoadDataTableOffline();

                }

                this.Close();


                this.UseWaitCursor = false;
            }
        }

        private async void pb_profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Choose Image File";
            opf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            opf.Multiselect = false;
            try
            {
               
                if (opf.ShowDialog() == DialogResult.OK)
                {

                    image = opf.FileName;  
                    byte[] ImageData;
                    FileStream fs;
                    BinaryReader br;
                    fs = new FileStream(image, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);

                    byte[] img = (byte[])(ImageData);
                    MemoryStream mstream = new MemoryStream(img);
                    updateOfficials.image = mstream;

                  
                    this.UseWaitCursor = true;
         
                    if (ControlsServices.CheckIfOnline())
                    {

                        await Officials.UpdateProfilePicOnline
                            (
                            updateOfficials.Id,
                            updateOfficials.firstName,
                            updateOfficials.position,
                            updateOfficials.rank,
                            image
                            );
                        await Officials.UpdateProfilePicOffline
                          (
                          updateOfficials.Id,
                          updateOfficials.firstName,
                          updateOfficials.position,
                          updateOfficials.rank,
                          image
                          );

                    }
                    else
                    {
                        await Officials.UpdateProfilePicOffline
                           (
                           updateOfficials.Id,
                           updateOfficials.firstName,
                           updateOfficials.position,
                           updateOfficials.rank,
                           image
                           );
                    }

                    MessageBox.Show("Profile has been updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pb_profile.Image = System.Drawing.Image.FromStream(updateOfficials.image);
                    SbOfficialEncode obj = (SbOfficialEncode)Application.OpenForms["SbOfficialEncode"];

                    if (ControlsServices.CheckIfOnline())
                    {
                        await obj.LoadDataTableOnline();

                    }
                    else
                    {
                        await obj.LoadDataTableOffline();

                    }
                    this.UseWaitCursor = false;

                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cb_from_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
