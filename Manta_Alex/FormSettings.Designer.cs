namespace LTDesktop
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_db = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(20, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 27);
            this.label6.TabIndex = 23;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(20, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 27);
            this.label5.TabIndex = 22;
            this.label5.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(20, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 27);
            this.label4.TabIndex = 21;
            this.label4.Text = "DB Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(20, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 27);
            this.label3.TabIndex = 20;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(18, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 27);
            this.label2.TabIndex = 19;
            this.label2.Text = "Server(Name or IP)";
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_password.Location = new System.Drawing.Point(225, 172);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(291, 34);
            this.txt_password.TabIndex = 18;
            this.txt_password.UseSystemPasswordChar = true;
            this.txt_password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_user.Location = new System.Drawing.Point(225, 132);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(291, 34);
            this.txt_user.TabIndex = 17;
            this.txt_user.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txt_db
            // 
            this.txt_db.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_db.Location = new System.Drawing.Point(225, 92);
            this.txt_db.Name = "txt_db";
            this.txt_db.Size = new System.Drawing.Size(291, 34);
            this.txt_db.TabIndex = 16;
            this.txt_db.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_port.Location = new System.Drawing.Point(225, 52);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(291, 34);
            this.txt_port.TabIndex = 15;
            this.txt_port.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txt_server
            // 
            this.txt_server.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_server.Location = new System.Drawing.Point(225, 12);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(291, 34);
            this.txt_server.TabIndex = 14;
            this.txt_server.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 13;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.Location = new System.Drawing.Point(406, 213);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(109, 36);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 262);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_db);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_db;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_save;
    }
}