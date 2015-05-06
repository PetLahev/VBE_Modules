using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace VbeComponents.Business.Configurations
{
    /// <summary>Provides functionality for storing project settings to an XML configuration file </summary>
    public class ConfigurationXmlFile : ConfigurationBase
    {
        private readonly string _configFilePath = Properties.Settings.Default.ConfigurationPath.ToString();
        private const string ConfigName = "VbeComponentsConfig.xml";
        private XmlDocument _doc= null;

        /// <summary>Checks if a configuration directory exists, if not, will create it with empty configuration file </summary>
        public ConfigurationXmlFile()
        {
            if (!Directory.Exists(_configFilePath)) CreateConfigLocation(_configFilePath);
            if (!File.Exists(GetConfigFullName)) CreateConfigFile(_configFilePath);
            if (_doc == null) _doc= new XmlDocument();
            _doc.Load(GetConfigFullName);
        }

        /// <summary>
        /// Initialize the internal properties
        /// </summary>
        /// <param name="configFile">a configuration file to be used for getting information about projects</param>
        public ConfigurationXmlFile(XmlDocument configFile)
        {
            _doc = configFile;
        }
        
        /// <summary>
        /// Gets the path to components from a configuration file based on given project name
        /// </summary>
        /// <param name="projectName">a name of a project to look up</param>
        /// <returns>a path associated with the project name or null if the project couldn't be found</returns>
        public override string GetProjectPath(string projectName)
        {
            XmlNode nd = GetProject(projectName);
            return nd == null ? null : nd.SelectSingleNode("Path").InnerText;
        }

        public override IList<Project> GetProjects()
        {
            XmlNodeList list =  _doc.SelectNodes(string.Format(".//VBProject"));
            if (list == null) return null;

            var retVal =  list.Cast<XmlNode>()
                .Select(
                    x =>
                        new Project()
                        {
                            Name = x.Attributes["name"].Value,
                            Path = x.SelectSingleNode("Path").InnerText
                        })
                .ToList();
            return retVal;
        }

        /// <summary>
        /// Saves the given data back to a configuration file.
        /// If the project already exists, will change the data, if not, will create a new one
        /// </summary>
        /// <param name="projectName">a name of a project to be saved</param>
        /// <param name="path">a path associated with the project to be saved</param>
        /// <returns>True if succeeded, otherwise False </returns>
        public override bool SaveProject(string projectName, string path)
        {
            bool retVal = false;
            try
            {
                bool exist = GetProjectPath(projectName) != null;
                if (exist)
                {
                    XmlNode project = GetProject(projectName);
                    project.SelectSingleNode("Path").InnerText = path;
                    project.SelectSingleNode("LastSavedUTC").InnerText = DateTime.UtcNow.ToString();
                }
                else
                {
                    XmlNode vbProjects = _doc.DocumentElement;
                    XmlElement vbProject = _doc.CreateElement(String.Empty, "VBProject", string.Empty);
                    vbProjects.AppendChild(vbProject);

                    XmlAttribute attrName = _doc.CreateAttribute(String.Empty, "name", String.Empty);
                    attrName.Value = projectName;
                    vbProject.Attributes.Append(attrName);

                    XmlElement projectPath = _doc.CreateElement(String.Empty, "Path", string.Empty);
                    XmlText pathText = _doc.CreateTextNode(path);
                    projectPath.AppendChild(pathText);
                    vbProject.AppendChild(projectPath);

                    XmlElement created = _doc.CreateElement(String.Empty, "CreatedUTC", string.Empty);
                    XmlText createdText = _doc.CreateTextNode(DateTime.UtcNow.ToString());
                    created.AppendChild(createdText);
                    vbProject.AppendChild(created);

                    XmlElement saved = _doc.CreateElement(String.Empty, "LastSavedUTC", string.Empty);
                    XmlText savedText = _doc.CreateTextNode(DateTime.UtcNow.ToString());
                    saved.AppendChild(savedText);
                    vbProject.AppendChild(saved);
                }
                _doc.Save(GetConfigFullName);
                retVal = true;
            }
            catch (Exception)
            {
                throw;
            }
            return retVal;
        }

        /// <summary>
        /// Removes the given project and all its information from the configuration file
        /// </summary>
        /// <param name="projectName">a name of a project to be removed</param>
        /// <returns>True if succeeded, otherwise False </returns>
        public override bool RemoveProject(string projectName)
        {
            bool retVal;
            try
            {
                bool exist = GetProjectPath(projectName) != null;
                if (exist)
                {
                    XmlNode project = GetProject(projectName);
                    project.ParentNode.RemoveChild(project);
                }
                _doc.Save(ConfigName);
                retVal = true;
            }
            catch (Exception)
            {
                throw;
            }
            return retVal;
        }


        private XmlNode GetProject(string projectName)
        {
            return _doc.SelectSingleNode(string.Format(".//VBProject[@name='{0}']", projectName));
        }

        private string GetConfigFullName
        {
            get { return Path.Combine(_configFilePath, ConfigName); }
        }
    
        private void CreateConfigLocation(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;
            Directory.CreateDirectory((path));
            CreateConfigFile(path);
        }

        private void CreateConfigFile(string path)
        {
            _doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = _doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = _doc.DocumentElement;
            _doc.InsertBefore(xmlDeclaration, root);

            XmlElement vbProjects = _doc.CreateElement(string.Empty, "VBProjects", string.Empty);
            _doc.AppendChild(vbProjects);
            _doc.Save(GetConfigFullName);
        }

    }
}
