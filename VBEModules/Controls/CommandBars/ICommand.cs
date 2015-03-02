using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VBEModules.Controls.CommandBars
{
    /// <summary>
    ///  Defines set of method for a Command object
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes a specific action of given command
        /// </summary>
        void Execute();
    }
}
