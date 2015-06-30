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
    public partial class Form5 : Form
    {
        public SqlConnection Conn;
        List<string> G_arg = new List<string>();
        public bool error = false;
        public bool cancel = false;
        public Form5()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public Form5(List<string> arg)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            G_arg = arg;
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<string> arg = (List<string>)e.Argument;
                SqlConnection Conn = new SqlConnection("Data Source=" + arg[0].ToString() + (arg[1].ToString() != "" ? "," + arg[1].ToString(): "") + ";Network Library=DBMSSOCN;Initial Catalog=" + arg[2].ToString() + ";User ID=" + arg[3].ToString() + ";Password=" + arg[4].ToString() + ";");
                Conn.Open();
                e.Result = Conn;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && !cancel)
            {
                
                if (e.Result != null)
                {
                    Conn = (SqlConnection)e.Result;
                    if (Convert.ToBoolean(G_arg[5]))
                    {
                        progressBar1.ForeColor = Color.Aqua;
                        progressBar1.Style = ProgressBarStyle.Continuous;
                        progressBar1.Value = 100;
                        label_connect.Text = "Connected!";
                        SqlDataAdapter daAuthors = new SqlDataAdapter("Select TOP 100 * From LTD", Conn);
                        DataSet dsPubs = new DataSet("Pubs");
                        daAuthors.FillSchema(dsPubs, SchemaType.Source, "LTD");
                        daAuthors.Fill(dsPubs, "LTD");
                        bindingSource1.DataSource = dsPubs.Tables["LTD"];
                        dataGridView1.DataSource = bindingSource1;
                        Conn.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Visible = false;
                    MessageBox.Show("Invalid Connection");
                    error = true;
                    this.Close();
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(G_arg[5]))
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dataGridView1.Visible = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                pictureBox.Visible = true;
                this.ControlBox = false;
            }
            backgroundWorker1.RunWorkerAsync(G_arg);
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (backgroundWorker1.IsBusy)
            {
                cancel = true;
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
