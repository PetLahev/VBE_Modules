using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Vbe.Interop;
using VbeComponents.Resources;

namespace VbeComponents.Business.Import.Models
{
    public class ImportModel
    {
        private VBE _vbe;
        private string _projectName;
        private IEnumerable<Component> _components = null;

        public event EventHandler ValidPathSelected;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vbe">a reference to VBE</param>
        /// <param name="projectName"></param>
        public ImportModel(VBE vbe, string projectName)
        {
            _vbe = vbe;
            _projectName = projectName;
        }

        public List<Component> Components
        {
            get { return _components == null ? null : _components.ToList(); }
        }

        /// <summary>
        /// Displays folder browser dialog and let user to choose a path to a folder.
        /// Raises event if a path was chosen
        ///  </summary>
        public void PathRequestHandler()
        {
            var selectedPath = Utils.DisplayFolderDialog();
            if (selectedPath == null) return;
            if (!Utils.HasComponent(selectedPath))
            {
                MessageBox.Show(strings.InvalidComponentFolder, strings.ImportFormMessageCaption, MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                _components = Utils.GetComponents(selectedPath);
                if (ValidPathSelected != null) ValidPathSelected(null, null);
            }
        }


    }
}
