namespace Santa_Archiving_System.screens.auth
{
    partial class UserSettings
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
            this.btn_logout = new Guna.UI2.WinForms.Guna2Button();
            this.btn_account = new Guna.UI2.WinForms.Guna2Button();
            this.btn_changePassword = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btn_logout
            // 
            this.btn_logout.BorderRadius = 10;
            this.btn_logout.CheckedState.Parent = this.btn_logout;
            this.btn_logout.CustomImages.Parent = this.btn_logout;
            this.btn_logout.FillColor = System.Drawing.Color.Red;
            this.btn_logout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.HoverState.Parent = this.btn_logout;
            this.btn_logout.Location = new System.Drawing.Point(12, 134);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.ShadowDecoration.Parent = this.btn_logout;
            this.btn_logout.Size = new System.Drawing.Size(174, 45);
            this.btn_logout.TabIndex = 97;
            this.btn_logout.Text = "Log out";
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_account
            // 
            this.btn_account.BorderRadius = 10;
            this.btn_account.CheckedState.Parent = this.btn_account;
            this.btn_account.CustomImages.Parent = this.btn_account;
            this.btn_account.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_account.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_account.ForeColor = System.Drawing.Color.White;
            this.btn_account.HoverState.Parent = this.btn_account;
            this.btn_account.Location = new System.Drawing.Point(12, 12);
            this.btn_account.Name = "btn_account";
            this.btn_account.ShadowDecoration.Parent = this.btn_account;
            this.btn_account.Size = new System.Drawing.Size(174, 45);
            this.btn_account.TabIndex = 98;
            this.btn_account.Text = "Account";
            // 
            // btn_changePassword
            // 
            this.btn_changePassword.BorderRadius = 10;
            this.btn_changePassword.CheckedState.Parent = this.btn_changePassword;
            this.btn_changePassword.CustomImages.Parent = this.btn_changePassword;
            this.btn_changePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_changePassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_changePassword.ForeColor = System.Drawing.Color.White;
            this.btn_changePassword.HoverState.Parent = this.btn_changePassword;
            this.btn_changePassword.Location = new System.Drawing.Point(12, 72);
            this.btn_changePassword.Name = "btn_changePassword";
            this.btn_changePassword.ShadowDecoration.Parent = this.btn_changePassword;
            this.btn_changePassword.Size = new System.Drawing.Size(174, 45);
            this.btn_changePassword.TabIndex = 99;
            this.btn_changePassword.Text = "Change password";
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 191);
            this.Controls.Add(this.btn_changePassword);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.btn_account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_logout;
        private Guna.UI2.WinForms.Guna2Button btn_account;
        private Guna.UI2.WinForms.Guna2Button btn_changePassword;
    }
}