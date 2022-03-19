using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.auth;
using Santa_Archiving_System.screens.mainPanel;
using Santa_Archiving_System.services.account;
using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.users
{
    public partial class ChangePassword : Form
    {
        Thread th;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public void checkTextbox()
        {
            if (string.IsNullOrWhiteSpace(tb_old.Text) || string.IsNullOrWhiteSpace(tb_new.Text) || string.IsNullOrWhiteSpace(tb_confirm.Text))
            {
                btn_changePassword.Enabled = false;
            }
            else
            {
                btn_changePassword.Enabled = true;
            }
        }

        private void tb_old_TextChanged(object sender, EventArgs e)
        {
            checkTextbox();
        }

        private void tb_new_TextChanged(object sender, EventArgs e)
        {
            checkTextbox();
        }

        private void tb_confirm_TextChanged(object sender, EventArgs e)
        {
            checkTextbox();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
        private void openLogin(object obj)
        {
            Application.Run(new Login());
        }
        private async void btn_changePassword_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            await Account.CheckLoginOnline(Account.userName);
            if (ControlsServices.CheckIfOnline())
            {
               

                if (Account.checkedLoginOnline == true)
                {
                    if(tb_old.Text == ControlsServices.Decrypt(Account.password))
                    {
                        if(tb_new.Text == tb_confirm.Text)
                        {

                            if (MessageBox.Show("Changing password will log you out, Do you want to continue?", "Change password", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                await Account.UpdatePasswordOnline(ControlsServices.Encrypt(tb_confirm.Text));
                                await Account.UpdatePasswordOffline(ControlsServices.Encrypt(tb_confirm.Text));
                                this.Close();
                                MainPanel obj = (MainPanel)Application.OpenForms["MainPanel"];
                                obj.Close(); //close application
                                th = new Thread(openLogin);
                                th.SetApartmentState(ApartmentState.STA);
                                th.Start();

                            }

                           
                        }
                        else
                        {
                            MessageBox.Show("New password doesn't match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old password doesn't match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Please try again!", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.UseWaitCursor = false;
        }
    }
}
