using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.electronic;
using Santa_Archiving_System.screens.sendToEmail;
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

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_MouseEnter(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.FromArgb(55, 81, 255);
            lb_resolution_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.FromArgb(159, 160, 182);
            lb_resolution_count.ForeColor = Color.Black;
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Resolution"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_MouseEnter(object sender, EventArgs e)
        {
            lb_ordinance.ForeColor = Color.FromArgb(55, 81, 255);
            lb_ordinance_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel2_MouseLeave(object sender, EventArgs e)
        {
            lb_ordinance.ForeColor = Color.FromArgb(159, 160, 182);
            lb_ordinance_count.ForeColor = Color.Black;
        }

        private void guna2Panel2_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Ordinance"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }

        private void guna2Panel3_MouseEnter(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.FromArgb(55, 81, 255);
            lb_appropriation_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel3_MouseLeave(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.FromArgb(159, 160, 182);
            lb_appropriation_count.ForeColor = Color.Black;
        }

        private void guna2Panel3_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Appropriation"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
        }
    }
}
