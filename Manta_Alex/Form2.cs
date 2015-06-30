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
using System.Net;
using System.Net.Mail;
using System.Xml;
using LTDesktop;
using Manta_Alex_Payments;

namespace Manta_Alex
{
    public partial class Form2 : Form
    {
        DataSet dsPubs;
        DataSet dsr;
        SqlDataAdapter daAuthors;
        SqlDataAdapter tickets;
        SqlDataAdapter darate;
        string rd, rn, ro, rw, rs;
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        DataGridViewColumn no = new DataGridViewColumn();
        CheckBox checkboxHeader = new CheckBox();
        DataGridViewCell cel = new DataGridViewTextBoxCell();
        List<int> check = new List<int>();
        DataSet1 dataset = new DataSet1();
        string id;
        bool head = false;
        bool ver = true;
        string body;
        ContextMenu cm = new ContextMenu();
        public static string deleteQuery = "DELETE FROM @table WHERE [ID] = @idd";

        public Form2()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            no.HeaderText = "No";
            chk.HeaderText = "";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.Width = 30;
            no.CellTemplate = cel;
            dataGridView.Columns.Add(no);
            dataGridView.Columns.Add(chk);
            timer1.Tick += new EventHandler(timer1_Tick); // Everytime timer ticks, timer_Tick will be called
            timer1.Interval = 25000;
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();
            txt_search1.Enabled = false;
            comboBox_se.Enabled = false;
            label3.Text = Form1.username;
            cm.MenuItems.Add("Log out", new EventHandler(logout));
            if (Form1.role == "admin")
            {
                cm.MenuItems.Add("View logs", new EventHandler(logs));
            }
        }
        
        public static string GenerateRandomString()
        {
            {
                string randomString = string.Empty;
                randomString += Path.GetRandomFileName();
                randomString = randomString.Replace(".", string.Empty);
                return randomString.Substring(0, 4) ;
            }
        }
        private void logout(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void show_chkBox()
        {
            Rectangle rect = dataGridView.GetCellDisplayRectangle(1, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 6;
            rect.X = rect.Location.X + (rect.Width / 4) +4;
            
            checkboxHeader.Name = "checkboxHeader";
            //datagridview[0, 0].ToolTipText = "sdfsdf";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dataGridView.Controls.Add(checkboxHeader);
            
        }
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox headerBox = ((CheckBox)dataGridView.Controls.Find("checkboxHeader", true)[0]);
            
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Cells[1].Value = headerBox.Checked;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 11F);
            dataGridView_ticket.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 11F);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            
            daAuthors = new SqlDataAdapter("Select * From LTD", Form1.Conn);
            dsPubs = new DataSet("Pubs");
            daAuthors.FillSchema(dsPubs, SchemaType.Source, "LTD");
            daAuthors.Fill(dsPubs, "LTD");
            bindingSource1.DataSource = dsPubs.Tables["LTD"];
            dataGridView.DataSource = bindingSource1;
            dataset.connection.Clear();
            DataSet1.connectionRow row = dataset.connection.NewconnectionRow();
            if (File.Exists("View.xml"))
            {
                dataset.ReadXml("View.xml");
                row = dataset.connection.Rows[0] as DataSet1.connectionRow;
            }
            else
            {
                row = dataset.connection.NewconnectionRow();
            }
            foreach (DataGridViewColumn c in dataGridView.Columns)
            {
                if (!File.Exists("View.xml"))
                {
                    switch (c.Name)
                    {
                        case "ID":
                            c.Visible = false;
                            row.ID = c.Visible.ToString();
                            break;
                        case "Birth date":
                            c.Visible = false;
                            row.Birth_date = c.Visible.ToString();
                            break;
                        case "Postcode":
                            c.Visible = false;
                            row.Postcode = c.Visible.ToString();
                            break;
                        case "Nationality":
                            c.Visible = false;
                            row.Nationality = c.Visible.ToString();
                            break;
                        case "Address":
                            c.Visible = false;
                            row.Address = c.Visible.ToString();
                            break;
                        case "Email":
                            c.Visible = false;
                            row.Email = c.Visible.ToString();
                            break;
                        case "Bank":
                            c.Visible = false;
                            row.Bank = c.Visible.ToString();
                            break;
                        case "CSCS Expiry date":
                            c.Visible = false;
                            row.CSCS_Expiry_date = c.Visible.ToString();
                            break;
                        case "Start date":
                            c.Visible = false;
                            row.Start_date = c.Visible.ToString();
                            break;
                        case "Working":
                            c.Visible = false;
                            row.Working = c.Visible.ToString();
                            break;
                        case "Sort Code":
                            c.Visible = false;
                            row.Sort_Code = c.Visible.ToString();
                            break;
                        case "Acc no":
                            c.Visible = false;
                            row.Acc_no = c.Visible.ToString();
                            break;
                        case "CSCS":
                            c.Visible = false;
                            row.CSCS = c.Visible.ToString();
                            break;
                        case "UTR":
                            c.Visible = false;
                            row.UTR = c.Visible.ToString();
                            break;
                        case "NINO":
                            c.Visible = false;
                            row.NINO = c.Visible.ToString();
                            break;
                        case "First Name":
                            c.ReadOnly = true;
                            row.First_Name = c.Visible.ToString();
                            break;
                        case "Middle Name":
                            c.ReadOnly = true;
                            row.Middle_Name = c.Visible.ToString();
                            break;
                        case "Last Name":
                            c.ReadOnly = true;
                            row.Last_Name = c.Visible.ToString();
                            break;
                        case "Mobile":
                            c.ReadOnly = true;
                            row.Mobile = c.Visible.ToString();
                            break;
                        case "Right to work":
                            c.ReadOnly = true;
                            row.Right_to_work = c.Visible.ToString();
                            break;
                        case "Trade":
                            c.ReadOnly = true;
                            row.Trade = c.Visible.ToString();
                            break;
                        case "Verification no.":
                            c.ReadOnly = true;
                            row._Verification_no_ = c.Visible.ToString();
                            break;
                        case "Tax status":
                            c.Visible = false;
                            row.Tax_status = c.Visible.ToString();
                            break;
                    }
                    
                }
                else
                {
                    switch (c.Name)
                    {
                        case "ID":
                            c.Visible = Convert.ToBoolean(row.ID);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Birth date":
                            c.Visible = Convert.ToBoolean(row.Birth_date);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Postcode":
                            c.Visible = Convert.ToBoolean(row.Postcode);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Nationality":
                            c.Visible = Convert.ToBoolean(row.Nationality);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Address":
                            c.Visible = Convert.ToBoolean(row.Address);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Email":
                            c.Visible = Convert.ToBoolean(row.Email);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Bank":
                            c.Visible = Convert.ToBoolean(row.Bank);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            break;
                        case "CSCS Expiry date":
                            c.Visible = Convert.ToBoolean(row.CSCS_Expiry_date);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            break;
                        case "Start date":
                            c.Visible = Convert.ToBoolean(row.Start_date);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Working":
                            c.Visible = Convert.ToBoolean(row.Working);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Sort Code":
                            c.Visible = Convert.ToBoolean(row.Sort_Code);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            break;
                        case "Acc no":
                            c.Visible = Convert.ToBoolean(row.Acc_no);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            break;
                        case "CSCS":
                            c.Visible = Convert.ToBoolean(row.CSCS);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "UTR":
                            c.Visible = Convert.ToBoolean(row.UTR);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "NINO":
                            c.Visible = Convert.ToBoolean(row.NINO);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "First Name":
                            c.Visible = Convert.ToBoolean(row.First_Name);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Middle Name":
                            c.Visible = Convert.ToBoolean(row.Middle_Name);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Last Name":
                            c.Visible = Convert.ToBoolean(row.Last_Name);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Mobile":
                            c.Visible = Convert.ToBoolean(row.Mobile);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Right to work":
                            c.Visible = Convert.ToBoolean(row.Right_to_work);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Trade":
                            c.Visible = Convert.ToBoolean(row.Trade);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Verification no.":
                            c.Visible = Convert.ToBoolean(row._Verification_no_);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                        case "Tax status":
                            c.Visible = Convert.ToBoolean(row.Tax_status);
                            if (c.Visible)
                            {
                                c.ReadOnly = true;
                            }
                            cb_search.Items.Add(c.Name.ToString());
                            comboBox_se.Items.Add(c.Name.ToString());
                            break;
                    }
                }
                
                
                
                
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            //cb_search.SelectedItem = cb_search.Items[4];
            //comboBox_se.SelectedIndex = 4;
            if (File.Exists("View.xml"))
            {

            }
            else
            {
                dataset.connection.Rows.Add(row);
                dataset.WriteXml("View.xml");
            }
            show_chkBox();
            head = true;
            cb_search.SelectedItem = cb_search.Items[1];
            comboBox_se.SelectedItem = comboBox_se.Items[2];
            tickets = new SqlDataAdapter("Select * From Ticket", Form1.Conn);
            tickets.FillSchema(dsPubs, SchemaType.Source, "Ticket");
            tickets.Fill(dsPubs, "Ticket");
            bindingSource2.DataSource = dsPubs.Tables["Ticket"];
            dataGridView_ticket.DataSource = bindingSource2;
            dataGridView_ticket.Columns[0].Visible = false;
            verifdate();
            foreach (DataGridViewColumn c in dataGridView_ticket.Columns)
            {
                cb_search.Items.Add(c.Name.ToString());
                comboBox_se.Items.Add(c.Name.ToString());
                cb_search.Items.Remove("Code");
                cb_search.Items.Remove("Expiry date");
                comboBox_se.Items.Remove("Code");
                comboBox_se.Items.Remove("Expiry date");

            }
            AddContextMenu();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.HeaderCell.ContextMenuStrip = strip;
            }
            work();
        }
        private void AddContextMenu()
        {
            for (int i=2; i < dataGridView.Columns.Count; i++)
            {
                ToolStripMenuItem tool = new ToolStripMenuItem();
                tool.Text = dataGridView.Columns[i].HeaderText.ToString();
                tool.Name = dataGridView.Columns[i].Name.ToString();
                if (dataGridView.Columns[i].Visible)
                {
                    tool.Checked = true;
                }
                tool.CheckOnClick = true;
                strip.Items.Add(tool);
            }
        }
        private void strip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Name.ToString();
            ToolStripMenuItem tool = (ToolStripMenuItem)e.ClickedItem;
            if (tool.Checked)
            {
                dataGridView.Columns[e.ClickedItem.Name].Visible = false;
            }
            else
            {
                dataGridView.Columns[e.ClickedItem.Name].Visible = true;
                dataGridView.Columns[e.ClickedItem.Name].ReadOnly = true;
            }
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            id = GenerateRandomString();
            while (dsPubs.Tables["LTD"].Select("[ID]= '" + id + "'").Count() != 0)
            {
                id = GenerateRandomString();
            }
            id = id.ToUpper();
            timer1.Stop();
            Form3 frm = new Form3(id);
            frm.ShowDialog();
            dsPubs.Tables["LTD"].Clear();
            daAuthors.Fill(dsPubs, "LTD");
            dsPubs.Tables["Ticket"].Clear();
            tickets.Fill(dsPubs, "Ticket");
            verifdate();
            work();
            timer1.Start();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            
            darate = new SqlDataAdapter("Select * From Rates", Form1.Conn);
            dsr = new DataSet("Pubs");
            darate.FillSchema(dsr, SchemaType.Source, "Rates");
            darate.Fill(dsr, "Rates");
            foreach (DataRow r in dsr.Tables["Rates"].Rows)
            {
                if (r[0].ToString() == dataGridView.SelectedRows[0].Cells[2].Value.ToString())
                {
                    rd = r[1].ToString();
                    rn = r[2].ToString();
                    ro = r[3].ToString();
                    rw = r[4].ToString();
                    rs = r[5].ToString();
                }
            }
            timer1.Stop();
            Form3 frm = new Form3(dataGridView.SelectedRows[0].Cells[2].Value.ToString(), dataGridView.SelectedRows[0].Cells[3].Value.ToString(), dataGridView.SelectedRows[0].Cells[4].Value.ToString(), dataGridView.SelectedRows[0].Cells[5].Value.ToString(), dataGridView.SelectedRows[0].Cells[6].Value.ToString(), dataGridView.SelectedRows[0].Cells[7].Value.ToString(), dataGridView.SelectedRows[0].Cells[8].Value.ToString(), dataGridView.SelectedRows[0].Cells[9].Value.ToString(), dataGridView.SelectedRows[0].Cells[10].Value.ToString(), dataGridView.SelectedRows[0].Cells[11].Value.ToString(), dataGridView.SelectedRows[0].Cells[12].Value.ToString(), dataGridView.SelectedRows[0].Cells[13].Value.ToString(), dataGridView.SelectedRows[0].Cells[14].Value.ToString(), dataGridView.SelectedRows[0].Cells[15].Value.ToString(), dataGridView.SelectedRows[0].Cells[16].Value.ToString(), dataGridView.SelectedRows[0].Cells[17].Value.ToString(), dataGridView.SelectedRows[0].Cells[18].Value.ToString(), dataGridView.SelectedRows[0].Cells[19].Value.ToString(), dataGridView.SelectedRows[0].Cells[20].Value.ToString(), dataGridView.SelectedRows[0].Cells[21].Value.ToString(), dataGridView.SelectedRows[0].Cells[22].Value.ToString(), dataGridView.SelectedRows[0].Cells[23].Value.ToString(), dataGridView.SelectedRows[0].Cells[24].Value.ToString(), rd, rn, ro, rw, rs);
            frm.ShowDialog();
            dsPubs.Tables["LTD"].Clear();
            daAuthors.Fill(dsPubs, "LTD");
            work();
            timer1.Start();
        }

        private void Search()
        {
            if (!ch_box_search.Checked)
            {
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (cb_search.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                        ver = false;
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                                else
                                {
                                    bindingSource1.Filter += "AND [ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "";
                        bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                    }
                }
                else
                {
                    bindingSource1.Filter = "";
                    ver = true;
                }
            }
            else
            {
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (txt_search1.Text != null && txt_search1.Text != "")
                    {
                        if (cb_search.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                    bindingSource1.Filter += "AND [" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                                }
                            }
                        }
                        else
                        {
                            if (comboBox_se.SelectedItem.ToString() == "Title")
                            {
                                bindingSource2.RemoveFilter();
                                bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                                ver = false;
                                List<string> nrid = new List<string>();
                                if (dataGridView_ticket.Rows.Count != 0)
                                {
                                    foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                    {
                                        if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                        {
                                            nrid.Add(r.Cells["ID"].Value.ToString());
                                        }
                                    }
                                    bindingSource1.Filter = "";
                                    if (nrid.Count != 0)
                                    {
                                        if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                        {
                                            bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                            for (int i = 1; i < nrid.Count; i++)
                                            {
                                                bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                            }
                                        }
                                        bindingSource1.Filter += "AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                                    }
                                }
                            }
                            else
                            {
                                bindingSource1.Filter = "";
                                bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                            }
                        }
                    }
                    else
                    {
                        if (cb_search.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                    else
                                    {
                                        bindingSource1.Filter += "AND [ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                        }

                    }
                }
                else
                {
                    if (txt_search1.Text != null && txt_search1.Text != "")
                    {
                        if (comboBox_se.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "";
                        ver = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6(dataGridView.SelectedRows[0].Cells[2].Value.ToString());
            frm.Show();
            dsPubs.Tables["Ticket"].Clear();
            tickets.Fill(dsPubs, "Ticket");
            verifdate();
            work();
        }

        private void verifdate()
        {
            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
            {
                if ((DateTime.Now+TimeSpan.FromDays(30)) >= Convert.ToDateTime(r.Cells[3].Value.ToString()))
                {
                    r.DefaultCellStyle.SelectionForeColor = Color.Red;
                    r.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void work()
        {
            foreach (DataGridViewRow r in dataGridView.Rows)
            {
                if (r.Cells[23].Value.ToString() == "Active")
                {
                    r.DefaultCellStyle.SelectionForeColor = Color.ForestGreen;
                    r.DefaultCellStyle.ForeColor = Color.ForestGreen;
                }
            }
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string action = "Deleted " + dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    using (SqlCommand newq = new SqlCommand("INSERT INTO log([User], [Action], [Date]) VALUES (@use, @actio, @dat)", Form1.Conn))
                    {
                        newq.Parameters.Add(new SqlParameter("@use", Form1.username));
                        newq.Parameters.Add(new SqlParameter("@actio", action));
                        newq.Parameters.Add(new SqlParameter("@dat", DateTime.Now.ToString("yyyy_MM_dd")));
                        newq.ExecuteNonQuery();
                    }
                    using (SqlCommand delQ = new SqlCommand("DELETE FROM Ticket WHERE [ID] = @idd", Form1.Conn))
                    {
                        delQ.Parameters.Add(new SqlParameter("@table", "Ticket"));
                        delQ.Parameters.Add(new SqlParameter("@idd", dataGridView.SelectedRows[0].Cells[2].Value.ToString()));
                        delQ.ExecuteNonQuery();
                    }
                    using (SqlCommand delQ = new SqlCommand("DELETE FROM LTD WHERE [ID] = @idd", Form1.Conn))
                    {
                        delQ.Parameters.Add(new SqlParameter("@table", "LTD"));
                        delQ.Parameters.Add(new SqlParameter("@idd", dataGridView.SelectedRows[0].Cells[2].Value.ToString()));
                        delQ.ExecuteNonQuery();
                    }
                    using (SqlCommand delQ = new SqlCommand("DELETE FROM Rates WHERE [ID] = @idd", Form1.Conn))
                    {
                        delQ.Parameters.Add(new SqlParameter("@table", "Rates"));
                        delQ.Parameters.Add(new SqlParameter("@idd", dataGridView.SelectedRows[0].Cells[2].Value.ToString()));
                        delQ.ExecuteNonQuery();
                    }
                    dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
                    if (dataGridView.SelectedRows.Count == 0)
                    {
                        dsPubs.Tables["Ticket"].Clear();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                }
            }
            work();

        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            bindingSource2.RemoveFilter();
            if (dataGridView.SelectedRows.Count != 0)
            {
                dsPubs.Tables["Ticket"].Clear();
                tickets.Fill(dsPubs, "Ticket");
                bindingSource2.Filter = "[ID] = '" + dataGridView.SelectedRows[0].Cells[3].Value.ToString() + "'";
                verifdate();
                work();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 fr = new Form6(dataGridView.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_ticket.SelectedRows[0].Cells[1].Value.ToString(), dataGridView_ticket.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_ticket.SelectedRows[0].Cells[3].Value.ToString());
            fr.Show();
            dsPubs.Tables["Ticket"].Clear();
            tickets.Fill(dsPubs, "Ticket");
            verifdate();
            work();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                darate = new SqlDataAdapter("Select * From Rates", Form1.Conn);
                dsr = new DataSet("Pubs");
                darate.FillSchema(dsr, SchemaType.Source, "Rates");
                darate.Fill(dsr, "Rates");
                foreach (DataRow r in dsr.Tables["Rates"].Rows)
                {
                    if (r[0].ToString() == dataGridView.SelectedRows[0].Cells[2].Value.ToString())
                    {
                        rd = r[1].ToString();
                        rn = r[2].ToString();
                        ro = r[3].ToString();
                        rw = r[4].ToString();
                        rs = r[5].ToString();
                    }
                }
                timer1.Stop();
                Form3 fr = new Form3(true, dataGridView.SelectedRows[0].Cells[2].Value.ToString(), dataGridView.SelectedRows[0].Cells[3].Value.ToString(), dataGridView.SelectedRows[0].Cells[4].Value.ToString(), dataGridView.SelectedRows[0].Cells[5].Value.ToString(), dataGridView.SelectedRows[0].Cells[6].Value.ToString(), dataGridView.SelectedRows[0].Cells[7].Value.ToString(), dataGridView.SelectedRows[0].Cells[8].Value.ToString(), dataGridView.SelectedRows[0].Cells[9].Value.ToString(), dataGridView.SelectedRows[0].Cells[10].Value.ToString(), dataGridView.SelectedRows[0].Cells[11].Value.ToString(), dataGridView.SelectedRows[0].Cells[12].Value.ToString(), dataGridView.SelectedRows[0].Cells[13].Value.ToString(), dataGridView.SelectedRows[0].Cells[14].Value.ToString(), dataGridView.SelectedRows[0].Cells[15].Value.ToString(), dataGridView.SelectedRows[0].Cells[16].Value.ToString(), dataGridView.SelectedRows[0].Cells[17].Value.ToString(), dataGridView.SelectedRows[0].Cells[18].Value.ToString(), dataGridView.SelectedRows[0].Cells[19].Value.ToString(), dataGridView.SelectedRows[0].Cells[20].Value.ToString(), dataGridView.SelectedRows[0].Cells[21].Value.ToString(), dataGridView.SelectedRows[0].Cells[22].Value.ToString(), dataGridView.SelectedRows[0].Cells[23].Value.ToString(), dataGridView.SelectedRows[0].Cells[24].Value.ToString(), rd, rn, ro, rw, rs);
                fr.ShowDialog();
                timer1.Start();
            }
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            using (SqlCommand delQ = new SqlCommand("DELETE FROM Ticket WHERE [ID] = @idd AND [Title] = @title", Form1.Conn))
            {
                delQ.Parameters.Add(new SqlParameter("@idd", dataGridView_ticket.SelectedRows[0].Cells[0].Value.ToString()));
                delQ.Parameters.Add(new SqlParameter("@title", dataGridView_ticket.SelectedRows[0].Cells[1].Value.ToString()));
                delQ.ExecuteNonQuery();
            }
            dsPubs.Tables["Ticket"].Clear();
            tickets.Fill(dsPubs, "Ticket");
            verifdate();
            work();
        }
        private void Search1()
        {
            if (txt_search.Text != null && txt_search.Text != "")
            {
                if (txt_search1.Text != null && txt_search1.Text != "")
                {
                    if (cb_search.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                        ver = false;
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                                bindingSource1.Filter += "AND [" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                            }
                        }
                    }
                    else
                    {
                        if (comboBox_se.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                    bindingSource1.Filter += "AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                        }
                    }
                }
                else
                {
                    if (cb_search.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                        ver = false;
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                                else
                                {
                                    bindingSource1.Filter += "AND [ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "";
                        bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                    }

                }
            }
            else
            {
                if (txt_search1.Text != null && txt_search1.Text != "")
                {
                    if (comboBox_se.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                        ver = false;
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "";
                        bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                    }
                }
                else
                {
                    bindingSource1.Filter = "";
                    ver = true;
                }
            }
        }

        private void dataGridView_ticket_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView_ticket.SelectedRows.Count != 0)
            {
                dataGridView.ClearSelection();
                foreach (DataGridViewRow r in dataGridView.Rows)
                {
                    if (r.Cells[2].Value.ToString() == dataGridView_ticket.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        r.Selected = true;
                    }
                }
            }

        }

        private void ch_box_search_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_box_search.Checked)
            {
                txt_search1.Enabled = true;
                comboBox_se.Enabled = true;
                Search1();
            }
            else
            {
                txt_search1.Enabled = false;
                comboBox_se.Enabled = false;
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (cb_search.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                        ver = false;
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            //bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                                else
                                {
                                    bindingSource1.Filter += "AND [ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                    }
                }
                else
                {
                    bindingSource1.Filter = "";
                    ver = true;
                }
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                //write column header
                // creating Excel Application
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


                // creating new WorkBook within Excel application
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // see the excel sheet behind the program
                app.Visible = true;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                // changing the name of active sheet
                //worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 2; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i-1] = dataGridView.Columns[i].HeaderText;
                }

                // storing Each row and column value to excel sheet
                int k = 0;
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Cells[1].Value != null && (bool)dataGridView.Rows[i].Cells[1].Value == true)
                    {
                        for (int j = 2; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[k + 2, j-1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        k = k + 1;
                    }
                }
                worksheet.Columns.AutoFit();
            }
        }

        private void button_mail_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                body = "";
                
                foreach (DataGridViewRow b in dataGridView.Rows)
                {
                    if (b.Cells[1].Value != null && (bool)b.Cells[1].Value)
                    {
                        body += b.Cells[10].Value.ToString() + " ";
                    } 
                }
                string FromMailAdress = "maltdinfo@gmail.com";
                string ToMailAdress = "maaltd@hotmail.co.uk";
                MailMessage message = new MailMessage(FromMailAdress, ToMailAdress);
                message.Subject = "Phone numbers";
                message.Body = body;
                message.Priority = MailPriority.Normal; 
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("maltdinfo@gmail.com", "Info22ma"),
                    EnableSsl = true
                };
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Email sent");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error with SMTP: " + ex.Message);
                }
                message.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count != 0)
            {
                int ii = dataGridView.SelectedRows[0].Index;
                int i = dataGridView.FirstDisplayedScrollingRowIndex;
                dsPubs.Tables["LTD"].Clear();
                daAuthors.Fill(dsPubs, "LTD");
                dataGridView.ClearSelection();
                dataGridView.Rows[ii].Selected = true;
                dataGridView.FirstDisplayedScrollingRowIndex = i;
                if (check.Count != 0)
                {
                    for (int j = 0; j <= check.Count - 1; j++)
                    {
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.Index == check[j])
                            {
                                row.Cells[1].Value = true;
                            }
                        }
                    }
                }
                dataGridView.EndEdit();
                bindingSource2.Filter = "[ID] = '" + dataGridView.Rows[ii].Cells[2].Value.ToString() + "'";
                verifdate();
                work();
                dsPubs.Dispose();
            }
        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex == 0)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                strip.Show(dataGridView, e.Location);
            }
        }

        private void btt_search_Click(object sender, EventArgs e)
        {
            if (!ch_box_search.Checked)
            {
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (cb_search.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                for (int i = 1; i < nrid.Count; i++)
                                {
                                    bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                }
                            }
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "";
                        bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a value to search!");
                }
            }
            else
            {
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (txt_search1.Text != null && txt_search1.Text != "")
                    {
                        if (cb_search.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%' AND [" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%' AND [" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (comboBox_se.SelectedItem.ToString() == "Title")
                            {
                                bindingSource2.RemoveFilter();
                                bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                                ver = false;
                                List<string> nrid = new List<string>();
                                if (dataGridView_ticket.Rows.Count != 0)
                                {
                                    foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                    {
                                        if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                        {
                                            nrid.Add(r.Cells["ID"].Value.ToString());
                                        }
                                    }
                                    bindingSource1.Filter = "";

                                    if (nrid.Count != 0)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bindingSource1.Filter = "";
                                bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                            }
                        }
                    }
                    else
                    {
                        if (cb_search.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                        }
                    }
                }
                else
                {
                    if (txt_search1.Text != null && txt_search1.Text != "")
                    {
                        if (comboBox_se.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a value to search!");
                    }
                }
            }
            verifdate();
            work();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource1.Filter = "";
            if (dataGridView.SelectedRows.Count != 0)
            {
                dsPubs.Tables["Ticket"].Clear();
                tickets.Fill(dsPubs, "Ticket");
                bindingSource2.Filter = "[ID] = '" + dataGridView.SelectedRows[0].Cells[2].Value.ToString() + "'";
                verifdate();
                work();
            }
            txt_search.Text = string.Empty;
            txt_search1.Text = string.Empty;
            ch_box_search.Checked = false;
            verifdate();
            work();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_search_Click((object)sender, (EventArgs)e);
            }
        }

        private void cb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_search_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_search1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_search_Click((object)sender, (EventArgs)e);
            }
        }

        private void comboBox_se_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_search_Click((object)sender, (EventArgs)e);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_add.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_edit.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_delete.PerformClick();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_export.PerformClick();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_mail.PerformClick();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button_del.PerformClick();
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //this.dataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int o = 1;
            for (int i = 0; i < e.RowCount; i++)
            {
                this.dataGridView.Rows[e.RowIndex + i].Cells[0].Value = (e.RowIndex + o).ToString();
                o++;
            }
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.manta-alex.co.uk");
        }

        private void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (head)
            {
                Rectangle rect = dataGridView.GetCellDisplayRectangle(1, -1, true);
                // set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 4;
                rect.X = rect.Location.X + (rect.Width / 4) -2;
                //datagridview[0, 0].ToolTipText = "sdfsdf";
                checkboxHeader.Size = new Size(18, 18);
                checkboxHeader.Location = rect.Location;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataset.connection.Clear();
            DataSet1.connectionRow row = dataset.connection.NewconnectionRow();
            foreach (DataGridViewColumn c in dataGridView.Columns)
            {
                
                if (File.Exists("View.xml"))
                {
                    File.Delete("View.xml");
                }
                switch (c.Name)
                {
                    case "ID":
                        row.ID = c.Visible.ToString();
                        break;
                    case "Birth date":
                        row.Birth_date = c.Visible.ToString();
                        break;
                    case "Postcode":
                        row.Postcode = c.Visible.ToString();
                        break;
                    case "Nationality":
                        row.Nationality = c.Visible.ToString();
                        break;
                    case "Address":
                        c.Visible = false;
                        row.Address = c.Visible.ToString();
                        break;
                    case "Email":
                        row.Email = c.Visible.ToString();
                        break;
                    case "Bank":
                        row.Bank = c.Visible.ToString();
                        break;
                    case "CSCS Expiry date":
                        row.CSCS_Expiry_date = c.Visible.ToString();
                        break;
                    case "Start date":
                        row.Start_date = c.Visible.ToString();
                        break;
                    case "Working":
                        row.Working = c.Visible.ToString();
                        break;
                    case "Sort Code":
                        row.Sort_Code = c.Visible.ToString();
                        break;
                    case "Acc no":
                        row.Acc_no = c.Visible.ToString();
                        break;
                    case "CSCS":
                        row.CSCS = c.Visible.ToString();
                        break;
                    case "UTR":
                        row.UTR = c.Visible.ToString();
                        break;
                    case "NINO":
                        row.NINO = c.Visible.ToString();
                        break;
                    case "First Name":
                        row.First_Name = c.Visible.ToString();
                        break;
                    case "Middle Name":
                        row.Middle_Name = c.Visible.ToString();
                        break;
                    case "Last Name":
                        row.Last_Name = c.Visible.ToString();
                        break;
                    case "Mobile":
                        row.Mobile = c.Visible.ToString();
                        break;
                    case "Right to work":
                        row.Right_to_work = c.Visible.ToString();
                        break;
                    case "Trade":
                        row.Trade = c.Visible.ToString();
                        break;
                    case "Verification no.":
                        row._Verification_no_ = c.Visible.ToString();
                        break;
                    case "Tax status":
                        row.Tax_status = c.Visible.ToString();
                        break;
                }
                
            }
            dataset.connection.Rows.Add(row);
            dataset.WriteXml("View.xml");
        }
        private void logs(object sender, EventArgs e)
        {
            log fr = new log();
            fr.Show();
        }
        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        cm.Show(this, label3.Location);
                    }
                    break;
            }
        }

        private void btt_files_Click(object sender, EventArgs e)
        {
            files f = new files();
            f.Show();
        }

        private void btt_payments_Click(object sender, EventArgs e)
        {
            payments payment = new payments();
            payment.Show();
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (!ch_box_search.Checked)
            {
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (cb_search.SelectedItem.ToString() == "Title")
                    {
                        bindingSource2.RemoveFilter();
                        bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                        List<string> nrid = new List<string>();
                        if (dataGridView_ticket.Rows.Count != 0)
                        {
                            foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                            {
                                if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                {
                                    nrid.Add(r.Cells["ID"].Value.ToString());
                                }
                            }
                            bindingSource1.Filter = "";
                            if (nrid.Count != 0)
                            {
                                bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                for (int i = 1; i < nrid.Count; i++)
                                {
                                    bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                }
                            }
                        }
                    }
                    else
                    {
                        bindingSource1.Filter = "";
                        bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                if (txt_search.Text != null && txt_search.Text != "")
                {
                    if (txt_search1.Text != null && txt_search1.Text != "")
                    {
                        if (cb_search.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%' AND [" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%' AND [" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (comboBox_se.SelectedItem.ToString() == "Title")
                            {
                                bindingSource2.RemoveFilter();
                                bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                                ver = false;
                                List<string> nrid = new List<string>();
                                if (dataGridView_ticket.Rows.Count != 0)
                                {
                                    foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                    {
                                        if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                        {
                                            nrid.Add(r.Cells["ID"].Value.ToString());
                                        }
                                    }
                                    bindingSource1.Filter = "";

                                    if (nrid.Count != 0)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bindingSource1.Filter = "";
                                bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%' AND [" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                            }
                        }
                    }
                    else
                    {
                        if (cb_search.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                    for (int i = 1; i < nrid.Count; i++)
                                    {
                                        bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                    }
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + cb_search.SelectedItem.ToString() + "] LIKE '%" + txt_search.Text + "%'";
                        }
                    }
                }
                else
                {
                    if (txt_search1.Text != null && txt_search1.Text != "")
                    {
                        if (comboBox_se.SelectedItem.ToString() == "Title")
                        {
                            bindingSource2.RemoveFilter();
                            bindingSource2.Filter = "[Title] LIKE '%" + txt_search1.Text + "%'";
                            ver = false;
                            List<string> nrid = new List<string>();
                            if (dataGridView_ticket.Rows.Count != 0)
                            {
                                foreach (DataGridViewRow r in dataGridView_ticket.Rows)
                                {
                                    if (!nrid.Contains(r.Cells["ID"].Value.ToString()))
                                    {
                                        nrid.Add(r.Cells["ID"].Value.ToString());
                                    }
                                }
                                bindingSource1.Filter = "";
                                if (nrid.Count != 0)
                                {
                                    if (bindingSource1.Filter == "" || bindingSource1.Filter == null)
                                    {
                                        bindingSource1.Filter = "[ID] LIKE '%" + nrid[0] + "%'";
                                        for (int i = 1; i < nrid.Count; i++)
                                        {
                                            bindingSource1.Filter += " OR [ID] LIKE '%" + nrid[i] + "%'";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            bindingSource1.Filter = "";
                            bindingSource1.Filter = "[" + comboBox_se.SelectedItem.ToString() + "] LIKE '%" + txt_search1.Text + "%'";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a value to search!");
                    }
                }
            }
            verifdate();
            work();
        }
    }
}
