using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Business
{
    /// <summary>
    /// Handles common action for TreeView
    /// Not OOP at all but helps a lot
    /// </summary>
    public static class TreeViewHelper
    {
        private static int _numOfAddComponents = 0;

        /// <summary>
        /// Checks all nodes in given TreeView control
        /// </summary>
        /// <param name="tw">a reference to a TreeView control</param>
        /// <param name="args"></param>
        public static void CheckAllNodes(TreeView tw, Events.TreeNodeEventArgs args)
        {
            ChangeCheckedStateOfNodes(tw.Nodes, true);
        }

        /// <summary>
        /// Unchecks all nodes in given TreeView control
        /// </summary>
        /// <param name="tw">a reference to a TreeView control</param>
        /// <param name="args"></param>
        public static void UncheckAllNodes(TreeView tw, Events.TreeNodeEventArgs args)
        {
            ChangeCheckedStateOfNodes(tw.Nodes, false);
        }

        /// <summary>
        /// Changes state of all children of given parent node
        /// </summary>
        /// <param name="parentNode">a parent node for which all children state will be changed</param>
        /// <param name="state">a checked state to be applied</param>
        public static void ChangeStateOfChildNodes(TreeNode parentNode, bool state)
        {
            CheckChildren(parentNode, state);
        }

        /// <summary>
        /// Determines if all children of given parent node are checked
        /// </summary>
        /// <param name="parentNode">a parent node for which all children state will be determined</param>
        /// <returns>True if all children are checked, otherwise false</returns>
        public static bool IsAllChildernChecked(TreeNode parentNode)
        {
            return  parentNode.Nodes.OfType<TreeNode>()
                        .SelectMany(x => GetNodeAndChildren(x))
                        .All(x => x.Checked);            
        }

        /// <summary>
        /// Add given components to given TreeView control
        /// </summary>
        /// <param name="tw">a reference to a TreeView control</param>
        /// <param name="components">list of components to be added</param>
        /// <returns>number of components that were added to given tree view control</returns>
        public static int AddComponents(TreeView tw, IEnumerable<Business.Component> components)
        {
            _numOfAddComponents = 0;
            var vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_StdModule, components);
            AddComponent(tw, vbComponents, "Modules", "module");

            vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_MSForm, components);
            AddComponent(tw, vbComponents, "Forms", "form");

            vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_ClassModule, components);
            AddComponent(tw, vbComponents, "Classes", "class");

            vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_Document, components);
            AddComponent(tw, vbComponents, "Documents", "document");
            
            tw.ExpandAll();
            return _numOfAddComponents;
        }

        /// <summary>
        /// Returns all components that are checked on given TreeView control
        /// </summary>
        /// <param name="tw">a reference to a TreeView control</param>
        /// <param name="args"></param>
        /// <returns>All components that are checked</returns>
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

        private static void AddComponent(TreeView tw, Business.Component[] items, string nodeText, string imageKey)
        {
            if (items.Any())
            {
                var parentNode = tw.Nodes.Add(key: nodeText, text: string.Format("{0} ({1})", nodeText, items.Count()), imageKey: imageKey);
                foreach (Business.Component item in items)
                {
                    TreeNode nd=  parentNode.Nodes.Add(key: item.Name, text: item.Name, imageKey: imageKey);
                    nd.Tag = item;
                    _numOfAddComponents += 1;
                }
            }
        }

        private static Business.Component[] GetComponnets(vbext_ComponentType componentType, IEnumerable<Business.Component> components)
        {
            var component = components.Where(x => x.Type == componentType);
            var vbComponents = component as Business.Component[] ?? component.ToArray();
            return vbComponents;
        }

    }
}
