using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTDesktop
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            txt_server.Text = LTDesktop.Properties.Settings.Default.Server.ToString();
            txt_port.Text = LTDesktop.Properties.Settings.Default.Port.ToString();
            txt_db.Text = LTDesktop.Properties.Settings.Default.DB.ToString();
            txt_user.Text = LTDesktop.Properties.Settings.Default.User.ToString();
            txt_password.Text = LTDesktop.Properties.Settings.Default.Password.ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            LTDesktop.Properties.Settings.Default.Server = txt_server.Text.ToString();
            LTDesktop.Properties.Settings.Default.Port = txt_port.Text.ToString();
            LTDesktop.Properties.Settings.Default.DB = txt_db.Text.ToString();
            LTDesktop.Properties.Settings.Default.User = txt_user.Text.ToString();
            LTDesktop.Properties.Settings.Default.Password = txt_password.Text.ToString();
            LTDesktop.Properties.Settings.Default.run = false;
            LTDesktop.Properties.Settings.Default.Save();
            this.Close();
        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                btn_save.PerformClick();
            }
        }
    }
}
