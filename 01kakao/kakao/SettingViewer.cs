using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace kakao
{
    public partial class SettingViewer : UserControl
    {       

        public SettingViewer(string _DriverName)
        {
            InitializeComponent();            
            Initialize(_DriverName);
        }
        private void Initialize(string _DriverName)
        {
            flowLayoutPanel.Controls.Add(CreateNewControl());
            flowLayoutPanel.Controls.Add(CreateNewControl());
            // kryptonListBox.Items.Add(CreateNewItem());            
            // kryptonListBox.Items.Add(CreateNewItem());
        }
        private KryptonPanel CreateNewControl()
        {
            KryptonPanel item = new KryptonPanel();

            KryptonLabel label = new KryptonLabel();
            label.Text = "1";
            label.ForeColor = Color.White;
            label.Dock = DockStyle.Left;
            label.LabelStyle = LabelStyle.BoldPanel;
            KryptonTextBox text = new KryptonTextBox();
            text.Dock = DockStyle.Fill;
           
            item.Controls.Add(text);
            item.Controls.Add(label);
            
            item.Height = text.Height;

            return item;
        }

       
    }
}
