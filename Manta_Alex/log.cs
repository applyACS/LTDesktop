using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manta_Alex
{
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        private void log_Load(object sender, EventArgs e)
        {
            SqlDataAdapter daAuthors = new SqlDataAdapter("Select * From log", Form1.Conn);
            DataSet dsPubs = new DataSet("Pubs");
            //dsPubs.Tables["LTD"].Columns.Add(no);
            daAuthors.FillSchema(dsPubs, SchemaType.Source, "log");
            daAuthors.Fill(dsPubs, "log");
            //dsPubs.Tables["LTD"].Columns.Add(no);
            bindingSource1.DataSource = dsPubs.Tables["log"];
            dgv_log.DataSource = bindingSource1;
        }
    }
}
