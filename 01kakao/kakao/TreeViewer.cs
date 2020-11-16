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
using ComponentFactory.Krypton.Navigator;

namespace kakao
{
    public partial class TreeViewer : UserControl
    {
        #region singleton
        private static TreeViewer _instance = null;
        public static TreeViewer getInstance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TreeViewer();
                }
                return _instance;
            }
        }
        #endregion

        List<string> _driverName = null;

        private TreeViewer()
        {            
            InitializeComponent();
        }
        public KryptonTreeView TreeView
        {
            get { return kryptonTreeView; }
            set { kryptonTreeView = value; }
        }

        private void TreeViewer_Load(object sender, EventArgs e)
        {    
            //TreeView parent node 생성
            kryptonTreeView.TreeView.Nodes.Add("Main", "Main", 0);
            kryptonTreeView.TreeView.Nodes.Add("Driver", "Driver", 0);
            kryptonTreeView.TreeView.Nodes.Add("Log", "Log", 0);

            //Treeview  child노드 생성            
            _driverName = Driver._instance.DriverName;
            foreach (string drvName in _driverName)
            {
                AddTreeNode(drvName, drvName, 0);
            }
           
            kryptonTreeView.Refresh();
        }
        private void AddTreeNode(string _nodeName,string _viewName,int _imageidx)
        {
            try
            {
                kryptonTreeView.TreeView.Nodes["Driver"].Nodes.Insert(kryptonTreeView.TreeView.Nodes["Driver"].Index, _nodeName, _viewName, _imageidx);
                kryptonTreeView.TreeView.Nodes["Log"].Nodes.Insert(kryptonTreeView.TreeView.Nodes["Log"].Index, _nodeName, _viewName, _imageidx);                
            }
            catch(Exception e)
            {

            }

        }

    }
}
