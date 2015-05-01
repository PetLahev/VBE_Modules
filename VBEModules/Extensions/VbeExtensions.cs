using System;
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
        /// Returns all components from active VB project
        /// </summary>
        /// <param name="vbe">instance of he VBE editor</param>
        /// <returns>collection of all components from the given project</returns>
        public static IEnumerable<VBComponent> GetComponents(this VBE vbe)
        {
            return vbe.ActiveVBProject.VBComponents.Cast<VBComponent>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetExtension(vbext_ComponentType type)
        {
            switch (type)
            {
                case vbext_ComponentType.vbext_ct_StdModule:
                    return ".bas";
                    break;
                case vbext_ComponentType.vbext_ct_ClassModule:
                    return ".cls";
                    break;
                case vbext_ComponentType.vbext_ct_MSForm:
                    return ".frm";
                    break;
                case vbext_ComponentType.vbext_ct_ActiveXDesigner:
                    throw new ArgumentOutOfRangeException("type");
                    break;
                case vbext_ComponentType.vbext_ct_Document:
                    return ".cls";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

    }
}