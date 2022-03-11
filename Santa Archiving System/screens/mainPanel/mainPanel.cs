using Guna.UI2.WinForms;
using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.dashboard;
using Santa_Archiving_System.screens.auth;
using Santa_Archiving_System.screens.ordinance;
using Santa_Archiving_System.screens.resolution;
using Santa_Archiving_System.screens.sbOfficial;
using Santa_Archiving_System.screens.tricycle;
using Santa_Archiving_System.services.account;
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
        bool clicked = false;
       

        public MainPanel()
        {
            InitializeComponent();
            customizeDesign();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Remove Form Flicker
                return cp;
            }
        }
        private void MainPanel_Load(object sender, EventArgs e)
        {
           
            pb_profile.Image = System.Drawing.Image.FromStream(Account.image);
            lbl_name.Text = Account.firstName + " " + Account.middleName + " " + Account.lastName;
            if(Account.accountRole == "Admin")
            {
                Appropriation.Enabled = true;
                Legislative.Enabled = true;
                Ordinance.Enabled = true;
                Committee.Enabled = true;
                Tricycle.Enabled = true;
                AccountManagement.Enabled = true;
            }
            else
            {
                Account.privilege.ForEach(delegate (string s) {
                    bool appropriation = s.Contains(Appropriation.Text);
                    bool legislative = s.Contains(Legislative.Text);
                    bool ordinance = s.Contains(Ordinance.Text);
                    bool sb = s.Contains(Committee.Text);
                    bool tricycle = s.Contains(Tricycle.Text);
                    bool account = s.Contains(AccountManagement.Text);
                    if (!appropriation)
                        Appropriation.Visible = false;
                    if (!legislative)
                        Legislative.Visible = false;
                    if (!ordinance)
                        Ordinance.Visible = false;
                    if (!sb)
                        Committee.Visible = false;
                    if (!tricycle)
                        Tricycle.Visible = false;
                    if (!account)
                        AccountManagement.Visible = false;
                    if (appropriation)
                        Appropriation.Enabled = true;
                    if (legislative)
                        Legislative.Enabled = true;
                    if (ordinance)
                        Ordinance.Enabled = true;
                    if (sb)
                        Committee.Enabled = true;
                    if (tricycle)
                        Tricycle.Enabled = true;
                    if (account)
                        AccountManagement.Enabled = true;
                });
            }
           

        }
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
            openChildForm(new Dashboard());
        }

        private void Ordinance_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = false;
            showSubMenu(panelOrdinanceHolder);
        }

        private void Tricycle_Click(object sender, EventArgs e)
        {
            TabSlider.Visible = true;
            TabSlider.BringToFront();
            hideSubMenu();
            moveImageBox(sender);
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
            TabSlider.Visible = true;
            moveImageBox(sender);

            TabSlider.BringToFront();
            hideSubMenu();
            openChildForm(new ManageUser());
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

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            account data = new account();
            openChildForm(new Registration(data));

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            clicked = true;

            tabshow();
            moveImageBox(sender);
            openChildForm(new ManageUser());
        }

      

      
    }
}
