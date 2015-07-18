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
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.NetworkInformation;


namespace LTDesktop
{
    public partial class payments : Form
    {
        DataSet dsPubs;
        DataSet pdf_data = new DataSet();
        DataSet pdf_datay = new DataSet();
        SqlDataAdapter paym;
        SqlDataAdapter month;
        SqlDataAdapter year_select;
        string yname;
        string yaddress;
        string ypostcode;
        Double gross;
        Double tax;
        Double txtgross = 0;
        Double txttax = 0;
        Double txtnet = 0;
        Double txth = 0;
        string name;
        string yurt;
        string yver;
        static string pdate;
        string daay;
        string yeaar;
        string montth;
        static string weeek;
        static string end;
        bool head = false;
        static string start;
        bool activ = false;
        List<string> id = new List<string>();
        List<lis> id_address = new List<lis>();
        List<list> pay = new List<list>();
        Calendar uk = CultureInfo.CurrentCulture.Calendar;
        DataGridViewColumn no = new DataGridViewColumn();
        DataGridViewCheckBoxColumn chkk = new DataGridViewCheckBoxColumn();
        CheckBox checkboxHeader = new CheckBox();
        DataGridViewCell cel = new DataGridViewTextBoxCell();
        List<int> check = new List<int>();
        ContextMenu cm = new ContextMenu();
        public payments()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            no.HeaderText = "No";
            no.ReadOnly = true;
            chkk.HeaderText = "";
            chkk.TrueValue = true;
            chkk.FalseValue = false;
            chkk.Width = 30;
            no.CellTemplate = cel;
            dgv_rate.Columns.Add(chkk);
            if (!dtp_process.Checked)
            {
                // hide date value since it's not set
                dtp_process.CustomFormat = " ";
                dtp_process.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtp_process.CustomFormat = "dd/MM/yyyy";
                dtp_process.Format = DateTimePickerFormat.Custom;
            }
            if (!dtp_week.Checked)
            {
                // hide date value since it's not set
                dtp_week.CustomFormat = " ";
                dtp_week.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtp_week.CustomFormat = "dd/MM/yyyy";
                dtp_week.Format = DateTimePickerFormat.Custom;
            }
            label9.Text = Form1.username;
            cm.MenuItems.Add("Log out", new EventHandler(logout));
            if (label9.Text == "Administrator" || label9.Text == "administrator")
            {
                cm.MenuItems.Add("View logs", new EventHandler(logs));
            }
        }
        private void sort()
        {
            DataView view = dsPubs.Tables["Payments"].DefaultView;
            view.Sort = "Last Name ASC, First Name ASC";
            dgv_rate.DataSource = view;
        }
        private void logout(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void logs(object sender, EventArgs e)
        {
            log fr = new log();
            fr.Show();
        }
        private void show_chkBox()
        {
            System.Drawing.Rectangle rect = dgv_rate.GetCellDisplayRectangle(1, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position 
            rect.Y = 6;
            rect.X = rect.Location.X + (rect.Width / 4) + 4;

            checkboxHeader.Name = "checkboxHeader";
            //datagridview[0, 0].ToolTipText = "sdfsdf";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dgv_rate.Controls.Add(checkboxHeader);

        }
        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox headerBox = ((CheckBox)dgv_rate.Controls.Find("checkboxHeader", true)[0]);

            for (int i = 0; i < dgv_rate.RowCount; i++)
            {
                dgv_rate.Rows[i].Cells[1].Value = headerBox.Checked;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void VisibleOnly()
        {
            foreach (DataGridViewColumn c in dgv_rate.Columns)
            {

                switch (c.Name)
                {
                    case "ID":
                        c.Visible = false;
                        break;
                    case "First Name":
                        c.Visible = true;
                        break;
                    case "Middle Name":
                        c.Visible = false;
                        break;
                    case "Last Name":
                        c.Visible = true;
                        break;
                    case "Process Date":
                        c.Visible = false;
                        break;
                    case "Day":
                        c.Visible = false;
                        break;
                    case "Month":
                        c.Visible = false;
                        break;
                    case "Year":
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
                    case "Gross":
                        c.ReadOnly = true;
                        break;
                    case "Tax":
                        c.ReadOnly = true;
                        break;
                    case "Net":
                        c.ReadOnly = true;
                        break;
                    case "Rate":
                        c.ReadOnly = true;
                        break;
                    case "Hours":
                        c.ReadOnly = true;
                        break;
                    case "Address":
                        c.Visible = false;
                        break;
                    case "Postcode":
                        c.Visible = false;
                        break;
                }
            }
            //dgv_rate.Sort(dgv_rate.Columns[2], ListSortDirection.Ascending);
            sort();
            foreach (DataGridViewRow s in dgv_rate.Rows)
            {
                if (!id.Contains(s.Cells[1].Value.ToString()))
                {
                    id.Add(s.Cells[1].Value.ToString());

                    id_address.Add(new lis
                    {
                        id = s.Cells[1].Value.ToString(),
                        address = s.Cells[5].Value.ToString(),
                        postcode = s.Cells[6].Value.ToString(),
                        name = s.Cells[2].Value.ToString() + " " + s.Cells[3].Value.ToString() + " " + s.Cells[4].Value.ToString(),
                        utr = s.Cells[16].Value.ToString(),
                        ver = s.Cells[18].Value.ToString()
                    });
                }
            }

        }
        public class lis
        {
            public string id { get; set; }
            public string address { get; set; }
            public string postcode { get; set; }
            public string name { get; set; }
            public string utr { get; set; }
            public string ver { get; set; }
        }
        public class list
        {
            public string rate { get; set; }
            public string hours { get; set; }
            public string gross { get; set; }
            public string tax { get; set; }
            public string net { get; set; }
        }
        private void btt_add_Click(object sender, EventArgs e)
        {
            working frm = new working(pdate, daay, montth, yeaar);
            frm.ShowDialog();
            activ = true;
            dsPubs.Tables["Payments"].Clear();
            paym.Fill(dsPubs, "Payments");
            sort();
            txth = 0;
            txtgross = 0;
            txtnet = 0;
            txttax = 0;
            foreach (DataGridViewRow s in dgv_rate.Rows)
            {
                txth += Convert.ToDouble(s.Cells[12].Value.ToString());
                txtgross += Convert.ToDouble(s.Cells[13].Value.ToString());
                txttax += Convert.ToDouble(s.Cells[14].Value.ToString());
                txtnet += Convert.ToDouble(s.Cells[15].Value.ToString());
                if (!id.Contains(s.Cells[1].Value.ToString()))
                {
                    id.Add(s.Cells[1].Value.ToString());

                    id_address.Add(new lis
                    {
                        id = s.Cells[1].Value.ToString(),
                        address = s.Cells[5].Value.ToString(),
                        postcode = s.Cells[6].Value.ToString(),
                        name = s.Cells[2].Value.ToString() + " " + s.Cells[3].Value.ToString() + " " + s.Cells[4].Value.ToString(),
                        utr = s.Cells[16].Value.ToString(),
                        ver = s.Cells[18].Value.ToString()
                    });
                }
            }
            txt_h.Text = txth.ToString();
            txt_gross.Text = txtgross.ToString();
            txt_tax.Text = txttax.ToString();
            txt_net.Text = txtnet.ToString();
        }

        private void btt_remove_Click(object sender, EventArgs e)
        {
            dgv_rate.EndEdit();
            foreach (DataGridViewRow r in dgv_rate.Rows)
            {
                if (r.Cells[0].Value != null && (bool)r.Cells[0].Value)
                {
                    SqlCommand undo = new SqlCommand("DELETE FROM [Payments] Where [ID] ='" + r.Cells[1].Value.ToString() + "' And [Gross] ='" + r.Cells[13].Value.ToString() + "'", Form1.Conn);
                    undo.ExecuteNonQuery();
                }
            }
            dsPubs.Tables["Payments"].Clear();
            paym.Fill(dsPubs, "Payments");
        }

        private void txt_lid_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_lid.Text == "ID")
            {
                txt_lid.Text = string.Empty;
                txt_lid.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_lid_Leave(object sender, EventArgs e)
        {
            if (txt_lid.Text == null || txt_lid.Text == "")
            {
                txt_lid.Text = "ID";
                txt_lid.ForeColor = SystemColors.ControlDarkDark;
            }
            txt_lid.Text.ToUpper();
        }

        private void txt_lmonth_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_lmonth.Text == "Month")
            {
                txt_lmonth.Text = string.Empty;
                txt_lmonth.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_lmonth_Leave(object sender, EventArgs e)
        {
            if (txt_lmonth.Text == null || txt_lmonth.Text == "")
            {
                txt_lmonth.Text = "Month";
                txt_lmonth.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void txt_lyear_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_lyear.Text == "Year")
            {
                txt_lyear.Text = string.Empty;
                txt_lyear.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_lyear_Leave(object sender, EventArgs e)
        {
            if (txt_lyear.Text == null || txt_lyear.Text == "")
            {
                txt_lyear.Text = "Year";
                txt_lyear.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void btt_load_Click(object sender, EventArgs e)
        {
            if (txt_lid.Text != "ID")
            {
                if (txt_lmonth.Text != "Month")
                {
                    if (dsPubs != null)
                    {
                        dsPubs.Tables["Payments"].Clear();
                    }
                    dsPubs = new DataSet("Pubs");
                    paym = new SqlDataAdapter("Select * From Payments Where [ID] = '" + txt_lid.Text + "' AND [Month]  '" + txt_lmonth.Text + "'", Form1.Conn);
                    paym.FillSchema(dsPubs, SchemaType.Source, "Payments");
                    paym.Fill(dsPubs, "Payments");
                    bindingSource2.DataSource = dsPubs.Tables["Payments"];
                    dgv_rate.DataSource = bindingSource2;
                    VisibleOnly();
                }
                else
                {
                    if (txt_lyear.Text != "Year")
                    {
                        if (dsPubs != null)
                        {
                            dsPubs.Tables["Payments"].Clear();
                        }
                        dsPubs = new DataSet("Pubs");
                        paym = new SqlDataAdapter("Select * From Payments Where [ID] = '" + txt_lid.Text + "' AND [Year] = '" + txt_lyear.Text + "'", Form1.Conn);
                        paym.FillSchema(dsPubs, SchemaType.Source, "Payments");
                        paym.Fill(dsPubs, "Payments");
                        bindingSource2.DataSource = dsPubs.Tables["Payments"];
                        dgv_rate.DataSource = bindingSource2;
                        VisibleOnly();
                    }
                    else
                    {
                        if (dsPubs != null)
                        {
                            dsPubs.Tables["Payments"].Clear();
                        }
                        dsPubs = new DataSet("Pubs");
                        paym = new SqlDataAdapter("Select * From Payments Where [ID] = '" + txt_lid.Text + "'", Form1.Conn);
                        paym.FillSchema(dsPubs, SchemaType.Source, "Payments");
                        paym.Fill(dsPubs, "Payments");
                        bindingSource2.DataSource = dsPubs.Tables["Payments"];
                        dgv_rate.DataSource = bindingSource2;
                        VisibleOnly();
                    }
                }
            }
            else
            {
                if (txt_lmonth.Text != "Month")
                {
                    if (dsPubs != null)
                    {
                        dsPubs.Tables["Payments"].Clear();
                    }
                    dsPubs = new DataSet("Pubs");
                    paym = new SqlDataAdapter("Select * From Payments Where [Month] = '" + txt_lmonth.Text + "'", Form1.Conn);
                    paym.FillSchema(dsPubs, SchemaType.Source, "Payments");
                    paym.Fill(dsPubs, "Payments");
                    bindingSource2.DataSource = dsPubs.Tables["Payments"];
                    dgv_rate.DataSource = bindingSource2;
                    VisibleOnly();
                }
                else
                {
                    if (txt_lyear.Text != "Year")
                    {
                        if (dsPubs != null)
                        {
                            dsPubs.Tables["Payments"].Clear();
                        }
                        dsPubs = new DataSet("Pubs");
                        paym = new SqlDataAdapter("Select * From Payments Where [Year] = '" + txt_lyear.Text + "'", Form1.Conn);
                        paym.FillSchema(dsPubs, SchemaType.Source, "Payments");
                        paym.Fill(dsPubs, "Payments");
                        bindingSource2.DataSource = dsPubs.Tables["Payments"];
                        dgv_rate.DataSource = bindingSource2;
                        VisibleOnly();
                    }
                    else
                    {
                        MessageBox.Show("You have to complete at least one field!");
                    }
                }
            }
        }

        private void btt_wage_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.130.12\d\Wage_list";
            bool tru = false;
            if (File.Exists(Path.Combine(path, "Wage " + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf")))
            {
                MessageBox.Show("File already exists!");
            }
            else
            {
                Document doc = new Document(PageSize.A4_LANDSCAPE, 25, 25, 150, 50);
                
                doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(Path.Combine(path, "Wage " + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf"), FileMode.Create));
                doc.Open();
                wri.PageEvent = new PageEventHelper();

                PdfPTable table = new PdfPTable(dgv_rate.Columns.Count - 10);
                table.WidthPercentage = 90;
                //dgv_rate.Sort(dgv_rate.Columns[4], ListSortDirection.Ascending);
                sort();
                double tg = 0;
                double tt = 0;
                double tn = 0;
                float[] w = new float[18];
                Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                SizeF f = new SizeF();
                System.Drawing.Font font = new System.Drawing.Font("Curier", 14, FontStyle.Bold);

                for (int i = 1; i < dgv_rate.Columns.Count; i++)
                {
                    if (i != 5 && i != 6 && i != 7 && i != 8 && i != 9 && i != 10 && i != 16 && i != 17 && i != 18)
                    {
                        table.AddCell(new Phrase(dgv_rate.Columns[i].HeaderText, FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                        f = g.MeasureString(dgv_rate.Columns[i].HeaderText, font);
                        if (f.Width > w[i])
                        {
                            w[i] = f.Width;
                        }
                    }
                }
                table.HeaderRows = 0;
                for (int i = 0; i < dgv_rate.Rows.Count; i++)
                {
  
                    for (int j = 1; j < dgv_rate.Columns.Count; j++)
                    {
                        if (dgv_rate[j, i].Value != null && j != 5 && j != 6 && j != 7 && j != 8 && j != 9 && j != 10 && j != 16 && j != 17 && j != 18)
                        {
                            
                            table.AddCell(new Phrase(dgv_rate[j, i].Value.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 13)));
                            f = g.MeasureString(dgv_rate[j, i].Value.ToString(), font);
                            if (f.Width > w[j])
                            {
                                w[j] = f.Width;
                            }
                            if (j == 13)
                            {
                                tg += Convert.ToDouble(dgv_rate[j, i].Value);
                            }
                            if (j == 14)
                            {
                                tt += Convert.ToDouble(dgv_rate[j, i].Value);
                            }
                            if (j == 15)
                            {
                                tn += Convert.ToDouble(dgv_rate[j, i].Value);
                            }
                        }
                    }
                }
                PdfPCell cell = new PdfPCell();
                cell.Border = 0;
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("£ " + tg.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString("  £ " + tg.ToString(), font);
                if (f.Width > w[13])
                {
                    w[13] = f.Width;
                }
                cell.Border = 1;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("£ " + tt.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString("  £ " + tt.ToString(), font);
                if (f.Width > w[14])
                {
                    w[14] = f.Width;
                }
                cell.Border = 1;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("£ " + tn.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString("  £ " + tn.ToString(), font);
                if (f.Width > w[15])
                {
                    w[15] = f.Width;
                }
                cell.Border = 1;
                table.AddCell(cell);
                float[] widths = new float[] { w[1], w[2], w[3], w[4], w[11], w[12], w[13], w[14], w[15] };
                table.SetWidths(widths);
                doc.Add(table);
                doc.NewPage();
                PdfPTable tab = new PdfPTable(dgv_rate.Columns.Count - 11);
                tab.AddCell(new Phrase("No.", FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString("No. ", font);
                w[0] = f.Width;
                int no = 1;
                for (int i = 1; i < dgv_rate.Columns.Count; i++)
                {
                    if (i != 5 && i != 6 && i != 7 && i != 8 && i != 9 && i != 10 && i != 11 && i != 12 && i != 16 && i != 17 && i != 18)
                    {
                        tab.AddCell(new Phrase(dgv_rate.Columns[i].HeaderText, FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                        f = g.MeasureString(dgv_rate.Columns[i].HeaderText.ToString(), font);
                        if (f.Width > w[i])
                        {
                            w[i] = f.Width;
                        }
                    }
                }
                tab.HeaderRows = 0;
                string id = "";
                for (int i = 0; i < dgv_rate.Rows.Count; i++)
                {
                    if (id == dgv_rate.Rows[i].Cells[1].Value.ToString())
                    {

                    }
                    else
                    {
                        tab.AddCell(new Phrase(no.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 13)));
                        id = dgv_rate.Rows[i].Cells[1].Value.ToString();
                        double totg = Convert.ToDouble(dgv_rate.Rows[i].Cells[13].Value);
                        double tott = Convert.ToDouble(dgv_rate.Rows[i].Cells[14].Value);
                        double totn = Convert.ToDouble(dgv_rate.Rows[i].Cells[15].Value);
                        for (int j = i + 1; j < dgv_rate.Rows.Count; j++)
                        {
                            if (id == dgv_rate.Rows[j].Cells[1].Value.ToString())
                            {
                                totg += Convert.ToDouble(dgv_rate.Rows[j].Cells[13].Value);
                                tott += Convert.ToDouble(dgv_rate.Rows[j].Cells[14].Value);
                                totn += Convert.ToDouble(dgv_rate.Rows[j].Cells[15].Value);
                            }
                        }
                        for (int j = 1; j < dgv_rate.Columns.Count; j++)
                        {
                            if (dgv_rate[j, i].Value != null && j != 5 && j != 6 && j != 7 && j != 8 && j != 9 && j != 10 && j != 11 && j != 12 && j != 13 && j != 14 && j != 15 && j != 16 && j != 17 && j != 18)
                            {
                                tab.AddCell(new Phrase(dgv_rate[j, i].Value.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 13)));
                                f = g.MeasureString(dgv_rate[j, i].Value.ToString(), font);
                                if (f.Width > w[j])
                                {
                                    w[j] = f.Width;
                                }
                            }
                            if (j == 13)
                            {
                                tab.AddCell(new Phrase(totg.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 13)));
                            }
                            if (j == 14)
                            {
                                tab.AddCell(new Phrase(tott.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 13)));
                            }
                            if (j == 15)
                            {
                                tab.AddCell(new Phrase(totn.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 13)));
                            }

                        }
                        no++;
                    }
                }
                cell = new PdfPCell();
                cell.Border = 0;
                tab.AddCell(cell);
                tab.AddCell(cell);
                tab.AddCell(cell);
                tab.AddCell(cell);
                tab.AddCell(cell);
                cell = new PdfPCell(new Phrase("£ " + tg.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString(" £ " + tg.ToString(), font);
                if (f.Width > w[13])
                {
                    w[13] = f.Width;
                }
                cell.Border = 1;
                tab.AddCell(cell);
                cell = new PdfPCell(new Phrase("£ " + tt.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString(" £ " + tt.ToString(), font);
                if (f.Width > w[14])
                {
                    w[14] = f.Width;
                }
                cell.Border = 1;
                tab.AddCell(cell);
                cell = new PdfPCell(new Phrase("£ " + tn.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 14)));
                f = g.MeasureString(" £ " + tn.ToString(), font);
                if (f.Width > w[15])
                {
                    w[15] = f.Width;
                }
                cell.Border = 1;
                tab.AddCell(cell);
                //table.WidthPercentage = 100;
                widths = new float[] {w[0], w[1], w[2], w[3], w[4], w[13], w[14], w[15] };
                tab.SetWidths(widths);
                doc.Add(tab);
                doc.Close();
                tru = true;
                string action = "Created WAGE LIST Wage " + DateTime.Now.ToString("yyyy_MM_dd") + ".pdf ";
                SqlCommand log = new SqlCommand("INSERT INTO log([User], [Action], [Date])" + "VALUES ('" + Form1.username + "','" + action + "','" + DateTime.Now.ToLongDateString() + "')", Form1.Conn);
                if (tru)
                {
                    DialogResult dr = MessageBox.Show("Do you want do open it?", "Wage list done!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Path.Combine(path, "Wage " + DateTime.Now.ToString("dd_MM_yyyy") + ".pdf"));
                    }
                    else if (dr == DialogResult.No)
                    {
                    }
                }
            }
        }

         public class PageEventHelper : PdfPageEventHelper {
             public override void OnEndPage(PdfWriter writer, Document doc)
             {
                 BaseColor grey = new BaseColor(128, 128, 128); 
                 iTextSharp.text.Font font = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL, grey);
                 // cell height 
                 float cellHeight = doc.TopMargin;
                 // PDF document size      
                 iTextSharp.text.Rectangle page = doc.PageSize;

                 // create two column table
                 PdfPTable head = new PdfPTable(2);
                 head.TotalWidth = page.Width - 30;
                 string url = "logo.jpg";
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(url);
                img.ScaleAbsolute(175, 45);
                img.Alignment = Element.ALIGN_LEFT;
                PdfPTable logo = new PdfPTable(1);
                 PdfPCell c = new PdfPCell(img, false);
                 c.HorizontalAlignment = Element.ALIGN_LEFT;
                 //c.FixedHeight = cellHeight;
                 c.Border = PdfPCell.NO_BORDER;
                 logo.AddCell(c);
                 BaseColor color = new BaseColor(249, 79, 1);
                 Paragraph heade = new Paragraph("MANTA & ALEX LTD", FontFactory.GetFont(BaseFont.TIMES_BOLD, 17, color)) { Alignment = Element.ALIGN_RIGHT };
                 c = new PdfPCell(new Phrase(heade));
                 c.HorizontalAlignment = Element.ALIGN_LEFT;
                 c.Border = PdfPCell.NO_BORDER;
                 logo.AddCell(c);
                 c = new PdfPCell(logo);
                 c.HorizontalAlignment = Element.ALIGN_LEFT;
                 c.Border = PdfPCell.NO_BORDER;
                 head.AddCell(c);
                 PdfPTable t = new PdfPTable(1);
                 Paragraph header = new Paragraph("WAGE LIST", FontFactory.GetFont(BaseFont.TIMES_BOLD, 17)) { Alignment = Element.ALIGN_RIGHT };
                 Paragraph header1 = new Paragraph("33 THE CHASE, EDGWARE, MIDDLESEX \nLONDON HA8 5DW \nTel/Fax No 02032096071 \nMobile No: 07792820031, 07800963526 \nEmail maaltd@hotmail.co.uk \n\n\n\n", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, BaseColor.BLACK)) { Alignment = Element.ALIGN_RIGHT };
                 Paragraph proces = new Paragraph("Proces date: " + pdate, FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)) { Alignment = Element.ALIGN_RIGHT };
                 Paragraph week = new Paragraph(" Week: " + weeek, FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)) { Alignment = Element.ALIGN_RIGHT };
                 Paragraph period = new Paragraph("Period: " + start + " - " + end + "\n\n", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)) { Alignment = Element.ALIGN_RIGHT };
                 c = new PdfPCell(new Phrase(header));
                 c.HorizontalAlignment = Element.ALIGN_RIGHT;
                 c.Border = PdfPCell.NO_BORDER;
                 t.AddCell(c);
                 c = new PdfPCell(new Phrase(proces));
                 c.HorizontalAlignment = Element.ALIGN_RIGHT;
                 c.Border = PdfPCell.NO_BORDER;
                 t.AddCell(c);
                 c = new PdfPCell(new Phrase(week));
                 c.HorizontalAlignment = Element.ALIGN_RIGHT;
                 c.Border = PdfPCell.NO_BORDER;
                 t.AddCell(c);
                 c = new PdfPCell(new Phrase(period));
                 c.HorizontalAlignment = Element.ALIGN_RIGHT;
                 c.Border = PdfPCell.NO_BORDER;
                 t.AddCell(c);
                 c = new PdfPCell(t);
                 c.HorizontalAlignment = Element.ALIGN_RIGHT;
                 c.Border = PdfPCell.NO_BORDER;
                 head.AddCell(c);
                 head.WriteSelectedRows(0, -1, 15, page.Height - cellHeight + 115, writer.DirectContent);
                 //tbl footer 
                 PdfPTable footerTbl = new PdfPTable(1);
                 footerTbl.TotalWidth = doc.PageSize.Width; 
                 //numero de la page

                 Chunk myFooter = new Chunk("Page " + (doc.PageNumber), FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, grey)); 
                 PdfPCell footer = new PdfPCell(new Phrase(myFooter)); 
                 footer.Border = iTextSharp.text.Rectangle.NO_BORDER; 
                 footer.HorizontalAlignment = Element.ALIGN_CENTER; 
                 footerTbl.AddCell(footer); 
                 footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 3), writer.DirectContent);
                 //doc.PageSize.Width = doc.PageSize.Width - 200;
                 writer.SetMargins(25, 25, 500, 60);
                 PdfPCell cel = new PdfPCell();
                 doc.Add(cel);
                 doc.Add(cel);
                 doc.Add(cel);
                 doc.Add(cel);
                 doc.Add(cel);
             }
         }
        private void btt_pay_Click(object sender, EventArgs e)
        {
            if (dgv_rate.Rows.Count != 0)
            {
                for (int i = 0; i < id_address.Count; i++)
                {
                    pay = new List<list>();
                    foreach (DataGridViewRow r in dgv_rate.Rows)
                    {
                        if (id_address[i].id == r.Cells[1].Value.ToString())
                        {
                            pay.Add(new list
                            {
                                rate = r.Cells[11].Value.ToString(),
                                hours = r.Cells[12].Value.ToString(),
                                gross = r.Cells[13].Value.ToString(),
                                tax = r.Cells[14].Value.ToString(),
                                net = r.Cells[15].Value.ToString()
                            });
                        }
                    }
                    pay_detail frm = new pay_detail(pay, id_address, i, pdate, weeek);
                    frm.ShowDialog();
                }
            }
        }

        private void btt_month_Click(object sender, EventArgs e)
        {
            string path = @"\\192.168.130.12\d\Montly_tax";
            if (txt_month.Text == null || txt_month.Text == "" || txt_month.Text == "MONTH NUMBER")
            {
                month = new SqlDataAdapter("SELECT * FROM [Payments] Where [Month] = '" + DateTime.Now.Month.ToString() + "' AND [Year] = '" + DateTime.Now.Year.ToString() + "'", Form1.Conn);
            }
            else if(txt_month.TextLength <= 2)
            {
                month = new SqlDataAdapter("SELECT * FROM [Payments] Where [Month] = '" + txt_month.Text.ToString() + "' AND [Year] = '" + DateTime.Now.Year.ToString() + "'", Form1.Conn);
            }
            pdf_data = new DataSet("Pubs");
            month.FillSchema(pdf_data, SchemaType.Source, "Payments");
            month.Fill(pdf_data, "Payments");
            if (pdf_data.Tables["Payments"].Rows.Count != 0)
            {
                bool tru = false;
                if (File.Exists(Path.Combine(path, "Monthly Tax " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + ".pdf")))
                {
                    MessageBox.Show("File already exists!");
                }
                else
                {
                    Document doc = new Document(PageSize.A4_LANDSCAPE, 25, 25, 50, 50);
                    doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(Path.Combine(path, "Monthly Tax " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + ".pdf"), FileMode.Create));
                    doc.Open();
                    Paragraph header = new Paragraph("MANTA & ALEX LTD\n\n\n", FontFactory.GetFont(BaseFont.TIMES_BOLD, 26, BaseColor.RED)) { Alignment = Element.ALIGN_RIGHT };
                    Paragraph date = new Paragraph(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "\n", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)) { Alignment = Element.ALIGN_LEFT };
                    PdfPTable table = new PdfPTable(1);
                    table.WidthPercentage = 100;
                    PdfPTable t1 = new PdfPTable(7);
                    PdfPCell cel = new PdfPCell(new Phrase("Contract no.", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Name", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Gross", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Tax", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("UTR", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Nino", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Verification no.", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(t1);
                    table.AddCell(cel);
                    foreach (DataRow r in pdf_data.Tables["Payments"].Rows)
                    {
                        if (!id.Contains(r.ItemArray[1].ToString()))
                        {
                            id.Add(r.ItemArray[1].ToString());
                        }
                    }
                    for (int i = 0; i < id.Count; i++)
                    {
                        PdfPTable var = new PdfPTable(7);
                        string utr = "";
                        string nino = "";
                        string ver = "";
                        gross = 0;
                        tax = 0;
                        foreach (DataRow r in pdf_data.Tables["Payments"].Rows)
                        {
                            if (id[i].ToString() == r.ItemArray[0].ToString())
                            {
                                name = r.ItemArray[1].ToString() + " " + r.ItemArray[2].ToString() + " " + r.ItemArray[3].ToString();
                                gross += Convert.ToDouble(r.ItemArray[12].ToString());
                                tax += Convert.ToDouble(r.ItemArray[13].ToString());
                                utr = r.ItemArray[15].ToString();
                                nino = r.ItemArray[16].ToString();
                                ver = r.ItemArray[17].ToString();
                            }
                        }
                        cel = new PdfPCell(new Phrase(id[i].ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(new Phrase(name, FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(new Phrase(gross.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(new Phrase(tax.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(new Phrase(utr, FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(new Phrase(nino, FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(new Phrase(ver, FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                        var.AddCell(cel);
                        cel = new PdfPCell(var);
                        table.AddCell(cel);
                    }
                    doc.Add(header);
                    doc.Add(date);
                    doc.Add(table);
                    doc.Close();
                    tru = true;
                    string action = "Created file Monthly Tax " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + ".pdf";
                    SqlCommand log = new SqlCommand("INSERT INTO log([User], [Action], [Date])" + "VALUES ('" + Form1.username + "','" + action + "','" + DateTime.Now.ToLongDateString() + "')", Form1.Conn);

                    if (tru)
                    {
                        DialogResult dr = MessageBox.Show("Do you want do open it?", "Yearly report done!", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Path.Combine(path, "Monthly Tax " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + ".pdf"));
                        }
                        else if (dr == DialogResult.No)
                        {
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("There are no payments in this month!");
            }
        }

        private void txt_month_Leave(object sender, EventArgs e)
        {
            if (txt_month.Text == null || txt_month.Text == "")
            {
                txt_month.Text = "MONTH NUMBER";
                txt_month.ForeColor = SystemColors.ControlDarkDark;
            }
            txt_month.Text.ToUpper();
        }

        private void txt_month_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_month.Text == "MONTH NUMBER")
            {
                txt_month.Text = String.Empty;
                txt_month.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_idyear_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_idyear.Text == "ID NUMBER")
            {
                txt_idyear.Text = String.Empty;
                txt_idyear.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_idyear_Leave(object sender, EventArgs e)
        {
            if (txt_idyear.Text == null || txt_idyear.Text == "")
            {
                txt_idyear.Text = "ID NUMBER";
                txt_idyear.ForeColor = SystemColors.ControlDarkDark;
            }
            txt_idyear.Text.ToUpper();
        }

        private void btt_year_Click(object sender, EventArgs e)
        {

            if (txt_idyear.Text != "ID NUMBER")
            {
                if (txt_year.Text != "MONTH/YEAR")
                {
                    if (txt_year.TextLength == 4)
                    {
                        string path = @"\\192.168.130.12\d\Year report";
                        bool tru = false;
                        gross = 0;
                        tax = 0;
                        year_select = new SqlDataAdapter("Select * From Payments Where [ID] LIKE '%" + txt_idyear.Text + "%' AND [Year] LIKE '%" + txt_year.Text + "%'", Form1.Conn);
                        year_select.FillSchema(pdf_data, SchemaType.Source, "Payments");
                        year_select.Fill(pdf_data, "Payments");
                        foreach (DataRow r in pdf_data.Tables["Payments"].Rows)
                        {
                            yaddress = r[4].ToString();
                            ypostcode = r[5].ToString();
                            yname = r[1].ToString() + " " + r[2].ToString() + " " + r[3].ToString();
                            yurt = r[15].ToString();
                            yver = r[17].ToString();
                            gross += Convert.ToDouble(r[12].ToString());
                            tax += Convert.ToDouble(r[13].ToString());
                        }
                        if (File.Exists(Path.Combine(path, "Yearly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf")))
                        {
                            MessageBox.Show("File already exists!");
                        }
                        else
                        {
                            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(Path.Combine(path, "Yearly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf"), FileMode.Create));
                            doc.Open();
                            Paragraph space = new Paragraph("\n\n");
                            PdfPTable t0 = new PdfPTable(1);
                            PdfPTable t00 = new PdfPTable(2);

                            Paragraph about = new Paragraph("Construction Industry Scheme", FontFactory.GetFont(BaseFont.COURIER_BOLD, 12));
                            Paragraph empty = new Paragraph(" ");
                            PdfPCell cel = new PdfPCell(about);
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            Paragraph month = new Paragraph("Statement of Tax Year of " + DateTime.Now.Year.ToString());
                            cel = new PdfPCell(month);
                            cel.HorizontalAlignment = Element.ALIGN_LEFT;
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            Paragraph header = new Paragraph("MANTA & ALEX LTD", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, BaseColor.BLACK)) { Alignment = Element.ALIGN_RIGHT };
                            cel = new PdfPCell(header);
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            Paragraph header1 = new Paragraph("33 THE CHASE, EDGWARE, MIDDLESEX \nLONDON HA8 5DW \nTel/Fax No 02032096071 \nMobile No: 07792820031, 07800963526 \nEmail maaltd@hotmail.co.uk \n\n\n\n", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, BaseColor.BLACK)) { Alignment = Element.ALIGN_RIGHT };
                            cel = new PdfPCell(header1);
                            cel.BorderColor = BaseColor.WHITE;
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t00.AddCell(cel);
                            cel = new PdfPCell(t00);
                            cel.BorderColor = BaseColor.BLACK;
                            t0.AddCell(cel);
                            t0.HorizontalAlignment = Element.ALIGN_CENTER;
                            t0.WidthPercentage = 100;

                            PdfPTable t1 = new PdfPTable(2);
                            t1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cel = new PdfPCell(new Phrase("Subcontractor", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Name", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(yname, FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Unique Taxpayer Reference", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(yurt, FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Verification Number", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(yver, FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("£", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Gross Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Deduction Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(tax.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            t1.HorizontalAlignment = Element.ALIGN_CENTER;
                            t1.WidthPercentage = 70;

                            PdfPTable t4 = new PdfPTable(1);
                            if (ypostcode == null)
                            {
                                ypostcode = " ";
                            }
                            Paragraph address = new Paragraph(yname.ToString() + "\n" + yaddress + "\n" + ypostcode);
                            address.Alignment = Element.ALIGN_LEFT;
                            t4.AddCell(address);
                            t4.HorizontalAlignment = Element.ALIGN_LEFT;
                            t4.WidthPercentage = 35;
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(t4);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(t0);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(t1);
                            doc.Close();
                            tru = true;
                            string action = "Created file Yearly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf";
                            SqlCommand log = new SqlCommand("INSERT INTO log([User], [Action], [Date])" + "VALUES ('" + Form1.username + "','" + action + "','" + DateTime.Now.ToLongDateString() + "')", Form1.Conn);

                            if (tru)
                            {
                                DialogResult dr = MessageBox.Show("Do you want do open it?", "Yearly report done!", MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(Path.Combine(path, "Yearly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf"));
                                }
                                else if (dr == DialogResult.No)
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The year number is incorect!");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a Year!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a ID number!");
            }
        }

        private void txt_year_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_year.Text == "MONTH/YEAR")
            {
                txt_year.Text = String.Empty;
                txt_year.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_year_Leave(object sender, EventArgs e)
        {
            if (txt_year.Text == null || txt_year.Text == "")
            {
                txt_year.Text = "MONTH/YEAR";
                txt_year.ForeColor = SystemColors.ControlDarkDark;
            }
            txt_year.Text.ToUpper();
        }

        private void btt_month_re_Click(object sender, EventArgs e)
        {
            if (txt_idyear.Text != "ID NUMBER")
            {
                if (txt_year.Text != "MONTH/YEAR")
                {
                    Double gross_tot = 0;
                    if (txt_year.TextLength <= 2)
                    {
                        string path = @"\\192.168.130.12\d\Month_report";
                        bool tru = false;
                        gross = 0;
                        tax = 0;
                        year_select = new SqlDataAdapter("Select * From Payments Where [ID] LIKE '%" + txt_idyear.Text + "%' AND [Year] LIKE '%" + DateTime.Now.Year.ToString() + "%'", Form1.Conn);
                        year_select.FillSchema(pdf_datay, SchemaType.Source, "Payments");
                        year_select.Fill(pdf_datay, "Payments");
                        foreach (DataRow r in pdf_datay.Tables["Payments"].Rows)
                        {
                            gross_tot += Convert.ToDouble(r[12].ToString());
                        }
                        year_select = new SqlDataAdapter("Select * From Payments Where [ID] LIKE '%" + txt_idyear.Text + "%' AND [Month] LIKE '%" + txt_year.Text + "%'", Form1.Conn);
                        year_select.FillSchema(pdf_data, SchemaType.Source, "Payments");
                        year_select.Fill(pdf_data, "Payments");
                        foreach (DataRow r in pdf_data.Tables["Payments"].Rows)
                        {
                            yaddress = r[4].ToString();
                            ypostcode = r[5].ToString();
                            yname = r[1].ToString() + " " + r[2].ToString() + " " + r[3].ToString();
                            yurt = r[15].ToString();
                            yver = r[17].ToString();
                            gross += Convert.ToDouble(r[12].ToString());
                            tax += Convert.ToDouble(r[13].ToString());
                        }
                        if (File.Exists(Path.Combine(path, "Monthly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf")))
                        {
                            MessageBox.Show("File already exists!");
                        }
                        else
                        {
                            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(Path.Combine(path, "Monthly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf"), FileMode.Create));
                            doc.Open();
                            Paragraph space = new Paragraph("\n\n");
                            PdfPTable t0 = new PdfPTable(1);
                            PdfPTable t00 = new PdfPTable(2);

                            Paragraph about = new Paragraph("Construction Industry Scheme", FontFactory.GetFont(BaseFont.COURIER_BOLD, 12));
                            Paragraph empty = new Paragraph(" ");
                            PdfPCell cel = new PdfPCell(about);
                            t00.AddCell(cel);
                            cel = new PdfPCell(empty);
                            t00.AddCell(cel);
                            Paragraph month = new Paragraph("Statement of Tax Month Ending 5/" + (Convert.ToDouble(txt_year.Text) + 1).ToString() + "/" + DateTime.Now.Year.ToString());
                            cel = new PdfPCell(month);
                            cel.HorizontalAlignment = Element.ALIGN_LEFT;
                            t00.AddCell(cel);
                            Paragraph header = new Paragraph("MANTA & ALEX LTD", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, BaseColor.BLACK)) { Alignment = Element.ALIGN_RIGHT };
                            cel = new PdfPCell(header);
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t00.AddCell(cel);
                            Paragraph header1 = new Paragraph("33 THE CHASE, EDGWARE, MIDDLESEX \nLONDON HA8 5DW \nTel/Fax No 02032096071 \nMobile No: 07792820031, 07800963526 \nEmail maaltd@hotmail.co.uk \n\n\n\n", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, BaseColor.BLACK)) { Alignment = Element.ALIGN_RIGHT };
                            cel = new PdfPCell(header1);
                            cel.BorderColor = BaseColor.WHITE;
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t00.AddCell(cel);
                            cel = new PdfPCell(t00);
                            cel.BorderColor = BaseColor.BLACK;
                            t0.AddCell(cel);
                            t0.HorizontalAlignment = Element.ALIGN_CENTER;
                            t0.WidthPercentage = 100;

                            PdfPTable t1 = new PdfPTable(2);
                            t1.HorizontalAlignment = Element.ALIGN_LEFT;
                            cel = new PdfPCell(new Phrase("Subcontractor", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Name", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(yname, FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Unique Taxpayer Reference", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(yurt, FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Verification Number", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(yver, FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t1.AddCell(cel);
                            cel = new PdfPCell(empty);
                            cel.BorderColor = BaseColor.WHITE;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("£", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Gross Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase("Deduction Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                            t1.AddCell(cel);
                            cel = new PdfPCell(new Phrase(tax.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                            cel.HorizontalAlignment = Element.ALIGN_RIGHT;
                            t1.AddCell(cel);
                            t1.HorizontalAlignment = Element.ALIGN_CENTER;
                            t1.WidthPercentage = 70;
                            PdfPTable t4 = new PdfPTable(1);
                            if (ypostcode == null)
                            {
                                ypostcode = " ";
                            }
                            Paragraph address = new Paragraph(yname.ToString() + "\n" + yaddress + "\n\n" + ypostcode);
                            address.Alignment = Element.ALIGN_LEFT;
                            t4.AddCell(address);
                            t4.HorizontalAlignment = Element.ALIGN_LEFT;
                            t4.WidthPercentage = 35;
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(t4);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(t0);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(space);
                            doc.Add(t1);
                            doc.Close();
                            tru = true;
                            string action = "Created file Monthly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf";
                            SqlCommand log = new SqlCommand("INSERT INTO log([User], [Action], [Date])" + "VALUES ('" + Form1.username + "','" + action + "','" + DateTime.Now.ToLongDateString() + "')", Form1.Conn);

                            if (tru)
                            {
                                DialogResult dr = MessageBox.Show("Do you want do open it?", "Monthly report done!", MessageBoxButtons.YesNo);
                                if (dr == DialogResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(Path.Combine(path, "Monthly report- " + txt_year.Text + "- " + txt_idyear.Text + ".pdf"));
                                }
                                else if (dr == DialogResult.No)
                                {
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The month number is incorect!");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter a month number!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a ID number!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadPaymentsTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_load_Click(null, null);
        }

        private void addNewPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_add_Click(null, null);
        }

        private void removePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_remove_Click(null, null);
        }

        private void wageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_wage_Click(null, null);
        }

        private void payslipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_pay_Click(null, null);
        }

        private void subcontractorTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_month_Click(null, null);
        }

        private void monthlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_month_re_Click(null, null);
        }

        private void yearlyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btt_year_Click(null, null);
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_rate_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (head)
            {
                System.Drawing.Rectangle rect = dgv_rate.GetCellDisplayRectangle(1, -1, true);
                // set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 4;
                rect.X = rect.Location.X + (rect.Width / 4) - 2;
                //datagridview[0, 0].ToolTipText = "sdfsdf";
                checkboxHeader.Size = new Size(18, 18);
                checkboxHeader.Location = rect.Location;
            }
        }

        private void dtp_process_ValueChanged(object sender, EventArgs e)
        {
            if (!dtp_process.Checked)
            {
                // hide date value since it's not set
                dtp_process.CustomFormat = " ";
                dtp_process.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtp_process.CustomFormat = "dd/MM/yyyy";
                dtp_process.Format = DateTimePickerFormat.Custom;
            }
        }

        private void dtp_week_ValueChanged(object sender, EventArgs e)
        {
            if (!dtp_week.Checked)
            {
                // hide date value since it's not set
                dtp_week.CustomFormat = " ";
                dtp_week.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtp_week.CustomFormat = "dd/MM/yyyy";
                dtp_week.Format = DateTimePickerFormat.Custom;
            }
        }
        private void yearr()
        {
            if (dtp_process.Value.Month < 4)
            {
                yeaar = dtp_process.Value.AddYears(-1).Year.ToString();
            }
            else
            {
                yeaar = dtp_process.Value.Year.ToString();
            }
        }
        private void mont()
        {
            if (dtp_process.Value.Day < 6)
            {
                montth = dtp_process.Value.AddMonths(-1).Month.ToString();
            }
            else
            {
                montth = dtp_process.Value.Month.ToString();
            }
        }
        private void btt_start_Click(object sender, EventArgs e)
        {
            if (dtp_process.Checked && dtp_week.Checked)
            {
                mont();
                yearr();
                pdate = dtp_process.Value.ToString("dd/MM/yyyy");
                daay = dtp_process.Value.Day.ToString();
                weeek = uk.GetWeekOfYear(dtp_week.Value.AddMonths(-3), CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString();
                start = dtp_week.Value.ToString("dd/MM/yyyy");
                end = dtp_week.Value.AddDays(6).ToString("dd/MM/yyyy");
                label_date.Text = "Week: " + weeek + " Process Date: " + pdate;
                btt_add.Enabled = true;
                btt_remove.Enabled = true;
                btt_wage.Enabled = true;
                btt_pay.Enabled = true;
                dtp_process.Enabled = false;
                dtp_week.Enabled = false;
                paym = new SqlDataAdapter("Select * From Payments Where [Process Date] LIKE '%" + pdate + "%'", Form1.Conn);
                dsPubs = new DataSet("Pubs");
                paym.FillSchema(dsPubs, SchemaType.Source, "Payments");
                paym.Fill(dsPubs, "Payments");
                bindingSource2.DataSource = dsPubs.Tables["Payments"];
                dgv_rate.DataSource = bindingSource2;
                if (dgv_rate.Rows.Count > 0)
                {
                    txth = 0;
                    txtgross = 0;
                    txtnet = 0;
                    txttax = 0;
                    foreach (DataGridViewRow s in dgv_rate.Rows)
                    {
                        txth += Convert.ToDouble(s.Cells[12].Value.ToString());
                        txtgross += Convert.ToDouble(s.Cells[13].Value.ToString());
                        txttax += Convert.ToDouble(s.Cells[14].Value.ToString());
                        txtnet += Convert.ToDouble(s.Cells[15].Value.ToString());
                    }
                    txt_h.Text = txth.ToString();
                    txt_gross.Text = txtgross.ToString();
                    txt_tax.Text = txttax.ToString();
                    txt_net.Text = txtnet.ToString();
                }
                VisibleOnly();
                head = true;
                dtp_week.Checked = false;
                dtp_process.Checked = false;
            }
            else
            {
                MessageBox.Show("You must set the Process date and Week start date!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_date.Text = "Process Date and Week start date not set ";
            btt_add.Enabled = false;
            btt_remove.Enabled = false;
            btt_wage.Enabled = false;
            btt_pay.Enabled = false;
            dtp_process.Enabled = true;
            dtp_week.Enabled = true;
            dsPubs.Tables["Payments"].Clear();
            bindingSource2.DataSource = dsPubs.Tables["Payments"];
            dgv_rate.DataSource = bindingSource2;
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.manta-alex.co.uk");
        }

        private void btt_7_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser b = new Browser();
            b.Show();
        }

        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        cm.Show(this, label9.Location);
                    }
                    break;
            }
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            if (activ)
            {
                dsPubs.Tables["Payments"].Clear();
                paym.Fill(dsPubs, "Payments");
                foreach (DataGridViewRow s in dgv_rate.Rows)
                {
                    if (!id.Contains(s.Cells[1].Value.ToString()))
                    {
                        id.Add(s.Cells[1].Value.ToString());

                        id_address.Add(new lis
                        {
                            id = s.Cells[1].Value.ToString(),
                            address = s.Cells[5].Value.ToString(),
                            postcode = s.Cells[6].Value.ToString(),
                            name = s.Cells[2].Value.ToString() + " " + s.Cells[3].Value.ToString() + " " + s.Cells[4].Value.ToString(),
                            utr = s.Cells[16].Value.ToString(),
                            ver = s.Cells[18].Value.ToString()
                        });
                    }
                }
            }
        }
    }
}
