namespace Santa_Archiving_System.screens.sendToEmail
{
    partial class EmailContents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_recipient = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_subject = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_body = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_send = new Guna.UI2.WinForms.Guna2Button();
            this.lb_attachement = new System.Windows.Forms.Label();
            this.lb_extension = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_recipient
            // 
            this.tb_recipient.BorderRadius = 10;
            this.tb_recipient.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_recipient.DefaultText = "";
            this.tb_recipient.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_recipient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_recipient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_recipient.DisabledState.Parent = this.tb_recipient;
            this.tb_recipient.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_recipient.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_recipient.FocusedState.Parent = this.tb_recipient;
            this.tb_recipient.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_recipient.HoverState.Parent = this.tb_recipient;
            this.tb_recipient.Location = new System.Drawing.Point(26, 73);
            this.tb_recipient.Margin = new System.Windows.Forms.Padding(4);
            this.tb_recipient.Name = "tb_recipient";
            this.tb_recipient.PasswordChar = '\0';
            this.tb_recipient.PlaceholderText = "";
            this.tb_recipient.SelectedText = "";
            this.tb_recipient.ShadowDecoration.Parent = this.tb_recipient;
            this.tb_recipient.Size = new System.Drawing.Size(482, 47);
            this.tb_recipient.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Recipients :";
            // 
            // tb_subject
            // 
            this.tb_subject.BorderRadius = 10;
            this.tb_subject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_subject.DefaultText = "";
            this.tb_subject.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_subject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_subject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_subject.DisabledState.Parent = this.tb_subject;
            this.tb_subject.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_subject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_subject.FocusedState.Parent = this.tb_subject;
            this.tb_subject.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_subject.HoverState.Parent = this.tb_subject;
            this.tb_subject.Location = new System.Drawing.Point(26, 157);
            this.tb_subject.Margin = new System.Windows.Forms.Padding(4);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.PasswordChar = '\0';
            this.tb_subject.PlaceholderText = "";
            this.tb_subject.SelectedText = "";
            this.tb_subject.ShadowDecoration.Parent = this.tb_subject;
            this.tb_subject.Size = new System.Drawing.Size(482, 47);
            this.tb_subject.TabIndex = 4;
            this.tb_subject.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Subject :";
            // 
            // tb_body
            // 
            this.tb_body.Location = new System.Drawing.Point(26, 244);
            this.tb_body.Name = "tb_body";
            this.tb_body.Size = new System.Drawing.Size(482, 135);
            this.tb_body.TabIndex = 6;
            this.tb_body.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Body :";
            // 
            // btn_send
            // 
            this.btn_send.BorderRadius = 5;
            this.btn_send.CheckedState.Parent = this.btn_send;
            this.btn_send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send.CustomImages.Parent = this.btn_send;
            this.btn_send.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_send.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_send.ForeColor = System.Drawing.Color.White;
            this.btn_send.HoverState.Parent = this.btn_send;
            this.btn_send.Location = new System.Drawing.Point(423, 451);
            this.btn_send.Name = "btn_send";
            this.btn_send.ShadowDecoration.Parent = this.btn_send;
            this.btn_send.Size = new System.Drawing.Size(85, 36);
            this.btn_send.TabIndex = 73;
            this.btn_send.Text = "Send";
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lb_attachement
            // 
            this.lb_attachement.AutoEllipsis = true;
            this.lb_attachement.AutoSize = true;
            this.lb_attachement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_attachement.Location = new System.Drawing.Point(22, 418);
            this.lb_attachement.MaximumSize = new System.Drawing.Size(462, 20);
            this.lb_attachement.Name = "lb_attachement";
            this.lb_attachement.Size = new System.Drawing.Size(110, 20);
            this.lb_attachement.TabIndex = 74;
            this.lb_attachement.Text = "Attachment";
            // 
            // lb_extension
            // 
            this.lb_extension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_extension.AutoSize = true;
            this.lb_extension.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_extension.Location = new System.Drawing.Point(467, 417);
            this.lb_extension.Name = "lb_extension";
            this.lb_extension.Size = new System.Drawing.Size(41, 21);
            this.lb_extension.TabIndex = 75;
            this.lb_extension.Text = ".pdf";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Santa_Archiving_System.Properties.Resources.icons8_attach_50;
            this.pictureBox1.Location = new System.Drawing.Point(26, 395);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // EmailContents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(527, 497);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_extension);
            this.Controls.Add(this.lb_attachement);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_body);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_recipient);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailContents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send to Email";
            this.Load += new System.EventHandler(this.EmailContents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tb_recipient;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tb_subject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox tb_body;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btn_send;
        private System.Windows.Forms.Label lb_attachement;
        private System.Windows.Forms.Label lb_extension;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}