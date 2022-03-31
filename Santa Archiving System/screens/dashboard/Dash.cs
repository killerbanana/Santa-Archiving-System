using Santa_Archiving_System.services.account;
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
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
        }
        public async Task LoadDataTableOnline()
        {
            try
            {
                dt_activities.DataSource = await dash.getActivities();          
                dt_activities.ClearSelection();

                dt_users.DataSource = await Account.getOnlineUsers();
                dt_users.Columns[1].HeaderText = "Name";
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        private async void Dash_Load(object sender, EventArgs e)
        {
            await LoadDataTableOnline();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }
    }
}
