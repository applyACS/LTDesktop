using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.DirectoryServices.AccountManagement;
using System.Security.Cryptography;
using System.Net;

namespace Manta_Alex
{
    public partial class Form1 : Form
    {
        public static SqlConnection Conn;
        public static string role;
        public Form5 frm = new Form5();
        public string table = "";
        List<string> arg = new List<string>();
        bool valid = false;
        public static string username;
        string password;
        public static string logQuery = "INSERT INTO log([User], [Action], [Date]) VALUES (@use, @actio, @dat)";
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            
            if (txt_user.Text == null || txt_user.Text == "" && txt_pass.Text == null || txt_pass.Text == "")
            {
                MessageBox.Show("You have to complete all fields!");
            }
            else
            {
                arg.Add(LTDesktop.Properties.Settings.Default.Server.ToString());
                arg.Add(LTDesktop.Properties.Settings.Default.Port.ToString());
                arg.Add(LTDesktop.Properties.Settings.Default.db.ToString());
                arg.Add(LTDesktop.Properties.Settings.Default.User.ToString());
                arg.Add(LTDesktop.Properties.Settings.Default.Password.ToString());
                arg.Add("false");
                username = txt_user.Text;
                password = txt_pass.Text;
                if (Directory.Exists(@"W:\"))
                {
                    label_con.Visible = true;
                    txt_pass.Enabled = false;
                    txt_user.Enabled = false;
                    label_con.Text = "Connected";
                    
                    frm = new Form5(arg);
                    frm.ShowDialog();
                    if (frm.error)
                    {
                        return;
                    }
                    string action = "Loged in";
                    Form1.Conn = frm.Conn;

                    user(txt_user.Text, txt_pass.Text);
                    if (!valid)
                    {
                        txt_pass.Enabled = true;
                        txt_user.Enabled = true;
                        MessageBox.Show("Check your credentials", "Error");
                        return;

                    }
                    label_con.Text = "Checking for updates...";
                    update();
                    this.DialogResult = DialogResult.OK;
                    using (SqlCommand newq = new SqlCommand("INSERT INTO log([User], [Action], [Date]) VALUES (@use, @actio, @dat)", Form1.Conn))
                    {
                        newq.Parameters.Add(new SqlParameter("@use", username));
                        newq.Parameters.Add(new SqlParameter("@actio", action));
                        newq.Parameters.Add(new SqlParameter("@dat", DateTime.Now.ToString("yyyy_MM_dd")));
                        newq.CommandType = CommandType.Text;
                        newq.ExecuteNonQuery();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please start your VPN connection");
                }
                
                
            }
        }
        private void user(string user, string pass)
        {
            var bytes = Encoding.UTF8.GetBytes(pass);
            SHA1 sha = new SHA1CryptoServiceProvider();
            Byte[] password = sha.ComputeHash(bytes);
            string Spassword = BitConverter.ToString(password);
            Spassword = Spassword.Replace("-", "");

            SqlDataAdapter userSelect = new SqlDataAdapter("SELECT * FROM Users WHERE [user] = '" + user + "'", Form1.Conn);
            DataSet setUser = new DataSet("Pubs");
            userSelect.FillSchema(setUser, SchemaType.Source, "Rates");
            userSelect.Fill(setUser, "Rates");
            foreach (DataRow r in setUser.Tables["Rates"].Rows)
            {
                if (r[2].ToString().ToUpper() == Spassword)
                {
                    valid = true;
                    role = r[3].ToString();
                }
                else
                {
                    valid = false;
                }
            }
        }
        private void update()
        {
            string downloadURL = "";
            System.Version newversion = null;
            FTP("update.xml", "/Update/update.xml");
            string xmlUrl = "update.xml";
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(xmlUrl);
                reader.MoveToContent();
                string elementname = "";
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "MA"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element))
                        {
                            elementname = reader.Name;
                        }
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch (elementname)
                                {
                                    case "version":
                                        newversion = new System.Version(reader.Value);
                                        break;
                                    case "url":
                                        downloadURL = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            System.Version appversion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (appversion.CompareTo(newversion) < 0)
            {
                DialogResult dialogResult = MessageBox.Show("Version " + newversion.Major + "." + newversion.Minor + "." + newversion.Build + " of M&A Database is available, would you like to download it?", "Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(downloadURL);
                    Application.Exit();
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
        }

        private void FTP(string path, string filepath)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            string inputfilepath = @"update.xml";
            string ftphost = "87.106.241.127";
            //string ftpfilepath = "/Update/update.xml";

            string ftpfullpath = "ftp://Cloud@" + ftphost + filepath;

            using (WebClient request = new WebClient())
            {
                try
                {
                    request.Credentials = new NetworkCredential("Cloud", "alex");
                    byte[] fileData = request.DownloadData(ftpfullpath);

                    using (FileStream file = File.Create(inputfilepath))
                    {
                        file.Write(fileData, 0, fileData.Length);
                        file.Close();
                    }
                }
                catch(WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs ee)
        {
        }

        private void txt_server_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_connect_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_port_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_connect_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_data_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_connect_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_tabele_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_connect_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_connect_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_connect_Click((object)sender, (EventArgs)e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
