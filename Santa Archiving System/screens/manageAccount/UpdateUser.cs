using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.auth;
using Santa_Archiving_System.services.account;
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

namespace Santa_Archiving_System.screens.manageAccount
{
    public partial class UpdateUser : Form
    {

        updateAccount updateaccount;
        string username;
        public UpdateUser(updateAccount data)
        {

            this.updateaccount = data;
            InitializeComponent();
        }


        private void UpdateUser_Load(object sender, EventArgs e)
        {

            this.UseWaitCursor = true;
            try
            {
                if (updateaccount.privilege != null)
                {
                    List<String> list = updateaccount.privilege.ToList();

                    list.ForEach(delegate (string s) {

                        switch (s)
                        {
                            case "All Privilege":
                                clb_privilege.SetItemChecked(0, true);
                                clb_privilege.SetItemChecked(1, true);
                                clb_privilege.SetItemChecked(2, true);
                                clb_privilege.SetItemChecked(3, true);
                                clb_privilege.SetItemChecked(4, true);
                                clb_privilege.SetItemChecked(5, true);
                                break;
                            case "Appropriation":

                                clb_privilege.SetItemChecked(0, true);
                                break;
                            case "Legislative":
                                clb_privilege.SetItemChecked(1, true);
                                break;
                            case "Ordinance":
                                clb_privilege.SetItemChecked(2, true);
                                break;
                            case "SB Information":
                                clb_privilege.SetItemChecked(3, true);
                                break;
                            case "Tricycle":
                                clb_privilege.SetItemChecked(4, true);
                                break;
                            case "Account Management":
                                clb_privilege.SetItemChecked(5, true);
                                break;

                        }

                    });
                }

                lbl_name.Text = updateaccount.firstName + " " + updateaccount.middleName + " " + updateaccount.lastName;
                pb_profile.Image = System.Drawing.Image.FromStream(updateaccount.image);
                lbl_gender.Text = updateaccount.gender;
                lbl_birthday.Text = updateaccount.birthday;
                lbl_address.Text = updateaccount.address;
                lbl_contactNo.Text = updateaccount.contactNo;
                cb_accountRole.Text = updateaccount.accountRole;
                username = updateaccount.username;
                if (updateaccount.status)
                {
                    ts_status.Checked = true;
                }
                else
                {
                    ts_status.Checked = false;
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.UseWaitCursor = false;
        }

        private void tb_contactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        ManageUser obj = (ManageUser)Application.OpenForms["ManageUser"];

        private async void btn_update_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            try
            {
                updateaccount.privilege = new List<string>();
                if (cb_accountRole.SelectedIndex == 0)
                {
                    updateaccount.privilege.Add("All Privilege");

                }
                else
                {
                    for (int i = 0; i < clb_privilege.Items.Count; i++)
                    {
                        if (clb_privilege.GetItemChecked(i))
                        {

                            switch (i)
                            {
                                case 0:
                                    updateaccount.privilege.Add("Appropriation");

                                    break;
                                case 1:
                                    updateaccount.privilege.Add("Legislative");

                                    break;
                                case 2:
                                    updateaccount.privilege.Add("Ordinance");

                                    break;
                                case 3:
                                    updateaccount.privilege.Add("SB Information");

                                    break;
                                case 4:
                                    updateaccount.privilege.Add("Tricycle");

                                    break;
                                case 5:
                                    updateaccount.privilege.Add("Account Management");

                                    break;

                            }



                        }
                    }
                }
                
                if (ControlsServices.CheckIfOnline())
                {
                    updateAccount cls = updateaccount;
                    await Account.getUserToUpdateOnline
                     (

                     cb_accountRole.Text,
                     cls.privilege,
                     cls.status,
                     cls.username

                     );
                    await Account.getUserToUpdateOnline
                     (

                     cb_accountRole.Text,
                     cls.privilege,
                     cls.status,
                     cls.username

                     );
                    await Account.getUserToUpdateOffline
                     (

                     cb_accountRole.Text,
                     cls.privilege,
                     cls.status,
                     cls.username

                     );
                    MessageBox.Show("Successfully updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await obj.LoadDataTableOnline();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please try again!", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            this.UseWaitCursor = false;
            this.Close();
        }

        private void ts_status_CheckedChanged(object sender, EventArgs e)
        {
            if (ts_status.Checked == true)
            {
                lbl_status.Text = "Active";
                updateaccount.status = true;
            }
            else
            {
                lbl_status.Text = "Inactive";
                updateaccount.status = false;
            }
        }

        private void _thePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_accountRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_accountRole.SelectedIndex == 0)
                clb_privilege.Enabled = false;
            else
                clb_privilege.Enabled = true;
        }

        private void pb_profile_Click(object sender, EventArgs e)
        {

        }
    }


}
