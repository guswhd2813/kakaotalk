using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kakao
{
    public partial class SettingViewer : UserControl
    {
        TreeNode driver = new TreeNode("Driver");
        public SettingViewer()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            TreeNode mainnode = new TreeNode("Main");
            
            mainnode.Nodes.Add("0", "Main", 0, 0);
            driver.Nodes.Add("0", "Python", 0, 0);
            treeView1.Nodes.Add(mainnode);
            treeView1.Nodes.Add(driver); treeView1.ExpandAll();
        }

        private void Btn_DriverAdd(object sender, EventArgs e)
        {
            treeView1.Nodes[1].Nodes.Add("123", "Python", 0,0);
            treeView1.Refresh();
            treeView1.ExpandAll();

        }

        private void Btn_Driverdelete(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode.Text !="Main" & treeView1.SelectedNode.Text != "Driver")
            {
                treeView1.SelectedNode.Remove();
            }

            treeView1.ExpandAll();
        }
    }
}
