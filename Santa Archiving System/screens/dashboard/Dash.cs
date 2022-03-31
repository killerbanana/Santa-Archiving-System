using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.appropriation;
using Santa_Archiving_System.screens.ordinance;
using Santa_Archiving_System.screens.resolution;
using Santa_Archiving_System.screens.sendToEmail;
using Santa_Archiving_System.screens.wordToPdf;
using Santa_Archiving_System.services.account;
using Santa_Archiving_System.services.appropriation;
using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.dashboard;
using Santa_Archiving_System.services.ordinance;
using Santa_Archiving_System.services.resolution;
using Santa_Archiving_System.services.tricycle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.dashboard
{
    public partial class Dash : Form
    {
      
        account account;
        public Dash(account data)
        {
            this.account = data;
            InitializeComponent();
        }
        public async Task LoadDataTableOnline()
        {
            try
            {
                dt_activities.DataSource = await dash.getActivities();          
                dt_activities.ClearSelection();
                dt_activities.Columns[0].Visible = false;
                dt_users.DataSource = await Account.getOnlineUsers();
              
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private async void Dash_Load(object sender, EventArgs e)
        {
            await LoadDataTableOnline();

            int resolutionCount = await Resolutions.getCount();
            int ordinanceCount = await Ordinances.getCount();
            int appropriationCount = await Appropriations.getCount();
            int tricyCount = await Tricycles.getCount();

            lb_resolution_count.Text = resolutionCount.ToString();
            lb_ordinance_count.Text = ordinanceCount.ToString();
            lb_appropriation_count.Text = appropriationCount.ToString();
            tricy_count.Text = tricyCount.ToString();
        }

        private async void btn_refresh_Click(object sender, EventArgs e)
        {
            if (ControlsServices.CheckIfOnline())
            {
                await LoadDataTableOnline();
            
            }
            else
            {
                MessageBox.Show("No data to be shown", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lb_resolution_count_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Resolution"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void lb_ordinance_count_Click(object sender, EventArgs e)
        {

            EmailContent emailContent = new EmailContent()
            {
                Type = "Ordinance"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

    

     

        private void guna2ShadowPanel1_MouseEnter(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.FromArgb(55, 81, 255);
            lb_resolution_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel2_MouseEnter(object sender, EventArgs e)
        {
            lb_ordinance.ForeColor = Color.FromArgb(55, 81, 255);
            lb_ordinance_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel3_MouseEnter(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.FromArgb(55, 81, 255);
            lb_appropriation_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel4_MouseEnter(object sender, EventArgs e)
        {
            tricy.ForeColor = Color.FromArgb(55, 81, 255);
            tricy_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel1_MouseLeave(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.Black;
            lb_resolution_count.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel2_MouseLeave(object sender, EventArgs e)
        {
            lb_ordinance.ForeColor = Color.Black;
            lb_ordinance_count.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel3_MouseLeave(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.Black;
            lb_appropriation_count.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel4_MouseLeave(object sender, EventArgs e)
        {
            tricy.ForeColor = Color.Black;
            tricy_count.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel5_MouseEnter(object sender, EventArgs e)
        {
            word2pdf.ForeColor = Color.FromArgb(55, 81, 255);
            word2pdflabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel5_MouseLeave(object sender, EventArgs e)
        {
            word2pdf.ForeColor = Color.Black;
            word2pdflabel.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel6_MouseEnter(object sender, EventArgs e)
        {
            addResolution.ForeColor = Color.FromArgb(55, 81, 255);
            addResolutionLabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel6_MouseLeave(object sender, EventArgs e)
        {
            addResolution.ForeColor = Color.Black;
            addResolutionLabel.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel7_MouseEnter(object sender, EventArgs e)
        {
            addOrdinance.ForeColor = Color.FromArgb(55, 81, 255);
            addOrdinanceLabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel7_MouseLeave(object sender, EventArgs e)
        {
            addOrdinance.ForeColor = Color.Black;
            addOrdinanceLabel.ForeColor = Color.Black;
        }

        private void guna2ShadowPanel8_MouseEnter(object sender, EventArgs e)
        {
            lbl_addApp.ForeColor = Color.FromArgb(55, 81, 255);
            lbl_App.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2ShadowPanel8_MouseLeave(object sender, EventArgs e)
        {
            lbl_addApp.ForeColor = Color.Black;
            lbl_App.ForeColor = Color.Black;
        }

        private void lb_appropriation_count_Click_1(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Appropriation"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void tricy_count_Click_1(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Tricy"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void word2pdflabel_Click(object sender, EventArgs e)
        {
            WordToPdf word = new WordToPdf();
            word.ShowDialog();
        }

        private void addResolutionLabel_Click(object sender, EventArgs e)
        {
            Resolution resolution = new Resolution()
            {
                QuickAction = true
            };
            AddResolution addResolution = new AddResolution(resolution);
            addResolution.ShowDialog();
        }

        private void addOrdinanceLabel_Click(object sender, EventArgs e)
        {
            Ordinance ordinance = new Ordinance()
            {
                QuickAction = true
            };
            AddOrdinance addOrdinance = new AddOrdinance(ordinance);
            addOrdinance.ShowDialog();
        }

        private void lbl_App_Click(object sender, EventArgs e)
        {
            Appropriation appropriation = new Appropriation();
            AddAppropriation addAppropriation = new AddAppropriation(appropriation);
            addAppropriation.ShowDialog();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddActivities addActivities = new AddActivities();
            addActivities.ShowDialog();
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
           
            if (String.IsNullOrWhiteSpace(account.title) || String.IsNullOrWhiteSpace(account.agenda))
            {
                MessageBox.Show("Please select activities to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this Data?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    await dash.DeleteActivities(account.title, account.agenda);
                  
                    await LoadDataTableOnline();
                    MessageBox.Show("Successfully deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    account.title = string.Empty;
                    account.agenda = string.Empty;
                }

            }
            this.UseWaitCursor = false;
        }

        private void dt_activities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
              
                foreach (DataGridViewRow item in this.dt_activities.SelectedRows)
                {

                    account.title = item.Cells[1].Value.ToString();
                    account.agenda = item.Cells[2].Value.ToString();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
