using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Extensions
{
    [ComVisible(false)]
    public static class VbeExtensions
    {
        /// <summary>
        /// Finds all code modules that match the specified project and component names.
        /// </summary>
        /// <param name="vbe"></param>
        /// <param name="projectName"></param>
        /// <param name="componentName"></param>
        /// <returns></returns>
        public static IEnumerable<CodeModule> FindCodeModules(this VBE vbe, string projectName, string componentName)
        {
            var matches = 
                vbe.VBProjects.Cast<VBProject>()
                              .Where(project => project.Name == projectName)
                              .SelectMany(project => project.VBComponents.Cast<VBComponent>()
                                                                         .Where(component => component.Name == componentName))
                              .Select(component => component.CodeModule);
            return matches;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vbe"></param>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public static IEnumerable<VBComponent> FindComponents(this VBE vbe, string projectName)
        {
            var matches =
                vbe.VBProjects.Cast<VBProject>()
                    .Where(project => project.Name == projectName)
                    .SelectMany(project => project.VBComponents.Cast<VBComponent>());
                              
            return matches;
        }

    }
}