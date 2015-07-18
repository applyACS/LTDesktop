using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Globalization;

namespace LTDesktop
{
    public partial class Form3 : Form
    {
        string id;
        string right;
        bool add = false;
        bool edit = false;
        bool det = false;
        public Form3(string iid)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            id = iid;
            txt_id.Text = id;
            this.Text = "Add";
            add = true;
            edit = false;
            det = false;
            cb_tax.Items.Add("Not known");
            cb_tax.Items.Add("Gross");
            cb_tax.Items.Add("Standard rate");
            cb_tax.Items.Add("Higher rate");
            cb_tax.SelectedItem = cb_tax.Items[0].ToString();
        }
        public Form3(string iid, string first, string mid, string last, string birth, string address, string postcode, string nationality, string mobile, string email, string bank, string sort, string acc, string rright, string utr, string nino, string verification, string cscs, string cs_ex, string trade, string start, string working, string status, string rday, string rnight, string rothers, string rweek, string rshift)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            button_add.Text = "Save";
            txt_address.Text = address;
            txt_code.Text = postcode;
            txt_cs.Text = cscs;
            txt_mid.Text = mid;
            txt_email.Text = email;
            txt_acc.Text = acc;
            txt_sort.Text = sort;
            txt_bank.Text = bank;
            txt_first.Text = first;
            txt_last.Text = last;
            txt_nat.Text = nationality;
            txt_mobile.Text = mobile;
            txt_nino.Text = nino;
            txt_no.Text = verification;
            txt_trade.Text = trade;
            date_cs_expr.Text = cs_ex;
            date_start.Text = start;
            cb_work.Text = working;
            txt_utr.Text = utr;
            txt_rothers.Text = rothers;
            txt_rnight.Text = rnight;
            txt_rday.Text = rday;
            txt_rweek.Text = rweek;
            txt_shift.Text = rshift;
            cb_tax.Text = status;
            button_finish.Visible = false;
            dateTimePicker_birth.Text = birth;
            txt_id.Text = iid;
            this.Text = "Edit";
            id = iid;
            cb_tax.Items.Add("Not known");
            cb_tax.Items.Add("Gross");
            cb_tax.Items.Add("Standard rate");
            cb_tax.Items.Add("Higher rate");
            edit = true;
            det = false;
            add = false;
            right = rright;
            if (right == "Blue card")
            {
                checkBox1.Checked = true;
            }
            if (right == "Yellow card")
            {
                checkBox2.Checked = true;
            }
            if (right == "Resident")
            {
                checkBox_re.Checked = true;
            }
        }
        public Form3(bool r, string iid, string first, string mid, string last, string birth, string address, string postcode, string nationality, string mobile, string email, string bank, string sort, string acc, string rright, string utr, string nino, string verification, string cscs, string cs_ex, string trade, string start, string working, string status, string rday, string rnight, string rothers, string rweek, string rshift)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            button_add.Text = "Close";
            txt_address.Text = address;
            txt_code.Text = postcode;
            txt_cs.Text = cscs;
            txt_mid.Text = mid;
            txt_email.Text = email;
            txt_acc.Text = acc;
            txt_sort.Text = sort;
            txt_bank.Text = bank;
            txt_first.Text = first;
            txt_last.Text = last;
            txt_nat.Text = nationality;
            txt_mobile.Text = mobile;
            txt_nino.Text = nino;
            txt_no.Text = verification;
            txt_trade.Text = trade;
            txt_utr.Text = utr;
            date_cs_expr.Text = cs_ex;
            date_start.Text = start;
            cb_work.Text = working;
            txt_rothers.Text = rothers;
            txt_rnight.Text = rnight;
            txt_rday.Text = rday;
            txt_rweek.Text = rweek;
            txt_shift.Text = rshift;
            cb_tax.Text = status;
            dateTimePicker_birth.Text = birth;
            txt_id.Text = iid;
            id = iid;
            right = rright;
            if (right == "Blue card")
            {
                checkBox1.Checked = true;
            }
            if (right == "Yellow card")
            {
                checkBox2.Checked = true;
            }
            if (right == "Resident")
            {
                checkBox_re.Checked = true;
            }
            txt_address.ReadOnly = true;
            txt_code.ReadOnly = true;
            txt_cs.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_first.ReadOnly = true;
            txt_last.ReadOnly = true;
            txt_bank.ReadOnly = true;
            txt_acc.ReadOnly = true;
            txt_sort.ReadOnly = true;
            txt_mobile.ReadOnly = true;
            txt_nat.ReadOnly = true;
            txt_nino.ReadOnly = true;
            txt_no.ReadOnly = true;
            txt_trade.ReadOnly = true;
            txt_utr.ReadOnly = true;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox_re.Enabled = false;
            date_cs_expr.Enabled = false;
            date_start.Enabled = false;
            cb_work.Enabled = false;
            txt_mid.ReadOnly = true;
            cb_tax.Enabled = false;
            txt_rday.ReadOnly = true;
            txt_rnight.ReadOnly = true;
            txt_rothers.ReadOnly = true;
            txt_rweek.ReadOnly = true;
            txt_shift.ReadOnly = true;
            button_finish.Visible = false;
            dateTimePicker_birth.Enabled = false;
            this.Text = "Details";
            det = true;
            add = false;
            edit = false;
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
       

        private void button_add_Click(object sender, EventArgs e)
        {
            bool error = true;
            errorProvider1.Clear();
            if (txt_first.Text != null && txt_first.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_first, "First Name is missing!");
            }
            if (txt_last.Text != null && txt_last.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_last, "Last Name is missing!");
            }
            if (txt_address.Text != null && txt_address.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_address, "Address is missing!");
            }
            if (txt_code.Text != null && txt_code.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_code, "Postcode is missing!");
            }
            if (txt_mobile.Text != null && txt_mobile.Text != "")
            {
                if (txt_mobile.Text.Length == 11 && txt_mobile.Text.All(c => Char.IsDigit(c)) == true)
                {

                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_mobile, "Mobile number is incorect!");
                }
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_mobile, "Mobile number is missing!");
            }
            if (txt_email.Text != null && txt_email.Text != "")
            {
                if (IsValidEmail(txt_email.Text) == true)
                {
                    
                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_email, "Email address is not correct!");
                }
            }
            if (txt_cs.Text != null && txt_cs.Text != "")
            {
                if (txt_cs.Text.All(c => Char.IsDigit(c)) == true && txt_cs.Text.Length == 8)
                {
                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_cs, "CSCS must contain 8 digits!");
                }
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_cs, "CSCS is missing!");
            }
            if (txt_trade.Text != null || txt_trade.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_trade, "Trade is missing!");
            }
            if (txt_utr.Text != null && txt_utr.Text != "")
            {
                if (txt_utr.Text.All(c => Char.IsDigit(c)) == true && txt_utr.Text.Length == 10)
                {
                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_utr, "UTR must contain 10 digits!");
                }
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_utr, "UTR is missing!");
            }
            SqlDataAdapter ver = new SqlDataAdapter("Select * From LTD", Form1.Conn);
            DataSet dsPubs = new DataSet("Pubs");
            ver.FillSchema(dsPubs, SchemaType.Source, "LTD");
            ver.Fill(dsPubs, "LTD");
            foreach (DataRow r in dsPubs.Tables["LTD"].Rows)
            {
                if (txt_nino.Text != null && txt_nino.Text != "")
                {
                    if (txt_nino.Text == r[16].ToString())
                    {
                        error = false;
                        MessageBox.Show("You already have this person in database!", "NINO");
                    }
                }
            }
            if (add == true && error)
            {
                using (SqlCommand delQ = new SqlCommand("INSERT INTO LTD ([ID], [First Name], [Middle Name], [Last Name],[Birth date], [Address], [Postcode], [Nationality], [Mobile], [Email], [Bank], [Sort Code], [Acc no], [Right to work], [UTR], [NINO], [Verification no.], [CSCS], [CSCS Expiry date], [Trade], [Start date], [Working], [Tax status]) " +
                                        "VALUES (@idd, @first, @mid, @last, @birth, @address, @code, @nat, @mobile, @email, @bank, @sort, @acc, @right, @utr, @nino, @no, @cs, @csExpr, @trade, @dateStart, @cbWork, @cbTax)", Form1.Conn))
                {
                    delQ.Parameters.Add(new SqlParameter("@idd", id));
                    delQ.Parameters.Add(new SqlParameter("@first", txt_first.Text));
                    delQ.Parameters.Add(new SqlParameter("@mid", txt_mid.Text));
                    delQ.Parameters.Add(new SqlParameter("@last", txt_last.Text));
                    delQ.Parameters.Add(new SqlParameter("@birth", dateTimePicker_birth.Text));
                    delQ.Parameters.Add(new SqlParameter("@address", txt_address.Text));
                    delQ.Parameters.Add(new SqlParameter("@code", txt_code.Text));
                    delQ.Parameters.Add(new SqlParameter("@nat", txt_nat.Text));
                    delQ.Parameters.Add(new SqlParameter("@mobile", txt_mobile.Text));
                    delQ.Parameters.Add(new SqlParameter("@email", txt_email.Text));
                    delQ.Parameters.Add(new SqlParameter("@bank", txt_bank.Text));
                    delQ.Parameters.Add(new SqlParameter("@sort", txt_sort.Text));
                    delQ.Parameters.Add(new SqlParameter("@acc", txt_acc.Text));
                    delQ.Parameters.Add(new SqlParameter("@right", right));
                    delQ.Parameters.Add(new SqlParameter("@utr", txt_utr.Text));
                    delQ.Parameters.Add(new SqlParameter("@nino", txt_nino.Text));
                    delQ.Parameters.Add(new SqlParameter("@no", txt_no.Text));
                    delQ.Parameters.Add(new SqlParameter("@cs", txt_cs.Text));
                    delQ.Parameters.Add(new SqlParameter("@csExpr", date_cs_expr.Text));
                    delQ.Parameters.Add(new SqlParameter("@trade", txt_trade.Text));
                    delQ.Parameters.Add(new SqlParameter("@dateStart", date_start.Text));
                    delQ.Parameters.Add(new SqlParameter("@cbWork", cb_work.Text));
                    delQ.Parameters.Add(new SqlParameter("@cbTax", cb_tax.Text));
                    delQ.ExecuteNonQuery();
                }
                //SqlCommand daAuthors = new SqlCommand("INSERT INTO LTD ([ID], [First Name], [Middle Name], [Last Name],[Birth date], [Address], [Postcode], [Nationality], [Mobile], [Email], [Bank], [Sort Code], [Acc no], [Right to work], [UTR], [NINO], [Verification no.], [CSCS], [CSCS Expiry date], [Trade], [Start date], [Working], [Tax status]) " +
                //                        "VALUES ('" + id + "', '" + txt_first.Text + "', '" + txt_mid.Text + "','" + txt_last.Text + "','" + dateTimePicker_birth.Text + "', '" + txt_address.Text + "', '" + txt_code.Text + "', '" + txt_nat.Text + "','" + txt_mobile.Text + "', '" + txt_email.Text + "', '" + txt_bank.Text + "', '" + txt_sort.Text + "', '" + txt_acc.Text + "', '" + right + "','" + txt_utr.Text + "', '" + txt_nino.Text + "', '" + txt_no.Text + "', '" + txt_cs.Text + "', '" + date_cs_expr.Text + "', '" + txt_trade.Text + "', '" + date_start.Text + "', '" + cb_work.Text + "', '" + cb_tax.Text + "')", Form1.Conn);
                //daAuthors.ExecuteNonQuery();
                using (SqlCommand delQ = new SqlCommand("INSERT INTO Rates ([ID], [Day], [Night], [Others], [Weekend], [Shift])" + " VALUES (@idd, @rday, @rnight, @rothers, @rweek, @rshift)", Form1.Conn))
                {
                    delQ.Parameters.Add(new SqlParameter("@idd", id));
                    delQ.Parameters.Add(new SqlParameter("@rday", txt_rday.Text));
                    delQ.Parameters.Add(new SqlParameter("@rnight", txt_rnight.Text));
                    delQ.Parameters.Add(new SqlParameter("@rothers", txt_rothers.Text));
                    delQ.Parameters.Add(new SqlParameter("@rweek", txt_rweek.Text));
                    delQ.Parameters.Add(new SqlParameter("@rshift", txt_shift.Text));
                    delQ.ExecuteNonQuery();
                }
                //SqlCommand darates = new SqlCommand("INSERT INTO Rates ([ID], [Day], [Night], [Others], [Weekend], [Shift])" + " VALUES ('" + id + "', '" + txt_rday.Text + "', '" + txt_rnight.Text + "', '" + txt_rothers.Text + "', '" + txt_rweek.Text + "', '" + txt_shift.Text + "')", Form1.Conn);
                //darates.ExecuteNonQuery();
                string action = "Added " + id.ToString();
                using (SqlCommand newq = new SqlCommand("INSERT INTO log([User], [Action], [Date]) VALUES (@use, @actio, @dat)", Form1.Conn))
                {
                    newq.Parameters.Add(new SqlParameter("@use", Form1.username));
                    newq.Parameters.Add(new SqlParameter("@actio", action));
                    newq.Parameters.Add(new SqlParameter("@dat", DateTime.Now.ToString("yyyy_MM_dd")));
                    newq.CommandType = CommandType.Text;
                    newq.ExecuteNonQuery();
                }
                this.Close();
                Form6 fr = new Form6(id);
                fr.ShowDialog();
            }
            else
            {
                if (edit == true && error)
                {
                    using (SqlCommand delQ = new SqlCommand("UPDATE LTD SET [First Name] = @first, [Middle Name] = @mid, [Last Name] = @last, [Birth date] = @birth, [Address] = @address, [Postcode] = @code, [Nationality] = @nat, [Mobile] = @mobile, [Email] = @email, [Bank] = @bank, [Sort Code] = @sort, [Acc no] = @acc, [Right to work] = @right, [UTR] = @utr, [NINO] = @nino, [Verification no.] = @no, [CSCS] = @cs, [CSCS Expiry date] = @csExpr, [Trade] = @trade, [Start date] = @dateStart, [Working] = @cbwork, [Tax status] = @cbTax WHERE [ID] = @idd", Form1.Conn))
                    {
                        delQ.Parameters.Add(new SqlParameter("@idd", id));
                        delQ.Parameters.Add(new SqlParameter("@first", txt_first.Text));
                        delQ.Parameters.Add(new SqlParameter("@mid", txt_mid.Text));
                        delQ.Parameters.Add(new SqlParameter("@last", txt_last.Text));
                        delQ.Parameters.Add(new SqlParameter("@birth", dateTimePicker_birth.Text));
                        delQ.Parameters.Add(new SqlParameter("@address", txt_address.Text));
                        delQ.Parameters.Add(new SqlParameter("@code", txt_code.Text));
                        delQ.Parameters.Add(new SqlParameter("@nat", txt_nat.Text));
                        delQ.Parameters.Add(new SqlParameter("@mobile", txt_mobile.Text));
                        delQ.Parameters.Add(new SqlParameter("@email", txt_email.Text));
                        delQ.Parameters.Add(new SqlParameter("@bank", txt_bank.Text));
                        delQ.Parameters.Add(new SqlParameter("@sort", txt_sort.Text));
                        delQ.Parameters.Add(new SqlParameter("@acc", txt_acc.Text));
                        delQ.Parameters.Add(new SqlParameter("@right", right));
                        delQ.Parameters.Add(new SqlParameter("@utr", txt_utr.Text));
                        delQ.Parameters.Add(new SqlParameter("@nino", txt_nino.Text));
                        delQ.Parameters.Add(new SqlParameter("@no", txt_no.Text));
                        delQ.Parameters.Add(new SqlParameter("@cs", txt_cs.Text));
                        delQ.Parameters.Add(new SqlParameter("@csExpr", date_cs_expr.Text));
                        delQ.Parameters.Add(new SqlParameter("@trade", txt_trade.Text));
                        delQ.Parameters.Add(new SqlParameter("@dateStart", date_start.Text));
                        delQ.Parameters.Add(new SqlParameter("@cbWork", cb_work.Text));
                        delQ.Parameters.Add(new SqlParameter("@cbTax", cb_tax.Text));
                        delQ.ExecuteNonQuery();
                    }
                    //SqlCommand daAuthors = new SqlCommand("UPDATE LTD SET [First Name] ='" + txt_first.Text + "', [Middle Name] ='" + txt_mid.Text + "', [Last Name] ='" + txt_last.Text + "', [Birth date] ='" + dateTimePicker_birth.Text + "', [Address] ='" + txt_address.Text + "', [Postcode] ='" + txt_code.Text + "', [Nationality] ='" + txt_nat.Text + "', [Mobile] ='" + txt_mobile.Text + "', [Email] ='" + txt_email.Text + "', [Bank] ='" + txt_bank.Text + "', [Sort Code] ='" + txt_sort.Text + "', [Acc no] ='" + txt_acc.Text + "', [Right to work] ='" + right + "', [UTR] ='" + txt_utr.Text + "', [NINO] ='" + txt_nino.Text + "', [Verification no.] ='" + txt_no.Text + "', [CSCS] ='" + txt_cs.Text + "', [CSCS Expiry date] ='" + date_cs_expr.Text + "', [Trade] ='" + txt_trade.Text + "', [Start date] ='" + date_start.Text + "', [Working] ='" + cb_work.Text + "', [Tax status] ='" + cb_tax.Text + "' WHERE [ID] = '" + id + "'", Form1.Conn);
                    //daAuthors.ExecuteNonQuery();
                    using (SqlCommand delQ = new SqlCommand("DELETE From Rates Where [ID] = @idd", Form1.Conn))
                    {
                        delQ.Parameters.Add(new SqlParameter("@idd", id));
                        delQ.ExecuteNonQuery();
                    }
                    //SqlCommand delr = new SqlCommand("DELETE From Rates Where [ID] = '" + id + "'", Form1.Conn);
                    //delr.ExecuteNonQuery();
                    using (SqlCommand delQ = new SqlCommand("INSERT INTO Rates ([ID], [Day], [Night], [Others], [Weekend], [Shift])" + " VALUES (@idd, @rday, @rnight, @rothers, @rweek, @rshift)", Form1.Conn))
                    {
                        delQ.Parameters.Add(new SqlParameter("@idd", id));
                        delQ.Parameters.Add(new SqlParameter("@rday", txt_rday.Text));
                        delQ.Parameters.Add(new SqlParameter("@rnight", txt_rnight.Text));
                        delQ.Parameters.Add(new SqlParameter("@rothers", txt_rothers.Text));
                        delQ.Parameters.Add(new SqlParameter("@rweek", txt_rweek.Text));
                        delQ.Parameters.Add(new SqlParameter("@rshift", txt_shift.Text));
                        delQ.ExecuteNonQuery();
                    }
                    //SqlCommand darates = new SqlCommand("INSERT INTO Rates([ID], [Day], [Night], [Others], [Weekend], [Shift])" + " VALUES ('" + id + "', '" + txt_rday.Text + "', '" + txt_rnight.Text + "', '" + txt_rothers.Text + "', '" + txt_rweek.Text + "', '" + txt_shift.Text + "')", Form1.Conn);
                    //darates.ExecuteNonQuery();
                    string action = "Edited " + id;
                    using (SqlCommand newq = new SqlCommand("INSERT INTO log([User], [Action], [Date]) VALUES (@use, @actio, @dat)", Form1.Conn))
                    {
                        newq.Parameters.Add(new SqlParameter("@use", Form1.username));
                        newq.Parameters.Add(new SqlParameter("@actio", action));
                        newq.Parameters.Add(new SqlParameter("@dat", DateTime.Now.ToString("yyyy_MM_dd")));
                        newq.ExecuteNonQuery();
                    }
                    this.Close();
                }
                else
                    if (det == true)
                    {
                        this.Close();
                    }
            }
                           
        }

        private void txt_first_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object) sender, (EventArgs) e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_last_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
        }

        private void txt_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dateTimePicker_birth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_mobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_utr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_nino_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_cs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_trade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_add_Click((object)sender, (EventArgs)e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                right = "Blue card";
                checkBox2.Checked = false;
                checkBox_re.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                right = "Yellow card";
                checkBox_re.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox_re_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_re.Checked)
            {
                right = "Resident";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }
        private void txt_first_Leave(object sender, EventArgs e)
        {
            txt_first.Text = txt_first.Text.ToUpper();
        }

        private void txt_mid_Leave(object sender, EventArgs e)
        {
            txt_mid.Text = txt_mid.Text.ToUpper();
        }

        private void txt_last_Leave(object sender, EventArgs e)
        {
            txt_last.Text = txt_last.Text.ToUpper();
        }

        private void txt_address_Leave(object sender, EventArgs e)
        {
            txt_address.Text = txt_address.Text.ToUpper();
        }

        private void txt_nat_Leave(object sender, EventArgs e)
        {
            txt_nat.Text = txt_nat.Text.ToUpper();
        }

        private void txt_trade_Leave(object sender, EventArgs e)
        {
            txt_trade.Text = txt_trade.Text.ToUpper();
        }

        private void txt_code_Leave(object sender, EventArgs e)
        {
            txt_code.Text = txt_code.Text.ToUpper();
        }

        private void txt_nino_Leave(object sender, EventArgs e)
        {
            txt_nino.Text = txt_nino.Text.ToUpper();
        }

        private void txt_no_Leave(object sender, EventArgs e)
        {
            txt_no.Text = txt_no.Text.ToUpper();
        }

        private void txt_bank_Leave(object sender, EventArgs e)
        {
            txt_bank.Text = txt_bank.Text.ToUpper();
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            bool error = true;
            errorProvider1.Clear();
            if (txt_first.Text != null && txt_first.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_first, "First Name is missing!");
            }
            if (txt_last.Text != null && txt_last.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_last, "Last Name is missing!");
            }
            if (txt_address.Text != null && txt_address.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_address, "Address is missing!");
            }
            if (txt_code.Text != null && txt_code.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_code, "Postcode is missing!");
            }
            if (txt_mobile.Text != null && txt_mobile.Text != "")
            {
                if (txt_mobile.Text.Length == 11 && txt_mobile.Text.All(c => Char.IsDigit(c)) == true)
                {

                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_mobile, "Mobile number is incorect!");
                }
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_mobile, "Mobile number is missing!");
            }
            if (txt_email.Text != null && txt_email.Text != "")
            {
                if(IsValidEmail(txt_email.Text) == true)
                {
                    
                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_email, "Email address is not correct!");
                }
            }
            if (txt_cs.Text != null && txt_cs.Text != "")
            {
                if (txt_cs.Text.All(c => Char.IsDigit(c)) == true && txt_cs.Text.Length == 8)
                {
                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_cs, "CSCS must contain 8 digits!");
                }
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_cs, "CSCS is missing!");
            }
            if (txt_trade.Text != null || txt_trade.Text != "")
            {
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_trade, "Trade is missing!");
            }
            if (txt_utr.Text != null && txt_utr.Text != "")
            {
                if (txt_utr.Text.All(c => Char.IsDigit(c)) == true && txt_utr.Text.Length == 10)
                {
                }
                else
                {
                    error = false;
                    errorProvider1.SetError(txt_utr, "UTR must contain 10 digits!");
                }
            }
            else
            {
                error = false;
                errorProvider1.SetError(txt_utr, "UTR is missing!");
            }
            SqlDataAdapter ver = new SqlDataAdapter("Select * From LTD", Form1.Conn);
            DataSet dsPubs = new DataSet("Pubs");
            ver.FillSchema(dsPubs, SchemaType.Source, "LTD");
            ver.Fill(dsPubs, "LTD");
            foreach (DataRow r in dsPubs.Tables["LTD"].Rows)
            {
                if (txt_nino.Text != null && txt_nino.Text != "")
                {
                    if (txt_nino.Text == r[16].ToString())
                    {
                        error = false;
                        MessageBox.Show("You already have this person in database!", "NINO");
                    }
                }
            }
            if (add == true && error)
            {
                using (SqlCommand delQ = new SqlCommand("INSERT INTO LTD ([ID], [First Name], [Middle Name], [Last Name],[Birth date], [Address], [Postcode], [Nationality], [Mobile], [Email], [Bank], [Sort Code], [Acc no], [Right to work], [UTR], [NINO], [Verification no.], [CSCS], [CSCS Expiry date], [Trade], [Start date], [Working], [Tax status]) " +
                                        "VALUES (@idd, @first, @mid, @last, @birth, @address, @code, @nat, @mobile, @email, @bank, @sort, @acc, @right, @utr, @nino, @no, @cs, @csExpr, @trade, @dateStart, @cbWork, @cbTax)", Form1.Conn))
                {
                    delQ.Parameters.Add(new SqlParameter("@idd", id));
                    delQ.Parameters.Add(new SqlParameter("@first", txt_first.Text));
                    delQ.Parameters.Add(new SqlParameter("@mid", txt_mid.Text));
                    delQ.Parameters.Add(new SqlParameter("@last", txt_last.Text));
                    delQ.Parameters.Add(new SqlParameter("@birth", dateTimePicker_birth.Text));
                    delQ.Parameters.Add(new SqlParameter("@address", txt_address.Text));
                    delQ.Parameters.Add(new SqlParameter("@code", txt_code.Text));
                    delQ.Parameters.Add(new SqlParameter("@nat", txt_nat.Text));
                    delQ.Parameters.Add(new SqlParameter("@mobile", txt_mobile.Text));
                    delQ.Parameters.Add(new SqlParameter("@email", txt_email.Text));
                    delQ.Parameters.Add(new SqlParameter("@bank", txt_bank.Text));
                    delQ.Parameters.Add(new SqlParameter("@sort", txt_sort.Text));
                    delQ.Parameters.Add(new SqlParameter("@acc", txt_acc.Text));
                    delQ.Parameters.Add(new SqlParameter("@right", right));
                    delQ.Parameters.Add(new SqlParameter("@utr", txt_utr.Text));
                    delQ.Parameters.Add(new SqlParameter("@nino", txt_nino.Text));
                    delQ.Parameters.Add(new SqlParameter("@no", txt_no.Text));
                    delQ.Parameters.Add(new SqlParameter("@cs", txt_cs.Text));
                    delQ.Parameters.Add(new SqlParameter("@csExpr", date_cs_expr.Text));
                    delQ.Parameters.Add(new SqlParameter("@trade", txt_trade.Text));
                    delQ.Parameters.Add(new SqlParameter("@dateStart", date_start.Text));
                    delQ.Parameters.Add(new SqlParameter("@cbWork", cb_work.Text));
                    delQ.Parameters.Add(new SqlParameter("@cbTax", cb_tax.Text));
                    delQ.ExecuteNonQuery();
                }
                //SqlCommand daAuthors = new SqlCommand("INSERT INTO LTD ([ID], [First Name], [Middle Name], [Last Name],[Birth date], [Address], [Postcode], [Nationality], [Mobile], [Email], [Bank], [Sort Code], [Acc no], [Right to work], [UTR], [NINO], [Verification no.], [CSCS],[CSCS Expiry date], [Trade], [Start date], [Working], [Tax status]) " +
                //                        "VALUES ('" + id + "', '" + txt_first.Text + "', '" + txt_mid.Text + "','" + txt_last.Text + "','" + dateTimePicker_birth.Text + "', '" + txt_address.Text + "', '" + txt_code.Text + "', '" + txt_nat.Text + "','" + txt_mobile.Text + "', '" + txt_email.Text + "', '" + txt_bank.Text + "', '" + txt_sort.Text + "', '" + txt_acc.Text + "', '" + right + "','" + txt_utr.Text + "', '" + txt_nino.Text + "', '" + txt_no.Text + "', '" + txt_cs.Text + "', '" + date_cs_expr.Text + "', '" + txt_trade.Text + "', '" + date_start.Text + "', '" + cb_work.Text + "', '" + cb_tax.Text + "')", Form1.Conn);
                //daAuthors.ExecuteNonQuery();
                using (SqlCommand delQ = new SqlCommand("INSERT INTO Rates ([ID], [Day], [Night], [Others], [Weekend], [Shift])" + " VALUES (@idd, @rday, @rnight, @rothers, @rweek, @rshift)", Form1.Conn))
                {
                    delQ.Parameters.Add(new SqlParameter("@idd", id));
                    delQ.Parameters.Add(new SqlParameter("@rday", txt_rday.Text));
                    delQ.Parameters.Add(new SqlParameter("@rnight", txt_rnight.Text));
                    delQ.Parameters.Add(new SqlParameter("@rothers", txt_rothers.Text));
                    delQ.Parameters.Add(new SqlParameter("@rweek", txt_rweek.Text));
                    delQ.Parameters.Add(new SqlParameter("@rshift", txt_shift.Text));
                    delQ.ExecuteNonQuery();
                }
                //SqlCommand drates = new SqlCommand("INSERT INTO Rates ([ID], [Day], [Night], [Others], [Weekend])" + " VALUES ('" + id + "', '" + txt_rday.Text + "', '" + txt_rnight.Text + "', '" + txt_rothers.Text + "', '" + txt_rweek.Text + "')", Form1.Conn);
                //drates.ExecuteNonQuery();
                string action = "Added " + id.ToString();
                using (SqlCommand newq = new SqlCommand("INSERT INTO log([User], [Action], [Date]) VALUES (@use, @actio, @dat)", Form1.Conn))
                {
                    newq.Parameters.Add(new SqlParameter("@use", Form1.username));
                    newq.Parameters.Add(new SqlParameter("@actio", action));
                    newq.Parameters.Add(new SqlParameter("@dat", DateTime.Now.ToString("yyyy_MM_dd")));
                    newq.CommandType = CommandType.Text;
                    newq.ExecuteNonQuery();
                }
                this.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cb_work.Items.Add("Active");
            cb_work.Items.Add("Stand by");
            if (add)
            {
                cb_work.SelectedItem = cb_work.Items[0].ToString();
            }
        }
    }
}
