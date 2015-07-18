using LTDesktop;
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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
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

        private void btn_reg_Click(object sender, EventArgs e)
        {
            if (txt_user.Text != null && txt_user.Text != "")
            {
                if (txt_pass.Text != null && txt_pass.Text != "")
                {
                    if (IsValidEmail(txt_email.Text))
                    {
                        var bytes = Encoding.UTF8.GetBytes(txt_pass.Text);
                        SHA1 sha = new SHA1CryptoServiceProvider();
                        Byte[] password = sha.ComputeHash(bytes);
                        string Spassword = BitConverter.ToString(password);
                        Spassword = Spassword.Replace("-", "");

                        using (SqlCommand delQ = new SqlCommand("INSERT INTO Users ([user], [password], [role], [email]) " +
                                       "VALUES (@user, @pass, @role, @email)", Form1.Conn))
                        {
                            delQ.Parameters.Add(new SqlParameter("@user", txt_user.Text));
                            delQ.Parameters.Add(new SqlParameter("@pass", Spassword));
                            delQ.Parameters.Add(new SqlParameter("@role", cb_role.SelectedText));
                            delQ.Parameters.Add(new SqlParameter("@email", txt_email.Text));
                            delQ.ExecuteNonQuery();
                        }
                        MessageBox.Show("New user registration succesfuly!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Email invalid!");
                    }
                }
                else
                {
                    MessageBox.Show("Password is required!");
                }
            }
            else
            {
                MessageBox.Show("Username is required!");
            }
        }
    }
}
