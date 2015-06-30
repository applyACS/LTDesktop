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
    public partial class Form7 : Form
    {
        DataSet dsPubs;
        SqlDataAdapter name;
        SqlDataAdapter ticket;
        public Form7()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            name = new SqlDataAdapter("Select * From LTD", Form1.Conn);
            dsPubs = new DataSet("Pubs");
            name.FillSchema(dsPubs, SchemaType.Source, "LTD");
            name.Fill(dsPubs, "LTD");
            bindingSource1.DataSource = dsPubs.Tables["LTD"];
            dataGridView_flt.DataSource = bindingSource1;
            foreach (DataGridViewColumn c in dataGridView_flt.Columns)
            {
                switch (c.Name)
                {
                    case "ID":
                        c.Visible = false;
                        break;
                    case "Birth date":
                        c.Visible = false;
                        break;
                    case "Postcode":
                        c.Visible = false;
                        break;
                    case "Nationality":
                        c.Visible = false;
                        break;
                    case "Address":
                        c.Visible = false;
                        break;
                    case "Right to work":
                        c.Visible = false;
                        break;
                    case "UTR":
                        c.Visible = false;
                        break;
                    case "NINO":
                        c.Visible = false;
                        break;
                    case "Verification no.":
                        c.Visible = false;
                        break;
                    case "Trade":
                        c.Visible = false;
                        break;
                    case "CSCS":
                        c.Visible = false;
                        break;
                    case "Bank":
                        c.Visible = false;
                        break;
                    case "CSCS Expiry date":
                        c.Visible = false;
                        break;
                    case "Start date":
                        c.Visible = false;
                        break;
                    case "Working":
                        c.Visible = false;
                        break;
                    case "Sort Code":
                        c.Visible = false;
                        break;
                    case "Acc no":
                        c.Visible = false;
                        break;
                }
            }
            ticket = new SqlDataAdapter("Select * From Ticket WHERE Convert(DateTime, [Expiry date], 103) <= '" + DateTime.Now.AddMonths(1).ToString("MM/dd/yy") + "'", Form1.Conn);
            ticket.FillSchema(dsPubs, SchemaType.Source, "Ticket");
            ticket.Fill(dsPubs, "Ticket");
            bindingSource2.DataSource = dsPubs.Tables["Ticket"];
            dataGridView_tichet.DataSource = bindingSource2;
            dataGridView_tichet.Columns[0].Visible = false;
            Validare();
        }

        private void Validare()
        {
            List<string> nrid = new List<string>();
            if (dataGridView_tichet.Rows.Count != 0)
            {
                foreach (DataGridViewRow r in dataGridView_tichet.Rows)
                {
                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                    {
                        nrid.Add(r.Cells["ID"].Value.ToString());
                    }
                }
                if (nrid.Count != 0)
                {
                    bindingSource1.Filter = "[ID] = '" + nrid[0] + "'";
                    for (int i = 1; i < nrid.Count; i++)
                    {
                        bindingSource1.Filter += " OR [ID] = '" + nrid[i] + "'";
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void dataGridView_flt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_flt.SelectedRows.Count != 0)
            {
                bindingSource2.Filter = "[ID] = '" + dataGridView_flt.SelectedRows[0].Cells[0].Value.ToString() + "'";
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_re_Click(object sender, EventArgs e)
        {
            Form6 fr = new Form6(dataGridView_flt.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_tichet.SelectedRows[0].Cells[1].Value.ToString(), dataGridView_tichet.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_tichet.SelectedRows[0].Cells[3].Value.ToString());
            fr.ShowDialog();
            dsPubs.Tables["Ticket"].Clear();
            ticket.Fill(dsPubs, "Ticket");
            Validare();
        }
    }
}
