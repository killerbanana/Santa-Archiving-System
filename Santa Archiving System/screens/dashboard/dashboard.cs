﻿using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.appropriation;
using Santa_Archiving_System.screens.electronic;
using Santa_Archiving_System.screens.ordinance;
using Santa_Archiving_System.screens.resolution;
using Santa_Archiving_System.screens.sendToEmail;
using Santa_Archiving_System.screens.wordToPdf;
using Santa_Archiving_System.services.account;
using Santa_Archiving_System.services.appropriation;
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
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.dashboard
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        account account;
        public async Task LoadDataTableOnline()
        {
            try
            {
                dt_activities.DataSource = await dash.getActivities();
                dt_activities.ClearSelection();

                await LoadDataTableOnline();
                dt_users.Columns[1].HeaderText = "Name";
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            int resolutionCount = await Resolutions.getCount();
            int ordinanceCount = await Ordinances.getCount();
            int appropriationCount = await Appropriations.getCount();
            int tricyCount = await Tricycles.getCount();

            lb_resolution_count.Text = resolutionCount.ToString();
            lb_ordinance_count.Text = ordinanceCount.ToString();
            lb_appropriation_count.Text = appropriationCount.ToString();
            tricy_count.Text = tricyCount.ToString();

            try
            {
                dt_activities.DataSource = await dash.getActivities();
               // dt_activities.ClearSelection();

                dt_users.DataSource = await Account.getOnlineUsers();
                //dt_users.Columns[1].HeaderText = "Name";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void guna2Panel7_Click(object sender, EventArgs e)
        {
            Resolution resolution = new Resolution() {
                QuickAction = true
            };
            AddResolution addResolution = new AddResolution(resolution);
            addResolution.ShowDialog();
        }

        private void guna2Panel8_Click(object sender, EventArgs e)
        {
            Ordinance ordinance = new Ordinance()
            {
                QuickAction = true
            };
            AddOrdinance addOrdinance = new AddOrdinance(ordinance);
            addOrdinance.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Ordinance ordinance = new Ordinance()
            {
                QuickAction = true
            };
            AddOrdinance addOrdinance = new AddOrdinance(ordinance);
            addOrdinance.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Resolution resolution = new Resolution()
            {
                QuickAction = true
            };
            AddResolution addResolution = new AddResolution(resolution);
            addResolution.ShowDialog();
        }

        private void guna2Panel9_Click(object sender, EventArgs e)
        {
            Appropriation appropriation = new Appropriation();
            AddAppropriation addAppropriation = new AddAppropriation(appropriation);
            addAppropriation.ShowDialog();

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Appropriation appropriation = new Appropriation();
            AddAppropriation addAppropriation = new AddAppropriation(appropriation);
            addAppropriation.ShowDialog();
        }

        private void lb_appropriation_count_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Appropriation"
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

        private void lb_resolution_count_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Resolution"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel5_Click(object sender, EventArgs e)
        {
            WordToPdf word = new WordToPdf();
            word.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            WordToPdf word = new WordToPdf();
            word.ShowDialog();
        }

        private void guna2Panel5_MouseEnter(object sender, EventArgs e)
        {
            word2pdf.ForeColor = Color.FromArgb(55, 81, 255);
            word2pdflabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel5_MouseLeave(object sender, EventArgs e)
        {
            word2pdf.ForeColor = Color.Black;
            word2pdflabel.ForeColor = Color.Black;
        }

        private void guna2Panel4_MouseEnter(object sender, EventArgs e)
        {
            tricy.ForeColor = Color.FromArgb(55, 81, 255);
            tricy_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel4_MouseLeave(object sender, EventArgs e)
        {
            tricy.ForeColor = Color.Black;
            tricy_count.ForeColor = Color.Black;
        }
        
        private void tricy_count_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Tricy"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel7_MouseEnter(object sender, EventArgs e)
        {
            addResolution.ForeColor = Color.FromArgb(55, 81, 255);
            addResolutionLabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel7_MouseLeave(object sender, EventArgs e)
        {
            addResolution.ForeColor = Color.Black;
            addResolutionLabel.ForeColor = Color.Black;
        }

        private void guna2Panel8_MouseEnter(object sender, EventArgs e)
        {
            addOrdinance.ForeColor = Color.FromArgb(55, 81, 255);
            addOrdinanceLabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel8_MouseLeave(object sender, EventArgs e)
        {
            addOrdinance.ForeColor = Color.Black;
            addOrdinanceLabel.ForeColor = Color.Black;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel9_MouseEnter(object sender, EventArgs e)
        {
            addAppropriation.ForeColor = Color.FromArgb(55, 81, 255);
            addAppropriationLabel.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel9_MouseLeave(object sender, EventArgs e)
        {
            addAppropriation.ForeColor = Color.Black;
            addAppropriationLabel.ForeColor = Color.Black;
        }

        private void guna2Panel1_Click_1(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Resolution"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel1_MouseEnter_1(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.FromArgb(55, 81, 255);
            lb_resolution_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel1_MouseLeave_1(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.Black;
            lb_resolution_count.ForeColor = Color.Black;
        }

        private void guna2Panel2_Click_1(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Ordinance"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel2_MouseEnter_1(object sender, EventArgs e)
        {
            lb_ordinance.ForeColor = Color.FromArgb(55, 81, 255);
            lb_ordinance_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel2_MouseLeave_1(object sender, EventArgs e)
        {
            lb_ordinance.ForeColor = Color.Black;
            lb_ordinance_count.ForeColor = Color.Black;
        }

        private void guna2Panel3_Click_1(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Appropriation"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel3_MouseEnter_1(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.FromArgb(55, 81, 255);
            lb_appropriation_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel3_MouseLeave_1(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.Black;
            lb_appropriation_count.ForeColor = Color.Black;
        }

        private void guna2Panel4_Click_1(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Tricy"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddActivities addActivities = new AddActivities();
            addActivities.ShowDialog();
        }

        private async void btn_delete_Click(object sender, EventArgs e)
        {
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
        }

        private void dt_activities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.dt_activities.SelectedRows)
            {
                account = new account()
                {
                    title = item.Cells[0].Value.ToString(),
                    agenda = item.Cells[1].Value.ToString(),
                };
            }
        }
    }
}
