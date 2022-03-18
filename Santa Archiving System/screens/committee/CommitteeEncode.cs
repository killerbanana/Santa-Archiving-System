using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.sbOfficial;
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

namespace Santa_Archiving_System.screens.committee
{
    public partial class CommitteeEncode : Form
    {
        private string terms;
        committees updateCommittee;
        public CommitteeEncode(committees data)
        {
            this.updateCommittee = data;
            InitializeComponent();
        }

        public async Task LoadDataTableOnline()
        {
            try
            {
                dt_committee.DataSource = await Committee.getCommitteeListOnline(terms);
                dt_committee.Columns[0].Visible = false;
                dt_committee.ClearSelection();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public async Task LoadDataTableOffline()
        {
            try
            {
                dt_committee.DataSource = await Committee.getCommitteeListOffline(terms);
                dt_committee.Columns[0].Visible = false;
                dt_committee.ClearSelection();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private async void CommitteEncode_Load(object sender, EventArgs e)
        {
           
       

            if(ControlsServices.CheckIfOnline())
            {
                await Committee.getTermsOnline();
            }
            else
            {
                await Committee.getTermsOffline();
            }

            try
            {
                List<String> list = Committee.terms;
                if (list.Count != 0)
                {
                    list.ForEach(delegate (string s)
                    {
                        if (!cb_terms.Items.Contains(s))
                        {
                            cb_terms.Items.Add(s);
                        }

                    });
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
       

        }

    
        private void btn_add_Click(object sender, EventArgs e)
        {
            SbAddCommittee sbAddCommittee = new SbAddCommittee();
            sbAddCommittee.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(updateCommittee.Id))
            {
                MessageBox.Show("Please select account to update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SbUpdateCommittee sbUpdateCommittee = new SbUpdateCommittee(updateCommittee);
                sbUpdateCommittee.ShowDialog();
            }
        }

        private void dt_committee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string members;
            foreach (DataGridViewRow item in this.dt_committee.SelectedRows)
            {
                updateCommittee.Id = item.Cells[0].Value.ToString();
                updateCommittee.title = item.Cells[1].Value.ToString();
                updateCommittee.description = item.Cells[2].Value.ToString();
                updateCommittee.chairman = item.Cells[3].Value.ToString();
                updateCommittee.viceChairman = item.Cells[4].Value.ToString();
                members = item.Cells[5].Value.ToString();
                updateCommittee.members = members.Split(',').ToList();
                updateCommittee.terms = item.Cells[6].Value.ToString();

            }
        }

        private async void cb_terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            terms = cb_terms.SelectedItem.ToString();
           
            if(terms != string.Empty)
            {
                loading1.Visible = true;
                if (ControlsServices.CheckIfOnline())
                {
                    await LoadDataTableOnline();
                }
                else
                {
                    await LoadDataTableOffline();
                }
                loading1.Visible = false;
            }
           
        }
    }
}
