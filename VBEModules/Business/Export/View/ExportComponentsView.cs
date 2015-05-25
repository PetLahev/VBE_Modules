using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VbeComponents.Controls;
using VbeComponents.Events;
using VbeComponents.Resources;

namespace VbeComponents.Business.Export.View
{
    public partial class ExportComponentsView : Form, IExport
    {
        private IEnumerable<Business.Component> _components;
        private ISelectionPanel _panel;
        private int _counter = 0;
        private Font _fnRegular = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
        private Font _fnItalic = new Font("Microsoft Sans Serif", 9, FontStyle.Italic);

        public event ExportEventHandler PathSelecting;
        public event ExportEventHandler PathValidating;
        public event ExportEventHandler ExportRequestedRaised;
        
        public ExportComponentsView()
        {
            InitializeComponent();
            this.imageList1.Images.Add("class",   Properties.Resources.Class);
            this.imageList1.Images.Add("module",  Properties.Resources.Module);
            this.imageList1.Images.Add("form",    Properties.Resources.Form);
            this.imageList1.Images.Add("document", Properties.Resources.document);
            tw.ImageList = this.imageList1;
            _panel = this.selectionPanel1;
            _panel.SelectionChanged += new EventHandler<Events.SelectionEventArgs>(selectionPanel1_SelectionChanged);
        }

        void selectionPanel1_SelectionChanged(object sender, EventArgs e)
        {
            lblItems.Text = string.Format(strings.NumberOfComponentsPlusSelected, _counter, SelectedItems.Count());            
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
                txtExportPath.Font = _fnRegular;
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
            txtExportPath.Font = _fnItalic;
            txtExportPath.ForeColor = Color.Gray;
        }

        public IEnumerable<Business.Component>Items
        {
            get { return _components; }
            set
            {
                try
                {
                    tw.Nodes.Clear();
                    _counter = 0;
                    _components = value;

                    if (_components == null)
                    {
                        _panel.Nodes = null;
                        return;
                    }

                    _panel.ProjectComponets = _components;
                    _counter = TreeViewHelper.AddComponents(tw, _components);
                    lblItems.Text = string.Format(strings.NumberOfComponentsPlusSelected, _counter, _counter);
                    Business.TreeViewHelper.CheckAllNodes(tw, null);
                    _panel.Nodes = tw.Nodes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, strings.ExportFormMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IEnumerable<Business.Component> SelectedItems
        {
            get
            {
                return Business.TreeViewHelper.GetCheckedNodes(tw, null);
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
            try
            {
                if (!SelectedItems.Any())
                {
                    MessageBox.Show(strings.ExportNoItemSelected, strings.ExportFormMessageCaption, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                ExportEventArgs args = new ExportEventArgs() { ProjectName = txtProjectName.Text, Path = txtExportPath.Text };
                if (PathValidating != null) PathValidating(this, args);
                if (!args.Cancel)
                {
                    MessageBox.Show(strings.PathIsNotValid, strings.ExportFormMessageCaption, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                int numofChecked = SelectedItems.Count();
                string confirmMessage = string.Format(strings.ExportConfirmation,
                    numofChecked, numofChecked == 1 ? strings.Item : strings.Items);
                DialogResult answer = MessageBox.Show(
                    confirmMessage, strings.ExportFormMessageCaption, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.No) return;

                args = new ExportEventArgs()
                {
                    ProjectName = txtProjectName.Text,
                    Path = txtExportPath.Text,
                    SelectedComponents = SelectedItems
                };
                if (ExportRequestedRaised != null) ExportRequestedRaised(this, args);
                if (args.Cancel) return;
                MessageBox.Show(string.Format(strings.SuccessfullyExported, numofChecked), 
                    strings.ExportFormMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strings.ExportFormMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tw_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            if (e.Node.Parent == null)
            {
                TreeViewHelper.ChangeStateOfChildNodes(e.Node, e.Node.Checked);
            }
            else
            {
                if (!e.Node.Checked)
                {
                    e.Node.Parent.Checked = false;
                }
                else
                {                    
                    bool allChildernChecked = TreeViewHelper.IsAllChildernChecked(e.Node.Parent);
                    if (allChildernChecked) e.Node.Parent.Checked = true;
                }
            }
            lblItems.Text = string.Format(strings.NumberOfComponentsPlusSelected, _counter, SelectedItems.Count());            
        }

        private void txtExportPath_MouseHover(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExportPath.Text))
                toolTip1.SetToolTip(txtExportPath, null);
            else
                toolTip1.SetToolTip(txtExportPath, txtExportPath.Text);
        }

        private void tw_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e == null || e.Node.Tag == null)
            {
                txtContent.Text = null;
                return;
            }

            Component component = (Component)e.Node.Tag;
            if (string.IsNullOrWhiteSpace(component.Content))
            {
                txtContent.Text = null;
            }
            else
            {
                txtContent.Text = component.Content;
            }
        }
        
    }
}
