using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kakao
{
    public partial class MainForm : Form
    {
        private static ProgressViewer cPv = new ProgressViewer();
        private static SettingViewer cSv = new SettingViewer();
        public MainForm()
        {
            InitializeComponent();
            cPv.Dock = DockStyle.Fill;
            container.Panel2.Controls.Add(cPv);
            
        }

        private void Click_Progress(object sender, EventArgs e)
        {
            container.Panel2.Controls.Clear();
            cPv.Dock = DockStyle.Fill;
            container.Panel2.Controls.Add(cPv);
            
        }

        private void Click_setting(object sender, EventArgs e)
        {
            container.Panel2.Controls.Clear();
            cSv.Dock = DockStyle.Fill;
            container.Panel2.Controls.Add(cSv);
           
        }
    }
}
