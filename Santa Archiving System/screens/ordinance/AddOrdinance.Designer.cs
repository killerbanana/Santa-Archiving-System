namespace Santa_Archiving_System.screens.ordinance
{
    partial class AddOrdinance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loading1 = new Santa_Archiving_System.common.loading();
            this.reading_cb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tag = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ampm = new Guna.UI2.WinForms.Guna2ComboBox();
            this.time = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.series = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.author = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_cancel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.btn_browse = new Guna.UI2.WinForms.Guna2Button();
            this.title = new Guna.UI2.WinForms.Guna2TextBox();
            this.ordinanceNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.fileName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel19 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn_scan = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 20);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 671);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(616, 20);
            this.panel4.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(596, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 651);
            this.panel5.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 651);
            this.panel2.TabIndex = 9;
            // 
            // loading1
            // 
            this.loading1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loading1.BackColor = System.Drawing.Color.Transparent;
            this.loading1.Location = new System.Drawing.Point(281, 316);
            this.loading1.Name = "loading1";
            this.loading1.Size = new System.Drawing.Size(71, 70);
            this.loading1.TabIndex = 109;
            this.loading1.Visible = false;
            // 
            // reading_cb
            // 
            this.reading_cb.BackColor = System.Drawing.Color.Transparent;
            this.reading_cb.BorderRadius = 5;
            this.reading_cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.reading_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reading_cb.FocusedColor = System.Drawing.Color.Empty;
            this.reading_cb.FocusedState.Parent = this.reading_cb;
            this.reading_cb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.reading_cb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.reading_cb.FormattingEnabled = true;
            this.reading_cb.HoverState.Parent = this.reading_cb;
            this.reading_cb.ItemHeight = 30;
            this.reading_cb.Items.AddRange(new object[] {
            "1st Reading",
            "2nd Reading",
            "3rd Reading"});
            this.reading_cb.ItemsAppearance.Parent = this.reading_cb;
            this.reading_cb.Location = new System.Drawing.Point(32, 550);
            this.reading_cb.Name = "reading_cb";
            this.reading_cb.ShadowDecoration.Parent = this.reading_cb;
            this.reading_cb.Size = new System.Drawing.Size(538, 36);
            this.reading_cb.TabIndex = 108;
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(32, 521);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(69, 23);
            this.guna2HtmlLabel10.TabIndex = 107;
            this.guna2HtmlLabel10.Text = "Reading";
            // 
            // tag
            // 
            this.tag.BorderRadius = 5;
            this.tag.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tag.DefaultText = "";
            this.tag.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tag.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tag.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tag.DisabledState.Parent = this.tag;
            this.tag.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tag.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tag.FocusedState.Parent = this.tag;
            this.tag.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tag.HoverState.Parent = this.tag;
            this.tag.Location = new System.Drawing.Point(332, 470);
            this.tag.Name = "tag";
            this.tag.PasswordChar = '\0';
            this.tag.PlaceholderText = "";
            this.tag.SelectedText = "";
            this.tag.ShadowDecoration.Parent = this.tag;
            this.tag.Size = new System.Drawing.Size(238, 36);
            this.tag.TabIndex = 91;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(332, 439);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(33, 23);
            this.guna2HtmlLabel9.TabIndex = 106;
            this.guna2HtmlLabel9.Text = "Tag";
            // 
            // ampm
            // 
            this.ampm.BackColor = System.Drawing.Color.Transparent;
            this.ampm.BorderRadius = 5;
            this.ampm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ampm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ampm.FocusedColor = System.Drawing.Color.Empty;
            this.ampm.FocusedState.Parent = this.ampm;
            this.ampm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ampm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ampm.FormattingEnabled = true;
            this.ampm.HoverState.Parent = this.ampm;
            this.ampm.ItemHeight = 30;
            this.ampm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.ampm.ItemsAppearance.Parent = this.ampm;
            this.ampm.Location = new System.Drawing.Point(414, 284);
            this.ampm.Name = "ampm";
            this.ampm.ShadowDecoration.Parent = this.ampm;
            this.ampm.Size = new System.Drawing.Size(78, 36);
            this.ampm.TabIndex = 105;
            // 
            // time
            // 
            this.time.BorderRadius = 5;
            this.time.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.time.DefaultText = "";
            this.time.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.time.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.time.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.time.DisabledState.Parent = this.time;
            this.time.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.time.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.time.FocusedState.Parent = this.time;
            this.time.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.time.HoverState.Parent = this.time;
            this.time.Location = new System.Drawing.Point(284, 284);
            this.time.Name = "time";
            this.time.PasswordChar = '\0';
            this.time.PlaceholderText = "";
            this.time.SelectedText = "";
            this.time.ShadowDecoration.Parent = this.time;
            this.time.Size = new System.Drawing.Size(124, 36);
            this.time.TabIndex = 88;
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Bodoni MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(284, 253);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(43, 25);
            this.guna2HtmlLabel8.TabIndex = 104;
            this.guna2HtmlLabel8.Text = "Time";
            // 
            // series
            // 
            this.series.BorderRadius = 5;
            this.series.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.series.DefaultText = "";
            this.series.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.series.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.series.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.series.DisabledState.Parent = this.series;
            this.series.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.series.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.series.FocusedState.Parent = this.series;
            this.series.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.series.HoverState.Parent = this.series;
            this.series.Location = new System.Drawing.Point(284, 200);
            this.series.Name = "series";
            this.series.PasswordChar = '\0';
            this.series.PlaceholderText = "";
            this.series.SelectedText = "";
            this.series.ShadowDecoration.Parent = this.series;
            this.series.Size = new System.Drawing.Size(208, 36);
            this.series.TabIndex = 87;
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(284, 169);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(68, 23);
            this.guna2HtmlLabel7.TabIndex = 103;
            this.guna2HtmlLabel7.Text = "Series Of";
            // 
            // author
            // 
            this.author.BorderRadius = 5;
            this.author.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.author.DefaultText = "";
            this.author.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.author.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.author.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.author.DisabledState.Parent = this.author;
            this.author.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.author.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.author.FocusedState.Parent = this.author;
            this.author.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.author.HoverState.Parent = this.author;
            this.author.Location = new System.Drawing.Point(32, 470);
            this.author.Name = "author";
            this.author.PasswordChar = '\0';
            this.author.PlaceholderText = "";
            this.author.SelectedText = "";
            this.author.ShadowDecoration.Parent = this.author;
            this.author.Size = new System.Drawing.Size(294, 36);
            this.author.TabIndex = 90;
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(32, 439);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(58, 23);
            this.guna2HtmlLabel6.TabIndex = 102;
            this.guna2HtmlLabel6.Text = "Author";
            // 
            // date
            // 
            this.date.BorderRadius = 5;
            this.date.CheckedState.Parent = this.date;
            this.date.FillColor = System.Drawing.Color.White;
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.date.HoverState.Parent = this.date;
            this.date.Location = new System.Drawing.Point(33, 284);
            this.date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.ShadowDecoration.Parent = this.date;
            this.date.Size = new System.Drawing.Size(208, 36);
            this.date.TabIndex = 101;
            this.date.Value = new System.DateTime(2021, 4, 15, 14, 15, 37, 736);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BorderRadius = 5;
            this.btn_cancel.CheckedState.Parent = this.btn_cancel;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.CustomImages.Parent = this.btn_cancel;
            this.btn_cancel.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btn_cancel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.HoverState.Parent = this.btn_cancel;
            this.btn_cancel.Location = new System.Drawing.Point(334, 608);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.ShadowDecoration.Parent = this.btn_cancel;
            this.btn_cancel.Size = new System.Drawing.Size(111, 45);
            this.btn_cancel.TabIndex = 99;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BorderRadius = 5;
            this.btn_add.CheckedState.Parent = this.btn_add;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.CustomImages.Parent = this.btn_add;
            this.btn_add.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_add.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.HoverState.Parent = this.btn_add;
            this.btn_add.Location = new System.Drawing.Point(451, 608);
            this.btn_add.Name = "btn_add";
            this.btn_add.ShadowDecoration.Parent = this.btn_add;
            this.btn_add.Size = new System.Drawing.Size(119, 45);
            this.btn_add.TabIndex = 100;
            this.btn_add.Text = "ADD";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.BorderRadius = 5;
            this.btn_browse.CheckedState.Parent = this.btn_browse;
            this.btn_browse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_browse.CustomImages.Parent = this.btn_browse;
            this.btn_browse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(65)))), ((int)(((byte)(164)))));
            this.btn_browse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_browse.ForeColor = System.Drawing.Color.White;
            this.btn_browse.HoverState.Parent = this.btn_browse;
            this.btn_browse.Location = new System.Drawing.Point(401, 119);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.ShadowDecoration.Parent = this.btn_browse;
            this.btn_browse.Size = new System.Drawing.Size(84, 36);
            this.btn_browse.TabIndex = 98;
            this.btn_browse.Text = "Browse";
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // title
            // 
            this.title.BorderRadius = 5;
            this.title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.title.DefaultText = "";
            this.title.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.title.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.title.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.title.DisabledState.Parent = this.title;
            this.title.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.title.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.title.FocusedState.Parent = this.title;
            this.title.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.title.HoverState.Parent = this.title;
            this.title.Location = new System.Drawing.Point(33, 381);
            this.title.Name = "title";
            this.title.PasswordChar = '\0';
            this.title.PlaceholderText = "";
            this.title.SelectedText = "";
            this.title.ShadowDecoration.Parent = this.title;
            this.title.Size = new System.Drawing.Size(537, 36);
            this.title.TabIndex = 89;
            // 
            // ordinanceNumber
            // 
            this.ordinanceNumber.BorderRadius = 5;
            this.ordinanceNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ordinanceNumber.DefaultText = "";
            this.ordinanceNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ordinanceNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ordinanceNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ordinanceNumber.DisabledState.Parent = this.ordinanceNumber;
            this.ordinanceNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ordinanceNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ordinanceNumber.FocusedState.Parent = this.ordinanceNumber;
            this.ordinanceNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ordinanceNumber.HoverState.Parent = this.ordinanceNumber;
            this.ordinanceNumber.Location = new System.Drawing.Point(32, 200);
            this.ordinanceNumber.Name = "ordinanceNumber";
            this.ordinanceNumber.PasswordChar = '\0';
            this.ordinanceNumber.PlaceholderText = "";
            this.ordinanceNumber.SelectedText = "";
            this.ordinanceNumber.ShadowDecoration.Parent = this.ordinanceNumber;
            this.ordinanceNumber.Size = new System.Drawing.Size(209, 36);
            this.ordinanceNumber.TabIndex = 86;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(33, 350);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(34, 23);
            this.guna2HtmlLabel4.TabIndex = 95;
            this.guna2HtmlLabel4.Text = "Title";
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
            this.fileName.Location = new System.Drawing.Point(32, 119);
            this.fileName.Name = "fileName";
            this.fileName.PasswordChar = '\0';
            this.fileName.PlaceholderText = "";
            this.fileName.ReadOnly = true;
            this.fileName.SelectedText = "";
            this.fileName.ShadowDecoration.Parent = this.fileName;
            this.fileName.Size = new System.Drawing.Size(363, 36);
            this.fileName.TabIndex = 85;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(33, 253);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(43, 23);
            this.guna2HtmlLabel5.TabIndex = 94;
            this.guna2HtmlLabel5.Text = "Date";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(32, 169);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(117, 23);
            this.guna2HtmlLabel3.TabIndex = 93;
            this.guna2HtmlLabel3.Text = "Ordinance No.";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(32, 88);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(27, 23);
            this.guna2HtmlLabel2.TabIndex = 96;
            this.guna2HtmlLabel2.Text = "File";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(32, 38);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(281, 34);
            this.guna2HtmlLabel1.TabIndex = 92;
            this.guna2HtmlLabel1.Text = "New Ordinance Data";
            // 
            // guna2HtmlLabel19
            // 
            this.guna2HtmlLabel19.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel19.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel19.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel19.Location = new System.Drawing.Point(155, 169);
            this.guna2HtmlLabel19.Name = "guna2HtmlLabel19";
            this.guna2HtmlLabel19.Size = new System.Drawing.Size(9, 23);
            this.guna2HtmlLabel19.TabIndex = 140;
            this.guna2HtmlLabel19.Text = "*";
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel11.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(358, 169);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(9, 23);
            this.guna2HtmlLabel11.TabIndex = 141;
            this.guna2HtmlLabel11.Text = "*";
            // 
            // guna2HtmlLabel12
            // 
            this.guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel12.ForeColor = System.Drawing.Color.Red;
            this.guna2HtmlLabel12.Location = new System.Drawing.Point(65, 88);
            this.guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            this.guna2HtmlLabel12.Size = new System.Drawing.Size(9, 23);
            this.guna2HtmlLabel12.TabIndex = 142;
            this.guna2HtmlLabel12.Text = "*";
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
            this.btn_scan.Location = new System.Drawing.Point(491, 119);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.ShadowDecoration.Parent = this.btn_scan;
            this.btn_scan.Size = new System.Drawing.Size(79, 36);
            this.btn_scan.TabIndex = 176;
            this.btn_scan.Text = "Scan";
            // 
            // AddOrdinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 691);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.guna2HtmlLabel12);
            this.Controls.Add(this.guna2HtmlLabel11);
            this.Controls.Add(this.guna2HtmlLabel19);
            this.Controls.Add(this.loading1);
            this.Controls.Add(this.reading_cb);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.ampm);
            this.Controls.Add(this.time);
            this.Controls.Add(this.guna2HtmlLabel8);
            this.Controls.Add(this.series);
            this.Controls.Add(this.guna2HtmlLabel7);
            this.Controls.Add(this.author);
            this.Controls.Add(this.guna2HtmlLabel6);
            this.Controls.Add(this.date);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.title);
            this.Controls.Add(this.ordinanceNumber);
            this.Controls.Add(this.guna2HtmlLabel4);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.guna2HtmlLabel5);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrdinance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddOrdinance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private common.loading loading1;
        private Guna.UI2.WinForms.Guna2ComboBox reading_cb;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2TextBox tag;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2ComboBox ampm;
        private Guna.UI2.WinForms.Guna2TextBox time;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2TextBox series;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2TextBox author;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2DateTimePicker date;
        private Guna.UI2.WinForms.Guna2Button btn_cancel;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2Button btn_browse;
        private Guna.UI2.WinForms.Guna2TextBox title;
        private Guna.UI2.WinForms.Guna2TextBox ordinanceNumber;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2TextBox fileName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel12;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel19;
        private Guna.UI2.WinForms.Guna2Button btn_scan;
    }
}