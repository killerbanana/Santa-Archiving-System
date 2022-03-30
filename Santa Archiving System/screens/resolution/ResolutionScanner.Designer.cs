namespace Santa_Archiving_System.screens.resolution
{
    partial class ResolutionScanner
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
            this.components = new System.ComponentModel.Container();
            this.btn_scan = new Guna.UI2.WinForms.Guna2Button();
            this.btn_aspectRatio = new Guna.UI2.WinForms.Guna2Button();
            this.btn_originalSize = new Guna.UI2.WinForms.Guna2Button();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cb_to = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tb_page = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_changeFolder = new Guna.UI2.WinForms.Guna2Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pic_scan = new System.Windows.Forms.PictureBox();
            this.lblPath = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDocNo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_scan)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_scan
            // 
            this.btn_scan.BorderRadius = 5;
            this.btn_scan.CheckedState.Parent = this.btn_scan;
            this.btn_scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_scan.CustomImages.Parent = this.btn_scan;
            this.btn_scan.FillColor = System.Drawing.Color.Green;
            this.btn_scan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_scan.ForeColor = System.Drawing.Color.White;
            this.btn_scan.HoverState.Parent = this.btn_scan;
            this.btn_scan.Location = new System.Drawing.Point(582, 477);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.ShadowDecoration.Parent = this.btn_scan;
            this.btn_scan.Size = new System.Drawing.Size(85, 36);
            this.btn_scan.TabIndex = 176;
            this.btn_scan.Text = "Scan";
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // btn_aspectRatio
            // 
            this.btn_aspectRatio.BorderRadius = 5;
            this.btn_aspectRatio.CheckedState.Parent = this.btn_aspectRatio;
            this.btn_aspectRatio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_aspectRatio.CustomImages.Parent = this.btn_aspectRatio;
            this.btn_aspectRatio.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_aspectRatio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_aspectRatio.ForeColor = System.Drawing.Color.White;
            this.btn_aspectRatio.HoverState.Parent = this.btn_aspectRatio;
            this.btn_aspectRatio.Location = new System.Drawing.Point(285, 477);
            this.btn_aspectRatio.Name = "btn_aspectRatio";
            this.btn_aspectRatio.ShadowDecoration.Parent = this.btn_aspectRatio;
            this.btn_aspectRatio.Size = new System.Drawing.Size(85, 36);
            this.btn_aspectRatio.TabIndex = 177;
            this.btn_aspectRatio.Text = "Aspect Ratio";
            // 
            // btn_originalSize
            // 
            this.btn_originalSize.BorderRadius = 5;
            this.btn_originalSize.CheckedState.Parent = this.btn_originalSize;
            this.btn_originalSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_originalSize.CustomImages.Parent = this.btn_originalSize;
            this.btn_originalSize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_originalSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_originalSize.ForeColor = System.Drawing.Color.White;
            this.btn_originalSize.HoverState.Parent = this.btn_originalSize;
            this.btn_originalSize.Location = new System.Drawing.Point(455, 477);
            this.btn_originalSize.Name = "btn_originalSize";
            this.btn_originalSize.ShadowDecoration.Parent = this.btn_originalSize;
            this.btn_originalSize.Size = new System.Drawing.Size(85, 36);
            this.btn_originalSize.TabIndex = 178;
            this.btn_originalSize.Text = "Original Size";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderRadius = 5;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.FocusedState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.HoverState.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Location = new System.Drawing.Point(12, 269);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.ShadowDecoration.Parent = this.guna2TextBox1;
            this.guna2TextBox1.Size = new System.Drawing.Size(235, 36);
            this.guna2TextBox1.TabIndex = 184;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(12, 238);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(161, 23);
            this.guna2HtmlLabel3.TabIndex = 185;
            this.guna2HtmlLabel3.Text = "Total Scanned Page";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(12, 317);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(84, 23);
            this.guna2HtmlLabel4.TabIndex = 187;
            this.guna2HtmlLabel4.Text = "File format";
            // 
            // cb_to
            // 
            this.cb_to.BackColor = System.Drawing.Color.Transparent;
            this.cb_to.BorderRadius = 5;
            this.cb_to.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to.FocusedColor = System.Drawing.Color.Empty;
            this.cb_to.FocusedState.Parent = this.cb_to;
            this.cb_to.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_to.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cb_to.FormattingEnabled = true;
            this.cb_to.HoverState.Parent = this.cb_to;
            this.cb_to.ItemHeight = 30;
            this.cb_to.ItemsAppearance.Parent = this.cb_to;
            this.cb_to.Location = new System.Drawing.Point(12, 343);
            this.cb_to.Name = "cb_to";
            this.cb_to.ShadowDecoration.Parent = this.cb_to;
            this.cb_to.Size = new System.Drawing.Size(235, 36);
            this.cb_to.TabIndex = 226;
            this.cb_to.TabStop = false;
            // 
            // tb_page
            // 
            this.tb_page.BorderRadius = 5;
            this.tb_page.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_page.DefaultText = "";
            this.tb_page.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_page.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_page.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_page.DisabledState.Parent = this.tb_page;
            this.tb_page.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_page.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_page.FocusedState.Parent = this.tb_page;
            this.tb_page.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_page.HoverState.Parent = this.tb_page;
            this.tb_page.Location = new System.Drawing.Point(12, 421);
            this.tb_page.Name = "tb_page";
            this.tb_page.PasswordChar = '\0';
            this.tb_page.PlaceholderText = "";
            this.tb_page.SelectedText = "";
            this.tb_page.ShadowDecoration.Parent = this.tb_page;
            this.tb_page.Size = new System.Drawing.Size(235, 36);
            this.tb_page.TabIndex = 227;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(12, 390);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(161, 23);
            this.guna2HtmlLabel7.TabIndex = 228;
            this.guna2HtmlLabel7.Text = "Total Scanned Page";
            // 
            // btn_changeFolder
            // 
            this.btn_changeFolder.BorderRadius = 5;
            this.btn_changeFolder.CheckedState.Parent = this.btn_changeFolder;
            this.btn_changeFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_changeFolder.CustomImages.Parent = this.btn_changeFolder;
            this.btn_changeFolder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_changeFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_changeFolder.ForeColor = System.Drawing.Color.White;
            this.btn_changeFolder.HoverState.Parent = this.btn_changeFolder;
            this.btn_changeFolder.Location = new System.Drawing.Point(11, 477);
            this.btn_changeFolder.Name = "btn_changeFolder";
            this.btn_changeFolder.ShadowDecoration.Parent = this.btn_changeFolder;
            this.btn_changeFolder.Size = new System.Drawing.Size(236, 36);
            this.btn_changeFolder.TabIndex = 229;
            this.btn_changeFolder.Text = "Change Output Folder";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(414, 174);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(224, 21);
            this.comboBox1.TabIndex = 230;
            // 
            // lbDevices
            // 
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(12, 57);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(235, 173);
            this.lbDevices.TabIndex = 181;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 28);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(132, 23);
            this.guna2HtmlLabel1.TabIndex = 182;
            this.guna2HtmlLabel1.Text = "Select a scanner";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(12, 3);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(66, 19);
            this.guna2HtmlLabel2.TabIndex = 183;
            this.guna2HtmlLabel2.Text = "Properties";
            // 
            // pic_scan
            // 
            this.pic_scan.Location = new System.Drawing.Point(483, 227);
            this.pic_scan.Name = "pic_scan";
            this.pic_scan.Size = new System.Drawing.Size(373, 214);
            this.pic_scan.TabIndex = 231;
            this.pic_scan.TabStop = false;
            // 
            // lblPath
            // 
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(506, 82);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(161, 23);
            this.lblPath.TabIndex = 232;
            this.lblPath.Text = "Total Scanned Page";
            // 
            // lblDocNo
            // 
            this.lblDocNo.BackColor = System.Drawing.Color.Transparent;
            this.lblDocNo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocNo.Location = new System.Drawing.Point(379, 127);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(161, 23);
            this.lblDocNo.TabIndex = 233;
            this.lblDocNo.Text = "Total Scanned Page";
            // 
            // ResolutionScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.lblDocNo);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.pic_scan);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_changeFolder);
            this.Controls.Add(this.tb_page);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.cb_to);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.btn_originalSize);
            this.Controls.Add(this.btn_aspectRatio);
            this.Controls.Add(this.btn_scan);
            this.Name = "ResolutionScanner";
            this.Text = "Scan Documents to PDF";
            this.Load += new System.EventHandler(this.ResolutionScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_scan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_scan;
        private Guna.UI2.WinForms.Guna2Button btn_aspectRatio;
        private Guna.UI2.WinForms.Guna2Button btn_originalSize;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2ComboBox cb_to;
        private Guna.UI2.WinForms.Guna2TextBox tb_page;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2Button btn_changeFolder;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox lbDevices;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pic_scan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPath;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDocNo;
    }
}