using System;
using System.Linq;
using System.Windows;
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
        private IImport _view = null;
        private bool disposed = false;

        /// <summary>Initializes internal properties</summary>
        /// <param name="vbe">instance of the VBE</param>
        public ImportCommand(VBE vbe)
        {
            _vbe = vbe;
            _config = new ConfigurationXmlFile();
        }

        /// <summary>
        /// Sets/Gets an instance of the import view
        /// Handy for testing
        /// </summary>
        public IImport GetView
        {
            get { return _view ?? (_view = new ImportView()) ; }
            set { _view = value; }
        }

        public void Execute()
        {
            _model = new ImportModel(_vbe, _config, _vbe.ActiveVBProject.Name);
            _model.ValidProjectAdded += new EventHandler(ProjectsUpdated);
            _model.CurrentProjectChanged += new EventHandler(SetDefaultProject);

            _view = GetView;
            _view.PathSelecting += new Events.ImportEventHandler(view_PathSelecting);
            _view.ImportRequestedRaised += new Events.ImportEventHandler(ImportRequestedRaised);
            _view.ProjectName = _vbe.ActiveVBProject.Name;
            
            _model.LoadProjects();
            _view.SelectedProject = _model.SetDefaultProject(_vbe.ActiveVBProject.Name);
            _view.ShowView();

            // due to using the ImportView getter, we need to dispose the view object to unsubscribe all events
            _view.CloseForm();
            _view = null;

        }

        /// <summary>
        /// Imports components to the active VB project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">stores information about selected components, type of import etc.
        /// Supports cancellation</param>
        void ImportRequestedRaised(object sender, Events.ImportEventArgs e)
        {
            e.Cancel = !_model.ImportComponents(e);
        }

        /// <summary>
        /// Sets the default project on the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SetDefaultProject(object sender, EventArgs e)
        {
            if ((sender as Project) == null) return;
            _view.SelectedProject = (Project) sender;
        }

        /// <summary>
        /// Occurs when a project is updated by model
        /// All projects will be reload on the view with updated information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectsUpdated(object sender, EventArgs e)
        {
            _view.Projects = _model.Projects;
        }

        /// <summary>
        /// Occurs when user wants to add a new folder to import
        /// components from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void view_PathSelecting(object sender, Events.ImportEventArgs e)
        {
            _model.PathRequestHandler();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _config = null;
                    _model = null;
                    if (_view != null) _view.CloseForm();
                    _view = null;
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
