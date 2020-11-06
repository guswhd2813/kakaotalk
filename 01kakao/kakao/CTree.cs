using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
namespace kakao
{
    class CTree
    {
        private KryptonTreeView _Tree;
        private KryptonTreeNode topNode = null;
      
        public CTree()
        {
            _Tree = new KryptonTreeView();
        }
        public KryptonTreeView Tree
        {
            get { return _Tree; }
            set { _Tree = value; }
        }
        public int SetTreeParentNode(string treeName, string viewName, int imageIndex)
        {
            try
            {
                //_Tree.TreeView.Nodes.Insert(_Tree.TopNode, treeName, viewName, imageIndex);
                return 1;
            }
            catch
            {
                //트리 생성 실패 로그
                return 0;
            }            
        }
        public int SetTreeChildNode(string parentNode,string treeName, string viewName, int imageIndex)
        {
            try
            {
                _Tree.TreeView.Nodes.Insert(_Tree.Nodes.IndexOfKey(parentNode), treeName, viewName, imageIndex);
                return 1;
            }
            catch
            {
                //트리 생성 실패 로그
                return 0;
            }
        }


    }
}
