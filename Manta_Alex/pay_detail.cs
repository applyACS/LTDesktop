using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace LTDesktop
{
    public partial class pay_detail : Form
    {
        List<payments.lis> id;
        List<payments.list> pay;
        int i;
        Double gross;
        Double total_gross = 0;
        Double tot_tax;
        DataSet dsPubs;
        string prcdate;
        string week;
        SqlDataAdapter gros;
        Calendar uk = CultureInfo.CurrentCulture.Calendar;
        public pay_detail(List<payments.list> paym, List<payments.lis> id_a, int n, string prdate, string wek)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            id = id_a;
            i = n;
            pay = paym;
            prcdate = prdate;
            week = wek;
            
        }
        public class lis
        {
            public string id { get; set; }
            public string address { get; set; }
        }
        public class list
        {
            public string rate { get; set; }
            public string hours { get; set; }
            public string gross { get; set; }
            public string tax { get; set; }
            public string net { get; set; }
        }

        private void btt_payslips_Click(object sender, EventArgs e)
        {
            string path = @"Z:\Payslips";
            bool tru = false;
            if (File.Exists(Path.Combine(path, id[i].name.ToString() + " " + uk.GetWeekOfYear(DateTime.Now.AddMonths(-3), CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString() + " " + DateTime.Now.Year.ToString() + ".pdf")))
            {
                MessageBox.Show("File already exists!");
            }
            else
            {
                Document doc = new Document(PageSize.A4, 25, 25, 50, 50);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(Path.Combine(path, id[i].name.ToString() + " " + uk.GetWeekOfYear(DateTime.Now.AddMonths(-3), CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString() + " " + DateTime.Now.Year.ToString() + ".pdf"), FileMode.Create));
                doc.Open();
                Paragraph header = new Paragraph("MANTA & ALEX LTD", FontFactory.GetFont(BaseFont.TIMES_BOLD, 26, BaseColor.RED)) { Alignment = Element.ALIGN_RIGHT };
                Paragraph header1 = new Paragraph("33 THE CHASE, EDGWARE, MIDDLESEX \nLONDON HA8 5DW \nTel/Fax No 02032096071 \nMobile No: 07792820031, 07800963526 \nEmail maaltd@hotmail.co.uk \n\n\n\n", FontFactory.GetFont(BaseFont.TIMES_BOLD, 12, BaseColor.BLACK)) { Alignment = Element.ALIGN_RIGHT };
                Paragraph proces = new Paragraph("Proces date: " + prcdate, FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)) { Alignment = Element.ALIGN_RIGHT };
                Paragraph period = new Paragraph("Week: " + week, FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)) { Alignment = Element.ALIGN_RIGHT };
                Paragraph name = new Paragraph("Remittance Advice", FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12)) { Alignment = Element.ALIGN_LEFT };
                Paragraph space = new Paragraph("\n");
                PdfPTable t1;
                PdfPTable t11;
                if (!cb_vat.Checked)
                {
                    t1 = new PdfPTable(4);
                    t11 = new PdfPTable(1);
                    t11.WidthPercentage = 100;
                    t1.SetWidths(new float[] { 150, 350, 200, 200 });
                    t1.HorizontalAlignment = Element.ALIGN_LEFT;
                    PdfPCell cel = new PdfPCell(new Phrase("Contract no.", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Name", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("UTR", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Verification no", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    t1.AddCell(new Phrase(id[i].id.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(id[i].name.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(id[i].utr.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(id[i].ver.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    cel = new PdfPCell(t1);
                    cel.BorderWidth = 1;
                    t11.AddCell(cel);
                }
                else
                {
                    t1 = new PdfPTable(5);
                    t11 = new PdfPTable(1);
                    t11.WidthPercentage = 100;
                    t1.SetWidths(new float[] { 150, 350, 200, 200, 200 });
                    t1.HorizontalAlignment = Element.ALIGN_LEFT;
                    PdfPCell cel = new PdfPCell(new Phrase("Contract no.", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Name", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("UTR", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("Verification no", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    cel = new PdfPCell(new Phrase("VAT number", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                    cel.BackgroundColor = BaseColor.LIGHT_GRAY;
                    t1.AddCell(cel);
                    t1.AddCell(new Phrase(id[i].id.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(id[i].name.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(id[i].utr.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(id[i].ver.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                    t1.AddCell(new Phrase(txt_vat.Text.ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 9)));
                    cel = new PdfPCell(t1);
                    cel.BorderWidth = 1;
                    t11.AddCell(cel);
                }
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                PdfPTable t2 = new PdfPTable(1);
                PdfPTable t22 = new PdfPTable(4);
                PdfPTable t222 = new PdfPTable(4);
                t2.KeepTogether = true;
                t2.HeaderRows = 1;
                t22.SetWidths(new float[] { 350, 100, 100, 100 });
                t222.SetWidths(new float[] { 350, 100, 100, 100 });
                table.SetWidths(new float[] { 350, 170 });
                t2.HorizontalAlignment = Element.ALIGN_LEFT;
                t2.WidthPercentage = 70;
                PdfPCell cell = new PdfPCell(new Phrase("Payments", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                t22.AddCell(cell);
                cell = new PdfPCell(new Phrase("Units", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                t22.AddCell(cell);
                cell = new PdfPCell(new Phrase("Rate", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                t22.AddCell(cell);
                cell = new PdfPCell(new Phrase("Gross Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                t22.AddCell(cell);
                for (int a = 0; a < pay.Count; a++)
                {
                    if (a == 0)
                    {
                        cell = new PdfPCell(new Phrase(txt_pay.Text, FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].hours.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].rate.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                    }
                    if (a == 1)
                    {
                        cell = new PdfPCell(new Phrase(txt_1.Text, FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].hours.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].rate.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                    }
                    if (a == 2)
                    {
                        cell = new PdfPCell(new Phrase(txt_2.Text, FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].hours.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].rate.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                    }
                    if (a == 3)
                    {
                        cell = new PdfPCell(new Phrase(txt_3.Text, FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].hours.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].rate.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                        cell = new PdfPCell(new Phrase(pay[a].gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                        t222.AddCell(cell);
                    }
                }
                cell = new PdfPCell(t22);
                t2.AddCell(cell);
                cell = new PdfPCell(t222);
                cell.Border = 0;
                t2.AddCell(cell);
                cell = new PdfPCell(new Phrase(" "));
                cell.MinimumHeight = 100;
                t2.AddCell(cell);
                cell = new PdfPCell(t2);
                cell.BorderWidth = 1;
                table.AddCell(cell);
                PdfPTable t3 = new PdfPTable(2);
                t3.WidthPercentage = 30;
                t3.SplitRows = false;
                t3.HorizontalAlignment = Element.ALIGN_LEFT;
                cell = new PdfPCell(new Paragraph("Deduction", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)) { Alignment = Element.ALIGN_LEFT });
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //t3.AddCell(new Paragraph("Deduction", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)) { Alignment = Element.ALIGN_LEFT });
                t3.AddCell(cell);
                cell = new PdfPCell(new Paragraph("Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)) { Alignment = Element.ALIGN_RIGHT });
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                t3.AddCell(cell);
                //t3.AddCell(new Paragraph("Amount", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)) { Alignment = Element.ALIGN_RIGHT });
                if (!cb_vat.Checked)
                {
                    tot_tax = 0;
                    for (int x = 0; x < pay.Count; x++)
                    {
                        tot_tax += Convert.ToDouble(pay[x].tax);
                    }
                    t3.AddCell(new Paragraph((100 * Convert.ToDouble(pay[0].tax) / Convert.ToDouble(pay[0].gross)).ToString() + "%", FontFactory.GetFont(BaseFont.COURIER, 9)) { Alignment = Element.ALIGN_LEFT });
                    t3.AddCell(new Paragraph(tot_tax.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)) { Alignment = Element.ALIGN_RIGHT });
                }
                cell = new PdfPCell(new Phrase(" "));
                cell.MinimumHeight = 100;
                t3.AddCell(cell);
                cell = new PdfPCell(t3);
                cell.BorderWidth = 1;
                table.AddCell(cell);
                PdfPTable table1 = new PdfPTable(3);
                table1.WidthPercentage = 100;
                PdfPTable t4 = new PdfPTable(1);
                if (id[i].postcode == null)
                {
                    id[i].postcode = " ";
                }
                Paragraph address = new Paragraph(id[i].name.ToString() + "\n" + id[i].address.ToString() + "\n" + id[i].postcode.ToString());
                address.Alignment = Element.ALIGN_LEFT;
                t4.AddCell(address);
                t4.HorizontalAlignment = Element.ALIGN_LEFT;
                t4.WidthPercentage = 35;
                cell = new PdfPCell(t4);
                cell.BorderWidth = 1;
                table1.AddCell(cell);
                PdfPTable t5 = new PdfPTable(1);
                PdfPTable t5_1 = new PdfPTable(2);
                cell = new PdfPCell(new Phrase("Year to Date", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                t5.AddCell(cell);
                cell = new PdfPCell(new Phrase("Gross pay TD", FontFactory.GetFont(BaseFont.COURIER, 9)));
                t5_1.AddCell(cell);
                cell = new PdfPCell(new Paragraph(gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)) { Alignment = Element.ALIGN_RIGHT });
                t5_1.AddCell(cell);
                cell = new PdfPCell(t5_1);
                t5.AddCell(cell);
                t5.WidthPercentage = 80;
                t5.HorizontalAlignment = Element.ALIGN_LEFT;
                cell = new PdfPCell(t5);
                cell.BorderWidth = 1;
                table1.AddCell(cell);
                for (int y = 0; y < pay.Count; y++)
                {
                    total_gross += Convert.ToDouble(pay[y].gross.ToString());
                }
                PdfPTable t6 = new PdfPTable(1);
                PdfPTable t6_1 = new PdfPTable(2);
                cell = new PdfPCell(new Phrase("This Period", FontFactory.GetFont(BaseFont.COURIER_BOLD, 8)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                t6.AddCell(cell);
                cell = new PdfPCell(new Phrase("Total Gross Pay", FontFactory.GetFont(BaseFont.COURIER, 9)));
                t6_1.AddCell(cell);
                cell = new PdfPCell(new Phrase(total_gross.ToString(), FontFactory.GetFont(BaseFont.COURIER, 9)));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                t6_1.AddCell(cell);
                cell = new PdfPCell(new Phrase("Payment Method", FontFactory.GetFont(BaseFont.COURIER, 9)));
                t6_1.AddCell(cell);
                cell = new PdfPCell(new Phrase("Bacs", FontFactory.GetFont(BaseFont.COURIER, 9)));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                t6_1.AddCell(cell);
                cell = new PdfPCell(t6_1);
                t6.AddCell(cell);
                t6.WidthPercentage = 80;
                t6.HorizontalAlignment = Element.ALIGN_LEFT;
                cell = new PdfPCell(t6);
                cell.BorderWidth = 1;
                table1.AddCell(cell);
                PdfPTable t7 = new PdfPTable(2);
                cell = new PdfPCell(new Phrase("Net Due", FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.BorderWidth = 1;
                t7.AddCell(cell);
                cell = new PdfPCell(new Phrase((total_gross - tot_tax).ToString(), FontFactory.GetFont(BaseFont.COURIER_BOLD, 11)));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.BorderWidth = 1;
                t7.AddCell(cell);
                t7.HorizontalAlignment = Element.ALIGN_RIGHT;
                t7.WidthPercentage = 35;
                doc.Add(header);
                doc.Add(header1);
                doc.Add(name);
                doc.Add(proces);
                doc.Add(period);
                doc.Add(space);
                doc.Add(t11);
                doc.Add(space);
                doc.Add(table);
                doc.Add(space);
                doc.Add(space);
                doc.Add(table1);
                doc.Add(space);
                doc.Add(space);
                doc.Add(t7);
                doc.Close();
                tru = true;
                string action = "Created PAYSLIPS " + id[i].name.ToString() + " " + uk.GetWeekOfYear(DateTime.Now.AddMonths(-3), CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString() + " " + DateTime.Now.Year.ToString() + ".pdf";
                SqlCommand log = new SqlCommand("INSERT INTO log([User], [Action], [Date])" + "VALUES ('" + Form1.username + "','" + action + "','" + DateTime.Now.ToLongDateString() + "')", Form1.Conn);
                if (tru)
                {
                    DialogResult dr = MessageBox.Show("Do you want do open it?", "Wage list done!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Path.Combine(path, id[i].name.ToString() + " " + uk.GetWeekOfYear(DateTime.Now.AddMonths(-3), CalendarWeekRule.FirstDay, DayOfWeek.Sunday).ToString() + " " + DateTime.Now.Year.ToString() + ".pdf"));
                    }
                    else if (dr == DialogResult.No)
                    {
                    }
                }
                this.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = id[i].id.ToString() + " " + id[i].name.ToString();
            this.Size = new System.Drawing.Size(399, 161);
            cb_vat.Location = new System.Drawing.Point(12, 65);
            txt_vat.Location = new System.Drawing.Point(12, 90);
            btt_payslips.Location = new Point(283, 84);
            txt_rate.Text = pay[0].rate.ToString();
            txt_hours.Text = pay[0].hours.ToString();
            for (int k = 1; k < pay.Count; k++)
            {
                if (k == 1)
                {
                    this.Size = new System.Drawing.Size(399, 185);
                    cb_vat.Location = new System.Drawing.Point(12, 89);
                    txt_vat.Location = new System.Drawing.Point(12, 114);
                    btt_payslips.Location = new Point(283, 108);
                    txt_1.Visible = true;
                    txt_11.Visible = true;
                    txt_111.Visible = true;
                    txt_11.Text = pay[k].rate.ToString();
                    txt_111.Text = pay[k].hours.ToString();
                }
                if (k == 2)
                {
                    this.Size = new System.Drawing.Size(399, 209);
                    cb_vat.Location = new System.Drawing.Point(12, 113);
                    txt_vat.Location = new System.Drawing.Point(12, 138);
                    btt_payslips.Location = new Point(283, 132);
                    txt_2.Visible = true;
                    txt_22.Visible = true;
                    txt_22.Text = pay[k].rate.ToString();
                    txt_222.Visible = true;
                    txt_222.Text = pay[k].hours.ToString();
                }
                if (k == 3)
                {
                    this.Size = new System.Drawing.Size(399, 233);
                    cb_vat.Location = new System.Drawing.Point(12, 137);
                    txt_vat.Location = new System.Drawing.Point(12, 162);
                    btt_payslips.Location = new Point(283, 156);
                    txt_3.Visible = true;
                    txt_33.Visible = true;
                    txt_33.Text = pay[k].rate.ToString();
                    txt_333.Visible = true;
                    txt_333.Text = pay[k].hours.ToString();
                }
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void cb_vat_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_vat.Checked)
            {
                txt_vat.ReadOnly = false;
            }
            else
            {
                txt_vat.ReadOnly = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            dsPubs.Clear();
            gros = new SqlDataAdapter("SELECT [Gross] FROM Payments Where [ID] LIKE '%" + id[i].id.ToString() + "%' AND [Year] LIKE '%" + DateTime.Now.Year.ToString() + "%'", Form1.Conn);
            dsPubs = new DataSet("Pubs");
            gros.FillSchema(dsPubs, SchemaType.Source, "Payments");
            gros.Fill(dsPubs, "Payments");
            dsPubs.Dispose();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (DataRow r in dsPubs.Tables["Payments"].Rows)
            {
                gross += Convert.ToDouble(r[0].ToString());
            }
        }

        private void txt_pay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_payslips_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_payslips_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_payslips_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_payslips_Click((object)sender, (EventArgs)e);
            }
        }

        private void cb_vat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_payslips_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_vat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btt_payslips_Click((object)sender, (EventArgs)e);
            }
        }
    }
}
