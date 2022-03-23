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
                dt_committee.Columns[4].HeaderText = "Vice Chairman";
                dt_committee.Columns[0].Visible = false;
                dt_committee.ClearSelection();


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        public async Task loadBatch()
        {

            if (ControlsServices.CheckIfOnline())
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async void CommitteEncode_Load(object sender, EventArgs e)
        {
            await loadBatch();
            terms = cb_terms.Text;
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
                MessageBox.Show("Please select committee to update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
           
            try
            {
                terms = cb_terms.Text;
                if (terms != string.Empty)
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btn_refresh_Click(object sender, EventArgs e)
        {
            loading1.Visible = true;

            if (terms != string.Empty)
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
            updateCommittee.Id = string.Empty;

            loading1.Visible = false;
        }

        private async void tb_search_TextChanged(object sender, EventArgs e)
        {
            if (dt_committee == null || dt_committee.Rows.Count == 0)
            {
                if (ControlsServices.CheckIfOnline())
                {
                    await LoadDataTableOnline();
                }
                else
                {
                    await LoadDataTableOffline();
                }
            }
            else
            {
                (dt_committee.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Title] LIKE '%{0}%' OR [Chairman] LIKE '%{0}%'  OR [ViceChairman] LIKE '%{0}%' ", tb_search.Text);
            }
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Upload backup from cloud? This process make up some time.", "Upload", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;

                if (ControlsServices.CheckIfOnline())
                {
                    await Committee.ExportData();
                    await LoadDataTableOnline();
                    MessageBox.Show("Successfully uploaded!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to process!", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataTableOffline();
                }


                loading1.Visible = false;
            }
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to download backup from cloud?", "Download", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;

                if (ControlsServices.CheckIfOnline())
                {
                    await Committee.ImportCommittee();
                    await LoadDataTableOnline();
                    MessageBox.Show("Successfully downloaded!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to process!", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataTableOffline();
                }


                loading1.Visible = false;
            }
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            loading1.Visible = true;
            if (String.IsNullOrWhiteSpace(updateCommittee.title) || String.IsNullOrWhiteSpace(updateCommittee.Id))
            {
                MessageBox.Show("Please select committee to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this Data?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    await Committee.DeleteCommitteeOnline(updateCommittee.title, updateCommittee.Id);
                    await Committee.DeleteCommitteeOffline(updateCommittee.title, updateCommittee.Id);
                    await LoadDataTableOnline();
                    MessageBox.Show("Successfully deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateCommittee.Id = string.Empty;
                    updateCommittee.title = string.Empty;
                    updateCommittee.description = string.Empty;
                    updateCommittee.chairman = string.Empty;
                    updateCommittee.viceChairman = string.Empty;
                    updateCommittee.members.Clear();
                    updateCommittee.terms = string.Empty;
                }


            }
            loading1.Visible = false;
        }
    }
}
