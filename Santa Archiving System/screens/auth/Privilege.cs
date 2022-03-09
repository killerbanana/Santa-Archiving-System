using Santa_Archiving_System.models;
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
    public partial class Privilege : Form
    {
        account account;
        

        public Privilege(account data)
        {
            this.account = data;
            InitializeComponent();
        }

       

        private void Privilege_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            account.privilege = new List<string>();
            int y = 0;
            for (int i = 0; i < clb_privilege.Items.Count; i++)
            {
                if (clb_privilege.GetItemChecked(i))
                {
                    if (y == 0)
                    {
                        account.privilege.Add(clb_privilege.Items[i].ToString());
                    }
                    else
                    {
                        account.privilege.Add(clb_privilege.Items[i].ToString());
                    }
                    y++;
                }
            }
         
            this.Close();
        }

        private void clb_privilege_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
        }
    }
}
