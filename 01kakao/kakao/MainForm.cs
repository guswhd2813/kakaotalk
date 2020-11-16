using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Docking;

namespace kakao
{

    public partial class MainForm : KryptonForm
    {
        private int consize;
        private int _count = 1;
        //private static ProgressViewer cPv = new ProgressViewer();
        //private static SettingViewer cSv = new SettingViewer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            KryptonDockingWorkspace w = kryptonDockingManager.ManageWorkspace(kryptonDockableWorkspace);
            kryptonDockingManager.ManageControl(kryptonPanel, w);
            kryptonDockingManager.ManageFloating(this);

            //kryptonDockingManager.AddToWorkspace("Workspace", new KryptonPage[] { NewDocument(), NewDocument() });
            kryptonDockingManager.AddDockspace("Control", DockingEdge.Left, new KryptonPage[] { NewPage() });
            TreeViewer.getInstance.TreeView.NodeMouseDoubleClick += TreeView_NodeMouseDoubleClick;
        }

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name != "Log" && e.Node.Name != "Driver")
            
                kryptonDockingManager.AddToWorkspace("Workspace", new KryptonPage[] { NewDocument(e) });
            
        }
            
        private KryptonPage NewPage()
        {
            return NewPage("Process", 2, TreeViewer.getInstance);
        }
        private KryptonPage NewPage(string name, int image, Control content)
        {
            // Create new page with title and image
            KryptonPage p = new KryptonPage();
            p.Text = name;
            p.TextTitle = name;
            p.TextDescription = name;
            p.ClearFlags(KryptonPageFlags.DockingAllowClose | KryptonPageFlags.DockingAllowFloating| KryptonPageFlags.DockingAllowWorkspace);
            //p.ImageSmall = imageListIcon.Images[image];

            // Add the control for display inside the page
            content.Dock = DockStyle.Fill;
            
            p.Controls.Add(content);

            _count++;
            return p;
        }

        private KryptonPage NewDocument(TreeNodeMouseClickEventArgs e)
        {
            KryptonPage page = null;
            if (e.Node.Parent!= null)
                page = NewPage(e.Node.Parent.Text+"_" + e.Node.Text, 1, new SettingViewer(e.Node.Text));
            else
                 page = NewPage(e.Node.Text, 1, new SettingViewer(e.Node.Text));

            // Document pages cannot be docked or auto hidden
            page.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);
            
            return page;
        }

        private void Test(object sender, EventArgs e)
        {
            List<string> _str = Driver._instance.DriverName;
        }
    }
}
