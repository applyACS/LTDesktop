using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manta_Alex_Payments
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }
        private void PopulateTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"\\192.168.130.12\d\Invoice");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView2.Nodes.Add(rootNode);
            }
            info = new DirectoryInfo(@"\\192.168.130.12\d\Month_report");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView2.Nodes.Add(rootNode);
            }
            info = new DirectoryInfo(@"\\192.168.130.12\d\Montly_tax");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView2.Nodes.Add(rootNode);
            }
            info = new DirectoryInfo(@"\\192.168.130.12\d\Payslips");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView2.Nodes.Add(rootNode);
            }
            info = new DirectoryInfo(@"\\192.168.130.12\d\Wage_list");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView2.Nodes.Add(rootNode);
            }
            info = new DirectoryInfo(@"\\192.168.130.12\d\Year_report");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView2.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode = null;
            DirectoryInfo[] subSubDirs = new DirectoryInfo[1];
            foreach (DirectoryInfo subDir in subDirs)
            {
                if (subDir != null)
                {
                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";

                    try
                    {
                        subSubDirs = subDir.GetDirectories();
                    }
                    catch (UnauthorizedAccessException)
                    {

                    }
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode);
                    }
                    nodeToAddTo.Nodes.Add(aNode);
                }
            }
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            try
            {
                foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                {
                    item = new ListViewItem(dir.Name, 0);
                    subItems = new ListViewItem.ListViewSubItem[]
                    {
                        new ListViewItem.ListViewSubItem(item, "Directory"), 
                     new ListViewItem.ListViewSubItem(item, 
						dir.LastAccessTime.ToShortDateString())};
                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }

                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                    { 
                        new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString()),
                        new ListViewItem.ListViewSubItem(item, Path.GetDirectoryName(file.FullName))
                    };

                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Unable to access this folder!");
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            string s ="";
            string d = "";
            string tag = "";
            if(e.KeyCode == Keys.O)
            {
                e.Handled = e.SuppressKeyPress = true;
                foreach(ListViewItem i in listView1.Items)
                {
                    if(i.Selected)
                    {
                        s = i.SubItems[3].Text + "\\" + i.SubItems[0].Text;
                    }
                }
                System.Diagnostics.Process.Start(s);
                
            }
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = e.SuppressKeyPress = true;
                foreach (ListViewItem i in listView1.Items)
                {
                    if (i.Selected)
                    {
                        s = i.SubItems[3].Text + "\\" + i.SubItems[0].Text;
                        tag = i.SubItems[3].Text;
                        d = @"\\192.168.130.12\d\Deleted\" + i.SubItems[0].Text;
                    }
                }
                File.Move(s, d);
                listView1.Refresh();
                listView1.Update();
            }
        }
    }
}
