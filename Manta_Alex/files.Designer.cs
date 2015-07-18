namespace LTDesktop
{
    partial class files
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.shellTreeView1 = new GongSolutions.Shell.ShellTreeView();
            this.shellView1 = new GongSolutions.Shell.ShellView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.shellTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.shellView1);
            this.splitContainer1.Size = new System.Drawing.Size(875, 553);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 0;
            // 
            // shellTreeView1
            // 
            this.shellTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellTreeView1.Location = new System.Drawing.Point(0, 0);
            this.shellTreeView1.Name = "shellTreeView1";
            this.shellTreeView1.RootFolder = new GongSolutions.Shell.ShellItem("file:///W:/");
            this.shellTreeView1.ShellView = this.shellView1;
            this.shellTreeView1.Size = new System.Drawing.Size(290, 553);
            this.shellTreeView1.TabIndex = 0;
            this.shellTreeView1.Click += new System.EventHandler(this.shellTreeView1_Click);
            // 
            // shellView1
            // 
            this.shellView1.CurrentFolder = new GongSolutions.Shell.ShellItem("file:///W:/");
            this.shellView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellView1.Location = new System.Drawing.Point(0, 0);
            this.shellView1.Name = "shellView1";
            this.shellView1.Size = new System.Drawing.Size(581, 553);
            this.shellView1.StatusBar = null;
            this.shellView1.TabIndex = 0;
            this.shellView1.Text = "shellView1";
            // 
            // files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 553);
            this.Controls.Add(this.splitContainer1);
            this.Name = "files";
            this.Text = "Browser";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GongSolutions.Shell.ShellTreeView shellTreeView1;
        private GongSolutions.Shell.ShellView shellView1;
    }
}