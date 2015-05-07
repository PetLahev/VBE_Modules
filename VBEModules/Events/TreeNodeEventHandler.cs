using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbeComponents.Events
{
    public delegate void TreeNodeHelperDel(TreeView sender, TreeNodeEventArgs e );
    
    public class TreeNodeEventArgs :EventArgs
    {
        TreeNode ClickedNode { get; set; }
        bool ChangingState { get; set; }
    }
}
