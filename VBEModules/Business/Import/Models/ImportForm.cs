using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Vbe.Interop;
using System.IO;

namespace VbeComponents.Business.Import.Models
{
    /// <summary>Imports user form</summary>
    public class ImportForm :IImportType
    {
        /// <summary>
        /// Imports form to active project with additional checks.
        /// Forms will not get unique name from VBE (as it's done for classes or modules)
        /// If user wants to add a form which already exists, an exception occurs.
        /// The form needs to be copied and renamed the attributes inside the frm file and the
        /// frx file needs to be renamed
        /// </summary>
        /// <param name="vbe">a reference to the VBE</param>
        /// <param name="item">a form to be imported</param>
        /// <param name="shouldOverride">true if the component should be overridden</param>
        public void Import(VBE vbe, Component item, bool shouldOverride)
        {
            VBProject vbProject = vbe.ActiveVBProject;
            bool isInProject  = Extensions.VbeExtensions.HasCodeModule(vbe, item.ToString());
                        
            if (isInProject) item = CopyAndRename(item);            
            vbProject.VBComponents.Import(item.FullPath);            
        }

        /// <summary>
        /// Copies the frm file to temporary location and renames all occurrences of the
        /// filename (without extension) to a new unique name. 
        /// Then copies the frx file with the new name to temporary location as well
        /// </summary>
        /// <param name="item">a component to be copied</param>
        /// <returns>newly created component</returns>
        private Component CopyAndRename(Component item)
        {
            File.Copy(item.FullPath, Path.Combine(Path.GetTempPath(), item.Name), true);
            
            string newName = string.Format("{0}_{1}",item.ToString(), GetNowAsSafeString());
            ReplaceString(Path.Combine(Path.GetTempPath(), item.Name), item.ToString(), newName);

            string frxNewName = Path.Combine(Path.GetTempPath(), string.Format("{0}.frx", newName));
            File.Copy(Path.Combine(item.Path, item.ToString() + ".frx"), frxNewName, true);            
            
            Component retVal = new Component() { Name = item.Name, Path = Path.GetTempPath(), Type = item.Type, Content = item.Content };
            return retVal;
        }
        
        /// <summary>Gets date and time in safe string for name </summary>        
        private string GetNowAsSafeString()
        {
            StringBuilder str = new StringBuilder(DateTime.Now.ToString("s"));
            str.Replace(".", "_");
            str.Replace("/", "_");
            str.Replace(" ", "_");
            str.Replace(":", "_");
            str.Replace("-", "_");
            return str.ToString();
        }

        /// <summary>
        /// Replaces the given text. The files should be fairly small, 
        /// probably never more than a few MB so I hope this will not cause any issue
        /// </summary>
        /// <param name="frmPath"></param>
        /// <param name="findText"></param>
        /// <param name="replaceText"></param>
        private void ReplaceString(string frmPath, string findText, string replaceText)
        {
            string text = File.ReadAllText(frmPath);
            text = text.Replace(findText, replaceText);
            File.WriteAllText(frmPath, text);
        }

    }
}
