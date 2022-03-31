using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.appropriation;
using Santa_Archiving_System.screens.electronic;
using Santa_Archiving_System.screens.ordinance;
using Santa_Archiving_System.screens.resolution;
using Santa_Archiving_System.screens.sendToEmail;
using Santa_Archiving_System.screens.wordToPdf;
using Santa_Archiving_System.services.appropriation;
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
        }

        private void guna2Panel1_MouseEnter(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.FromArgb(55, 81, 255);
            lb_resolution_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel1_MouseLeave(object sender, EventArgs e)
        {
            lb_resolution.ForeColor = Color.Black;
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
            lb_ordinance.ForeColor = Color.Black;
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

        private void guna2Panel3_MouseEnter(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.FromArgb(55, 81, 255);
            lb_appropriation_count.ForeColor = Color.FromArgb(55, 81, 255);
        }

        private void guna2Panel3_MouseLeave(object sender, EventArgs e)
        {
            lb_appropriation.ForeColor = Color.Black;
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

        private void guna2Panel4_Click(object sender, EventArgs e)
        {
            EmailContent emailContent = new EmailContent()
            {
                Type = "Tricy"
            };
            SendToEmail sendToEmail = new SendToEmail(emailContent);
            sendToEmail.ShowDialog();
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
    }
}
