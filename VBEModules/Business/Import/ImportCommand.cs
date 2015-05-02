using System;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Configurations;
using VbeComponents.Business.Import.Models;
using VbeComponents.Business.Import.Views;

namespace VbeComponents.Business.Import
{
    class ImportCommand : ICommand
    {
        private VBE _vbe;
        private ConfigurationBase _config = null;
        private Models.ImportModel _model = null;

        /// <summary>Initializes internal properties</summary>
        /// <param name="vbe">instance of the VBE</param>
        public ImportCommand(VBE vbe)
        {
            _vbe = vbe;
            _config = new ConfigurationXmlFile();
        }

        public void Execute()
        {
            ImportView view = new ImportView();
            _model = new ImportModel(_vbe, _vbe.ActiveVBProject.Name);
            
            view.PathSelecting += new Events.ImportEventHandler(view_PathSelecting);
            
            view.ShowDialog();
        }

        void view_PathSelecting(object sender, Events.ImportEventArgs e)
        {
            _model.PathRequestHandler();
        }
    }
}
