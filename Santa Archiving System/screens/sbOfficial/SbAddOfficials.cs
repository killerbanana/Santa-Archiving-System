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
                clb_committee.Visible = true;
                clb_committee.Items.Clear();

               
                await getCommittee();
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
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
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
               string.IsNullOrWhiteSpace(tb_lastName.Text) 
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
                        committeeList,
                        terms,
                        image
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
                         committeeList,
                         terms,
                         image
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
                         committeeList,
                         terms,
                         image
                         );
                }
                MessageBox.Show("Successfully created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                committeeList.Clear();
                tb_firstName.Text = String.Empty;
                tb_middleName.Text = String.Empty;
                tb_lastName.Text = String.Empty;
                cb_from.SelectedIndex = -1;
                cb_to.SelectedIndex = -1;
                image = string.Empty;

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
    }
}
