using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.Vbe.Interop;

namespace VbeComponents.Business.Controls
{
    enum SelectionPanelOptions
    {
        All,
        Modules,
        Forms,
        Classes,
        Documents
    };

    public interface ISelectionPanel
    {
        /// <summary> Sets the available components in active project </summary>
        IEnumerable<_VBComponent> ProjectComponets { set; }
        /// <summary> Occurs when user click on a selection option  </summary>
        event EventHandler SelectionChanged;
    }
}
