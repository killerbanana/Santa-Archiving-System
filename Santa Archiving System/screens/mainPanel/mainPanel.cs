using Guna.UI2.WinForms;
using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.ordinance;
using Santa_Archiving_System.screens.resolution;
using Santa_Archiving_System.screens.sbOfficial;
using Santa_Archiving_System.screens.tricycle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.mainPanel
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {
            InitializeComponent();
            customizeDesign();
        }

        bool clicked = false;

        private void customizeDesign()
        {
            panelOrdinanceHolder.Visible = false;
            panelLegislativeHolder.Visible = false;
        }

        private void tabhide()
        {
            if (TabSlider.Visible == true)
                TabSlider.Visible = false;
        }
        private void tabshow()
        {

            if (TabSlider.Visible == false)
            {
                hideSubMenu();
                TabSlider.Visible = true;
            }
            else
                TabSlider.Visible = false;

            if (clicked)
            {
                hideSubMenu();
                TabSlider.Visible = true;
            }
            else
            {
                TabSlider.Visible = false;
            }
        }

        private void hideSubMenu()
        {
            if (panelLegislativeHolder.Visible == true)
                panelLegislativeHolder.Visible = false;
            if (panelOrdinanceHolder.Visible == true)
                panelOrdinanceHolder.Visible = false;
            if (panelAppropriation.Visible == true)
                panelAppropriation.Visible = false;
            if (sbInformationPanel.Visible == true)
                sbInformationPanel.Visible = false;
            if (accountManagementPanel.Visible == true)
                accountManagementPanel.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            TabSlider.Location = new Point(b.Location.X + 141, b.Location.Y - 38);
            TabSlider.BringToFront();


        }

        private void Legislative_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = false;
            showSubMenu(panelLegislativeHolder);
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            clicked = true;

            tabshow();
            moveImageBox(sender);
        }

        private void Ordinance_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = false;
            showSubMenu(panelOrdinanceHolder);
        }

        private void Tricycle_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = true;
            moveImageBox(sender);
            Guna2Button b = (Guna2Button)sender;
            TabSlider.Location = new Point(b.Location.X + 141, Legislative.Location.Y + 48);
            TabSlider.BringToFront();
            hideSubMenu();
            openChildForm(new TricycleEncode());
        }

        private void Appropriation_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = false;
            showSubMenu(panelAppropriation);
        }

        private void Committee_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = false;
            showSubMenu(sbInformationPanel);
        }

        private void AccountManagement_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = false;
            showSubMenu(accountManagementPanel);
        }

        private void PDFButton_Click(object sender, EventArgs e)
        {
            Resolution data = new Resolution()
            {
            };
            openChildForm(new ResoluionEncode(data));
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            openChildForm(new SbOfficialEncode());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Resolution data = new Resolution()
            {
                Reading = "First Reading"
            };
            openChildForm(new ResoluionEncode(data));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Resolution data = new Resolution()
            {
                Reading = "Second Reading"
            };
            openChildForm(new ResoluionEncode(data));
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Resolution data = new Resolution()
            {
                Reading = "Third Reading"
            };
            openChildForm(new ResoluionEncode(data));
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Ordinance data = new Ordinance()
            {
            };
            openChildForm(new OrdinaceEncode(data));
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Ordinance data = new Ordinance()
            {
                Reading = "First Reading"
            };
            openChildForm(new OrdinaceEncode(data));
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            Ordinance data = new Ordinance()
            {
                Reading = "Second Reading"
            };
            openChildForm(new OrdinaceEncode(data));
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Ordinance data = new Ordinance()
            {
                Reading = "Third Reading"
            };
            openChildForm(new OrdinaceEncode(data));
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {

        }
    }
}
