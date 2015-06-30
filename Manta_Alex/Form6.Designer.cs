namespace Manta_Alex
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.button_add = new System.Windows.Forms.Button();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_ex = new System.Windows.Forms.DateTimePicker();
            this.button_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_add
            // 
            this.button_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_add.Location = new System.Drawing.Point(363, 63);
            this.button_add.Margin = new System.Windows.Forms.Padding(4);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(100, 28);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Next";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(16, 31);
            this.txt_title.Margin = new System.Windows.Forms.Padding(4);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(201, 22);
            this.txt_title.TabIndex = 0;
            this.txt_title.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_title_KeyDown);
            this.txt_title.Leave += new System.EventHandler(this.txt_title_Leave);
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(227, 31);
            this.txt_code.Margin = new System.Windows.Forms.Padding(4);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(132, 22);
            this.txt_code.TabIndex = 1;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_code_KeyDown);
            this.txt_code.Leave += new System.EventHandler(this.txt_code_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Expiry date";
            // 
            // dateTimePicker_ex
            // 
            this.dateTimePicker_ex.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ex.Location = new System.Drawing.Point(368, 31);
            this.dateTimePicker_ex.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_ex.Name = "dateTimePicker_ex";
            this.dateTimePicker_ex.ShowCheckBox = true;
            this.dateTimePicker_ex.Size = new System.Drawing.Size(201, 22);
            this.dateTimePicker_ex.TabIndex = 3;
            this.dateTimePicker_ex.ValueChanged += new System.EventHandler(this.dateTimePicker_ex_ValueChanged);
            this.dateTimePicker_ex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker_ex_KeyDown);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.Location = new System.Drawing.Point(471, 63);
            this.button_save.Margin = new System.Windows.Forms.Padding(4);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(100, 28);
            this.button_save.TabIndex = 12;
            this.button_save.Text = "Finish";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(588, 100);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.dateTimePicker_ex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.button_add);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(604, 139);
            this.MinimumSize = new System.Drawing.Size(604, 139);
            this.Name = "Form6";
            this.Text = "Add ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ex;
        private System.Windows.Forms.Button button_save;
    }
}