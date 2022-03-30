namespace Santa_Archiving_System.screens.wordToPdf
{
    partial class WordToPdf
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
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_convert = new Guna.UI2.WinForms.Guna2Button();
            this.fileName = new Guna.UI2.WinForms.Guna2TextBox();
            this.loading1 = new Santa_Archiving_System.common.loading();
            this.SuspendLayout();
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 5;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.guna2Button3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(356, 42);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(111, 36);
            this.guna2Button3.TabIndex = 75;
            this.guna2Button3.Text = "Choose File";
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BorderRadius = 5;
            this.btn_cancel.CheckedState.Parent = this.btn_cancel;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.CustomImages.Parent = this.btn_cancel;
            this.btn_cancel.FillColor = System.Drawing.Color.Red;
            this.btn_cancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.HoverState.Parent = this.btn_cancel;
            this.btn_cancel.Location = new System.Drawing.Point(239, 119);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.ShadowDecoration.Parent = this.btn_cancel;
            this.btn_cancel.Size = new System.Drawing.Size(111, 36);
            this.btn_cancel.TabIndex = 76;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_convert
            // 
            this.btn_convert.BorderRadius = 5;
            this.btn_convert.CheckedState.Parent = this.btn_convert;
            this.btn_convert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_convert.CustomImages.Parent = this.btn_convert;
            this.btn_convert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_convert.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_convert.ForeColor = System.Drawing.Color.White;
            this.btn_convert.HoverState.Parent = this.btn_convert;
            this.btn_convert.Location = new System.Drawing.Point(356, 119);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.ShadowDecoration.Parent = this.btn_convert;
            this.btn_convert.Size = new System.Drawing.Size(111, 36);
            this.btn_convert.TabIndex = 77;
            this.btn_convert.Text = "Convert";
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // fileName
            // 
            this.fileName.BorderRadius = 5;
            this.fileName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fileName.DefaultText = "";
            this.fileName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.fileName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.fileName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fileName.DisabledState.Parent = this.fileName;
            this.fileName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.fileName.Enabled = false;
            this.fileName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fileName.FocusedState.Parent = this.fileName;
            this.fileName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.fileName.HoverState.Parent = this.fileName;
            this.fileName.Location = new System.Drawing.Point(12, 42);
            this.fileName.Name = "fileName";
            this.fileName.PasswordChar = '\0';
            this.fileName.PlaceholderText = "";
            this.fileName.ReadOnly = true;
            this.fileName.SelectedText = "";
            this.fileName.ShadowDecoration.Parent = this.fileName;
            this.fileName.Size = new System.Drawing.Size(338, 36);
            this.fileName.TabIndex = 78;
            // 
            // loading1
            // 
            this.loading1.BackColor = System.Drawing.Color.Transparent;
            this.loading1.Location = new System.Drawing.Point(201, 30);
            this.loading1.Name = "loading1";
            this.loading1.Size = new System.Drawing.Size(72, 74);
            this.loading1.TabIndex = 79;
            this.loading1.Visible = false;
            // 
            // WordToPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 179);
            this.Controls.Add(this.loading1);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.guna2Button3);
            this.Name = "WordToPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convert";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
        private Guna.UI2.WinForms.Guna2Button btn_convert;
        private Guna.UI2.WinForms.Guna2TextBox fileName;
        private common.loading loading1;
    }
}