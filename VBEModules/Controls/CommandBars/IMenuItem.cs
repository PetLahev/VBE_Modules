using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VbeComponents.Controls.CommandBars
{
    /// <summary>
    /// Defines interface for a menu item
    /// </summary>
    public interface IMenuItem
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        int IconId { get; set; }
        System.Drawing.Image Image { get; set; }
        double Order { get; set; }
        bool HasSeparator { get; set; }
        Business.ICommand Command { get; set; }
    }
}
