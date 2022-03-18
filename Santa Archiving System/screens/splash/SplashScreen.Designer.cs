namespace Santa_Archiving_System.screens.splash
{
    partial class SplashScreen
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
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_version = new System.Windows.Forms.Label();
            this.lbl_pressToContinue = new System.Windows.Forms.Label();
            this.panel_loading = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_percent = new System.Windows.Forms.Label();
            this.lbl_wait = new System.Windows.Forms.Label();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.lbl_by = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_logo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_lgu = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel_loading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.BorderRadius = 10;
            this.progressBar.BorderThickness = 1;
            this.progressBar.FillColor = System.Drawing.Color.Transparent;
            this.progressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.progressBar.Location = new System.Drawing.Point(2, 493);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(124)))), ((int)(((byte)(255)))));
            this.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(166)))), ((int)(((byte)(232)))));
            this.progressBar.ShadowDecoration.Parent = this.progressBar;
            this.progressBar.Size = new System.Drawing.Size(986, 20);
            this.progressBar.TabIndex = 1;
            this.progressBar.TabStop = false;
            this.progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.progressBar.Value = 100;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_version
            // 
            this.lbl_version.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_version.AutoSize = true;
            this.lbl_version.BackColor = System.Drawing.Color.Transparent;
            this.lbl_version.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_version.ForeColor = System.Drawing.Color.Black;
            this.lbl_version.Location = new System.Drawing.Point(884, 9);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(91, 21);
            this.lbl_version.TabIndex = 6;
            this.lbl_version.Text = "Version 0.2";
            this.lbl_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_pressToContinue
            // 
            this.lbl_pressToContinue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_pressToContinue.AutoSize = true;
            this.lbl_pressToContinue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pressToContinue.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pressToContinue.ForeColor = System.Drawing.Color.Black;
            this.lbl_pressToContinue.Location = new System.Drawing.Point(378, 416);
            this.lbl_pressToContinue.Name = "lbl_pressToContinue";
            this.lbl_pressToContinue.Size = new System.Drawing.Size(233, 22);
            this.lbl_pressToContinue.TabIndex = 29;
            this.lbl_pressToContinue.Text = "Press \"Enter\" to continue ";
            this.lbl_pressToContinue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_pressToContinue.Visible = false;
            // 
            // panel_loading
            // 
            this.panel_loading.BackColor = System.Drawing.Color.Transparent;
            this.panel_loading.BorderColor = System.Drawing.Color.Transparent;
            this.panel_loading.Controls.Add(this.lbl_percent);
            this.panel_loading.Controls.Add(this.lbl_wait);
            this.panel_loading.Controls.Add(this.lbl_loading);
            this.panel_loading.Location = new System.Drawing.Point(326, 441);
            this.panel_loading.Name = "panel_loading";
            this.panel_loading.ShadowDecoration.Parent = this.panel_loading;
            this.panel_loading.Size = new System.Drawing.Size(337, 46);
            this.panel_loading.TabIndex = 30;
            // 
            // lbl_percent
            // 
            this.lbl_percent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_percent.AutoSize = true;
            this.lbl_percent.BackColor = System.Drawing.Color.Transparent;
            this.lbl_percent.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_percent.ForeColor = System.Drawing.Color.Black;
            this.lbl_percent.Location = new System.Drawing.Point(128, 22);
            this.lbl_percent.Name = "lbl_percent";
            this.lbl_percent.Size = new System.Drawing.Size(49, 21);
            this.lbl_percent.TabIndex = 7;
            this.lbl_percent.Text = "100%";
            this.lbl_percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_wait
            // 
            this.lbl_wait.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_wait.AutoSize = true;
            this.lbl_wait.BackColor = System.Drawing.Color.Transparent;
            this.lbl_wait.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_wait.ForeColor = System.Drawing.Color.Black;
            this.lbl_wait.Location = new System.Drawing.Point(178, 22);
            this.lbl_wait.Name = "lbl_wait";
            this.lbl_wait.Size = new System.Drawing.Size(115, 21);
            this.lbl_wait.TabIndex = 6;
            this.lbl_wait.Text = "Please Wait....";
            this.lbl_wait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_loading
            // 
            this.lbl_loading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_loading.AutoSize = true;
            this.lbl_loading.BackColor = System.Drawing.Color.Transparent;
            this.lbl_loading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loading.ForeColor = System.Drawing.Color.Black;
            this.lbl_loading.Location = new System.Drawing.Point(56, 22);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(73, 21);
            this.lbl_loading.TabIndex = 5;
            this.lbl_loading.Text = "Loading";
            this.lbl_loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_by
            // 
            this.lbl_by.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_by.AutoSize = true;
            this.lbl_by.BackColor = System.Drawing.Color.Transparent;
            this.lbl_by.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_by.ForeColor = System.Drawing.Color.White;
            this.lbl_by.Location = new System.Drawing.Point(450, 229);
            this.lbl_by.Name = "lbl_by";
            this.lbl_by.Size = new System.Drawing.Size(83, 17);
            this.lbl_by.TabIndex = 35;
            this.lbl_by.Text = " Created By";
            this.lbl_by.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(362, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 17);
            this.label1.TabIndex = 34;
            this.label1.Text = "Hackdogs Software Development Services";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_logo
            // 
            this.pb_logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_logo.Enabled = false;
            this.pb_logo.Image = global::Santa_Archiving_System.Properties.Resources.HACKDogs_2__2_;
            this.pb_logo.Location = new System.Drawing.Point(429, 223);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.ShadowDecoration.Parent = this.pb_logo;
            this.pb_logo.Size = new System.Drawing.Size(130, 147);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo.TabIndex = 33;
            this.pb_logo.TabStop = false;
            // 
            // lbl_lgu
            // 
            this.lbl_lgu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_lgu.AutoSize = true;
            this.lbl_lgu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_lgu.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lgu.ForeColor = System.Drawing.Color.White;
            this.lbl_lgu.Location = new System.Drawing.Point(334, 165);
            this.lbl_lgu.Name = "lbl_lgu";
            this.lbl_lgu.Size = new System.Drawing.Size(321, 24);
            this.lbl_lgu.TabIndex = 32;
            this.lbl_lgu.Text = "Municipality of Santa Ilocos Sur";
            this.lbl_lgu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(279, 100);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(430, 57);
            this.lbl_title.TabIndex = 31;
            this.lbl_title.Text = "Santa Archiving System";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Santa_Archiving_System.Properties.Resources.splash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(988, 516);
            this.Controls.Add(this.lbl_by);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.lbl_lgu);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.panel_loading);
            this.Controls.Add(this.lbl_pressToContinue);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.progressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splash";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SplashScreen_KeyDown);
            this.panel_loading.ResumeLayout(false);
            this.panel_loading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Label lbl_pressToContinue;
        private Guna.UI2.WinForms.Guna2Panel panel_loading;
        private System.Windows.Forms.Label lbl_percent;
        private System.Windows.Forms.Label lbl_wait;
        private System.Windows.Forms.Label lbl_loading;
        private System.Windows.Forms.Label lbl_by;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox pb_logo;
        private System.Windows.Forms.Label lbl_lgu;
        private System.Windows.Forms.Label lbl_title;
    }
}