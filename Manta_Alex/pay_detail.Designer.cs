namespace Manta_Alex_Payments
{
    partial class pay_detail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pay_detail));
            this.txt_pay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btt_payslips = new System.Windows.Forms.Button();
            this.cb_vat = new System.Windows.Forms.CheckBox();
            this.txt_vat = new System.Windows.Forms.TextBox();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.txt_hours = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.txt_11 = new System.Windows.Forms.TextBox();
            this.txt_111 = new System.Windows.Forms.TextBox();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.txt_22 = new System.Windows.Forms.TextBox();
            this.txt_222 = new System.Windows.Forms.TextBox();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.txt_33 = new System.Windows.Forms.TextBox();
            this.txt_333 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txt_pay
            // 
            this.txt_pay.Location = new System.Drawing.Point(12, 27);
            this.txt_pay.Name = "txt_pay";
            this.txt_pay.Size = new System.Drawing.Size(146, 21);
            this.txt_pay.TabIndex = 0;
            this.txt_pay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pay_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment";
            // 
            // btt_payslips
            // 
            this.btt_payslips.Location = new System.Drawing.Point(283, 156);
            this.btt_payslips.Name = "btt_payslips";
            this.btt_payslips.Size = new System.Drawing.Size(87, 27);
            this.btt_payslips.TabIndex = 2;
            this.btt_payslips.Text = "Payslips";
            this.btt_payslips.UseVisualStyleBackColor = true;
            this.btt_payslips.Click += new System.EventHandler(this.btt_payslips_Click);
            // 
            // cb_vat
            // 
            this.cb_vat.AutoSize = true;
            this.cb_vat.Location = new System.Drawing.Point(12, 137);
            this.cb_vat.Name = "cb_vat";
            this.cb_vat.Size = new System.Drawing.Size(64, 19);
            this.cb_vat.TabIndex = 3;
            this.cb_vat.Text = "VAT no";
            this.cb_vat.UseVisualStyleBackColor = true;
            this.cb_vat.CheckedChanged += new System.EventHandler(this.cb_vat_CheckedChanged);
            this.cb_vat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_vat_KeyDown);
            // 
            // txt_vat
            // 
            this.txt_vat.Location = new System.Drawing.Point(12, 162);
            this.txt_vat.Name = "txt_vat";
            this.txt_vat.ReadOnly = true;
            this.txt_vat.Size = new System.Drawing.Size(146, 21);
            this.txt_vat.TabIndex = 4;
            this.txt_vat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_vat_KeyDown);
            // 
            // txt_rate
            // 
            this.txt_rate.Location = new System.Drawing.Point(164, 27);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.ReadOnly = true;
            this.txt_rate.Size = new System.Drawing.Size(100, 21);
            this.txt_rate.TabIndex = 5;
            // 
            // txt_hours
            // 
            this.txt_hours.Location = new System.Drawing.Point(270, 27);
            this.txt_hours.Name = "txt_hours";
            this.txt_hours.ReadOnly = true;
            this.txt_hours.Size = new System.Drawing.Size(100, 21);
            this.txt_hours.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hours";
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(12, 54);
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(146, 21);
            this.txt_1.TabIndex = 9;
            this.txt_1.Visible = false;
            this.txt_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_1_KeyDown);
            // 
            // txt_11
            // 
            this.txt_11.Location = new System.Drawing.Point(164, 54);
            this.txt_11.Name = "txt_11";
            this.txt_11.ReadOnly = true;
            this.txt_11.Size = new System.Drawing.Size(100, 21);
            this.txt_11.TabIndex = 10;
            this.txt_11.Visible = false;
            // 
            // txt_111
            // 
            this.txt_111.Location = new System.Drawing.Point(270, 54);
            this.txt_111.Name = "txt_111";
            this.txt_111.ReadOnly = true;
            this.txt_111.Size = new System.Drawing.Size(100, 21);
            this.txt_111.TabIndex = 11;
            this.txt_111.Visible = false;
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(12, 81);
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(146, 21);
            this.txt_2.TabIndex = 12;
            this.txt_2.Visible = false;
            this.txt_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_2_KeyDown);
            // 
            // txt_22
            // 
            this.txt_22.Location = new System.Drawing.Point(164, 81);
            this.txt_22.Name = "txt_22";
            this.txt_22.ReadOnly = true;
            this.txt_22.Size = new System.Drawing.Size(100, 21);
            this.txt_22.TabIndex = 13;
            this.txt_22.Visible = false;
            // 
            // txt_222
            // 
            this.txt_222.Location = new System.Drawing.Point(270, 81);
            this.txt_222.Name = "txt_222";
            this.txt_222.ReadOnly = true;
            this.txt_222.Size = new System.Drawing.Size(100, 21);
            this.txt_222.TabIndex = 14;
            this.txt_222.Visible = false;
            // 
            // txt_3
            // 
            this.txt_3.Location = new System.Drawing.Point(12, 108);
            this.txt_3.Name = "txt_3";
            this.txt_3.Size = new System.Drawing.Size(146, 21);
            this.txt_3.TabIndex = 15;
            this.txt_3.Visible = false;
            this.txt_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_3_KeyDown);
            // 
            // txt_33
            // 
            this.txt_33.Location = new System.Drawing.Point(164, 108);
            this.txt_33.Name = "txt_33";
            this.txt_33.ReadOnly = true;
            this.txt_33.Size = new System.Drawing.Size(100, 21);
            this.txt_33.TabIndex = 16;
            this.txt_33.Visible = false;
            // 
            // txt_333
            // 
            this.txt_333.Location = new System.Drawing.Point(270, 108);
            this.txt_333.Name = "txt_333";
            this.txt_333.ReadOnly = true;
            this.txt_333.Size = new System.Drawing.Size(100, 21);
            this.txt_333.TabIndex = 17;
            this.txt_333.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(383, 195);
            this.Controls.Add(this.txt_333);
            this.Controls.Add(this.txt_33);
            this.Controls.Add(this.txt_3);
            this.Controls.Add(this.txt_222);
            this.Controls.Add(this.txt_22);
            this.Controls.Add(this.txt_2);
            this.Controls.Add(this.txt_111);
            this.Controls.Add(this.txt_11);
            this.Controls.Add(this.txt_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_hours);
            this.Controls.Add(this.txt_rate);
            this.Controls.Add(this.txt_vat);
            this.Controls.Add(this.cb_vat);
            this.Controls.Add(this.btt_payslips);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_pay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments details";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_pay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btt_payslips;
        private System.Windows.Forms.CheckBox cb_vat;
        private System.Windows.Forms.TextBox txt_vat;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.TextBox txt_hours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.TextBox txt_11;
        private System.Windows.Forms.TextBox txt_111;
        private System.Windows.Forms.TextBox txt_2;
        private System.Windows.Forms.TextBox txt_22;
        private System.Windows.Forms.TextBox txt_222;
        private System.Windows.Forms.TextBox txt_3;
        private System.Windows.Forms.TextBox txt_33;
        private System.Windows.Forms.TextBox txt_333;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}