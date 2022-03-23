using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.committee;
using Santa_Archiving_System.services.committee;
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

namespace Santa_Archiving_System.screens.sbOfficial

{
    public partial class SbUpdateCommittee : Form
    {
        committees updateCommittee;
        private List<String> membersList = new List<String>();
        public SbUpdateCommittee(committees data)
        {
            this.updateCommittee = data;
            InitializeComponent();
        }

        private async Task getMembers()
        {
         
            loading1.Visible = true;

            if (ControlsServices.CheckIfOnline())
            {
                await Committee.getMembersOnline(updateCommittee.terms);
            }
            else
            {
                await Committee.getMembersOffline(updateCommittee.terms);
            }

            List<String> list = Committee.committeeMembers;
   
            list.ForEach(delegate (string s)
            {
                clb_members.Items.Add(s);
                cb_chair.Items.Add(s);
                cb_vc.Items.Add(s);
            });

            if (clb_members.Items.Count == 0)
            {
                clb_members.Visible = false;
                lbl_info.Text = "No Datas to show";
            }
            else
            {
                clb_members.Visible = true;
            }
            for (int year = 2015; year <= DateTime.UtcNow.Year; ++year)
            {
                cb_from.Items.Add(year);
                cb_to.Items.Add(year);

            }
            tb_title.Text = updateCommittee.title;
            tb_desc.Text = updateCommittee.description;
            cb_chair.Text = updateCommittee.chairman;
            cb_vc.Text = updateCommittee.viceChairman;
            string str = updateCommittee.terms;
            List<String> subs = str.Split(' ').ToList();
            int indexFrom = cb_from.FindString(subs[0]);
            cb_from.SelectedIndex = indexFrom;
            int indexTo = cb_from.FindString(subs[2]);
            cb_to.SelectedIndex = indexTo;
         


            loading1.Visible = false;


        }

        private async void SbUpdateCommittee_Load(object sender, EventArgs e)
        {
            
            this.UseWaitCursor = true;
            try
            {
                await getMembers();
                List<String> list = updateCommittee.members;
                if (updateCommittee.members != null)
                {
                    for (int i = 0; i < clb_members.Items.Count; i++)
                    {
                        list.ForEach(delegate (string s) {

                            if(clb_members.Items[i].ToString() == s)
                            {
                                clb_members.SetItemChecked(i, true);

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

        private async void btn_update_Click(object sender, EventArgs e)
        {
            string terms = cb_from.Text + " " + "-" + " " + cb_to.Text;
            try
            {
                foreach (var item in clb_members.CheckedItems)
                {


                    membersList.Add(item.ToString());


                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (string.IsNullOrWhiteSpace(tb_title.Text) ||
               string.IsNullOrWhiteSpace(tb_desc.Text) ||
               string.IsNullOrWhiteSpace(cb_chair.Text) ||
               string.IsNullOrWhiteSpace(cb_from.Text) ||
               string.IsNullOrWhiteSpace(cb_vc.Text)
               )
            {
                MessageBox.Show("Please fill all required fields!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                this.UseWaitCursor = true;
                if (ControlsServices.CheckIfOnline())
                {
                    await Committee.UpdateMembersOnline
                        (
                        tb_title.Text,
                        tb_desc.Text,
                        cb_chair.Text,
                        cb_vc.Text,
                        membersList,
                        terms,
                        updateCommittee.Id
                        );
                    await Committee.UpdateMembersOffline
                        (
                        tb_title.Text,
                        tb_desc.Text,
                        cb_chair.Text,
                        cb_vc.Text,
                        membersList,
                        terms,
                        updateCommittee.Id
                        );
                }
                else
                {
                    await Committee.UpdateMembersOffline
                        (
                        tb_title.Text,
                        tb_desc.Text,
                        cb_chair.Text,
                        cb_vc.Text,
                        membersList,
                        terms,
                        updateCommittee.Id
                        );
                }
                MessageBox.Show("Successfully updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                membersList.Clear();
                updateCommittee.Id = string.Empty;
                updateCommittee.title = string.Empty;
                updateCommittee.description = string.Empty;
                updateCommittee.chairman = string.Empty;
                updateCommittee.viceChairman = string.Empty;
                updateCommittee.members.Clear();
                updateCommittee.terms = string.Empty;
                CommitteeEncode obj = (CommitteeEncode)Application.OpenForms["CommitteeEncode"];
           
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

        private void tb_title_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_title.Text))
            {
                lbl_title.Visible = true;
            }
            else
            {
                lbl_title.Visible = false;
            }
        }

        private void tb_desc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_desc.Text))
            {
                lbl_desc.Visible = true;
            }
            else
            {
                lbl_desc.Visible = false;
            }
        }

        private void cb_chair_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cb_chair.Text))
            {
                lbl_chair.Visible = true;
            }
            else
            {
                lbl_chair.Visible = false;
            }
        }

        private void cb_vc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cb_vc.Text))
            {
                lbl_vc.Visible = true;
            }
            else
            {
                lbl_vc.Visible = false;
            }
        }

        private void SbUpdateCommittee_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateCommittee.Id = string.Empty;
       
        }

        private void cb_from_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_to_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
