using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Configurations;
using VbeComponents.Events;
using VbeComponents.Extensions;
using VbeComponents.Resources;

namespace VbeComponents.Business.Import.Models
{
    /// <summary>
    /// Business logic for import components to a project
    /// </summary>
    public class ImportModel
    {
        private VBE _vbe;
        private string _projectName;
        private Configurations.ConfigurationBase _config;
        private IEnumerable<Component> _components = null;
        private IList<Project> _projects = null; 

        /// <summary>Occurs when a valid project is added to list of Projects </summary>
        public event EventHandler ValidProjectAdded;
        /// <summary>Occurs when a project is set as default </summary>
        public event EventHandler CurrentProjectChanged;

        /// <summary>
        /// Initializes internal objects
        /// </summary>
        /// <param name="vbe">a reference to VBE</param>
        /// <param name="config">a reference to configuration file</param>
        /// <param name="projectName">a name of the active VBA project</param>
        public ImportModel(VBE vbe, ConfigurationBase config, string projectName)
        {
            _vbe = vbe;
            _config = config;
            _projectName = projectName;
        }

        /// <summary>
        /// Loads all projects from configuration file and validates them.
        /// Raises ValidProjectAdded event when all projects are loaded but not validated yet.
        /// Then validates each project, one by one and for each raises the same event with initialized properties
        /// </summary>
        /// <remarks>Todo: Make it run in separate task </remarks>
        public void LoadProjects()
        {
            IList<Project> projects = _config.GetProjects();
            if (projects == null) return;

            projects.ToList().ForEach(x => x.Validating = true);
            if (_projects == null) _projects = new List<Project>();
            _projects = projects;
            if (ValidProjectAdded != null) ValidProjectAdded(null, null);
            ValidateProjects();
        }
        
        /// <summary>
        /// Gets the list of components associated to a project
        /// </summary>
        public IList<Component> Components
        {
            get { return _components == null ? null : _components.ToList(); }
        }

        /// <summary>
        /// Gets a list of Projects available in configuration file or added manually by user
        /// </summary>
        public IList<Project> Projects
        {
            get { return _projects; }
        }
        
        /// <summary>
        /// Displays folder browser dialog and let user to choose a path to a folder.
        /// Raises event if a path was chosen
        ///  </summary>
        public void PathRequestHandler()
        {
            var selectedPath = Utils.DisplayFolderDialog(false);
            if (selectedPath == null) return;
            if (!Utils.HasComponent(selectedPath))
            {
                MessageBox.Show(strings.InvalidComponentFolder, strings.ImportFormMessageCaption, MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
            else
            {
                _components = Utils.GetComponents(selectedPath);
                Project project = null;
                // if manually added, check if already exists in list of projects
                // if not, save it to config and add it to list
                if (!HasProject(selectedPath))
                {
                    string projectName = System.IO.Path.GetFileName(selectedPath);
                    _config.SaveProject(projectName, selectedPath);
                    project = new Project() 
                        { Name = projectName, Path = selectedPath, Valid = true, Components = _components };
                    AddProject(project);
                }
                else
                {
                    project = Projects.First(x => x.Path == selectedPath);
                }

                if (ValidProjectAdded != null) ValidProjectAdded(null, null);
                if (CurrentProjectChanged != null) CurrentProjectChanged(project, null);
            }
        }

        /// <summary>
        /// Checks if given project already exists in list of Projects
        /// Compares the path of the Project
        /// </summary>
        /// <param name="project">a project to be checked</param>
        /// <returns>True if a project with the same path already exists, otherwise False</returns>
        public bool HasProject(Project project)
        {
            return project != null && HasProject(project.Path);
        }

        /// <summary>
        /// Checks if given path already exists in list of Projects
        /// </summary>
        /// <param name="path">a path of project to be checked</param>
        /// <returns>True if a project with the same path already exists, otherwise False</returns>
        public bool HasProject(string path)
        {
            if (Projects == null) return false;
            return  Projects.FirstOrDefault(x => x.Path == path) != null;
        }

        public Project SetDefaultProject(string activeProjectName)
        {
            Project retVal = null;

            if (string.IsNullOrWhiteSpace(activeProjectName)) return null;
            string activePath = _config.GetProjectPath(activeProjectName);
            if (!string.IsNullOrWhiteSpace(activePath))
            {
                retVal =  this.Projects.FirstOrDefault(x => x.Path == activePath);
            }
            return retVal;
        }

        /// <summary>
        /// Imports selected components to the active VB project
        /// Calls special method for handling document type components
        /// </summary>
        /// <param name="args">arguments with all necessary information from a view</param>
        /// <returns></returns>
        public bool ImportComponents(ImportEventArgs args)
        {
            try
            {
                VBProject vbProject = _vbe.ActiveVBProject;
                bool replace = args.Override;
                foreach (Component item in args.SelectedComponents)
                {
                    if (replace) _vbe.RemoveComponent(item.Name);
                    if ( !item.FullPath.EndsWith(".cls") || !replace )
                    {
                        if (item.FullPath.EndsWith(".frm") || !replace)
                        {
                            // forms will not get random name form VBE automatically
                            // so if we import the same name => exception
                            if (_vbe.HasCodeModule(item.ToString()))
                            {
                                var dupForm = vbProject.VBComponents.Add(vbext_ComponentType.vbext_ct_MSForm);                                
                                dupForm.Name = string.Format("{0}_{1}", item.ToString(), GetNowAsSafeString() );
                                dupForm.CodeModule.AddFromFile(item.FullPath);
                            }
                            else
                            {
                                vbProject.VBComponents.Import(item.FullPath);
                            }
                        }
                        else
                        {
                            vbProject.VBComponents.Import(item.FullPath);
                        }
                    }                   
                    else
                    {
                        HandleClassType(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, strings.ImportFormMessageCaption, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Handles importing class modules. The imported item can be either a normal class or a document type class (which cannot be determined before)
        /// It tries to find if the same name exist in the project and if so, will check if the same name is a document type, if so, will insert the code as text
        /// instead of inserting component. This code is called only if user wants to override existing components
        /// </summary>
        /// <param name="item">a component to be imported</param>
        private void HandleClassType(Component item)
        {
            VBProject vbProject = _vbe.ActiveVBProject;
            IEnumerable<CodeModule> module = _vbe.FindCodeModules(item.ToString());
            if (module == null || !module.ToArray().Any())
            {
                //the component name was not found in the active project, import it standard way
                vbProject.VBComponents.Import(item.FullPath);
            }
            else
            {
                if (module.ToArray()[0].Parent.Type == vbext_ComponentType.vbext_ct_ClassModule)
                {
                    // the item with the same name is not a document type => was replaced in calling method, we can import standard way
                    vbProject.VBComponents.Import(item.FullPath);
                }
                else
                {
                    // here is the interesting part, the imported item has the same name as one of the document type component
                    // user want's to replace it, which is not possible for that type, so we will copy text of the imported item
                    // to the module with the same name (its text was removed in calling method)
                    module.ToArray()[0].AddFromFile(item.FullPath);
                }
            }
        }
        
        private string GetNowAsSafeString()
        {
            StringBuilder str = new StringBuilder(DateTime.Now.ToString());
            str.Replace(".", "_");
            str.Replace("/", "_");
            str.Replace(" ", "_");
            str.Replace(":", "_");
            return str.ToString();
        }

        /// <summary>
        /// Adds given project to the internal collection of projects
        /// </summary>
        /// <param name="project">a project to be added</param>
        private void AddProject(Project project)
        {
            if (_projects == null) _projects = new List<Project>();
            _projects.Add(project);
        }

        /// <summary>
        /// Iterates through each projects and validates its path
        /// and components in the path. Raises ValidProjectAdded event for each project
        /// </summary>
        private void ValidateProjects()
        {
            if (Projects == null) return;

            foreach (Project project in Projects)
            {
                bool isValid =  Utils.PathExists(project.Path);
                if (isValid) isValid = Utils.HasComponent(project.Path);
                project.Validating = false;
                project.Valid = isValid;
                if (isValid) project.Components = Utils.GetComponents(project.Path);
                if (ValidProjectAdded != null) ValidProjectAdded(project, null);
            }
        }

    }
}
