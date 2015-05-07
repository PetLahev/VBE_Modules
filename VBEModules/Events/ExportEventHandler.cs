using System;
using System.Collections.Generic;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Events
{
    public delegate void ExportEventHandler(object sender, ExportEventArgs e);

    public class ExportEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public IEnumerable<Business.Component> SelectedComponents { get; set; }
        public string ProjectName { get; set; }
        public string Path { get; set; }
    }
}
