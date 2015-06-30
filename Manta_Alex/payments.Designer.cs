namespace Manta_Alex_Payments
{
    partial class payments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(payments));
            this.dgv_rate = new System.Windows.Forms.DataGridView();
            this.btt_load = new System.Windows.Forms.Button();
            this.txt_lid = new System.Windows.Forms.TextBox();
            this.txt_lmonth = new System.Windows.Forms.TextBox();
            this.txt_lyear = new System.Windows.Forms.TextBox();
            this.txt_month = new System.Windows.Forms.TextBox();
            this.txt_idyear = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txt_year = new System.Windows.Forms.TextBox();
            this.label_date = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPaymentsTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payslipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subcontractorTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f_browse = new System.Windows.Forms.FolderBrowserDialog();
            this.dtp_process = new System.Windows.Forms.DateTimePicker();
            this.dtp_week = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btt_start = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btt_month_re = new System.Windows.Forms.Button();
            this.btt_wage = new System.Windows.Forms.Button();
            this.btt_year = new System.Windows.Forms.Button();
            this.btt_month = new System.Windows.Forms.Button();
            this.btt_pay = new System.Windows.Forms.Button();
            this.btt_remove = new System.Windows.Forms.Button();
            this.btt_add = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_net = new System.Windows.Forms.TextBox();
            this.txt_tax = new System.Windows.Forms.TextBox();
            this.txt_gross = new System.Windows.Forms.TextBox();
            this.txt_h = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rate)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_rate
            // 
            this.dgv_rate.AllowUserToAddRows = false;
            this.dgv_rate.AllowUserToDeleteRows = false;
            this.dgv_rate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_rate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_rate.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_rate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_rate.Location = new System.Drawing.Point(12, 126);
            this.dgv_rate.Name = "dgv_rate";
            this.dgv_rate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_rate.Size = new System.Drawing.Size(1132, 563);
            this.dgv_rate.TabIndex = 1;
            this.dgv_rate.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgv_rate_ColumnWidthChanged);
            // 
            // btt_load
            // 
            this.btt_load.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_load.Location = new System.Drawing.Point(254, 95);
            this.btt_load.Name = "btt_load";
            this.btt_load.Size = new System.Drawing.Size(75, 25);
            this.btt_load.TabIndex = 18;
            this.btt_load.Text = "Load...";
            this.btt_load.UseVisualStyleBackColor = true;
            this.btt_load.Click += new System.EventHandler(this.btt_load_Click);
            // 
            // txt_lid
            // 
            this.txt_lid.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lid.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_lid.Location = new System.Drawing.Point(12, 95);
            this.txt_lid.Name = "txt_lid";
            this.txt_lid.Size = new System.Drawing.Size(69, 29);
            this.txt_lid.TabIndex = 19;
            this.txt_lid.Text = "ID";
            this.txt_lid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_lid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_lid_MouseClick);
            this.txt_lid.Leave += new System.EventHandler(this.txt_lid_Leave);
            // 
            // txt_lmonth
            // 
            this.txt_lmonth.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lmonth.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_lmonth.Location = new System.Drawing.Point(87, 95);
            this.txt_lmonth.Name = "txt_lmonth";
            this.txt_lmonth.Size = new System.Drawing.Size(77, 29);
            this.txt_lmonth.TabIndex = 20;
            this.txt_lmonth.Text = "Month";
            this.txt_lmonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_lmonth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_lmonth_MouseClick);
            this.txt_lmonth.Leave += new System.EventHandler(this.txt_lmonth_Leave);
            // 
            // txt_lyear
            // 
            this.txt_lyear.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lyear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_lyear.Location = new System.Drawing.Point(170, 95);
            this.txt_lyear.Name = "txt_lyear";
            this.txt_lyear.Size = new System.Drawing.Size(78, 29);
            this.txt_lyear.TabIndex = 21;
            this.txt_lyear.Text = "Year";
            this.txt_lyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_lyear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_lyear_MouseClick);
            this.txt_lyear.Leave += new System.EventHandler(this.txt_lyear_Leave);
            // 
            // txt_month
            // 
            this.txt_month.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_month.Location = new System.Drawing.Point(412, 33);
            this.txt_month.Name = "txt_month";
            this.txt_month.Size = new System.Drawing.Size(160, 26);
            this.txt_month.TabIndex = 23;
            this.txt_month.Text = "MONTH NUMBER";
            this.txt_month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_month.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_month_MouseClick);
            this.txt_month.Leave += new System.EventHandler(this.txt_month_Leave);
            // 
            // txt_idyear
            // 
            this.txt_idyear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_idyear.Location = new System.Drawing.Point(578, 33);
            this.txt_idyear.Name = "txt_idyear";
            this.txt_idyear.Size = new System.Drawing.Size(140, 26);
            this.txt_idyear.TabIndex = 25;
            this.txt_idyear.Text = "ID NUMBER";
            this.txt_idyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_idyear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_idyear_MouseClick);
            this.txt_idyear.Leave += new System.EventHandler(this.txt_idyear_Leave);
            // 
            // txt_year
            // 
            this.txt_year.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_year.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txt_year.Location = new System.Drawing.Point(578, 68);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(140, 25);
            this.txt_year.TabIndex = 26;
            this.txt_year.Text = "MONTH/YEAR";
            this.txt_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_year.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_year_MouseClick);
            this.txt_year.Leave += new System.EventHandler(this.txt_year_Leave);
            // 
            // label_date
            // 
            this.label_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_date.Location = new System.Drawing.Point(12, 710);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(99, 21);
            this.label_date.TabIndex = 28;
            this.label_date.Text = "Date not set";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.pDFToolStripMenuItem,
            this.changeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 28);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPaymentsTableToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // loadPaymentsTableToolStripMenuItem
            // 
            this.loadPaymentsTableToolStripMenuItem.Name = "loadPaymentsTableToolStripMenuItem";
            this.loadPaymentsTableToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadPaymentsTableToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.loadPaymentsTableToolStripMenuItem.Text = "Load payments table";
            this.loadPaymentsTableToolStripMenuItem.Click += new System.EventHandler(this.loadPaymentsTableToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPaymentToolStripMenuItem,
            this.removePaymentToolStripMenuItem});
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // addNewPaymentToolStripMenuItem
            // 
            this.addNewPaymentToolStripMenuItem.Name = "addNewPaymentToolStripMenuItem";
            this.addNewPaymentToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.addNewPaymentToolStripMenuItem.Text = "Add new payment";
            this.addNewPaymentToolStripMenuItem.Click += new System.EventHandler(this.addNewPaymentToolStripMenuItem_Click);
            // 
            // removePaymentToolStripMenuItem
            // 
            this.removePaymentToolStripMenuItem.Name = "removePaymentToolStripMenuItem";
            this.removePaymentToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.removePaymentToolStripMenuItem.Text = "Remove payment";
            this.removePaymentToolStripMenuItem.Click += new System.EventHandler(this.removePaymentToolStripMenuItem_Click);
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wageListToolStripMenuItem,
            this.payslipsToolStripMenuItem,
            this.subcontractorTaxToolStripMenuItem,
            this.monthlyReportToolStripMenuItem,
            this.yearlyReportToolStripMenuItem});
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.pDFToolStripMenuItem.Text = "PDF";
            // 
            // wageListToolStripMenuItem
            // 
            this.wageListToolStripMenuItem.Name = "wageListToolStripMenuItem";
            this.wageListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.wageListToolStripMenuItem.Size = new System.Drawing.Size(248, 24);
            this.wageListToolStripMenuItem.Text = "Wage list";
            this.wageListToolStripMenuItem.Click += new System.EventHandler(this.wageListToolStripMenuItem_Click);
            // 
            // payslipsToolStripMenuItem
            // 
            this.payslipsToolStripMenuItem.Name = "payslipsToolStripMenuItem";
            this.payslipsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.payslipsToolStripMenuItem.Size = new System.Drawing.Size(248, 24);
            this.payslipsToolStripMenuItem.Text = "Payslips";
            this.payslipsToolStripMenuItem.Click += new System.EventHandler(this.payslipsToolStripMenuItem_Click);
            // 
            // subcontractorTaxToolStripMenuItem
            // 
            this.subcontractorTaxToolStripMenuItem.Name = "subcontractorTaxToolStripMenuItem";
            this.subcontractorTaxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.subcontractorTaxToolStripMenuItem.Size = new System.Drawing.Size(248, 24);
            this.subcontractorTaxToolStripMenuItem.Text = "Subcontractor Tax";
            this.subcontractorTaxToolStripMenuItem.Click += new System.EventHandler(this.subcontractorTaxToolStripMenuItem_Click);
            // 
            // monthlyReportToolStripMenuItem
            // 
            this.monthlyReportToolStripMenuItem.Name = "monthlyReportToolStripMenuItem";
            this.monthlyReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.monthlyReportToolStripMenuItem.Size = new System.Drawing.Size(248, 24);
            this.monthlyReportToolStripMenuItem.Text = "Monthly report";
            this.monthlyReportToolStripMenuItem.Click += new System.EventHandler(this.monthlyReportToolStripMenuItem_Click);
            // 
            // yearlyReportToolStripMenuItem
            // 
            this.yearlyReportToolStripMenuItem.Name = "yearlyReportToolStripMenuItem";
            this.yearlyReportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.yearlyReportToolStripMenuItem.Size = new System.Drawing.Size(248, 24);
            this.yearlyReportToolStripMenuItem.Text = "Yearly report";
            this.yearlyReportToolStripMenuItem.Click += new System.EventHandler(this.yearlyReportToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem});
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.changeToolStripMenuItem.Text = "Help";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // dtp_process
            // 
            this.dtp_process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_process.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_process.Location = new System.Drawing.Point(629, 98);
            this.dtp_process.Name = "dtp_process";
            this.dtp_process.ShowCheckBox = true;
            this.dtp_process.Size = new System.Drawing.Size(120, 26);
            this.dtp_process.TabIndex = 30;
            this.dtp_process.ValueChanged += new System.EventHandler(this.dtp_process_ValueChanged);
            // 
            // dtp_week
            // 
            this.dtp_week.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_week.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_week.Location = new System.Drawing.Point(862, 98);
            this.dtp_week.Name = "dtp_week";
            this.dtp_week.ShowCheckBox = true;
            this.dtp_week.Size = new System.Drawing.Size(120, 26);
            this.dtp_week.TabIndex = 31;
            this.dtp_week.ValueChanged += new System.EventHandler(this.dtp_week_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 32;
            this.label1.Text = "Process date";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(755, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "Week start date";
            // 
            // btt_start
            // 
            this.btt_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_start.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_start.Location = new System.Drawing.Point(988, 97);
            this.btt_start.Name = "btt_start";
            this.btt_start.Size = new System.Drawing.Size(75, 23);
            this.btt_start.TabIndex = 34;
            this.btt_start.Text = "Start";
            this.btt_start.UseVisualStyleBackColor = true;
            this.btt_start.Click += new System.EventHandler(this.btt_start_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1069, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1002, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 29);
            this.button2.TabIndex = 36;
            this.button2.Text = "File Explorer";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btt_month_re
            // 
            this.btt_month_re.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_month_re.Image = ((System.Drawing.Image)(resources.GetObject("btt_month_re.Image")));
            this.btt_month_re.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_month_re.Location = new System.Drawing.Point(724, 30);
            this.btt_month_re.Name = "btt_month_re";
            this.btt_month_re.Size = new System.Drawing.Size(142, 29);
            this.btt_month_re.TabIndex = 27;
            this.btt_month_re.Text = "Monthly report";
            this.btt_month_re.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_month_re.UseVisualStyleBackColor = true;
            this.btt_month_re.Click += new System.EventHandler(this.btt_month_re_Click);
            // 
            // btt_wage
            // 
            this.btt_wage.Enabled = false;
            this.btt_wage.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_wage.Image = ((System.Drawing.Image)(resources.GetObject("btt_wage.Image")));
            this.btt_wage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_wage.Location = new System.Drawing.Point(298, 28);
            this.btt_wage.Name = "btt_wage";
            this.btt_wage.Size = new System.Drawing.Size(108, 29);
            this.btt_wage.TabIndex = 22;
            this.btt_wage.Text = "Wage list";
            this.btt_wage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_wage.UseVisualStyleBackColor = true;
            this.btt_wage.Click += new System.EventHandler(this.btt_wage_Click);
            // 
            // btt_year
            // 
            this.btt_year.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_year.Image = ((System.Drawing.Image)(resources.GetObject("btt_year.Image")));
            this.btt_year.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_year.Location = new System.Drawing.Point(724, 63);
            this.btt_year.Name = "btt_year";
            this.btt_year.Size = new System.Drawing.Size(142, 29);
            this.btt_year.TabIndex = 17;
            this.btt_year.Text = "Yearly report";
            this.btt_year.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_year.UseVisualStyleBackColor = true;
            this.btt_year.Click += new System.EventHandler(this.btt_year_Click);
            // 
            // btt_month
            // 
            this.btt_month.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_month.Image = ((System.Drawing.Image)(resources.GetObject("btt_month.Image")));
            this.btt_month.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_month.Location = new System.Drawing.Point(412, 60);
            this.btt_month.Name = "btt_month";
            this.btt_month.Size = new System.Drawing.Size(160, 29);
            this.btt_month.TabIndex = 16;
            this.btt_month.Text = "Subcontractor Tax";
            this.btt_month.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_month.UseVisualStyleBackColor = true;
            this.btt_month.Click += new System.EventHandler(this.btt_month_Click);
            // 
            // btt_pay
            // 
            this.btt_pay.Enabled = false;
            this.btt_pay.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_pay.Image = ((System.Drawing.Image)(resources.GetObject("btt_pay.Image")));
            this.btt_pay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_pay.Location = new System.Drawing.Point(298, 60);
            this.btt_pay.Name = "btt_pay";
            this.btt_pay.Size = new System.Drawing.Size(108, 29);
            this.btt_pay.TabIndex = 15;
            this.btt_pay.Text = "Payslips";
            this.btt_pay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_pay.UseVisualStyleBackColor = true;
            this.btt_pay.Click += new System.EventHandler(this.btt_pay_Click);
            // 
            // btt_remove
            // 
            this.btt_remove.Enabled = false;
            this.btt_remove.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_remove.Image = ((System.Drawing.Image)(resources.GetObject("btt_remove.Image")));
            this.btt_remove.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btt_remove.Location = new System.Drawing.Point(155, 28);
            this.btt_remove.Name = "btt_remove";
            this.btt_remove.Size = new System.Drawing.Size(137, 61);
            this.btt_remove.TabIndex = 11;
            this.btt_remove.Text = "Remove   payment";
            this.btt_remove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_remove.UseVisualStyleBackColor = true;
            this.btt_remove.Click += new System.EventHandler(this.btt_remove_Click);
            // 
            // btt_add
            // 
            this.btt_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btt_add.Enabled = false;
            this.btt_add.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_add.Image = ((System.Drawing.Image)(resources.GetObject("btt_add.Image")));
            this.btt_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btt_add.Location = new System.Drawing.Point(12, 28);
            this.btt_add.Name = "btt_add";
            this.btt_add.Size = new System.Drawing.Size(137, 61);
            this.btt_add.TabIndex = 10;
            this.btt_add.Text = "Add     payment";
            this.btt_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btt_add.UseVisualStyleBackColor = true;
            this.btt_add.Click += new System.EventHandler(this.btt_add_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(984, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 56;
            this.label9.Text = "label9";
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label9_MouseDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(902, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 55;
            this.label3.Text = "Loged in: ";
            // 
            // txt_net
            // 
            this.txt_net.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_net.Location = new System.Drawing.Point(1060, 695);
            this.txt_net.Name = "txt_net";
            this.txt_net.ReadOnly = true;
            this.txt_net.Size = new System.Drawing.Size(84, 26);
            this.txt_net.TabIndex = 57;
            // 
            // txt_tax
            // 
            this.txt_tax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tax.Location = new System.Drawing.Point(895, 695);
            this.txt_tax.Name = "txt_tax";
            this.txt_tax.ReadOnly = true;
            this.txt_tax.Size = new System.Drawing.Size(84, 26);
            this.txt_tax.TabIndex = 58;
            // 
            // txt_gross
            // 
            this.txt_gross.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_gross.Location = new System.Drawing.Point(732, 695);
            this.txt_gross.Name = "txt_gross";
            this.txt_gross.ReadOnly = true;
            this.txt_gross.Size = new System.Drawing.Size(84, 26);
            this.txt_gross.TabIndex = 59;
            // 
            // txt_h
            // 
            this.txt_h.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_h.Location = new System.Drawing.Point(552, 695);
            this.txt_h.Name = "txt_h";
            this.txt_h.ReadOnly = true;
            this.txt_h.Size = new System.Drawing.Size(84, 26);
            this.txt_h.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 698);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 61;
            this.label4.Text = "Total hours";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(984, 698);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 62;
            this.label5.Text = "Total net";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(822, 698);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 63;
            this.label6.Text = "Total tax";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 698);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 64;
            this.label7.Text = "Total gross";
            // 
            // payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1156, 730);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_h);
            this.Controls.Add(this.txt_gross);
            this.Controls.Add(this.txt_tax);
            this.Controls.Add(this.txt_net);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btt_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_week);
            this.Controls.Add(this.dtp_process);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.btt_month_re);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.txt_idyear);
            this.Controls.Add(this.txt_month);
            this.Controls.Add(this.btt_wage);
            this.Controls.Add(this.txt_lyear);
            this.Controls.Add(this.txt_lmonth);
            this.Controls.Add(this.txt_lid);
            this.Controls.Add(this.btt_load);
            this.Controls.Add(this.btt_year);
            this.Controls.Add(this.btt_month);
            this.Controls.Add(this.btt_pay);
            this.Controls.Add(this.btt_remove);
            this.Controls.Add(this.btt_add);
            this.Controls.Add(this.dgv_rate);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "payments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manta & Alex LTD Payments";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form3_Activated);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_rate)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_rate;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Button btt_add;
        private System.Windows.Forms.Button btt_remove;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.Button btt_pay;
        private System.Windows.Forms.Button btt_month;
        private System.Windows.Forms.Button btt_year;
        private System.Windows.Forms.Button btt_load;
        private System.Windows.Forms.TextBox txt_lid;
        private System.Windows.Forms.TextBox txt_lmonth;
        private System.Windows.Forms.TextBox txt_lyear;
        private System.Windows.Forms.Button btt_wage;
        private System.Windows.Forms.TextBox txt_month;
        private System.Windows.Forms.TextBox txt_idyear;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txt_year;
        private System.Windows.Forms.Button btt_month_re;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPaymentsTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wageListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payslipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subcontractorTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearlyReportToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog f_browse;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtp_process;
        private System.Windows.Forms.DateTimePicker dtp_week;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btt_start;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_net;
        private System.Windows.Forms.TextBox txt_tax;
        private System.Windows.Forms.TextBox txt_gross;
        private System.Windows.Forms.TextBox txt_h;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}