using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Extensibility;
using Microsoft.Vbe.Interop;
using VbeComponents.Resources;

// Thanks MZ-Tools and RubberDuck - https://github.com/retailcoder/Rubberduck
namespace VbeComponents
{    
    /// <summary>
    /// The entry point of the VBE AddIn.
    /// Hooks the AddIn to the VB Editor and makes all necessary logic to run the AddIn
    /// Keep It Simple! 
    /// </summary>
    [ComVisible(true), Guid("59507bb9-1380-406e-929d-ed5030f7b1bf"), ProgId("VBEComponents.Connect")]
    public class Connect : IDTExtensibility2, IDisposable
    {
        private VBE _vbe;
        private AddIn _addIn;
        private  Menus.MainMenu _appMainMenu;

        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            try
            {
                _vbe = (VBE)application;
                _addIn = (AddIn)addInInst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(strings.AddInCouldNotBeLoaded, ex.Message));
            }
        }

        public void OnStartupComplete(ref Array custom)
        {
            try
            {
                _appMainMenu = new Menus.MainMenu(_vbe, _addIn);
                _appMainMenu.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(strings.AddInMenuCouldNotBeCreated, ex.Message));
            }
        }

        public void OnDisconnection(ext_DisconnectMode removeMode, ref Array custom)
        {
            Dispose(true);
        }

        public void OnAddInsUpdate(ref Array custom)
        {
            // not used
        }

        public void OnBeginShutdown(ref Array custom)
        {
            // not used
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing & _appMainMenu != null)
            {
                _appMainMenu.Dispose();
            }
        }

    }
}
