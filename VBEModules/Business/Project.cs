
namespace VbeComponents.Business
{
    /// <summary> Stores information about projects saved in the configuration file </summary>
    public class Project
    {
        /// <summary>Sets/Gets name of the project </summary>
        string Name { get; set; }
        /// <summary>Sets/Gets path of the project </summary>
        string Path { get; set; }
        /// <summary>Gets full path of the project </summary>
        string FullPath
        {
            get {return  System.IO.Path.Combine(Path, Name); }
        }

        /// <summary>Sets/Gets a flag if the path of the project is valid </summary>
        bool Validated { get; set; }
        /// <summary>Sets/Gets a flag if the validation of the project path is still processing </summary>
        bool Validating { get; set; }
    }
}
