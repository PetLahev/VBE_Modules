using System.IO;

namespace VbeComponents.Business.Configurations
{
    /// <summary>Provides basic functionality for reading/writting to a configuration file </summary>
    public abstract class ConfigurationBase 
    {
        /// <summary>
        /// Gets a path of given project where the components are placed
        /// </summary>
        /// <param name="projectName">a name of project to take a path for</param>
        /// <returns>a path to files or null if the given project is not associated with any path</returns>
        public abstract string GetProjectPath(string projectName);
        /// <summary>
        /// Saves the given path and project to a configuration file
        /// </summary>
        /// <param name="projectName">a name of a project that will be associated with given path</param>
        /// <param name="path">a path to files</param>
        /// <returns>true if succeeded, otherwise false</returns>
        public abstract bool SaveProject(string projectName, string path);
        /// <summary>
        /// Removes information about given project from a configuration file
        /// </summary>
        /// <param name="projectName">a name of a project that will be removed from configuration file</param>
        /// <returns>true if succeeded, otherwise false</returns>
        public abstract bool RemoveProject(string projectName);

        /// <summary>
        /// Checks if given path exists at the end machine
        /// </summary>
        /// <param name="path">a path to check</param>
        /// <returns>True if the path exists, otherwise false</returns>
        public virtual bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;
            return Utils.PathExists(path);
        }

    }
}
