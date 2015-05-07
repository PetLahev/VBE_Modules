using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Microsoft.Vbe.Interop;
using System.Windows.Forms;
using VbeComponents.Business;
using VbeComponents.Resources;

namespace VbeComponents.Controls
{
    public partial class SelectionPanel : UserControl, ISelectionPanel, IDisposable
    {
        private static Font _fnUnderlined = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold | FontStyle.Underline);
        private static Font _fnBold = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
        private bool _initialized = false;

        public event EventHandler<Events.SelectionEventArgs>  SelectionChanged;
       
        public SelectionPanel()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Not too OOP but it will save significant amount of code on implementing views
        /// If you don't want to use it, set it to null and subscribe for the SelectionChanged event
        /// </summary>
        public TreeNodeCollection Nodes { get; set; }

        public bool InitialState
        {
            set
            {
                if (!_initialized) return;
                Business.Component fakeForSetting = value ? new Business.Component() : null;
                ManageState(lblAll, fakeForSetting, value);
                ManageState(lblModules, fakeForSetting, value);
                ManageState(lblForms, fakeForSetting, value);
                ManageState(lblClasses, fakeForSetting, value);
                ManageState(lblDocs, fakeForSetting, value);
            }
        }

        public IEnumerable<Business.Component> ProjectComponets
        {
            set
            {
                _initialized = false;
                if (value == null) throw new ArgumentNullException(message: strings.ExceptionNoComponents, innerException: null);

                lblAll.Enabled = true;
                lblAll.Tag = false;
                var module = value.FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_StdModule);
                ManageState(this.lblModules, module, module != null);

                var form = value.FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_MSForm);
                ManageState(this.lblForms, form, form != null);

                var aClass = value.FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_ClassModule);
                ManageState(this.lblClasses, aClass, aClass != null);

                var doc = value.FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_Document);
                ManageState(this.lblDocs, doc, doc != null);
                _initialized = true;
            }
        }

        /// <summary>
        /// Sets the accessibility of given label and according to given state
        /// will set a font. The inversion of given state is saved to the Tag property
        /// to be able perform action when user click on a label again. Will work like a switcher
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="component"></param>
        /// <param name="state"></param>
        private void ManageState(Label lbl, Business.Component component, bool state)
        {
            lbl.Enabled = component != null;
            lbl.Font = state ? _fnUnderlined : _fnBold;
            lbl.Tag = !state; // this flag will be sent to listener and it's like switcher
        }

        private void Clicked(Label lbl, SelectionPanelOptions option)
        {
            if (option == SelectionPanelOptions.Unknown) return;
            bool state = (bool)lbl.Tag;
            if (Nodes != null)
            {
                if (option != SelectionPanelOptions.All)
                {
                    ChangeCheckedStateOfNodes(GetComponentType(option), state);
                }
                else
                {
                    ChangeCheckedStateOfNodes(GetComponentType(SelectionPanelOptions.Modules), state);
                    ChangeCheckedStateOfNodes(GetComponentType(SelectionPanelOptions.Classes), state);
                    ChangeCheckedStateOfNodes(GetComponentType(SelectionPanelOptions.Forms), state);
                    ChangeCheckedStateOfNodes(GetComponentType(SelectionPanelOptions.Documents), state);
                }
            }
            
            if (SelectionChanged != null)
            {
                SelectionChanged(option,
                      new Events.SelectionEventArgs() { CheckedState = state });
            }
            ManageState(lbl, new Business.Component(), state);
        }
        
        private vbext_ComponentType GetComponentType(SelectionPanelOptions option)
        {
            switch (option)
            {   
                case SelectionPanelOptions.Modules: return vbext_ComponentType.vbext_ct_StdModule;                    
                case SelectionPanelOptions.Forms: return vbext_ComponentType.vbext_ct_MSForm;                    
                case SelectionPanelOptions.Classes: return vbext_ComponentType.vbext_ct_ClassModule;                    
                case SelectionPanelOptions.Documents: return vbext_ComponentType.vbext_ct_Document;
                // we don't care about these, needs to be handled in calling method
                case SelectionPanelOptions.All: 
                case SelectionPanelOptions.Unknown:                    
                default:
                    throw new ArgumentOutOfRangeException(string.Format(strings.ComponentTypeCannotBeConverted, option.ToString()));
            }
        }

        private void ChangeCheckedStateOfNodes(vbext_ComponentType type, bool state)
        {
            foreach (TreeNode nd in Nodes)
            {                
                Business.Component item = (Business.Component)nd.FirstNode.Tag;
                if (item.Type == type)
                {
                    nd.Checked = state;
                    CheckChildren(nd, state);
                }
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

#region Labels events

        private void lblAll_Click(object sender, EventArgs e)
        {
            Clicked((Label)sender, SelectionPanelOptions.All);
        }

        private void lblModules_Click(object sender, EventArgs e)
        {
            Clicked((Label)sender, SelectionPanelOptions.Modules);
        }

        private void lblForms_Click(object sender, EventArgs e)
        {
            Clicked((Label)sender, SelectionPanelOptions.Forms);
        }

        private void lblClasses_Click(object sender, EventArgs e)
        {
            Clicked((Label)sender, SelectionPanelOptions.Classes);
        }

        private void lblDocs_Click(object sender, EventArgs e)
        {
            Clicked((Label)sender, SelectionPanelOptions.Documents);
        }

        #endregion

    }
}
