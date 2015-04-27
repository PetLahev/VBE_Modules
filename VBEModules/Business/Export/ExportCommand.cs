using System;
using System.Windows.Forms;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Configurations;
using VbeComponents.Business.Export.Model;
using VbeComponents.Business.Export.View;
using VbeComponents.Extensions;

namespace VbeComponents.Business.Export
{
    /// <summary>Provides functionality for Export feature - Command pattern. Acts like a presenter </summary>
    class ExportCommand : ICommand
    {
        private IExport _view;
        private VBE _vbe;
        private ExportModel _model = null;
        private Configurations.ConfigurationBase _config = null;

        /// <summary>Initializes internal properties</summary>
        /// <param name="vbe">instance of the VBE</param>
        public ExportCommand(VBE vbe)
        {
            _vbe = vbe;
            _model = new ExportModel(_vbe);
            _model.PathSelected += new EventHandler(_model_PathSelected);
            _config = new ConfigurationXmlFile();
        }

        /// <summary>
        /// Sets/Gets instance of the Export view that will be used
        /// </summary>
        public IExport ExportView
        {
            get { return _view ?? (_view = new ExportComponentsView()); }
            set { _view = value; }
        }

        /// <summary>
        /// Shows up the Export view to user
        /// </summary>
        public void Execute()
        {
            try
            {
                _view = ExportView;
                _view.PathSelecting += new EventHandler(PathRequestHandler);
                _view.ExportRequestedRaised += new Events.ExportEventHandler(_view_ExportRequestedRaised);
                _view.ProjectName = _vbe.ActiveVBProject.Name;
                _view.Path = _config.GetProjectPath(_vbe.ActiveVBProject.Name);
                _view.Items = _vbe.FindComponents(_vbe.ActiveVBProject.Name);
                _view.ShowView();
            }
            catch (Exception)
            {
                throw;
            }
        }

        void _view_ExportRequestedRaised(object sender, Events.ExportEventArgs e)
        {
            e.Cancel = true;
        }

        void _model_PathSelected(object sender, EventArgs e)
        {
            _view.Path =  (string)sender;
        }

        private void PathRequestHandler(object sender, EventArgs e)
        {
            _model.PathRequestHandler();
        }
    }
}
