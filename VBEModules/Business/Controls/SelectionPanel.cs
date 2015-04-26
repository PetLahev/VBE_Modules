using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Microsoft.Vbe.Interop;
using System.Windows.Forms;

namespace VbeComponents.Business.Controls 
{
    public partial class SelectionPanel : UserControl, ISelectionPanel
    {
        public event EventHandler SelectionChanged;
        public SelectionPanel()
        {
            InitializeComponent();
        }

        public IEnumerable<_VBComponent> ProjectComponets
        {
            set
            {
                if (value == null) throw new ArgumentNullException(message:"Are you crazy? Why do you want to export empty project, it's not even possible!", innerException: null);

                lblAll.Enabled = true;
                var module = value.Cast<VBComponent>().FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_StdModule);
                ManageState(this.lblModules, module);

                var form = value.Cast<VBComponent>().FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_MSForm);
                ManageState(this.lblForms, form);

                var aClass = value.Cast<VBComponent>().FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_ClassModule);
                ManageState(this.lblClasses, aClass);

                var doc = value.Cast<VBComponent>().FirstOrDefault(x => x.Type == vbext_ComponentType.vbext_ct_Document);
                ManageState(this.lblDocs, doc);

            }
        }

        private void ManageState(Label lbl,  VBComponent component)
        {
            lbl.Enabled = component != null;
            lbl.Font = lbl.Enabled ? new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold | FontStyle.Underline ) : new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }

        private void lblAll_Click(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(SelectionPanelOptions.All, new EventArgs());
        }

        private void lblModules_Click(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(SelectionPanelOptions.Modules, new EventArgs());
        }

        private void lblForms_Click(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(SelectionPanelOptions.Forms, new EventArgs());
        }

        private void lblClasses_Click(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(SelectionPanelOptions.Classes, new EventArgs());
        }

        private void lblDocs_Click(object sender, EventArgs e)
        {
            if (SelectionChanged != null) SelectionChanged(SelectionPanelOptions.Documents, new EventArgs());
        }

    }
}
