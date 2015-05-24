using System;
using Microsoft.Vbe.Interop;
using VbeComponents.Resources;

namespace VbeComponents.Business.Import.Models
{
    public class ComponentFactory
    {
        /// <summary>
        /// Gets the correct Import class based on given extension
        /// </summary>
        /// <param name="componentType">extension of the component</param>
        /// <returns>Instance of the appropriate class for import</returns>
        /// <exception cref="ArgumentException">if the type is not recognized or supported. Supported types are: cls, bas, frm</exception>
        public static IImportType GetTypeClass(string componentType)
        {
            switch (componentType.ToLower())
            {
                case "bas":
                    return new ImportModule();
                case "frm":
                    return new ImportForm();
                case "cls":
                    return new ImportClassorDocument();
                default:
                    throw new ArgumentException(string.Format(strings.ComponentNotValid, componentType));
            }
        }

        /// <summary>
        /// Gets the correct Import class based on given type
        /// </summary>
        /// <param name="componentType">type of the component</param>
        /// <returns>Instance of the appropriate class for import</returns>
        /// <exception cref="ArgumentException">if the type is not recognized or supported. Supported types are: ClassModule, STDModule, MSForms, Document</exception>
        public static IImportType GetTypeClass(vbext_ComponentType componentType)
        {
            switch (componentType)
            {                
                case vbext_ComponentType.vbext_ct_ClassModule:
                    return new ImportClassorDocument();
                case vbext_ComponentType.vbext_ct_Document:
                    return new ImportClassorDocument();
                case vbext_ComponentType.vbext_ct_MSForm:
                    return new ImportForm();
                case vbext_ComponentType.vbext_ct_StdModule:
                    return new ImportModule();
                default:
                    throw new ArgumentException(string.Format(strings.ComponentNotValid, componentType));
            }
        }
    }
}
