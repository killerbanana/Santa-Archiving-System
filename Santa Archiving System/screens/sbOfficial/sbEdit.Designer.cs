namespace Santa_Archiving_System.screens.sbOfficial
{
    partial class sbEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sbEdit));
            this.lbl_birthday = new System.Windows.Forms.Label();
            this.btn_update = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_contactNo = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.pb_profile = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_birthday
            // 
            this.lbl_birthday.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_birthday.Location = new System.Drawing.Point(347, 79);
            this.lbl_birthday.Name = "lbl_birthday";
            this.lbl_birthday.Size = new System.Drawing.Size(234, 21);
            this.lbl_birthday.TabIndex = 205;
            this.lbl_birthday.Text = "birthday";
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
            this.btn_update.Location = new System.Drawing.Point(198, 487);
            this.btn_update.Name = "btn_update";
            this.btn_update.ShadowDecoration.Parent = this.btn_update;
            this.btn_update.Size = new System.Drawing.Size(413, 45);
            this.btn_update.TabIndex = 194;
            this.btn_update.TabStop = false;
            this.btn_update.Text = "Update";
            // 
            // lbl_contactNo
            // 
            this.lbl_contactNo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_contactNo.Location = new System.Drawing.Point(347, 129);
            this.lbl_contactNo.Name = "lbl_contactNo";
            this.lbl_contactNo.Size = new System.Drawing.Size(234, 21);
            this.lbl_contactNo.TabIndex = 203;
            this.lbl_contactNo.Text = "cpNo";
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_address.Location = new System.Drawing.Point(347, 104);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(70, 21);
            this.lbl_address.TabIndex = 202;
            this.lbl_address.Text = "address";
            // 
            // lbl_gender
            // 
            this.lbl_gender.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_gender.Location = new System.Drawing.Point(347, 53);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(234, 21);
            this.lbl_gender.TabIndex = 201;
            this.lbl_gender.Text = "gender";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_name.Location = new System.Drawing.Point(347, 28);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(56, 21);
            this.lbl_name.TabIndex = 200;
            this.lbl_name.Text = "name";
            // 
            // pb_profile
            // 
            this.pb_profile.BorderRadius = 5;
            this.pb_profile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_profile.Image = ((System.Drawing.Image)(resources.GetObject("pb_profile.Image")));
            this.pb_profile.Location = new System.Drawing.Point(200, 28);
            this.pb_profile.Name = "pb_profile";
            this.pb_profile.ShadowDecoration.Parent = this.pb_profile;
            this.pb_profile.Size = new System.Drawing.Size(141, 121);
            this.pb_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_profile.TabIndex = 204;
            this.pb_profile.TabStop = false;
            // 
            // sbEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 561);
            this.Controls.Add(this.pb_profile);
            this.Controls.Add(this.lbl_birthday);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_contactNo);
            this.Controls.Add(this.lbl_address);
            this.Controls.Add(this.lbl_gender);
            this.Controls.Add(this.lbl_name);
            this.Name = "sbEdit";
            this.Text = "sbEdit";
            ((System.ComponentModel.ISupportInitialize)(this.pb_profile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pb_profile;
        private System.Windows.Forms.Label lbl_birthday;
        private Guna.UI2.WinForms.Guna2Button btn_update;
        private System.Windows.Forms.Label lbl_contactNo;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.Label lbl_name;
    }
}