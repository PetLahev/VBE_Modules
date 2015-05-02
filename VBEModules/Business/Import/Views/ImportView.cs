using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VbeComponents.Resources;

namespace VbeComponents.Business.Import.Views
{
    public partial class ImportView : Form, IImport
    {
        private Controls.ISelectionPanel _panel;

        public event Events.ImportEventHandler PathSelecting;
        public event Events.ImportEventHandler PathValidating;
        public event Events.ImportEventHandler ImportRequestedRaised;
        
        public ImportView()
        {
            InitializeComponent();
            _panel = this.selectionPanel1;
            cboProjects.Text = strings.ImportAddFolder;
        }

#region Drawing

        private void cboProjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font defaultFont = cboProjects.Font;
            FontFamily family = cboProjects.Font.FontFamily;

            Rectangle rectangle = new Rectangle(0, e.Bounds.Top + 2,
                e.Bounds.Height, e.Bounds.Height - 4);

            if (e.Index == -1)
            {
                Font fn = new Font(family, defaultFont.Size, FontStyle.Italic);
                e.Graphics.DrawString(strings.ImportAddFolder, fn, Brushes.Gray,
                    new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            }
        }

#endregion


        public string Path
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ProjectName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<string> Projects
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Component> Items
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Component> SelectedItems
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DialogResult ShowView()
        {
            throw new NotImplementedException();
        }

        public void CloseForm()
        {
            throw new NotImplementedException();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (PathSelecting != null) PathSelecting(null, null);
        }

    }
}
