using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LTDesktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 fr = new Form1();
            Application.Run(fr);
            if (fr.DialogResult == DialogResult.OK)
            {
                Form7 frm = new Form7();
                Application.Run(frm);
                LTDesktop.Form2 frm2 = new LTDesktop.Form2();
                Application.Run(frm2);
            }
        }
    }
}
