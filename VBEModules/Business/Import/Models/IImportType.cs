using Microsoft.Vbe.Interop;

namespace VbeComponents.Business.Import.Models
{
    public interface IImportType
    {
        /// <summary>
        /// Imports component to active VB project
        /// </summary>
        /// <param name="vbe">a reference to VBE</param>
        /// <param name="item">a component to be imported</param>
        /// <param name="shouldOverride">True if existing component should be overwritten</param>
        void Import(VBE vbe, Component item, bool shouldOverride);
    }
}
