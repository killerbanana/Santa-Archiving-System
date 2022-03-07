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
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            _thePanel.Location = new Point(
             this.ClientSize.Width / 2 - _thePanel.Size.Width / 2,
            this.ClientSize.Height / 2 - _thePanel.Size.Height / 2);
            _thePanel.Anchor = AnchorStyles.None;
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
        private void tb_middleName_TabStopChanged(object sender, EventArgs e)
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

        private void cb_accountRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_accountRole.SelectedIndex == 1)
            {
                lbl_accountRole.Visible = false;
            }

            else if(cb_accountRole.SelectedIndex == 0)
            {
                lbl_accountRole.Visible = false;
            }
            else
            {
                lbl_accountRole.Visible = true;
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
        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
        private void btn_create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_firstName.Text)||
                string.IsNullOrWhiteSpace(tb_middleName.Text)||
                string.IsNullOrWhiteSpace(tb_lastName.Text)||
                string.IsNullOrWhiteSpace(cb_accountRole.Text)||
                string.IsNullOrWhiteSpace(tb_username.Text) ||
                string.IsNullOrWhiteSpace(tb_password.Text) ||
                string.IsNullOrWhiteSpace(tb_confirmPassword.Text) )
            {
                MessageBox.Show("Please fill up all required fields!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }
        }

     
    }
}
