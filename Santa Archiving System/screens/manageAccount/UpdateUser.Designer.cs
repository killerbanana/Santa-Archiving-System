namespace Santa_Archiving_System.screens.manageAccount
{
    partial class UpdateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateUser));
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.clb_privilege = new System.Windows.Forms.CheckedListBox();
            this.lbl_status = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ts_status = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.cb_accountRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btn_update = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_contactNo = new System.Windows.Forms.Label();
            this.lbl_birthday = new System.Windows.Forms.Label();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pb_profile = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(10, 288);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(141, 23);
            this.guna2HtmlLabel5.TabIndex = 151;
            this.guna2HtmlLabel5.TabStop = false;
            this.guna2HtmlLabel5.Text = "Account Privilege";
            // 
            // clb_privilege
            // 
            this.clb_privilege.BackColor = System.Drawing.Color.White;
            this.clb_privilege.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clb_privilege.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clb_privilege.FormattingEnabled = true;
            this.clb_privilege.Items.AddRange(new object[] {
            "Appropriation Monitoring System",
            "Legislative Records Management",
            "Ordinance Monitoring System",
            "SB Officials Information System",
            "Tricycle Franchise Management System",
            "User Security Management"});
            this.clb_privilege.Location = new System.Drawing.Point(10, 317);
            this.clb_privilege.Name = "clb_privilege";
            this.clb_privilege.Size = new System.Drawing.Size(354, 126);
            this.clb_privilege.TabIndex = 150;
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(12, 143);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(56, 23);
            this.lbl_status.TabIndex = 148;
            this.lbl_status.TabStop = false;
            this.lbl_status.Text = "Active";
            // 
            // ts_status
            // 
            this.ts_status.Checked = true;
            this.ts_status.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ts_status.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ts_status.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ts_status.CheckedState.InnerColor = System.Drawing.Color.White;
            this.ts_status.CheckedState.Parent = this.ts_status;
            this.ts_status.Location = new System.Drawing.Point(113, 147);
            this.ts_status.Name = "ts_status";
            this.ts_status.ShadowDecoration.Parent = this.ts_status;
            this.ts_status.Size = new System.Drawing.Size(40, 19);
            this.ts_status.TabIndex = 146;
            this.ts_status.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ts_status.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ts_status.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ts_status.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.ts_status.UncheckedState.Parent = this.ts_status;
            this.ts_status.CheckedChanged += new System.EventHandler(this.ts_status_CheckedChanged);
            // 
            // cb_accountRole
            // 
            this.cb_accountRole.BackColor = System.Drawing.Color.Transparent;
            this.cb_accountRole.BorderRadius = 5;
            this.cb_accountRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_accountRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_accountRole.FocusedColor = System.Drawing.Color.Empty;
            this.cb_accountRole.FocusedState.Parent = this.cb_accountRole;
            this.cb_accountRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_accountRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_accountRole.FormattingEnabled = true;
            this.cb_accountRole.HoverState.Parent = this.cb_accountRole;
            this.cb_accountRole.ItemHeight = 30;
            this.cb_accountRole.Items.AddRange(new object[] {
            "Admin",
            "Staff"});
            this.cb_accountRole.ItemsAppearance.Parent = this.cb_accountRole;
            this.cb_accountRole.Location = new System.Drawing.Point(10, 245);
            this.cb_accountRole.Name = "cb_accountRole";
            this.cb_accountRole.ShadowDecoration.Parent = this.cb_accountRole;
            this.cb_accountRole.Size = new System.Drawing.Size(167, 36);
            this.cb_accountRole.TabIndex = 136;
            this.cb_accountRole.TabStop = false;
            this.cb_accountRole.SelectedIndexChanged += new System.EventHandler(this.cb_accountRole_SelectedIndexChanged);
            // 
            // btn_update
            // 
            this.btn_update.BorderRadius = 10;
            this.btn_update.CheckedState.Parent = this.btn_update;
            this.btn_update.CustomImages.Parent = this.btn_update;
            this.btn_update.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.HoverState.Parent = this.btn_update;
            this.btn_update.Location = new System.Drawing.Point(10, 471);
            this.btn_update.Name = "btn_update";
            this.btn_update.ShadowDecoration.Parent = this.btn_update;
            this.btn_update.Size = new System.Drawing.Size(413, 45);
            this.btn_update.TabIndex = 122;
            this.btn_update.TabStop = false;
            this.btn_update.Text = "Update";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(10, 216);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(110, 23);
            this.guna2HtmlLabel3.TabIndex = 115;
            this.guna2HtmlLabel3.TabStop = false;
            this.guna2HtmlLabel3.Text = "Account Role";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_name.Location = new System.Drawing.Point(159, 12);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(56, 21);
            this.lbl_name.TabIndex = 152;
            this.lbl_name.Text = "name";
            // 
            // lbl_gender
            // 
            this.lbl_gender.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_gender.Location = new System.Drawing.Point(159, 37);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(234, 21);
            this.lbl_gender.TabIndex = 153;
            this.lbl_gender.Text = "gender";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_address.Location = new System.Drawing.Point(159, 88);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(70, 21);
            this.lbl_address.TabIndex = 154;
            this.lbl_address.Text = "address";
            // 
            // lbl_contactNo
            // 
            this.lbl_contactNo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_contactNo.Location = new System.Drawing.Point(159, 113);
            this.lbl_contactNo.Name = "lbl_contactNo";
            this.lbl_contactNo.Size = new System.Drawing.Size(234, 21);
            this.lbl_contactNo.TabIndex = 155;
            this.lbl_contactNo.Text = "cpNo";
            // 
            // lbl_birthday
            // 
            this.lbl_birthday.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_birthday.Location = new System.Drawing.Point(159, 63);
            this.lbl_birthday.Name = "lbl_birthday";
            this.lbl_birthday.Size = new System.Drawing.Size(234, 21);
            this.lbl_birthday.TabIndex = 191;
            this.lbl_birthday.Text = "birthday";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(10, 180);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(151, 30);
            this.guna2HtmlLabel7.TabIndex = 120;
            this.guna2HtmlLabel7.TabStop = false;
            this.guna2HtmlLabel7.Text = "Account Info";
            // 
            // pb_profile
            // 
            this.pb_profile.BorderRadius = 5;
            this.pb_profile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_profile.Image = ((System.Drawing.Image)(resources.GetObject("pb_profile.Image")));
            this.pb_profile.Location = new System.Drawing.Point(12, 12);
            this.pb_profile.Name = "pb_profile";
            this.pb_profile.ShadowDecoration.Parent = this.pb_profile;
            this.pb_profile.Size = new System.Drawing.Size(141, 121);
            this.pb_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_profile.TabIndex = 190;
            this.pb_profile.TabStop = false;
            this.pb_profile.Click += new System.EventHandler(this.pb_profile_Click);
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 525);
            this.Controls.Add(this.pb_profile);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.lbl_birthday);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_contactNo);
            this.Controls.Add(this.cb_accountRole);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.ts_status);
            this.Controls.Add(this.lbl_gender);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.clb_privilege);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update User";
            this.Load += new System.EventHandler(this.UpdateUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lbl_status;
        private Guna.UI2.WinForms.Guna2ToggleSwitch ts_status;
        private Guna.UI2.WinForms.Guna2ComboBox cb_accountRole;
        private Guna.UI2.WinForms.Guna2Button btn_update;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private System.Windows.Forms.CheckedListBox clb_privilege;
        private System.Windows.Forms.Label lbl_contactNo;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_birthday;
        private Guna.UI2.WinForms.Guna2PictureBox pb_profile;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
    }
}