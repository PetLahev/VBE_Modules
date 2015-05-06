
using System.Collections.Generic;

namespace VbeComponents.Business
{
    /// <summary> 
    /// Stores information about projects saved in the configuration file.
    /// A path is considered as unique key => two or more projects can have the same name but must have unique Path
    /// </summary>
    public class Project
    {
        /// <summary>Sets/Gets path of the project. Must be unique </summary>
        public string Path { get; set; }
        /// <summary>Sets/Gets name of the project </summary>
        public string Name { get; set; }
        /// <summary>Sets/Gets components associated to the project </summary>
        public IEnumerable<Component> Components { get; set; } 
        /// <summary>Sets/Gets a flag if the the project is valid project. 
        /// The path exists and contains at least one VBA component </summary>
        public bool Valid { get; set; }
        /// <summary>Sets/Gets a flag if the validation of the project path is still processing </summary>
        public bool Validating { get; set; }
    }
}
