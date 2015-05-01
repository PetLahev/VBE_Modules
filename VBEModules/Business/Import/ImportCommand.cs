using System;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Configurations;
using VbeComponents.Business.Import.Views;

namespace VbeComponents.Business.Import
{
    class ImportCommand : ICommand
    {
        private VBE _vbe;
        private ConfigurationBase _config = null;

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
            view.ShowDialog();
        }
    }
}
