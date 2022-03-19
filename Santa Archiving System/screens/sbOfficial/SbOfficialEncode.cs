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
    public partial class SbOfficialEncode : Form
    {

        private string terms;
        public SbOfficialEncode()
        {
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
                dt_officials.Columns[0].Visible = false;
                dt_officials.Columns[13].Visible = false;
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
                dt_officials.Columns[0].Visible = false;
                dt_officials.Columns[13].Visible = false;
                dt_officials.ClearSelection();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private async void SbOfficialEncode_Load(object sender, EventArgs e)
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

        private async void cb_terms_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
