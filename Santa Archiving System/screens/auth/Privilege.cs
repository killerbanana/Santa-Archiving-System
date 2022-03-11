using Santa_Archiving_System.models;
using Santa_Archiving_System.services.account;
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
        public static bool privilegeEmpty;

        public Privilege(account data)
        {
            this.account = data;
            InitializeComponent();
        }



        private void Privilege_Load(object sender, EventArgs e)
        {

            privilegeEmpty = true;
            if (account.privilege != null || account.index != null)
            {
                List<String> list = account.privilege.ToList();
                List<int> index = account.index.ToList();
                list.ForEach(delegate (string s) {

                    for (int x = 0; x < clb_privilege.Items.Count; x++)
                    {
                        index.ForEach(delegate (int i)
                        {
                            if (x == i)
                            {

                                clb_privilege.SetItemChecked(i, true);
                            }

                        });
                    }

                });
            }
           
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

 
            account.privilege = new List<string>();
            account.index = new List<int>();
            for (int i = 0; i < clb_privilege.Items.Count; i++)
            {
                if (clb_privilege.GetItemChecked(i))
                {
                    privilegeEmpty = false;
                    switch (i)
                    {
                        case 0:
                            account.privilege.Add("Appropriation");
                            account.index.Add(0);
                            break;
                        case 1:
                            account.privilege.Add("Legislative");
                            account.index.Add(1);
                            break;
                        case 2:
                            account.privilege.Add("Ordinance");
                            account.index.Add(2);
                            break;
                        case 3:
                            account.privilege.Add("SB Information");
                            account.index.Add(3);
                            break;
                        case 4:
                            account.privilege.Add("Tricycle");
                            account.index.Add(4);
                            break;
                        case 5:
                            account.privilege.Add("Account Management");
                            account.index.Add(5);
                            break;

                    }



                }
            }

            this.Close();
        }

    }
}