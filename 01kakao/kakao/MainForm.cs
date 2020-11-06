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
        private static ProgressViewer cPv = new ProgressViewer();
        private static SettingViewer cSv = new SettingViewer();
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
            

        }
        private KryptonPage NewPage()
        {
            return NewPage("Process", 2, new TreeViewer());
        }
        private KryptonPage NewPage(string name, int image, Control content)
        {
            // Create new page with title and image
            KryptonPage p = new KryptonPage();
            p.Text = name + _count.ToString();
            p.TextTitle = name + _count.ToString();
            p.TextDescription = name + _count.ToString();
            //p.ImageSmall = imageListIcon.Images[image];

            // Add the control for display inside the page
            content.Dock = DockStyle.Fill;
            p.Controls.Add(content);

            _count++;
            return p;
        }
        private KryptonPage NewDocument()
        {
            KryptonPage page = NewPage("Driver Maker ", 1, new SettingViewer());

            // Document pages cannot be docked or auto hidden
            page.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);

            return page;
        }


        private void Click_Progress(object sender, EventArgs e)
        {
            //container.Panel2.Controls.Clear();
            //cPv.Dock = DockStyle.Fill;
            //container.Panel2.Controls.Add(cPv);

        }

        private void Click_setting(object sender, EventArgs e)
        {
            //container.Panel2.Controls.Clear();
            //cSv.Dock = DockStyle.Fill;
            //container.Panel2.Controls.Add(cSv);

        }
    }
}
