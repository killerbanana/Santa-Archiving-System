namespace Santa_Archiving_System.screens.users
{
    partial class ChangePassword
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
            this.tb_new = new Guna.UI2.WinForms.Guna2TextBox();
            this.tb_old = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_changePassword = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_confirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_new
            // 
            this.tb_new.BorderRadius = 10;
            this.tb_new.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_new.DefaultText = "";
            this.tb_new.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_new.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_new.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_new.DisabledState.Parent = this.tb_new;
            this.tb_new.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_new.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_new.FocusedState.Parent = this.tb_new;
            this.tb_new.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_new.HoverState.Parent = this.tb_new;
            this.tb_new.Location = new System.Drawing.Point(20, 141);
            this.tb_new.Margin = new System.Windows.Forms.Padding(5);
            this.tb_new.Name = "tb_new";
            this.tb_new.PasswordChar = '*';
            this.tb_new.PlaceholderText = "";
            this.tb_new.SelectedText = "";
            this.tb_new.ShadowDecoration.Parent = this.tb_new;
            this.tb_new.Size = new System.Drawing.Size(270, 47);
            this.tb_new.TabIndex = 6;
            this.tb_new.TextChanged += new System.EventHandler(this.tb_new_TextChanged);
            // 
            // tb_old
            // 
            this.tb_old.BorderRadius = 10;
            this.tb_old.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_old.DefaultText = "";
            this.tb_old.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_old.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_old.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_old.DisabledState.Parent = this.tb_old;
            this.tb_old.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_old.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_old.FocusedState.Parent = this.tb_old;
            this.tb_old.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_old.HoverState.Parent = this.tb_old;
            this.tb_old.Location = new System.Drawing.Point(20, 50);
            this.tb_old.Margin = new System.Windows.Forms.Padding(4);
            this.tb_old.Name = "tb_old";
            this.tb_old.PasswordChar = '*';
            this.tb_old.PlaceholderText = "";
            this.tb_old.SelectedText = "";
            this.tb_old.ShadowDecoration.Parent = this.tb_old;
            this.tb_old.Size = new System.Drawing.Size(273, 47);
            this.tb_old.TabIndex = 5;
            this.tb_old.TextChanged += new System.EventHandler(this.tb_old_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Old password";
            // 
            // btn_changePassword
            // 
            this.btn_changePassword.BorderRadius = 10;
            this.btn_changePassword.CheckedState.Parent = this.btn_changePassword;
            this.btn_changePassword.CustomImages.Parent = this.btn_changePassword;
            this.btn_changePassword.Enabled = false;
            this.btn_changePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_changePassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_changePassword.ForeColor = System.Drawing.Color.White;
            this.btn_changePassword.HoverState.Parent = this.btn_changePassword;
            this.btn_changePassword.Location = new System.Drawing.Point(18, 306);
            this.btn_changePassword.Name = "btn_changePassword";
            this.btn_changePassword.ShadowDecoration.Parent = this.btn_changePassword;
            this.btn_changePassword.Size = new System.Drawing.Size(272, 45);
            this.btn_changePassword.TabIndex = 9;
            this.btn_changePassword.TabStop = false;
            this.btn_changePassword.Text = "Save";
            this.btn_changePassword.Click += new System.EventHandler(this.btn_changePassword_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(18, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "New Password";
            // 
            // tb_confirm
            // 
            this.tb_confirm.BorderRadius = 10;
            this.tb_confirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_confirm.DefaultText = "";
            this.tb_confirm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_confirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_confirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_confirm.DisabledState.Parent = this.tb_confirm;
            this.tb_confirm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_confirm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_confirm.FocusedState.Parent = this.tb_confirm;
            this.tb_confirm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_confirm.HoverState.Parent = this.tb_confirm;
            this.tb_confirm.Location = new System.Drawing.Point(20, 238);
            this.tb_confirm.Margin = new System.Windows.Forms.Padding(5);
            this.tb_confirm.Name = "tb_confirm";
            this.tb_confirm.PasswordChar = '*';
            this.tb_confirm.PlaceholderText = "";
            this.tb_confirm.SelectedText = "";
            this.tb_confirm.ShadowDecoration.Parent = this.tb_confirm;
            this.tb_confirm.Size = new System.Drawing.Size(270, 47);
            this.tb_confirm.TabIndex = 10;
            this.tb_confirm.TextChanged += new System.EventHandler(this.tb_confirm_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(21, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Confirm password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 378);
            this.Controls.Add(this.tb_confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_new);
            this.Controls.Add(this.tb_old);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_changePassword);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tb_new;
        private Guna.UI2.WinForms.Guna2TextBox tb_old;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_changePassword;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox tb_confirm;
        private System.Windows.Forms.Label label1;
    }
}