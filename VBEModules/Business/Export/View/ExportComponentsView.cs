using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Controls;
using VbeComponents.Events;
using VbeComponents.Resources;

namespace VbeComponents.Business.Export.View
{
    public partial class ExportComponentsView : Form, IExport
    {
        private IEnumerable<_VBComponent> _componenets;
        private ISelectionPanel _panel;

        public event ExportEventHandler PathSelecting;
        public event ExportEventHandler PathValidating;
        public event ExportEventHandler ExportRequestedRaised;

        private int _counter = 0;

        public ExportComponentsView()
        {
            InitializeComponent();
            this.imageList1.Images.Add("class",   Properties.Resources.Class);
            this.imageList1.Images.Add("module",  Properties.Resources.Module);
            this.imageList1.Images.Add("form",    Properties.Resources.Form);
            this.imageList1.Images.Add("document", Properties.Resources.document);
            tw.ImageList = this.imageList1;
            _panel = this.selectionPanel1;
            _panel.SelectionChanged += new EventHandler(selectionPanel1_SelectionChanged);
        }

        void selectionPanel1_SelectionChanged(object sender, EventArgs e)
        {
            SelectionPanelOptions option = (SelectionPanelOptions) sender;
            TreeNode parentNode = null;
            UncheckAllNodes(tw.Nodes);
            switch (option)
            {
                case SelectionPanelOptions.All:
                    CheckAllNodes(tw.Nodes);
                    break;
                case SelectionPanelOptions.Modules:
                    parentNode = tw.Nodes["Modules"];
                    parentNode.Checked = true;
                    CheckChildren(parentNode, true);
                    break;
                case SelectionPanelOptions.Forms:
                    parentNode = tw.Nodes["Forms"];
                    parentNode.Checked = true;
                    CheckChildren(parentNode, true);
                    break;
                case SelectionPanelOptions.Classes:
                    parentNode = tw.Nodes["Classes"];
                    parentNode.Checked = true;
                    CheckChildren(parentNode, true);
                    break;
                case SelectionPanelOptions.Documents:
                    parentNode = tw.Nodes["Documents"];
                    parentNode.Checked = true;
                    CheckChildren(parentNode, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = true;
                CheckChildren(node, true);
            }
        }

        private void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        public string Path
        {
            get { return txtExportPath.Text; }
            set
            {
                if (value == null)
                {
                    AddDefaultPathText();
                    return;
                }

                txtExportPath.Text = value;
                txtExportPath.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                txtExportPath.ForeColor = Color.Black;
            }
        }

        public string ProjectName
        {
            get { return txtProjectName.Text; }
            set { txtProjectName.Text = value; }
        }

        private void AddDefaultPathText()
        {
            txtExportPath.Text = strings.DefaultPathValue;
            txtExportPath.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Italic);
            txtExportPath.ForeColor = Color.Gray;
        }

        public IEnumerable<_VBComponent> Items
        {
            get { return _componenets; }
            set
            {
                tw.Nodes.Clear();
                _counter = 0;
                _componenets = value;
                if (_componenets == null) return;

                _panel.ProjectComponets = _componenets;
                var vbComponents =  GetComponnets(vbext_ComponentType.vbext_ct_StdModule);
                AddComponent(vbComponents, "Modules", "module");

                vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_MSForm);
                AddComponent(vbComponents, "Forms", "form");
                
                vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_ClassModule);
                AddComponent(vbComponents, "Classes", "class");

                vbComponents = GetComponnets(vbext_ComponentType.vbext_ct_Document);
                AddComponent(vbComponents, "Documents", "document");
                
                CheckAllNodes(tw.Nodes);
                lblItems.Text = string.Format(strings.NumberOfComponentsPlusSelected, _counter, _counter);
                tw.ExpandAll();
            }
        }

        private _VBComponent[] GetComponnets(vbext_ComponentType componentType)
        {
            var component = _componenets.Cast<_VBComponent>().Where(x => x.Type == componentType);
            var vbComponents = component as _VBComponent[] ?? component.ToArray();
            return vbComponents;
        }

        private void AddComponent(_VBComponent[] items, string nodeText, string imageKey)
        {
            if (items.Any())
            {
                var parentNode = tw.Nodes.Add(key: nodeText, text: string.Format("{0} ({1})", nodeText, items.Count()), imageKey: imageKey);
                foreach (_VBComponent item in items)
                {
                    TreeNode nd=  parentNode.Nodes.Add(key: item.Name, text: item.Name, imageKey: imageKey);
                    nd.Tag = item;
                    _counter += 1;
                }
            }
        }

        public IEnumerable<_VBComponent> SelectedItems
        {
            get
            {
                var checkedNodes = tw.Nodes
                                .OfType<TreeNode>()
                                .SelectMany(x => GetNodeAndChildren(x))
                                .Where(x => x.Checked && x.Parent != null)
                                .Select(x => x.Tag as VBComponent)
                                .ToArray();
                return checkedNodes;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DialogResult ShowView() { return this.ShowDialog();}

        public void CloseForm() { this.Close();}

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (PathSelecting != null) PathSelecting(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!SelectedItems.Any())
            {
                MessageBox.Show(strings.ExportNoItemSelected, strings.ExportFormMessageCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            
            ExportEventArgs args = new ExportEventArgs() { ProjectName = txtProjectName.Text, Path = txtExportPath.Text};
            if (PathValidating != null) PathValidating(this, args);
            if (!args.Cancel)
            {
                MessageBox.Show(strings.PathIsNotValid, strings.ExportFormMessageCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            int numofChecked = SelectedItems.Count();
            string confirmMessage = string.Format(strings.ExportConfirmation, 
                numofChecked,  numofChecked == 1 ? strings.Item :  strings.Items );
            DialogResult answer =  MessageBox.Show(
                confirmMessage, strings.ExportFormMessageCaption, MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (answer == DialogResult.No) return;
            
            args = new ExportEventArgs() { ProjectName = txtProjectName.Text, 
                Path = txtExportPath.Text, 
                SelectedComponents = SelectedItems};
            if (ExportRequestedRaised != null) ExportRequestedRaised(this, args);
            if (args.Cancel) return;
            this.Close();
        }

        IEnumerable<TreeNode> GetNodeAndChildren(TreeNode node)
        {
            return new[] { node }.Concat(node.Nodes
                                            .OfType<TreeNode>()
                                            .SelectMany(x => GetNodeAndChildren(x)));
        }


    }
}
