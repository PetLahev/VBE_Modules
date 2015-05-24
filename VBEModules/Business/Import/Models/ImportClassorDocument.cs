using System.Collections.Generic;
using System.Linq;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Business.Import.Models
{
    /// <summary>Imports either class or as document type</summary>
    public class ImportClassorDocument : IImportType
    {
        /// <summary>
        /// Performs additional checks before importing.
        /// Checks if given component name can be found in active project. If so, will check
        /// its type and if the type is a document type, it will insert text inside the component 
        /// instead of importing it. If the component is recognized as a class, will import it standard way.
        /// </summary>
        /// <param name="vbe">a reference to the VBE</param>
        /// <param name="item">a form to be imported</param>
        /// <param name="shouldOverride">true if the component should be overridden</param>
        public void Import(VBE vbe, Component item, bool shouldOverride)
        {
            VBProject vbProject = vbe.ActiveVBProject;
            IEnumerable<CodeModule> module = Extensions.VbeExtensions.FindCodeModules(vbe, item.ToString());
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
    }
}
