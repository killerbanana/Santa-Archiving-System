using Santa_Archiving_System.models;
using Santa_Archiving_System.services.ordinance;
using Santa_Archiving_System.services.resolution;
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
        String path = "";
        EmailContent emailContent;
        public EmailContents(EmailContent data)
        {
            this.emailContent = data;
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void EmailContents_Load(object sender, EventArgs e)
        {
            lb_attachement.Text = emailContent.FileName;
            lb_extension.Text = emailContent.DocType;

            switch (emailContent.Type)
            {
                case "Resolution":
                    path = await Resolutions.CreateNewFileOnline(emailContent.Id.ToString(), emailContent.DocType);
                    break;
                case "Ordinance":
                    path = await Ordinances.CreateNewFileOnline(emailContent.Id.ToString(), emailContent.DocType);
                    break;
            }
            
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {

            if (tb_recipient.Text == string.Empty || tb_subject.Text == string.Empty)
            {
                MessageBox.Show("Fill all the fields.");
                return;
            }
            if (!IsValidEmail(tb_recipient.Text))
            {
                MessageBox.Show("Invalid email address!");
                return;
            }
            loading1.Visible = true;
            await sendMail(tb_recipient.Text, tb_body.Text, tb_subject.Text, emailContent.DocType);
            tb_recipient.Text = "";
            tb_body.Text = "";
            loading1.Visible = false;
            MessageBox.Show("Mail successfully sent.");
        }

        private static async Task sendMail(string rescipient, string body,  string subject, string content)
        {
            await Task.Run(() =>
            {
                MailMessage message = new MailMessage();
                message.To.Add(rescipient);
                message.From = new MailAddress("santalgu2022@gmail.com");
                message.Body = body;
                message.Subject = subject;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                System.Net.Mail.Attachment attachment;
                if (content== ".pdf")
                {
                    attachment = new System.Net.Mail.Attachment("C:\\New folder\\2.pdf");
                    message.Attachments.Add(attachment);
                }
                else if (content== ".docx")
                {
                    attachment = new System.Net.Mail.Attachment("C:\\New folder\\1.docx");
                    message.Attachments.Add(attachment);
                }

                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new System.Net.NetworkCredential("santalgu2022@gmail.com", @"uGB-WwL)[A3LAdV6");

                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }
    }
}
