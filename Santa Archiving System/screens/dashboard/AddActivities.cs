using Santa_Archiving_System.services.controls;
using Santa_Archiving_System.services.dashboard;
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
    public partial class AddActivities : Form
    {
        public AddActivities()
        {
            InitializeComponent();
        }

        private async void btn_create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_title.Text) ||
               string.IsNullOrWhiteSpace(tb_agenda.Text) ||
               string.IsNullOrWhiteSpace(tb_venue.Text))
            {
                MessageBox.Show("Please fill all required fields!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (ControlsServices.CheckIfOnline())
                {
                    this.UseWaitCursor = true;
                    var time = tb_time.Text + " " + cb_ampm.Text;
                    await dash.SaveActivities
                           (
                           tb_title.Text,
                           tb_agenda.Text,
                           cb_date.Text,
                           time,
                           tb_venue.Text
                          
                           );
                    MessageBox.Show("Successfully created!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                        this.Close();
                        Dash obj = (Dash)Application.OpenForms["Dash"];
                        await obj.LoadDataTableOnline();
                  

                }
                else
                {
                    MessageBox.Show("Creating an event needs internet connection.", "Network connection failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.UseWaitCursor = false;




            }

        }

        private void tb_title_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_title.Text))
            {
                tb_title.Visible = true;
            }
            else
            {
                lbl_title.Visible = false;
            }
        }

        private void tb_agenda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_agenda.Text))
            {
                tb_agenda.Visible = true;
            }
            else
            {
                lbl_agenda.Visible = false;
            }
        }

        private void tb_venue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_venue.Text))
            {
                tb_venue.Visible = true;
            }
            else
            {
                lbl_venue.Visible = false;
            }
        }
    }
}
