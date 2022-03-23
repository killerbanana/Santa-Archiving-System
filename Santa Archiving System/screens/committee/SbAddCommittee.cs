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
    public partial class SbAddCommittee : Form
    {
        private List<String> membersList = new List<String>();
        public SbAddCommittee()
        {
            InitializeComponent();
        }

        private async Task getMembers()
        {
            string term = cb_from.Text + " " + "-" + " " + cb_to.Text;
            loading1.Visible = true;

            if (ControlsServices.CheckIfOnline())
            {
                await Committee.getMembersOnline(term);
            }
            else
            {
                await Committee.getMembersOffline(term);
            }
               
                List<String> list = Committee.committeeMembers;
                  
                     list.ForEach(delegate (string s)
                     {
                        clb_members.Items.Add(s);
                        cb_chair.Items.Add(s);
                        cb_vc.Items.Add(s);
                    });
                
                if(clb_members.Items.Count == 0)
                {
                    clb_members.Visible = false;
                    lbl_info.Text = "No Datas to show";
                }
                else
                {
                    clb_members.Visible = true;
                }
                loading1.Visible = false;
            
           
        }
        private void SbAddCommittee_Load(object sender, EventArgs e)
        {   
            for (int year = 2015; year <= DateTime.UtcNow.Year; ++year)
            {
                cb_from.Items.Add(year);
                cb_to.Items.Add(year);
            }
           
           
        }
      
        private async void btn_create_Click(object sender, EventArgs e)
        {
            string terms = cb_from.Text + " " + "-" + " " + cb_to.Text;
       
            
            try
            {
                foreach (var item in clb_members.CheckedItems)
                {
                   

                        membersList.Add(item.ToString());
                       
                   
                }
            }
            catch(Exception err)
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
                    await Committee.SaveMembersOnline
                        (
                        tb_title.Text,
                        tb_desc.Text,
                        cb_chair.Text,
                        cb_vc.Text,
                        membersList,
                        terms
                        );
                    await Committee.SaveMembersOffline
                        (
                        tb_title.Text,
                        tb_desc.Text,
                        cb_chair.Text,
                        cb_vc.Text,
                        membersList,
                        terms
                        );
                }
                else
                {
                    await Committee.SaveMembersOffline
                        (
                        tb_title.Text,
                        tb_desc.Text,
                        cb_chair.Text,
                        cb_vc.Text,
                        membersList,
                        terms
                        );
                }
                MessageBox.Show("Successfully created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                membersList.Clear();
                tb_title.Text = String.Empty;
                tb_desc.Text = String.Empty;
                cb_chair.SelectedIndex = -1;
                cb_vc.SelectedIndex = -1;
                cb_from.SelectedIndex = -1;
                cb_to.SelectedIndex = -1;
              
                try
                {
                    disable();


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                CommitteeEncode obj = (CommitteeEncode)Application.OpenForms["CommitteeEncode"];
                if (ControlsServices.CheckIfOnline())
                {
                    await obj.LoadDataTableOnline();
                    await obj.loadBatch();
                }
                else
                {
                    await obj.LoadDataTableOffline();
                    await obj.loadBatch();
                }
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

     
     
        private  async void enable()
        {
            if(cb_from.Text != string.Empty && cb_to.Text != string.Empty)
            {
                tb_title.Enabled = true;
                tb_desc.Enabled = true;
                cb_chair.Enabled = true;
                cb_vc.Enabled = true;
                clb_members.Visible = true;
                clb_members.Items.Clear();
                cb_chair.Items.Clear();
                cb_vc.Items.Clear();
                await getMembers();
            }
        }
        private async void disable()
        {
            if (cb_from.Text == string.Empty && cb_to.Text == string.Empty)
            {
                await getMembers();
                tb_title.Enabled = false;
                tb_desc.Enabled = false;
                cb_chair.Enabled = false;
                cb_vc.Enabled = false;
                clb_members.Visible = false;
            
               
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

        private void cb_chair_SelectedIndexChanged_1(object sender, EventArgs e)
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

    
    }
}
