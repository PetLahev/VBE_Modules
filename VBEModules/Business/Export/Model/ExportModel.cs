using Microsoft.Vbe.Interop;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace VbeComponents.Business.Export.Model
{
    [ ComVisible(false) ]
    public class ExportModel
    {
        public IEnumerable<CodeModule> GetComponents(string projectName)
        {
            return new List<CodeModule>();   
        }

    }
}
