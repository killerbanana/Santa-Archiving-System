using Santa_Archiving_System.models;
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
            tb_title.Text = updateCommittee.title;
            tb_desc.Text = updateCommittee.description;
            cb_chair.Text = updateCommittee.chairman;
            cb_vc.Text = updateCommittee.viceChairman;
          
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
    }
}
