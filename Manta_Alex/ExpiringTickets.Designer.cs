namespace LTDesktop
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.dataGridView_flt = new System.Windows.Forms.DataGridView();
            this.dataGridView_tichet = new System.Windows.Forms.DataGridView();
            this.button_ok = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.button_re = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_flt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tichet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_flt
            // 
            this.dataGridView_flt.AllowUserToAddRows = false;
            this.dataGridView_flt.AllowUserToDeleteRows = false;
            this.dataGridView_flt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_flt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_flt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_flt.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_flt.Name = "dataGridView_flt";
            this.dataGridView_flt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_flt.Size = new System.Drawing.Size(391, 619);
            this.dataGridView_flt.TabIndex = 0;
            this.dataGridView_flt.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_flt_RowEnter);
            // 
            // dataGridView_tichet
            // 
            this.dataGridView_tichet.AllowUserToAddRows = false;
            this.dataGridView_tichet.AllowUserToDeleteRows = false;
            this.dataGridView_tichet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_tichet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_tichet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tichet.Location = new System.Drawing.Point(409, 12);
            this.dataGridView_tichet.Name = "dataGridView_tichet";
            this.dataGridView_tichet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_tichet.Size = new System.Drawing.Size(343, 619);
            this.dataGridView_tichet.TabIndex = 1;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(677, 637);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_re
            // 
            this.button_re.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_re.Location = new System.Drawing.Point(585, 637);
            this.button_re.Name = "button_re";
            this.button_re.Size = new System.Drawing.Size(86, 23);
            this.button_re.TabIndex = 3;
            this.button_re.Text = "Renew ticket";
            this.button_re.UseVisualStyleBackColor = true;
            this.button_re.Click += new System.EventHandler(this.button_re_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 669);
            this.Controls.Add(this.button_re);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.dataGridView_tichet);
            this.Controls.Add(this.dataGridView_flt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(780, 707);
            this.Name = "Form7";
            this.Text = "Expiring tickets";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_flt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tichet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_flt;
        private System.Windows.Forms.DataGridView dataGridView_tichet;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Button button_re;
    }
}