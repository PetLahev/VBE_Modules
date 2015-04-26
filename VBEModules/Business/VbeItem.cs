using System.Runtime.InteropServices;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Business
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
