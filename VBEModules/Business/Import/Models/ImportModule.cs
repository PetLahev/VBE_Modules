using Microsoft.Vbe.Interop;

namespace VbeComponents.Business.Import.Models
{
    /// <summary>Imports standard module</summary>
    public class ImportModule : IImportType
    {
        /// <summary>
        /// Imports standard module to the active VB project.
        /// If already exists, VBE will generate unique name automatically
        /// </summary>
        /// <param name="vbe">a reference to the VBE</param>
        /// <param name="item">a form to be imported</param>
        /// <param name="shouldOverride">true if the component should be overridden</param>
        public virtual void Import(Microsoft.Vbe.Interop.VBE vbe, Component item, bool shouldOverride)
        {            
            VBProject vbProject = vbe.ActiveVBProject;
            vbProject.VBComponents.Import(item.FullPath);
        }
    }
}
