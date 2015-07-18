using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTDesktop
{
    public partial class working : Form
    {
        SqlDataAdapter people;
        SqlDataAdapter rates;
        DataSet dsrate;
        DataSet dsPubs;
        string prcdate;
        string day;
        string month;
        string year, old;
        bool leave = false;
        bool lea = false;
        List<string> cinci = new List<string>();
        List<string> sase = new List<string>();
        List<string> sapte = new List<string>();
        List<string> opt = new List<string>();
        List<string> noua = new List<string>();
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        DataGridViewColumn no = new DataGridViewColumn();
        DataGridViewCell cel = new DataGridViewTextBoxCell();
        public working(string prdate, string dayy, string monthh, string yearr)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            no.HeaderText = "No";
            no.ReadOnly = true;
            chk.HeaderText = "";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.Width = 30;
            prcdate = prdate;
            day = dayy;
            month = monthh;
            year = yearr;
            no.CellTemplate = cel;
            dgv_people.Columns.Add(no);
            dgv_people.Columns.Add(chk);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            people = new SqlDataAdapter("Select * From LTD Where [Working] LIKE '%Active%'", Form1.Conn);
            dsPubs = new DataSet("Pubs");
            people.FillSchema(dsPubs, SchemaType.Source, "LTD");
            people.Fill(dsPubs, "LTD");
            bindingSource1.DataSource = dsPubs.Tables["LTD"];
            dgv_people.DataSource = bindingSource1;
            foreach (DataGridViewColumn c in dgv_people.Columns)
            {
                switch (c.Name)
                {
                    case "ID":
                        c.ReadOnly = true;
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
                    case "Email":
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
                    case "CSCS":
                        c.Visible = false;
                        break;
                    case "UTR":
                        c.Visible = false;
                        break;
                    case "NINO":
                        c.Visible = false;
                        break;
                    case "First Name":
                        c.ReadOnly = true;
                        break;
                    case "Middle Name":
                        c.ReadOnly = true;
                        break;
                    case "Last Name":
                        c.ReadOnly = true;
                        break;
                    case "Mobile":
                        c.Visible = false;
                        break;
                    case "Right to work":
                        c.Visible = false;
                        break;
                    case "Trade":
                        c.Visible = false;
                        break;
                    case "Verification no.":
                        c.Visible = false;
                        break;
                    case "Tax status":
                        c.Visible = false;
                        break;
                }
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ToolStripItem col = new ToolStripMenuItem(c.Name);

            }
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Name = "Rate";
            dgv_people.Columns.Add(column);
            dgv_people.Columns.Add("Col4", "Hours");
            dgv_people.Columns.Add("Col5", "Tax percent");
            
            rates = new SqlDataAdapter("SELECT * FROM Rates", Form1.Conn);
            dsrate = new DataSet("Pubs");
            rates.FillSchema(dsrate, SchemaType.Source, "Rates");
            rates.Fill(dsrate, "Rates");
            foreach (DataGridViewRow s in dgv_people.Rows)
            {
                foreach (DataRow r in dsrate.Tables["Rates"].Rows)
                {
                    if (s.Cells[2].Value != null)
                    {
                        if (s.Cells[2].Value.ToString() == r[0].ToString())
                        {
                            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(s.Cells["Rate"]);
                            cell.DataSource = new string[] { "Day-" + r[1].ToString(), "Night-" + r[2].ToString(), "Weekend-" + r[3].ToString(), "Shift-" + r[4].ToString(), "Others-" + r[5].ToString() };
                        }
                    }
                }
            }
            dgv_people.Sort(dgv_people.Columns[5], ListSortDirection.Ascending);            
            if (dgv_people.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow r in dgv_people.Rows)
                {
                    r.Cells[27].ReadOnly = true;
                    if (r.Cells[24].Value == null)
                    {
                        r.Cells[27].Value = "";
                    }
                    else
                    {
                        if (r.Cells[24].Value.ToString() == "Not known")
                        {
                            r.Cells[27].Value = "";
                        }
                        else
                        {
                            if (r.Cells[24].Value.ToString() == "Gross")
                            {
                                r.Cells[27].Value = 0;
                            }
                            else
                            {
                                if (r.Cells[24].Value.ToString() == "Standard rate")
                                {
                                    r.Cells[27].Value = 20;
                                }
                                else
                                {
                                    if (r.Cells[24].Value.ToString() == "Higher rate")
                                    {
                                        r.Cells[27].Value = 30;
                                    }
                                    else
                                    {
                                        r.Cells[27].Value = "";
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            foreach (DataGridViewColumn c in dgv_people.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            leave = true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            bool tx = false;
            int i = 0;
            rates = new SqlDataAdapter("SELECT * FROM Rates", Form1.Conn);
            dsrate = new DataSet("Pubs");
            rates.FillSchema(dsrate, SchemaType.Source, "Rates");
            rates.Fill(dsrate, "Rates");
            foreach (DataGridViewRow r in dgv_people.Rows)
            {
                if (r.Cells[1].Value != null && (bool)r.Cells[1].Value)
                {
                    i++;
                }
            }
            foreach (DataGridViewRow r in dgv_people.Rows)
            {
                if (r.Cells[1].Value != null && (bool)r.Cells[1].Value)
                {
                    if ((r.Cells[25].Value.ToString() == null || r.Cells[25].Value.ToString() == "") && (r.Cells[26].Value.ToString() == null || r.Cells[26].Value.ToString() == ""))
                    {
                        MessageBox.Show("You have to select RATE and enter the HOURS number for selected people!");
                        tx = true;
                    }
                    else
                    {
                        if (r.Cells[26].Value.ToString() == null || r.Cells[26].Value.ToString() == "")
                        {

                        }
                        else
                        {
                            if (r.Cells[27].Value.ToString() != null && r.Cells[27].Value.ToString() != "")
                            {
                                string st = r.Cells[25].Value.ToString();
                                string[] word = st.Split('-');
                                if (word[1] != "" && word[1] != " ")
                                {
                                    Double rate = 0;
                                    rate = Convert.ToDouble(word[1]);
                                    Double gross = 0;
                                    Double hours = 0;
                                    Double tax;
                                    Double taxx;
                                    hours = Convert.ToDouble(r.Cells[26].Value.ToString());
                                    gross = rate * hours;
                                    taxx = Convert.ToDouble(r.Cells[27].Value.ToString());
                                    tax = gross * taxx / 100;
                                    Double net = gross - tax;
                                    SqlCommand pay = new SqlCommand("INSERT INTO [Payments] ([ID], [First Name], [Middle Name], [Last Name], [Address], [Postcode], [Process Date], [Day], [Month], [Year], [Rate], [Hours], [Gross], [Tax], [Net], [UTR], [NINO], [Verification no.] )" + "VALUES ('" + r.Cells[2].Value.ToString() + "', '" + r.Cells[3].Value.ToString() + "', '" + r.Cells[4].Value.ToString() + "', '" + r.Cells[5].Value.ToString() + "', '" + r.Cells[7].Value.ToString() + "', '" + r.Cells[8].Value.ToString() + "', '" + prcdate + "', '" + day + "', '" + month + "', '" + year + "', '" + rate.ToString() + "', '" + hours.ToString() + "', '" + gross.ToString() + "', '" + tax.ToString() + "', '" + net.ToString() + "', '" + r.Cells[16].Value.ToString() + "', '" + r.Cells[17].Value.ToString() + "', '" + r.Cells[18].Value.ToString() + "')", Form1.Conn);
                                    pay.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a tax percent number!");
                                tx = true;
                            }
                        }
                    }
                }
                else
                {
                }
            }
            if (!tx)
            {
                this.Close();
            }
        }

        private void dgv_people_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_ok_Click((object)sender, (EventArgs)e);
            }
        }

        private void dgv_people_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int o = 1;
            for (int i = 0; i < e.RowCount; i++)
            {
                this.dgv_people.Rows[e.RowIndex + i].Cells[0].Value = (e.RowIndex + o).ToString();
                o++;
            }
        }

        private void dgv_people_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_people_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_people_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        
        }

        private void dgv_people_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (!leave && lea)
            {
                if (e.ColumnIndex > 24)
                {
                    if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    {
                        dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = old;
                    }
                    else
                    {
                        var cell = dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        if (e.ColumnIndex == 25)
                        {
                            if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cinci[e.RowIndex].ToString();
                            }
                            else
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.ToString() + cinci[e.RowIndex].ToString();
                            }
                        }
                        if (e.ColumnIndex == 26)
                        {
                            if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = sase[e.RowIndex].ToString();
                            }
                            else
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.ToString() + sase[e.RowIndex].ToString();
                            }
                        }
                        if (e.ColumnIndex == 27)
                        {
                            if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = sapte[e.RowIndex].ToString();
                            }
                            else
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.ToString() + sapte[e.RowIndex].ToString();
                            }
                        }
                        if (e.ColumnIndex == 28)
                        {
                            if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = opt[e.RowIndex].ToString();
                            }
                            else
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.ToString() + opt[e.RowIndex].ToString();
                            }
                        }
                        if (e.ColumnIndex == 29)
                        {
                            if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = noua[e.RowIndex].ToString();
                            }
                            else
                            {
                                dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.ToString() + noua[e.RowIndex].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void dgv_people_Click(object sender, EventArgs e)
        {
            if (dgv_people.Rows.Count > 1)
            {
                rates = new SqlDataAdapter("SELECT * FROM Rates", Form1.Conn);
                dsrate = new DataSet("Pubs");
                rates.FillSchema(dsrate, SchemaType.Source, "Rates");
                rates.Fill(dsrate, "Rates");
                foreach (DataGridViewRow s in dgv_people.Rows)
                {
                    foreach (DataRow r in dsrate.Tables["Rates"].Rows)
                    {
                        if (s.Cells[2].Value != null)
                        {
                            if (s.Cells[2].Value.ToString() == r[0].ToString())
                            {
                                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(s.Cells["Rate"]);
                                
                                if (cell.DataSource == null)
                                {
                                    cell.DataSource = new string[] { "Day-" + r[1].ToString(), "Night-" + r[2].ToString(), "Weekend-" + r[4].ToString(), "Shift-" + r[5].ToString(), "Others-" + r[3].ToString() };
                                    cell.Value = null;
                                }
                            }
                        }
                    }
                    if (s.Cells[1].Value != null && (bool)s.Cells[1].Value == true)
                    {
                        s.DefaultCellStyle.BackColor = Color.Aquamarine;
                    }
                    else
                    {
                        s.DefaultCellStyle.BackColor = SystemColors.Window;
                    }
                }
            }
        }

        private void dgv_people_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >=5)
            {
                if (dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    old = dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (!dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                {
                    dgv_people.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    
                }
                lea = true;
            }
        }
     }
}
