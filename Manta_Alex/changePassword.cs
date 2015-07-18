using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LTDesktop
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txt_new.UseSystemPasswordChar = false;
            }
            else
            {
                txt_new.UseSystemPasswordChar = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_old.UseSystemPasswordChar = false;
            }
            else
            {
                txt_old.UseSystemPasswordChar = true;
            }
        }

        public static bool IsValidEmail(string input)
        {
            try
            {
                new MailAddress(input);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_old.Text != null && txt_old.Text != "" && txt_new.Text != null && txt_new.Text != "")
            {
                if (IsValidEmail(txt_email.Text))
                {
                    var bytes = Encoding.UTF8.GetBytes(txt_old.Text);
                    SHA1 sha = new SHA1CryptoServiceProvider();
                    Byte[] password = sha.ComputeHash(bytes);
                    string Spassword = BitConverter.ToString(password);
                    Spassword = Spassword.Replace("-", "");

                    SqlDataAdapter userSelect = new SqlDataAdapter("SELECT * FROM Users WHERE [email] = '" + txt_email.Text + "'", Form1.Conn);
                    DataSet setUser = new DataSet("Pubs");
                    userSelect.FillSchema(setUser, SchemaType.Source, "Rates");
                    userSelect.Fill(setUser, "Rates");
                    foreach (DataRow r in setUser.Tables["Rates"].Rows)
                    {
                        if (r[2].ToString().ToUpper() == Spassword)
                        {
                            var newbytes = Encoding.UTF8.GetBytes(txt_new.Text);
                            SHA1 newsha = new SHA1CryptoServiceProvider();
                            Byte[] newpassword = sha.ComputeHash(bytes);
                            string newSpassword = BitConverter.ToString(password);
                            newSpassword = Spassword.Replace("-", "");

                            using (SqlCommand delQ = new SqlCommand("INSERT INTO Users ([password]) " +
                                       "VALUES (@pass)", Form1.Conn))
                            {
                                delQ.Parameters.Add(new SqlParameter("@pass", newSpassword));
                                delQ.ExecuteNonQuery();
                            }
                            MessageBox.Show("Password changed!");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Old password is invalid!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Email invalid!");
                }
            }
            else
            {
                MessageBox.Show("Please insert the passwords!");
            }
        }
    }
}
