using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Business
{
    /// <summary>
    /// Encapsulates information about a VB component
    /// </summary>
    public class Component
    {
        public Component() {}
        /// <summary>
        /// Converts given VBComponent to the internal Component object that is used across application
        /// </summary>
        /// <param name="component">a VB component to be converted</param>
        public Component(Microsoft.Vbe.Interop._VBComponent component)
        {
            Name = component.Name;
            Type = component.Type;
            VbComponent = component;
        }

        /// <summary>Sets/Gets name of the component</summary>
        public string Name { get; set; }
        /// <summary>Sets/Gets path of the component</summary>
        public string Path { get; set; }
        /// <summary>Gets full path of the component</summary>
        public string FullPath { get { return System.IO.Path.Combine(this.Path, this.Name); } }
        /// <summary>Sets/Gets the content of the component</summary>
        public string Content { get; set; }
        /// <summary>Sets/Gets type of the component</summary>
        public vbext_ComponentType Type { get; set; }
        /// <summary>Sets/Gets a reference to the actual component </summary>
        public Microsoft.Vbe.Interop._VBComponent VbComponent { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Name)) return base.ToString();
            int comma = Name.LastIndexOf(".");
            return comma > 0 ? Name.Substring(0, comma) : Name;
        }
    }
}
