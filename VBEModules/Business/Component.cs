using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Business
{
    public class Component
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string FullPath { get { return System.IO.Path.Combine(this.Path, this.Name); } }
        public vbext_ComponentType Type { get; set; }
    }
}
