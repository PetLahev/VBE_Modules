using System.Collections.Generic;
using System.Windows.Forms;
using VbeComponents.Events;

namespace VbeComponents.Business.Import
{
    public interface IImport
    {
        /// <summary>Sets/Gets the active project name </summary>
        string ProjectName { get; set; }

        /// <summary>Sets/Gets list of projects to import from </summary>
        IList<Project> Projects { get; set; }

        /// <summary>Sets/Gets a selected project on a view</summary>
        Project SelectedProject { get; set; }

        /// <summary>Gets items that are select for import </summary>
        IEnumerable<Component> SelectedItems { get; }

        /// <summary>Shows up the view and returns how the view was closed</summary>
        DialogResult ShowView();

        /// <summary>Closes the view </summary>
        void CloseForm();

        /// <summary>Occurs when a path initialization/change is requested</summary>
        event ImportEventHandler PathSelecting;

        /// <summary>Occurs when a path is going to be used and should be validated</summary>
        event ImportEventHandler PathValidating;

        /// <summary>Occurs when components should be imported</summary>
        event ImportEventHandler ImportRequestedRaised;
    }
}
