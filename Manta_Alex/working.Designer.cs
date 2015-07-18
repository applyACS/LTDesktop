namespace LTDesktop
{
    partial class working
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(working));
            this.dgv_people = new System.Windows.Forms.DataGridView();
            this.button_ok = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_people)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_people
            // 
            this.dgv_people.AllowUserToAddRows = false;
            this.dgv_people.AllowUserToDeleteRows = false;
            this.dgv_people.AllowUserToResizeRows = false;
            this.dgv_people.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_people.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_people.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_people.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_people.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_people.Location = new System.Drawing.Point(15, 15);
            this.dgv_people.MultiSelect = false;
            this.dgv_people.Name = "dgv_people";
            this.dgv_people.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_people.Size = new System.Drawing.Size(911, 646);
            this.dgv_people.TabIndex = 0;
            this.dgv_people.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_people_CellContentDoubleClick);
            this.dgv_people.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_people_CellEnter);
            this.dgv_people.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_people_CellLeave);
            this.dgv_people.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_people_CellMouseClick);
            this.dgv_people.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_people_CellValidated);
            this.dgv_people.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_people_RowsAdded);
            this.dgv_people.Click += new System.EventHandler(this.dgv_people_Click);
            this.dgv_people.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_people_KeyDown);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(839, 667);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(87, 27);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(938, 706);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.dgv_people);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Working people";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_people)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_people;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}