using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Vbe.Interop;
using System.Runtime.InteropServices;
using VbeComponents.Business.Configurations;
using System.Windows.Forms;
using VbeComponents.Resources;
using System.IO;
using VbeComponents.Extensions;

namespace VbeComponents.Business.Export.Model
{
    [ ComVisible(false) ]
    public class ExportModel
    {
        private readonly VBE _vbe;
        private readonly string _projectName;
        
        /// <summary>Occurs when user has chosen a path to a folder </summary>
        public event EventHandler PathSelected;

        /// <summary>Initializes internal properties </summary>
        /// <param name="vbe">an instance of the VBE editor</param>
        /// <param name="projectName">a name of active VBA project</param>
        public ExportModel(VBE vbe, string projectName)
        {
            _vbe = vbe;
            _projectName = projectName;
        }

        /// <summary>
        /// Exports components to specified path and updates configuration file
        /// </summary>
        /// <param name="args">info about specified path, selected components etc. </param>
        /// <param name="config">a reference to a configuration file</param>
        /// <returns></returns>
        public virtual bool ExportComponents(Events.ExportEventArgs args, Configurations.ConfigurationBase config )
        {
            try
            {
                List<_VBComponent> comps = args.SelectedComponents.ToList();
                foreach (var component in comps)
                {
                    string fullPath = Path.Combine(args.Path, component.Name + VbeExtensions.GetExtension(component.Type));
                    if (component.Type == vbext_ComponentType.vbext_ct_Document)
                    {
                        var text = component.CodeModule.get_Lines(1, component.CodeModule.CountOfLines);
                        File.WriteAllText(fullPath, text);
                    }
                    else
                    {
                        component.Export(fullPath);
                    }
                }
                config.SaveProject(_projectName, args.Path);
                return true;
            }
            catch (COMException comEx)
            {
                throw new COMException(string.Format(strings.ExportComExceptionText, comEx.ErrorCode), comEx.ErrorCode);
            }
        }
       
        /// <summary>
        /// Gets path of an active VB project and verifies if the path is valid.
        /// If so, will raise the PathSelected event to listeners
        /// </summary>
        /// <param name="config">an instance of the configuration file to use for getting path</param>
        /// <returns>True if a path is valid, otherwise false</returns>
        public bool GetProjectPath(ConfigurationBase config )
        {
            if (config == null) throw new ArgumentNullException(strings.ConfigIsNull);
            string projectPath =  config.GetProjectPath(_projectName);
            if (string.IsNullOrWhiteSpace(projectPath)) return false;
            if (config.Exists(projectPath))
            {
                if (PathSelected != null) PathSelected(projectPath, null);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Displays folder browser dialog and let user to choose a path to a folder.
        /// Raises event if a path was chosen
        ///  </summary>
        public void PathRequestHandler()
        {
            var retVal = Utils.DisplayFolderDialog();
            if (retVal == null) return;
            if (PathSelected != null) PathSelected(retVal, null);
        }

    }
}
