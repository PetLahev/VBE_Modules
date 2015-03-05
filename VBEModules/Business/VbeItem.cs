using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using VBEModules.Interop.VBAExtensibility;

namespace VBEModules.Business
{
    /// <summary>Provides common functionality for VBE component </summary>
    [ComVisible(false)]
    public class VbeComponent
    {
        public vbext_ComponentType Type { get; set; }
        public string Name { get; set; }
        public object Tag { get; set; }
    }
}
