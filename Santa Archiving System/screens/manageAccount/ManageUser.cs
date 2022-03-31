using Santa_Archiving_System.models;
using Santa_Archiving_System.screens.manageAccount;
using Santa_Archiving_System.services.account;
using Santa_Archiving_System.services.controls;
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

namespace Santa_Archiving_System.screens.auth
{
    public partial class ManageUser : Form
    {
        updateAccount updateaccount;

        public ManageUser(updateAccount data)
        {   
           
            this.updateaccount = data;
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            account data = new account();
            Registration registration = new Registration(data);
            registration.ShowDialog();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(updateaccount.username))
            {
                MessageBox.Show("Please select account to update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UpdateUser updateUser = new UpdateUser(updateaccount);
                updateUser.ShowDialog();
            }
        }

        public async Task LoadDataTableOnline()
        {
            try
            {
                dt_users.DataSource = await Account.getUsersListOnline();
                dt_users.Columns[1].HeaderText = "Firstname";
                dt_users.Columns[2].HeaderText = "Middlename";
                dt_users.Columns[3].HeaderText = "Lastname";
                dt_users.Columns[0].Visible = false;
                dt_users.Columns[5].Visible = false;
                dt_users.Columns[13].Visible = false;
                dt_users.Columns[14].Visible = false;
                dt_users.Columns[15].Visible = false;
                dt_users.ClearSelection();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
        }

        private async void ManageUser_Load(object sender, EventArgs e)
        {   
           
        
            loading1.Visible = true;
            if (ControlsServices.CheckIfOnline())
            {
                await LoadDataTableOnline();
                
            }
            else
            {
                MessageBox.Show("No data to be shown", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            loading1.Visible = false;
        }

        private async void btn_refresh_Click(object sender, EventArgs e)
        {
            loading1.Visible = true;
            if (ControlsServices.CheckIfOnline())
            {
                await LoadDataTableOnline();
                updateaccount.username = string.Empty;
            }
            else
            {
                MessageBox.Show("No data to be shown", "Internet connection lost", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            loading1.Visible = false;
        }

     

        private async void btn_delete_Click(object sender, EventArgs e)
        {
            loading1.Visible = true;
            if (String.IsNullOrWhiteSpace(updateaccount.username))
            {
                MessageBox.Show("Please select account to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to delete this Data?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    await Account.DeleteUserOnline(updateaccount.username);
                    await Account.DeleteUserOffline(updateaccount.username);
                    await LoadDataTableOnline();
                    MessageBox.Show("Successfully deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateaccount.username = string.Empty;
                }
                   
            }
            loading1.Visible = false;
        }

        private void dt_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string privilege;
                foreach (DataGridViewRow item in this.dt_users.SelectedRows)
                {
                    string listText = "";
                    updateaccount.firstName = item.Cells[1].Value.ToString();
                    updateaccount.middleName = item.Cells[2].Value.ToString();
                    updateaccount.lastName = item.Cells[3].Value.ToString();
                    updateaccount.suffix = item.Cells[4].Value.ToString();
                    byte[] bytes = (byte[])item.Cells[5].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    updateaccount.image = ms;
                    updateaccount.gender = item.Cells[6].Value.ToString();
                    updateaccount.birthday = item.Cells[7].Value.ToString();
                    updateaccount.address = item.Cells[8].Value.ToString();
                    updateaccount.contactNo = item.Cells[9].Value.ToString();
                    updateaccount.accountRole = item.Cells[10].Value.ToString();
                    listText = item.Cells[11].Value.ToString();
                    privilege = item.Cells[11].Value.ToString();
                    updateaccount.privilege = privilege.Split(',').ToList();
                    updateaccount.status = Convert.ToBoolean(item.Cells[14].Value);
                    updateaccount.username = item.Cells[12].Value.ToString();

                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         
        }

        private async void tb_searchBox_TextChanged(object sender, EventArgs e)
        {
            if (dt_users == null || dt_users.Rows.Count == 0)
            {
                if (ControlsServices.CheckIfOnline())
                {
                    await LoadDataTableOnline();
                }
             
            }
            else
            {
                (dt_users.DataSource as DataTable).DefaultView.RowFilter = string.Format("[FirstName] LIKE '%{0}%' OR [Username] LIKE '%{0}%'  OR [LastName] LIKE '%{0}%' ", tb_searchBox.Text);
            }
        }

      
    }
}
