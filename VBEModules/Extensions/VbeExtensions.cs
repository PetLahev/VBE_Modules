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
        public static IEnumerable<CodeModule> FindCodeModules(this VBE vbe, string componentName)
        {
            var matches = 
                vbe.ActiveVBProject.VBComponents.Cast<VBComponent>()                              
                              .Where(component => component.Name == componentName)
                              .Select(component => component.CodeModule);
            return matches;
        }

        /// <summary>
        /// Checks if active project contains a component with given name
        /// </summary>
        /// <param name="vbe"></param>
        /// <param name="componentName">a name of component to check</param>
        /// <returns></returns>
        public static bool HasCodeModule(this VBE vbe, string componentName)
        {
            var hasAny =
                vbe.ActiveVBProject.VBComponents.Cast<VBComponent>()
                              .Any(component => component.Name == componentName);
            return hasAny;
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
        /// Returns all components from active VB project converted to business Component object
        /// </summary>
        /// <param name="vbe">instance of he VBE editor</param>
        /// <returns>collection of all components from the given project</returns>
        public static IEnumerable<Business.Component> GetAsComponents(this VBE vbe)
        {
            var vbComps = vbe.ActiveVBProject.VBComponents.Cast<VBComponent>();
            var tmp = vbComps.ToList().ConvertAll(x => new Business.Component(x));
            tmp.ForEach(x => x.Content = GetComponentText(vbe, x.Name));
            return tmp;
        }

        /// <summary>
        /// Gets the whole code of given component
        /// </summary>
        /// <param name="vbe"></param>
        /// <param name="componentName">a name of component to get text from</param>
        /// <returns>code of the component</returns>
        public static string GetComponentText(this VBE vbe, string componentName)
        {
            var module = vbe.ActiveVBProject.VBComponents.Cast<VBComponent>()
                                 .FirstOrDefault(component => component.Name == componentName);
            string retVal = null;
            if (module.CodeModule.CountOfLines > 0)
            {
                retVal = module.CodeModule.get_Lines(1, module.CodeModule.CountOfLines);
            }
            return retVal;
        }


        /// <summary>
        /// Checks if given component exists, if so, will remove it from the project
        /// If the component is document type, will just clear all lines
        /// </summary>
        /// <param name="vbe"></param>
        /// <param name="componentName">name of the component to be removed</param>
        public static void RemoveComponent(this VBE vbe, string componentName)
        {
            if (string.IsNullOrWhiteSpace(componentName)) return;
            string name = componentName;
            if (name.Contains("."))
            {
                name = componentName.Substring(0, componentName.IndexOf(".", StringComparison.Ordinal));
            }

            var component = vbe.ActiveVBProject.VBComponents.Cast<VBComponent>().FirstOrDefault(x => x.Name == name);
            if (component == null) return;

            if (component.Type != vbext_ComponentType.vbext_ct_Document)
                vbe.ActiveVBProject.VBComponents.Remove(component);
            else
            {
                if (component.CodeModule.CountOfLines > 0)
                {
                    component.CodeModule.DeleteLines(1, component.CodeModule.CountOfLines);                    
                }
            }                
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
                case vbext_ComponentType.vbext_ct_ClassModule:
                    return ".cls";                    
                case vbext_ComponentType.vbext_ct_MSForm:
                    return ".frm";                    
                case vbext_ComponentType.vbext_ct_ActiveXDesigner:
                    throw new ArgumentOutOfRangeException("type");                    
                case vbext_ComponentType.vbext_ct_Document:
                    return ".cls";                    
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

    }
}