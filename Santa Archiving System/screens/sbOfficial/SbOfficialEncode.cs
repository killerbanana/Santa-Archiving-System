using Santa_Archiving_System.models;
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
    public partial class SbOfficialEncode : Form
    {

        public static string terms;
        Sb updateOfficials;
        public SbOfficialEncode(Sb data)
        {
            this.updateOfficials = data;
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            SbAddOfficials sbAddOfficials = new SbAddOfficials();
            sbAddOfficials.ShowDialog();
        }
        public async Task LoadDataTableOnline()
        {
           
            try
            {
              
                dt_officials.DataSource = await Officials.getOfficialsListOnline(terms);
                dt_officials.Columns[1].HeaderText = "Firstname";
                dt_officials.Columns[2].HeaderText = "Middlename";
                dt_officials.Columns[3].HeaderText = "Lastname";
                dt_officials.Columns[0].Visible = false;
                dt_officials.Columns[13].Visible = false;
                dt_officials.Columns[14].Visible = false;
                dt_officials.ClearSelection();
              
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

                dt_officials.DataSource = await Officials.getOfficialsListOffline(terms);
                dt_officials.Columns[1].HeaderText = "Firstname";
                dt_officials.Columns[2].HeaderText = "Middlename";
                dt_officials.Columns[3].HeaderText = "Lastname";
                dt_officials.Columns[0].Visible = false;
                dt_officials.Columns[13].Visible = false;
                dt_officials.Columns[14].Visible = false;
               
                dt_officials.ClearSelection();
        
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public async Task getBatch()
        {

            if (ControlsServices.CheckIfOnline())
            {
                await Officials.getTermsOnline();
            }
            else
            {
                await Officials.getTermsOffline();
            }


            try
            {
                List<String> list = Officials.terms;
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
        private async void SbOfficialEncode_Load(object sender, EventArgs e)
        {
            await getBatch();
            terms = string.Empty;
        }

        private async void cb_terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 terms = cb_terms.SelectedItem.ToString();
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
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

     

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(updateOfficials.Id))
            {
                MessageBox.Show("Please select committee to update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SbUpdateOfficials sbUpdateOfficials = new SbUpdateOfficials(updateOfficials);
                sbUpdateOfficials.ShowDialog();
            }
        }

        private void btn_chart_Click(object sender, EventArgs e)
        {
            
            SbOrganizationalChart sbOrganizationalChart = new SbOrganizationalChart();
            sbOrganizationalChart.ShowDialog();
        }

        private void dt_officials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string committee;
                foreach (DataGridViewRow item in this.dt_officials.SelectedRows)
                {
                    updateOfficials.Id = item.Cells[0].Value.ToString();
                    updateOfficials.firstName = item.Cells[1].Value.ToString();
                    updateOfficials.middleName = item.Cells[2].Value.ToString();
                    updateOfficials.lastName = item.Cells[3].Value.ToString();
                    updateOfficials.suffix = item.Cells[4].Value.ToString();
                    updateOfficials.title = item.Cells[5].Value.ToString();
                    updateOfficials.position = item.Cells[6].Value.ToString();
                    updateOfficials.gender = item.Cells[7].Value.ToString();
                    updateOfficials.birthday = item.Cells[8].Value.ToString();
                    updateOfficials.address = item.Cells[9].Value.ToString();
                    updateOfficials.contactNo = item.Cells[10].Value.ToString();
                    committee = item.Cells[11].Value.ToString();
                    updateOfficials.committee = committee.Split(',').ToList();
                    updateOfficials.terms = item.Cells[12].Value.ToString();
                    updateOfficials.rank = item.Cells[13].Value.ToString();
                    byte[] bytes = (byte[])item.Cells[14].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    updateOfficials.image = ms;
                    

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
            updateOfficials.Id = string.Empty;

            loading1.Visible = false;
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            loading1.Visible = true;
            if (String.IsNullOrWhiteSpace(updateOfficials.position) || String.IsNullOrWhiteSpace(updateOfficials.Id))
            {
                MessageBox.Show("Please select committee to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this Data?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    await Officials.DeleteOfficialsOnline(updateOfficials.position, updateOfficials.Id, updateOfficials.rank);
                    await Officials.DeleteOfficialsOffline(updateOfficials.position, updateOfficials.Id, updateOfficials.rank);
                    await LoadDataTableOnline();
                    MessageBox.Show("Successfully deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateOfficials.Id = string.Empty;
                    updateOfficials.position = string.Empty;
              
                }


            }
            loading1.Visible = false;
        }

        private async void btn_export_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Upload backup from cloud? This process make up some time.", "Upload", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                loading1.Visible = true;

                if (ControlsServices.CheckIfOnline())
                {
                    await Officials.ExportData();
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
                    await Officials.ImportOfficials();
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

        private async void tb_searchBox_TextChanged(object sender, EventArgs e)
        {
            if (dt_officials == null || dt_officials.Rows.Count == 0)
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
                (dt_officials.DataSource as DataTable).DefaultView.RowFilter = string.Format("[FirstName] LIKE '%{0}%' OR [Position] LIKE '%{0}%'  OR [LastName] LIKE '%{0}%' OR [Committee] LIKE '%{0}%' ", tb_searchBox.Text);
            }
        }
    }
}
