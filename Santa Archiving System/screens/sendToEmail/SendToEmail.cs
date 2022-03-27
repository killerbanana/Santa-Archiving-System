using Santa_Archiving_System.models;
using Santa_Archiving_System.services.appropriation;
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
                case "Appropriation":
                    guna2DataGridView1.DataSource = await Appropriations.getListOnline();
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
            switch (emailContent.Type)
            {
                case "Resolution":
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

                    break;
                case "Ordinance":
                    foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
                    {
                        emailContent = new EmailContent()
                        {
                            Id = int.Parse(item.Cells[0].Value.ToString()),
                            Type = "Ordinance",
                            FileName = item.Cells[3].Value.ToString(),
                            DocType = item.Cells[7].Value.ToString()
                        };
                    }
                    break;
                case "Appropriation":
                    foreach (DataGridViewRow item in this.guna2DataGridView1.SelectedRows)
                    {
                        emailContent = new EmailContent()
                        {
                            Id = int.Parse(item.Cells[0].Value.ToString()),
                            Type = "Appropriation",
                            FileName = item.Cells[3].Value.ToString(),
                            DocType = item.Cells[7].Value.ToString()
                        };
                    }
                    break;
            }
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            switch (emailContent.Type)
            {
                case "Resolution":
                    if (String.IsNullOrWhiteSpace(guna2TextBox1.Text))
                    {


                    }
                    else
                    {
                        (guna2DataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[ResolutionNo] LIKE '%{0}%' OR [Series] LIKE '%{0}%'  OR [Date] LIKE '%{0}%' OR  [Title] LIKE '%{0}%' OR  [Author] LIKE '%{0}%' OR  [Tag] LIKE '%{0}%'", guna2TextBox1.Text);
                    }
                    break;
                case "Ordinance":
                    if (String.IsNullOrWhiteSpace(guna2TextBox1.Text))
                    {


                    }
                    else
                    {
                        (guna2DataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[OrdinanceNo] LIKE '%{0}%' OR [Series] LIKE '%{0}%'  OR [Date] LIKE '%{0}%' OR  [Title] LIKE '%{0}%' OR  [Author] LIKE '%{0}%' OR  [Tag] LIKE '%{0}%'", guna2TextBox1.Text);
                    }
                    break;
            }
        }
    }
}
