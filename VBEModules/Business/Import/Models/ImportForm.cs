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
                        
            if (isInProject)
            {
                System.Windows.Forms.MessageBox.Show("Could not import this form because it's already exists. Working on it, stay tuned");
            }
            else
            {
                vbProject.VBComponents.Import(item.FullPath);
            }
        }

        private Component CopyAndRename(Component item)
        {   
            string nowString = GetNowAsSafeString();
            string newName = string.Format("{0}_{1}.frm", item.ToString(), nowString);
            string frmNewName = Path.Combine(Path.GetTempPath(), newName);
            string frxNewName = Path.Combine(Path.GetTempPath(), string.Format("{0}_{1}.frx", item.ToString(), nowString)); 
                        
            File.Copy(item.FullPath, frmNewName, true);
            File.Copy(Path.Combine(item.Path, item.ToString() +".frx"), frxNewName, true);

            Component retVal = new Component() { Name = newName, Path = Path.GetTempPath(), Type = item.Type, Content = item.Content };
            return retVal;
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

    }
}
