using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Vbe.Interop;
using VbeComponents.Events;

namespace VbeComponents.Business.Export
{
    /// <summary>Defines functions for the Export view </summary>
    [ComVisible(false)]
    public interface IExport
    {
        /// <summary>Sets/Gets a path where to export selected items </summary>
        string Path {get; set;}

        /// <summary>Sets/Gets the active project name </summary>
        string ProjectName { get; set; }

        /// <summary>Sets/Gets all available items (classes, modules, forms) that can be exported </summary>
        IEnumerable<Business.Component> Items { get; set; }

        /// <summary>Sets/Gets items that are select for export </summary>
        IEnumerable<Business.Component> SelectedItems { get; set; }

        /// <summary>Shows up the view and returns how the view was closed</summary>
        DialogResult ShowView();

        /// <summary>Closes the view </summary>
        void CloseForm();

        /// <summary>Occurs when a path initialization/change is requested</summary>
        event ExportEventHandler PathSelecting;

        /// <summary>Occurs when a path is going to be used and should be validated</summary>
        event ExportEventHandler PathValidating;

        /// <summary>Occurs when components should be exported</summary>
        event ExportEventHandler ExportRequestedRaised;

    }
}
