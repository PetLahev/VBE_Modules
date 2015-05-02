using System;
using System.Collections.Generic;

namespace VbeComponents.Events
{
    public delegate void ImportEventHandler(object sender, ImportEventArgs e);

    public class ImportEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public IEnumerable<Business.Component> SelectedComponents { get; set; }
        public string ProjectName { get; set; }
        public string Path { get; set; }
    }
}
