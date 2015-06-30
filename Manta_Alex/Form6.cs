using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Manta_Alex
{
    public partial class Form6 : Form
    {
        string id;
        string tt;
        bool ver;
        public Form6(string iid)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ver = true;
            id = iid;
            button_add.Visible = true;
            button_save.Visible = true;
            dateTimePicker_ex.Checked = false;
            if (!dateTimePicker_ex.Checked)
            {
                // hide date value since it's not set
                dateTimePicker_ex.CustomFormat = " ";
                dateTimePicker_ex.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker_ex.CustomFormat = "dd/MM/yyyy";
                dateTimePicker_ex.Format = DateTimePickerFormat.Custom;
            }
        }
        public Form6(string iid, string title, string code, string ex)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ver = false;
            id = iid;
            txt_title.Text = title;
            txt_code.Text = code;
            dateTimePicker_ex.Text = ex;
            tt = title;
            txt_title.ReadOnly = true;
            button_save.Text = "Save";
            button_save.Visible = true;
            button_add.Visible = false;
            dateTimePicker_ex.Checked = true;
            if (!dateTimePicker_ex.Checked)
            {
                // hide date value since it's not set
                dateTimePicker_ex.CustomFormat = " ";
                dateTimePicker_ex.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker_ex.CustomFormat = null;
                dateTimePicker_ex.Format = DateTimePickerFormat.Short;
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (txt_title.Text != null || txt_title.Text != "" && txt_code.Text != null || txt_code.Text != "" && dateTimePicker_ex.Checked)
            {
                using (SqlCommand newq = new SqlCommand("INSERT INTO Ticket ([ID], [Title], [Code], [Expiry date]) VALUES (@idd, @title, @code, @expr)", Form1.Conn))
                {
                    newq.Parameters.Add(new SqlParameter("@idd", id));
                    newq.Parameters.Add(new SqlParameter("@title", txt_title.Text));
                    newq.Parameters.Add(new SqlParameter("@code", txt_code.Text));
                    newq.Parameters.Add(new SqlParameter("@expr", dateTimePicker_ex.Value.ToString("dd/MM/yyyy")));
                    newq.ExecuteNonQuery();
                }
                //SqlCommand ticket = new SqlCommand("INSERT INTO Ticket ([ID], [Title], [Code], [Expiry date]) VALUES ('" + id + "','" + txt_title.Text + "','" + txt_code.Text + "','" + dateTimePicker_ex.Value.ToString("dd/MM/yyyy") + "')", Form1.Conn);
                //ticket.ExecuteNonQuery();
                this.Close();
                Form6 frm = new Form6(id);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show(" Title or code is empty! ");
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (ver)
            {
                if (txt_title.Text != null || txt_title.Text != "" && txt_code.Text != null || txt_code.Text != "" && dateTimePicker_ex.Checked)
                {
                    using (SqlCommand newq = new SqlCommand("INSERT INTO Ticket ([ID], [Title], [Code], [Expiry date]) VALUES (@idd, @title, @code, @expr)", Form1.Conn))
                    {
                        newq.Parameters.Add(new SqlParameter("@idd", id));
                        newq.Parameters.Add(new SqlParameter("@title", txt_title.Text));
                        newq.Parameters.Add(new SqlParameter("@code", txt_code.Text));
                        newq.Parameters.Add(new SqlParameter("@expr", dateTimePicker_ex.Value.ToString("dd/MM/yyyy")));
                        newq.ExecuteNonQuery();
                    }
                    //SqlCommand ticket = new SqlCommand("INSERT INTO Ticket ([ID], [Title], [Code], [Expiry date]) VALUES ('" + id + "','" + txt_title.Text + "','" + txt_code.Text + "','" + dateTimePicker_ex.Value.ToString("dd/MM/yyyy") + "')", Form1.Conn);
                    //ticket.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                if (txt_code.Text != null || txt_code.Text != "" && dateTimePicker_ex.Checked)
                {
                    using (SqlCommand newq = new SqlCommand("UPDATE Ticket SET [Code] = @code, [Expiry date] = @expr WHERE [ID] = @idd AND [Title] = @title", Form1.Conn))
                    {
                        newq.Parameters.Add(new SqlParameter("@idd", id));
                        newq.Parameters.Add(new SqlParameter("@title", txt_title.Text));
                        newq.Parameters.Add(new SqlParameter("@code", txt_code.Text));
                        newq.Parameters.Add(new SqlParameter("@expr", dateTimePicker_ex.Value.ToString("dd/MM/yyyy")));
                        newq.ExecuteNonQuery();
                    }
                    //SqlCommand up = new SqlCommand("UPDATE Ticket SET [Code] ='" + txt_code.Text + "', [Expiry date] ='" + dateTimePicker_ex.Text + "' WHERE [ID] = '" + id + "' AND [Title] = '" + tt + "'", Form1.Conn);
                    //up.ExecuteNonQuery();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter the code!");
                }
            }
        }

        private void txt_title_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_save.Visible == true)
            {
                button_save_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Enter && button_add.Visible == true)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_save.Visible == true)
            {
                button_save_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Enter && button_add.Visible == true)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
        }

        private void dateTimePicker_ex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button_save.Visible == true)
            {
                button_save_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Enter && button_add.Visible == true)
            {
                button_save_Click((object)sender, (EventArgs)e);
            }
        }

        private void dateTimePicker_ex_ValueChanged(object sender, EventArgs e)
        {
            if (!dateTimePicker_ex.Checked)
            {
                // hide date value since it's not set
                dateTimePicker_ex.CustomFormat = " ";
                dateTimePicker_ex.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker_ex.CustomFormat = "dd/MM/yyyy";
                dateTimePicker_ex.Format = DateTimePickerFormat.Custom;
            }
        }

        private void txt_title_Leave(object sender, EventArgs e)
        {
            txt_title.Text = txt_title.Text.ToUpper();
        }

        private void txt_code_Leave(object sender, EventArgs e)
        {
            txt_code.Text = txt_code.Text.ToUpper();
        }
    }

}
