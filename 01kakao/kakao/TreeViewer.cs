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
    public partial class TreeViewer : UserControl
    {
        public TreeViewer()
        {
            InitializeComponent();
        }

        private void TreeViewer_Load(object sender, EventArgs e)
        {
            //TreeView 생성
            CTree ctree = new CTree();
            ctree.Tree.ImageList = imageList1;
            ctree.SetTreeParentNode("a", "a", 0);
            ctree.SetTreeChildNode("a", "b", "b", 0);

            //Treeview 노드 생성

            //treeview 불러오기
            kryptonTreeView1 = ctree.Tree;
            kryptonTreeView1.Refresh();
        }
    }
}
