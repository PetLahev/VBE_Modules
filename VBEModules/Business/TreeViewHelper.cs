using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VbeComponents.Business
{
    /// <summary>
    /// Handles common action for TreeView
    /// Not OOP at all but helps a lot
    /// </summary>
    public static class TreeViewHelper
    {

        public static void CheckAllNodes(TreeView tw, Events.TreeNodeEventArgs args)
        {
            ChangeCheckedStateOfNodes(tw.Nodes, true);
        }

        public static void UncheckAllNodes(TreeView tw, Events.TreeNodeEventArgs args)
        {
            ChangeCheckedStateOfNodes(tw.Nodes, false);
        }


        public static IEnumerable<Business.Component> GetCheckedNodes(TreeView tw, DrawTreeNodeEventArgs args)
        {
            var checkedNodes = tw.Nodes
                               .OfType<TreeNode>()
                               .SelectMany(x => GetNodeAndChildren(x))
                               .Where(x => x.Checked && x.Parent != null)
                               .Select(x => x.Tag as Business.Component)
                               .ToArray();
            return checkedNodes;
        }

        private static void ChangeCheckedStateOfNodes(TreeNodeCollection nodes, bool state)
        {
            foreach (TreeNode nd in nodes)
            {   
                nd.Checked = state;
                CheckChildren(nd, state);                
            }
        }              

        private static void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private static IEnumerable<TreeNode> GetNodeAndChildren(TreeNode node)
        {
            return new[] { node }.Concat(node.Nodes
                                            .OfType<TreeNode>()
                                            .SelectMany(x => GetNodeAndChildren(x)));
        }

    }
}
