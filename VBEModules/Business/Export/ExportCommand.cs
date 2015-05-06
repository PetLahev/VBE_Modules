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
        private ConfigurationBase _config = null;

        /// <summary>Initializes internal properties</summary>
        /// <param name="vbe">instance of the VBE</param>
        public ExportCommand(VBE vbe)
        {
            _vbe = vbe;
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
            _model = new ExportModel(_vbe, _vbe.ActiveVBProject.Name);
            _model.PathSelected += new EventHandler(_model_PathSelected);

            _view = ExportView;
            _view.PathSelecting += new Events.ExportEventHandler(_view_PathSelecting);
            _view.ExportRequestedRaised += new Events.ExportEventHandler(_view_ExportRequestedRaised);
            _view.PathValidating += new Events.ExportEventHandler(_view_PathValidating);

            _model.GetProjectPath(_config);
            _view.ProjectName = _vbe.ActiveVBProject.Name;
            _view.Items = _vbe.GetComponents();
            _view.ShowView();

            // due to using the ExportView getter, we need to dispose the view object to unsubscribe all events
            _view.CloseForm();
            _view = null;
        }

        /// <summary>
        /// Raised when user is about to use a selected path.
        /// Will perform a validation if the path is still valid
        ///  </summary>
        void _view_PathValidating(object sender, Events.ExportEventArgs e)
        {
            e.Cancel = _config.Exists(e.Path);
        }

        /// <summary>Raise when user has request a path change </summary>
        void _view_PathSelecting(object sender, Events.ExportEventArgs e)
        {
            _model.PathRequestHandler();
        }

        private void _view_ExportRequestedRaised(object sender, Events.ExportEventArgs e)
        {
            if (e == null) return;
            _model.ExportComponents(e, _config);
        }

        private void _model_PathSelected(object sender, EventArgs e)
        {
            _view.Path = (string)sender;
        }

        public void Dispose()
        {
            
        }

    }
}
