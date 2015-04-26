using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Export.View;
using VbeComponents.Extensions;

namespace VbeComponents.Business.Export
{
    class ExportCommand : ICommand, IDisposable
    {
        private IExport _view;
        private VBE _vbe;

        public ExportCommand(VBE vbe)
        {
            _vbe = vbe;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            _view = new ExportComponentsView();
            _view.PathRequestHandler += new EventHandler(view_PathRequestHandler);
            _view.ProjectName = _vbe.ActiveVBProject.Name;
            _view.Items = _vbe.FindComponents(_vbe.ActiveVBProject.Name);
            _view.ShowView();
        }

        void view_PathRequestHandler(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog {ShowNewFolderButton = true};
            DialogResult result  = fbd.ShowDialog();

            if (result == DialogResult.Cancel) return;
            _view.Path = fbd.SelectedPath;
        }
    }
}
