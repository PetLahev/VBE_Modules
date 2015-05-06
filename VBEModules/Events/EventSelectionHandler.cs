using System;

namespace VbeComponents.Events
{
    public delegate void SelectionChangedHandler (object sender, EventSelectionEventArgs e); 

    public class EventSelectionEventArgs : EventArgs
    {
        public bool CheckedState { get; set; }
    }
}
