namespace Santa_Archiving_System.screens.auth
{
    partial class ManageUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_refresh = new Guna.UI2.WinForms.Guna2Button();
            this.btn_delete = new Guna.UI2.WinForms.Guna2Button();
            this.btn_update = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.tb_searchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dt_users = new Guna.UI2.WinForms.Guna2DataGridView();
            this.loading1 = new Santa_Archiving_System.common.loading();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_users)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btn_refresh);
            this.panel5.Controls.Add(this.btn_delete);
            this.panel5.Controls.Add(this.btn_update);
            this.panel5.Controls.Add(this.btn_add);
            this.panel5.Controls.Add(this.tb_searchBox);
            this.panel5.Controls.Add(this.guna2HtmlLabel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1013, 144);
            this.panel5.TabIndex = 35;
            // 
            // btn_refresh
            // 
            this.btn_refresh.BorderRadius = 5;
            this.btn_refresh.CheckedState.Parent = this.btn_refresh;
            this.btn_refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_refresh.CustomImages.Parent = this.btn_refresh;
            this.btn_refresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_refresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.ForeColor = System.Drawing.Color.White;
            this.btn_refresh.HoverState.Parent = this.btn_refresh;
            this.btn_refresh.Image = global::Santa_Archiving_System.Properties.Resources.icons8_refresh_100;
            this.btn_refresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_refresh.Location = new System.Drawing.Point(223, 97);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.ShadowDecoration.Parent = this.btn_refresh;
            this.btn_refresh.Size = new System.Drawing.Size(103, 36);
            this.btn_refresh.TabIndex = 30;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BorderRadius = 5;
            this.btn_delete.CheckedState.Parent = this.btn_delete;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.CustomImages.Parent = this.btn_delete;
            this.btn_delete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.HoverState.Parent = this.btn_delete;
            this.btn_delete.Image = global::Santa_Archiving_System.Properties.Resources.icons8_trash_100;
            this.btn_delete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_delete.Location = new System.Drawing.Point(332, 97);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.ShadowDecoration.Parent = this.btn_delete;
            this.btn_delete.Size = new System.Drawing.Size(104, 36);
            this.btn_delete.TabIndex = 29;
            this.btn_delete.Text = "Delete";
            this.btn_delete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.BorderRadius = 5;
            this.btn_update.CheckedState.Parent = this.btn_update;
            this.btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update.CustomImages.Parent = this.btn_update;
            this.btn_update.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.HoverState.Parent = this.btn_update;
            this.btn_update.Image = global::Santa_Archiving_System.Properties.Resources.icons8_write_100;
            this.btn_update.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_update.Location = new System.Drawing.Point(113, 97);
            this.btn_update.Name = "btn_update";
            this.btn_update.ShadowDecoration.Parent = this.btn_update;
            this.btn_update.Size = new System.Drawing.Size(104, 36);
            this.btn_update.TabIndex = 29;
            this.btn_update.Text = "Update";
            this.btn_update.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.BorderRadius = 5;
            this.btn_add.CheckedState.Parent = this.btn_add;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.CustomImages.Parent = this.btn_add;
            this.btn_add.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.HoverState.Parent = this.btn_add;
            this.btn_add.Image = global::Santa_Archiving_System.Properties.Resources.icons8_add_100;
            this.btn_add.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_add.Location = new System.Drawing.Point(3, 97);
            this.btn_add.Name = "btn_add";
            this.btn_add.ShadowDecoration.Parent = this.btn_add;
            this.btn_add.Size = new System.Drawing.Size(104, 36);
            this.btn_add.TabIndex = 29;
            this.btn_add.Text = "Add";
            this.btn_add.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tb_searchBox
            // 
            this.tb_searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_searchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb_searchBox.BorderRadius = 5;
            this.tb_searchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_searchBox.DefaultText = "";
            this.tb_searchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_searchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_searchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_searchBox.DisabledState.Parent = this.tb_searchBox;
            this.tb_searchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_searchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_searchBox.FocusedState.Parent = this.tb_searchBox;
            this.tb_searchBox.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tb_searchBox.ForeColor = System.Drawing.Color.Black;
            this.tb_searchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_searchBox.HoverState.Parent = this.tb_searchBox;
            this.tb_searchBox.Location = new System.Drawing.Point(724, 97);
            this.tb_searchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_searchBox.Name = "tb_searchBox";
            this.tb_searchBox.PasswordChar = '\0';
            this.tb_searchBox.PlaceholderForeColor = System.Drawing.Color.Black;
            this.tb_searchBox.PlaceholderText = "Search......";
            this.tb_searchBox.SelectedText = "";
            this.tb_searchBox.ShadowDecoration.Parent = this.tb_searchBox;
            this.tb_searchBox.Size = new System.Drawing.Size(283, 36);
            this.tb_searchBox.TabIndex = 28;
            this.tb_searchBox.TextChanged += new System.EventHandler(this.tb_searchBox_TextChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(404, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(158, 30);
            this.guna2HtmlLabel1.TabIndex = 27;
            this.guna2HtmlLabel1.Text = "Manage User";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(20, 572);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1013, 20);
            this.panel4.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1033, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 572);
            this.panel2.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 572);
            this.panel1.TabIndex = 32;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 20);
            this.panel3.TabIndex = 31;
            // 
            // dt_users
            // 
            this.dt_users.AllowDrop = true;
            this.dt_users.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dt_users.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_users.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_users.BackgroundColor = System.Drawing.Color.White;
            this.dt_users.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dt_users.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dt_users.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_users.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt_users.ColumnHeadersHeight = 25;
            this.dt_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dt_users.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_users.DefaultCellStyle = dataGridViewCellStyle3;
            this.dt_users.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dt_users.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dt_users.EnableHeadersVisualStyles = false;
            this.dt_users.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dt_users.Location = new System.Drawing.Point(20, 164);
            this.dt_users.Name = "dt_users";
            this.dt_users.RowHeadersVisible = false;
            this.dt_users.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dt_users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_users.Size = new System.Drawing.Size(1013, 408);
            this.dt_users.TabIndex = 36;
            this.dt_users.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dt_users.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dt_users.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dt_users.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dt_users.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dt_users.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dt_users.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dt_users.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dt_users.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.dt_users.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dt_users.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dt_users.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dt_users.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dt_users.ThemeStyle.HeaderStyle.Height = 25;
            this.dt_users.ThemeStyle.ReadOnly = false;
            this.dt_users.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dt_users.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dt_users.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dt_users.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dt_users.ThemeStyle.RowsStyle.Height = 22;
            this.dt_users.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dt_users.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dt_users.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_users_CellClick);
            // 
            // loading1
            // 
            this.loading1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading1.BackColor = System.Drawing.Color.Transparent;
            this.loading1.Location = new System.Drawing.Point(490, 259);
            this.loading1.Name = "loading1";
            this.loading1.Size = new System.Drawing.Size(72, 74);
            this.loading1.TabIndex = 38;
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1053, 592);
            this.Controls.Add(this.loading1);
            this.Controls.Add(this.dt_users);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ManageUser";
            this.Text = "Manage User";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_users)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private Guna.UI2.WinForms.Guna2Button btn_refresh;
        private Guna.UI2.WinForms.Guna2Button btn_delete;
        private Guna.UI2.WinForms.Guna2Button btn_update;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2TextBox tb_searchBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2DataGridView dt_users;
        private common.loading loading1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}