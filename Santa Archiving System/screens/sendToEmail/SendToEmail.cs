using Santa_Archiving_System.models;
using Santa_Archiving_System.services.ordinance;
using Santa_Archiving_System.services.resolution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.sendToEmail
{
    public partial class SendToEmail : Form
    {
        EmailContent emailContent;
        public SendToEmail(EmailContent data)
        {
            this.emailContent = data;
            InitializeComponent();
        }

        private async void SendToEmail_Load(object sender, EventArgs e)
        {
            lb_data.Text = emailContent.Type;
            loading1.Visible = true;
            switch (emailContent.Type) {
                case "Resolution":
                    guna2DataGridView1.DataSource = await Resolutions.getListOnline();
                    break;
                case "Ordinance":
                    guna2DataGridView1.DataSource = await Ordinances.getListOrdinanceOnline();
                    break;
            }
            loading1.Visible = false;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            EmailContents emailContents = new EmailContents(emailContent);
            emailContents.ShowDialog();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
            {
                emailContent = new EmailContent()
                {
                    Id = int.Parse(item.Cells[0].Value.ToString()),
                    Type = "Resolution",
                    FileName = item.Cells[3].Value.ToString(),
                    DocType = item.Cells[7].Value.ToString()
                };
            }
        }
    }
}
