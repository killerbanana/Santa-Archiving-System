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
    public partial class SbOrganizationalChart : Form
    {
        public SbOrganizationalChart()
        {
            InitializeComponent();

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private async Task LoadOfficialsOnline()
        {
            lbl_year.Text = SbOfficialEncode.terms;
            await Officials.getOfficialsChartOnline(SbOfficialEncode.terms);
            try
            {
                
                for (int i = 0; i < Officials.position.Count; i++)
                {
                    string positionCheck = Officials.position[i].ToString();

                    switch (positionCheck)
                    {
                        case "Vice Mayor":
                            lbl_vcName.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                            pb_profile.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            break;
                        case "SBM":

                            if (Officials.rank[i].ToString() == "1")
                            {
                                lbl_sbm1.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile1.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "2")
                            {
                                lbl_sbm2.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile2.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "3")
                            {
                                lbl_sbm3.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile3.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "4")
                            {
                                lbl_sbm4.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile4.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "5")
                            {
                                lbl_sbm5.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile5.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "6")
                            {
                                lbl_sbm6.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile6.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "7")
                            {
                                lbl_sbm7.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile7.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }
                            if (Officials.rank[i].ToString() == "8")
                            {
                                lbl_sbm8.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profile8.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            }


                            break;
                        case "ABC Pres":
                            lbl_abc.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                               pb_profileABC.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            break;
                        case "PPSK Pres":
                            lbl_ppsk.Text = Officials.title[i].ToString() + " " + Officials.firstName[i].ToString() + " " + Officials.middleName[i].ToString() + " " + Officials.lastName[i].ToString() + " " + Officials.suffix[i].ToString();
                                pb_profilePPSK.Image = System.Drawing.Image.FromStream(Officials.image[i]);
                            break;


                    }

                }

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private async void SbOfficialEncode_Load(object sender, EventArgs e)
        {
            if (ControlsServices.CheckIfOnline())
            {
                await LoadOfficialsOnline();
            }

          
        }

    
    }
}
