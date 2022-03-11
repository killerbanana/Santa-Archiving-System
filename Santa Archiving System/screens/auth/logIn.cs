using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Santa_Archiving_System.screens.mainPanel;
using Santa_Archiving_System.services.account;
using Santa_Archiving_System.services.controls;

namespace Santa_Archiving_System.screens.auth
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(tb_username.Text) || string.IsNullOrWhiteSpace(tb_password.Text))
            {
              
                MessageBox.Show("Please fill up all required fields!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ControlsServices.CheckIfOnline())
                {
                    await Account.CheckLoginOnline(tb_username.Text);
                    if (Account.checkedLoginOnline == true)
                    {
                        
                        

                        if (tb_password.Text == ControlsServices.Decrypt(Account.password))
                        {   
                            if(Account.status == true)
                            {
                                MainPanel mainPanel = new MainPanel();
                                this.Hide();
                                mainPanel.Show();
                            }
                            else
                            {
                                MessageBox.Show("Sorry, your account is deactivated.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Username doesn't exist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                  
                    }

                }
                else
                {
                    
                     await Account.CheckLoginOffline(tb_username.Text);
                    if (Account.checkedLoginOffline == true)
                    {

                        if (tb_password.Text == ControlsServices.Decrypt(Account.password))
                        {
                            if (Account.status == true)
                            {
                                MainPanel mainPanel = new MainPanel();
                                this.Hide();
                                mainPanel.Show();
                            }
                            else
                            {
                                MessageBox.Show("Sorry, your account is deactivated.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Username doesn't exist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    }
                }
             

            }

        }
    }
}
