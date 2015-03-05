using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VBEModules.Business.Export
{
    /// <summary>Defines functions for the Export view </summary>
    [ComVisible(false)]
    public interface IExport
    {
        /// <summary>Sets/Gets a path where to export selected items </summary>
        string Path {get; set;}

        /// <summary>Sets/Gets all available items (classes, modules, forms) that can be exported </summary>
        IList<VbeComponent> Items { get; set; }

        /// <summary>Sets/Gets items that are select for export </summary>
        IList<VbeComponent> SelectedItems { get; set; }

        /// <summary>Shows up the view and returns how the view was closed</summary>
        DialogResult ShowUI();

        /// <summary>Closes the view </summary>
        void CloseForm();

        /// <summary>Occurs when a path initialization/change is requested</summary>
        event EventHandler PathRequestHandler;

    }
}
