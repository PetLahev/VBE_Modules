using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Vbe.Interop;
using VbeComponents.Events;
using VbeComponents.Resources;

namespace VbeComponents.Business.Import.Views
{
    public partial class ImportView : Form, IImport
    {
        private Controls.ISelectionPanel _panel;
        private IList<Project> _projects;
        private bool _doNotRunEvents = false;
        private int _counter;

        public event Events.ImportEventHandler PathSelecting;
        public event Events.ImportEventHandler PathValidating;
        public event Events.ImportEventHandler ImportRequestedRaised;
        
        public ImportView()
        {
            InitializeComponent();
            imageList1.Images.Add("class", Properties.Resources.Class);
            imageList1.Images.Add("module", Properties.Resources.Module);
            imageList1.Images.Add("form", Properties.Resources.Form);
            imageList1.Images.Add("document", Properties.Resources.document);
            tw.ImageList = this.imageList1;

            _panel = this.selectionPanel1;
            _panel.SelectionChanged += new EventHandler<SelectionEventArgs>(_panel_SelectionChanged);
            cboProjects.Text = strings.ImportAddFolder;
        }

        void _panel_SelectionChanged(object sender, SelectionEventArgs e)
        {
            lblItems.Text = string.Format(strings.NumberOfComponentsPlusSelected, _counter, SelectedItems.Count());            
        }

#region Drawing

        private void cboProjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {            
                Font defaultFont = cboProjects.Font;
                FontFamily family = cboProjects.Font.FontFamily;

                Rectangle rectangle = new Rectangle(0, e.Bounds.Top + 2,
                    e.Bounds.Height, e.Bounds.Height - 4);

                if (e.Index == -1)
                {
                    Font fn = new Font(family, defaultFont.Size, FontStyle.Italic);
                    e.Graphics.DrawString(strings.ImportAddFolder, fn, Brushes.Gray,
                        new RectangleF(e.Bounds.X , e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                }
                else
                {
                    Font fn = new Font(family, defaultFont.Size, FontStyle.Regular);
                    Project project = (Project) cboProjects.Items[e.Index];
                    e.Graphics.DrawString(project.Name, fn, Brushes.Black,
                        new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                
                    var size = e.Graphics.MeasureString(project.Name, fn);
                    size.Width += 15;
                    Font fn1 = new Font(family, defaultFont.Size, FontStyle.Italic);
                    if (project.Validating)
                    {
                        e.Graphics.DrawString(strings.ProjectValidating, fn1, Brushes.Gray,
                            new RectangleF(e.Bounds.X + size.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                    }
                    else
                    {
                        if (project.Valid)
                        {
                            e.Graphics.DrawString(string.Format(strings.ProjectValidated, project.Components.Count()), fn1, Brushes.Gray,
                                new RectangleF(e.Bounds.X + size.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                        }
                        else
                        {
                            e.Graphics.DrawString(strings.ProjectInvalid,  fn1, Brushes.Gray,
                                new RectangleF(e.Bounds.X + size.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                        }
                    }            
                }
            }
            finally{} // swallow any error here            
        }

#endregion


        public Project SelectedProject
        {
            get
            {
                if (cboProjects.DataSource == null) return null;
                return (Project) cboProjects.SelectedItem;
            }
            set
            {
                if (value == null)
                {
                    cboProjects.SelectedIndex = -1;
                    return;
                }
                cboProjects.SelectedItem = value;
                lblSelectedProjectPath.Text = string.Format("({0})", value.Path);
                AddComponent(value.Components);
            }
        }

        public string ProjectName
        {
            get { return txtActiveProject.Text; }
            set { txtActiveProject.Text = value; }
        }

        public IList<Project> Projects
        {
            get { return _projects; }
            set
            {
                _doNotRunEvents = true;
                try
                {
                    if (cboProjects.DataSource == null) cboProjects.Items.Clear();
                    _projects = value;
                    cboProjects.DataSource = null;
                    cboProjects.DataSource = value;
                    cboProjects.DisplayMember = "Name";
                    cboProjects.DisplayMember = "Path";
                }
                finally
                {
                    _doNotRunEvents = false;
                }
            }
        }

        public IEnumerable<Component> SelectedItems
        {
            get { return Business.TreeViewHelper.GetCheckedNodes(tw, null); }       
        }

        public DialogResult ShowView()
        {
            return ShowDialog();
        }

        public void CloseForm()
        {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (PathSelecting != null) PathSelecting(null, null);
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_doNotRunEvents) return;
            lblSelectedProjectPath.Text = null;
            if (cboProjects.DataSource == null) return;
            ComponentsAdded(false);
            if (cboProjects.SelectedIndex == -1) return;

            Project project = (Project)cboProjects.Items[cboProjects.SelectedIndex];
            lblSelectedProjectPath.Text = string.Format("({0})", project.Path);
            if (project.Components == null) return;
            
            AddComponent(project.Components);
            ComponentsAdded(true);
        }

        private void ComponentsAdded(bool hasItems)
        {
            btnImport.Enabled = hasItems;
        }

        private void AddComponent(IEnumerable<Component> components )        
        {            
            tw.Nodes.Clear();
            _counter = 0;            
            if (components == null)
            {
                _panel.Nodes = null;
                return;
            }

            _panel.ProjectComponets = components;
            _counter = TreeViewHelper.AddComponents(tw, components);
                        
            lblItems.Text = string.Format(strings.NumberOfComponentsPlusSelected, _counter, _counter);
            Business.TreeViewHelper.CheckAllNodes(tw, null);
            _panel.Nodes = tw.Nodes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectedItems.Any())
                {
                    MessageBox.Show(strings.ImportNoItemSelected,
                        strings.ImportFormMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                int numofChecked = SelectedItems.Count();
                string confirmMessage = string.Format(strings.ExportConfirmation,
                    numofChecked, numofChecked == 1 ? strings.Item : strings.Items);

                DialogResult answer = MessageBox.Show(
                    confirmMessage,
                    strings.ImportFormMessageCaption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.No) return;

                ImportEventArgs args = new ImportEventArgs()
                {
                    ProjectName = txtActiveProject.Text,
                    Override = chbOverride.Checked,
                    SelectedComponents = SelectedItems
                };
                if (ImportRequestedRaised != null) ImportRequestedRaised(this, args);
                if (args.Cancel) return;
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
       
    }
}
