using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VbeComponents.Business.Configurations;

namespace VbeComponents.Tests.Business.Configurations
{
    [TestClass]
    public class ConfigurationXmlFileTests
    {

        private XmlDocument _doc = null;
        private void CreateXmlDoc(int numOfNodes = 1)
        {
            _doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = _doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = _doc.DocumentElement;
            _doc.InsertBefore(xmlDeclaration, root);

            XmlElement vbProjects = _doc.CreateElement(string.Empty, "VBProjects", string.Empty);
            _doc.AppendChild(vbProjects);

            for (int i = 0; i < numOfNodes; i++)
            {
                XmlElement vbProject = _doc.CreateElement(String.Empty, "VBProject", string.Empty);
                vbProjects.AppendChild(vbProject);

                XmlAttribute attrName = _doc.CreateAttribute(String.Empty, "name", String.Empty);
                attrName.Value = "Name" + i;
                vbProject.Attributes.Append(attrName);
                
                XmlElement path = _doc.CreateElement(String.Empty, "Path", string.Empty);
                XmlText pathText = _doc.CreateTextNode(@"C:\Windows\Temp\" + i + "\\");
                path.AppendChild(pathText);
                vbProject.AppendChild(path);

                XmlElement created = _doc.CreateElement(String.Empty, "CreatedUTC", string.Empty);
                XmlText createdText = _doc.CreateTextNode(DateTime.UtcNow.ToString());
                created.AppendChild(createdText);
                vbProject.AppendChild(created);

                XmlElement saved = _doc.CreateElement(String.Empty, "LastSavedUTC", string.Empty);
                XmlText savedText = _doc.CreateTextNode(DateTime.UtcNow.AddHours(1).ToString());
                saved.AppendChild(savedText);
                vbProject.AppendChild(saved);
            }

            MemoryStream wr = new MemoryStream();
            _doc.Save(wr);
            wr.Close();
        }

        [TestMethod]
        public void GetProjectPath_EmptyConfigFile_ReturnsNull()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<VBProjects></VBProjects>");
            ConfigurationBase myXml = new ConfigurationXmlFile(doc);
            string retVal = myXml.GetProjectPath("test");
            Assert.IsNull(retVal);
        }

        [TestMethod]
        public void GetProjectPath_ProjectDoesnExists_ReturnsNull()
        {
            CreateXmlDoc();
            ConfigurationBase myXml = new ConfigurationXmlFile(_doc);
            string retVal = myXml.GetProjectPath("test");
            Assert.IsNull(retVal);
        }

        [TestMethod]
        public void GetProjectPath_ProjectExists_ReturnsPath()
        {
            CreateXmlDoc(3);
            ConfigurationBase myXml = new ConfigurationXmlFile(_doc);
            string retVal = myXml.GetProjectPath("Name1");
            Assert.IsNotNull(retVal);
            Assert.IsTrue(retVal.StartsWith(@"C:\Windows\"));
        }

        [TestMethod]
        public void SaveProject_ProjectExists_ReturnsTrueAndChangeData()
        {
            CreateXmlDoc(3);
            ConfigurationBase myXml = new ConfigurationXmlFile(_doc);
            bool retVal = myXml.SaveProject("Name1", "Fake");
            Assert.IsTrue(retVal);
            Assert.IsTrue(myXml.GetProjectPath("Name1").StartsWith(@"Fake"));
        }

        [TestMethod]
        public void SaveProject_ProjectDoesNotExists_ReturnsTrueAndAddedData()
        {
            CreateXmlDoc();
            ConfigurationBase myXml = new ConfigurationXmlFile(_doc);
            bool retVal = myXml.SaveProject("Fake", "Fake");
            Assert.IsTrue(retVal);
            Assert.IsTrue(myXml.GetProjectPath("Fake").StartsWith(@"Fake"));
        }

        [TestMethod]
        public void RemoveProject_ProjectExists_ReturnsTrueAndWholeProjectIsRemoved()
        {
            CreateXmlDoc();
            ConfigurationBase myXml = new ConfigurationXmlFile(_doc);
            bool retVal = myXml.RemoveProject("Name0");
            Assert.IsTrue(retVal);
            Assert.IsNull(myXml.GetProjectPath("Name0"));
        }

    }
}
