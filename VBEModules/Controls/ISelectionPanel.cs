using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace VbeComponents.Controls
{
    enum SelectionPanelOptions
    {
        Unknown = 0,
        All,
        Modules,
        Forms,
        Classes,
        Documents
    };

    public interface ISelectionPanel
    {
        /// <summary> Sets the available components in active project </summary>
        IEnumerable<Business.Component> ProjectComponets { set; }
        /// <summary> Sets/Gets tree nodes collection to be able change its checked property on view </summary>
        TreeNodeCollection Nodes { get; set; }
        /// <summary> Sets the initial state of all available options </summary>
        bool InitialState { set; }
        /// <summary> Occurs when user click on a selection option  </summary>
        event EventHandler<Events.SelectionEventArgs> SelectionChanged;
    }
}
