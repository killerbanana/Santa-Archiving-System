﻿using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.services.account;
using Santa_Archiving_System.services.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.auth
{
    public partial class Registration : Form
    {
        account account;
        public Registration(account data)
        {
            this.account = data;
            InitializeComponent();
        }


        private void Registration_Load(object sender, EventArgs e)
        {
            _thePanel.Location = new Point(
            this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
           this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
            _thePanel.Anchor = AnchorStyles.None;

            cb_accountRole.SelectedIndex = 0;
            account.image = Constants.imagePath;
        }

        private void tb_contactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void tb_firstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_firstName.Text))
            {
                lbl_firstName.Visible = true;
            }
            else
            {
                lbl_firstName.Visible = false;
            }
        }


        private void tb_middleName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_middleName.Text))
            {
                lbl_middleName.Visible = true;
            }
            else
            {
                lbl_middleName.Visible = false;
            }
        }

        private void tb_lastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_lastName.Text))
            {
                lbl_lastName.Visible = true;
            }
            else
            {
                lbl_lastName.Visible = false;
            }
        }

        private void tb_username_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_username.Text))
            {
                lbl_username.Visible = true;
            }
            else
            {
                lbl_username.Visible = false;
            }
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_password.Text))
            {
                lbl_password.Visible = true;
            }
            else
            {
                lbl_password.Visible = false;
            }
        }
        private void tb_confirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_confirmPassword.Text))
            {
                lbl_confirmPassword.Visible = true;
            }
            else
            {
                lbl_confirmPassword.Visible = false;
            }
        }
       

        private void cb_accountRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_accountRole.SelectedIndex == 1)
            {
                Privilege privilege = new Privilege(account);
                privilege.ShowDialog();
                lbl_accountRole.Visible = false;
            }

            else if (cb_accountRole.SelectedIndex == 0)
            {
               
                lbl_accountRole.Visible = false;
            }
            else
            {
                lbl_accountRole.Visible = true;
            }
        }

        private async void btn_create_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(tb_firstName.Text) ||
               string.IsNullOrWhiteSpace(tb_middleName.Text) ||
               string.IsNullOrWhiteSpace(tb_lastName.Text) ||
               string.IsNullOrWhiteSpace(cb_accountRole.Text) ||
               string.IsNullOrWhiteSpace(tb_username.Text) ||
               string.IsNullOrWhiteSpace(tb_password.Text) ||
               string.IsNullOrWhiteSpace(tb_confirmPassword.Text))
            {
                MessageBox.Show("Please fill up all required fields!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                await Account.CheckUsername(tb_username.Text);
                if (Account.checkedUsername == true){

                    MessageBox.Show("Username Already Exist!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Account.checkedUsername = false;
                }
                else
                {
                    if(tb_password.Text != tb_confirmPassword.Text)
                    {
                        MessageBox.Show("Incorrect password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(tb_password.Text == tb_confirmPassword.Text)
                    {   
                        if (cb_accountRole.SelectedIndex == 0)
                        {
                            account.privilege = new List<string>();
                            account.privilege.Add("All Privilege");
                        }
                        
                        if(account.privilege.Count == 0)
                        {
                             DialogResult d = MessageBox.Show("Please select atleast one privilege", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             if (d == DialogResult.OK)
                             {
                                 Privilege privilege = new Privilege(account);
                                 privilege.ShowDialog();
                             }
                        }
                        else
                        {
                            if (ControlsServices.CheckIfOnline())
                            {


                                await Account.SaveAccountOnline
                                    (
                                    tb_firstName.Text,
                                    tb_middleName.Text,
                                    tb_lastName.Text,
                                    tb_gender.Text,
                                    dt_birthday.Text,
                                    tb_address.Text,
                                    tb_contactNo.Text,
                                    cb_accountRole.Text,
                                    string.Join(",", account.privilege.ToArray()),
                                    tb_username.Text,
                                    ControlsServices.Encrypt(tb_password.Text),
                                    account.image
                                    );
                                MessageBox.Show("Successfully Created");
                                tb_firstName.Text = String.Empty;
                                tb_middleName.Text = String.Empty;
                                tb_lastName.Text = String.Empty;
                                tb_gender.Text = String.Empty;
                                dt_birthday.Text = String.Empty;
                                tb_address.Text = String.Empty;
                                tb_contactNo.Text = String.Empty;
                                cb_accountRole.SelectedIndex = 0;
                                account.privilege.Clear();
                                tb_username.Text = String.Empty;
                                tb_password.Text = String.Empty;
                                tb_confirmPassword.Text = String.Empty;
                                pb_profile.Image = Image.FromFile(Constants.imagePath);
                            }
                        }
                          

                       



                    }
                }
            }
        }

        private void pb_profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pb_profile.Image = Image.FromFile(opf.FileName);
                account.image = opf.FileName;
             
            }
        }
    }
}
