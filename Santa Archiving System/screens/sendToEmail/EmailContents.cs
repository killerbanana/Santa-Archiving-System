using Santa_Archiving_System.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Archiving_System.screens.sendToEmail
{
    public partial class EmailContents : Form
    {
        EmailContent emailContent;
        public EmailContents(EmailContent data)
        {
            this.emailContent = data;
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailContents_Load(object sender, EventArgs e)
        {
            lb_attachement.Text = emailContent.FileName;
            lb_extension.Text = emailContent.DocType;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            message.To.Add(tb_recipient.Text);
            message.From = new MailAddress("santalgu2022@gmail.com");
            message.Body = tb_body.Text;
            message.Subject = tb_subject.Text;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential("santalgu2022@gmail.com", @"uGB-WwL)[A3LAdV6");

            try
            {
                smtpClient.Send(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
