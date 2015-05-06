using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VbeComponents.Events
{
    public delegate void SelectionChangedHandler (object sender, EventSelectionEventArgs e); 

    public class EventSelectionEventArgs : EventArgs
    {
        public bool CheckedState { get; set; }
    }
}
