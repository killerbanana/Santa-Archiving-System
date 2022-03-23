using Santa_Archiving_System.common;
using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.auth;
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

namespace Santa_Archiving_System.screens.users
{
    public partial class Profile : Form
    {
        account account;
        public Profile(account data)
        {
            this.account = data;
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
           
            tb_firstName.Text = Account.firstName;
            tb_middleName.Text = Account.middleName;
            tb_lastName.Text = Account.lastName;
            tb_gender.Text = Account.gender;
            dt_birthday.Text = Account.birthday;
            tb_address.Text = Account.address;
            tb_contactNo.Text = Account.contactNo;
            pb_profile.Image = System.Drawing.Image.FromStream(Account.image);
           
        }

      

        private void tb_contactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }
       
        private async void btn_create_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            if (ControlsServices.CheckIfOnline())
            {
                await Account.UpdateProfileOnline
              (
                  tb_firstName.Text,
                  tb_middleName.Text,
                  tb_lastName.Text,
                  tb_gender.Text,
                  dt_birthday.Text,
                  tb_address.Text,
                  tb_contactNo.Text

              );
                await Account.UpdateProfileOffline
            (
                tb_firstName.Text,
                tb_middleName.Text,
                tb_lastName.Text,
                tb_gender.Text,
                dt_birthday.Text,
                tb_address.Text,
                tb_contactNo.Text

            );
                await Account.CheckLoginOnline(Account.userName);
                ManageUser obj = (ManageUser)Application.OpenForms["ManageUser"];
                if (obj != null)
                {
                    await obj.LoadDataTableOnline();
                }
                MessageBox.Show("Successfully updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please try again!", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
              
            
            this.UseWaitCursor = false;
            this.Close();
        }

        private async void pb_profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Choose Image File";
            opf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            opf.Multiselect = false;
            try
            {
                if (opf.ShowDialog() == DialogResult.OK)
                {

                    pb_profile.Image = Image.FromFile(opf.FileName);
                    account.image = opf.FileName;
                    this.UseWaitCursor = true;

                    if (ControlsServices.CheckIfOnline())
                    {
                        await Account.UpdateProfilePicOnline(account.image);
                        await Account.UpdateProfilePicOffline(account.image);
                        await Account.CheckLoginOnline(Account.userName);

                    }
                    else
                    {
                        MessageBox.Show("Please try again!", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    MessageBox.Show("Profile has been updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.UseWaitCursor = false;

                }
            }
          
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     
    }
}
