using System;

namespace VbeComponents.Events
{
    public class SelectionEventArgs : EventArgs
    {
        /// <summary>Sets/Gets the checked of an item</summary>
        public bool CheckedState { get; set; }
    }
}
