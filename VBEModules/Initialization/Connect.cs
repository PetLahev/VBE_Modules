using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Extensibility;
using Microsoft.Vbe.Interop;

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
        private static Controls.CommandBars.MainMenu _menu;

        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
        {
            try
            {
                _vbe = (VBE)application;
                _addIn = (AddIn)addInInst;
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("VBE Modules Add-inn could not be loaded!\n{0}", e.Message));
            }
        }

        public void OnStartupComplete(ref Array custom)
        {
            _menu = Controls.CommandBars.MainMenu.GetInstance(_vbe);
            _menu.ButtonClickHandler -= new Controls.CommandBars.MainMenu.ButtonsClickDel(_menu_ButtonClickHandler);
            _menu.ButtonClickHandler += new Controls.CommandBars.MainMenu.ButtonsClickDel(_menu_ButtonClickHandler);            
        }

        public void OnDisconnection(ext_DisconnectMode removeMode, ref Array custom)
        {
            if (removeMode != ext_DisconnectMode.ext_dm_UserClosed && removeMode != ext_DisconnectMode.ext_dm_HostShutdown) return;
            try
            {
                _menu = Controls.CommandBars.MainMenu.GetInstance(_vbe);
                _menu.RemoveMenu();
            }
            catch (Exception e)
            {                
                MessageBox.Show(string.Format("VBE Modules Add-inn could not be unloaded!\n{0}", e.Message));
            }
        }
        
        public void OnAddInsUpdate(ref Array custom)
        {
            // not used
        }

        public void OnBeginShutdown(ref Array custom)
        {
            // not used
        }

        /// <summary>
        /// Common click event handler for all buttons under main menu.
        /// Uses Command pattern to decouple logic
        /// </summary>
        /// <param name="sender">an instance of the IMenuItem class</param>
        /// <param name="e"></param>
        void _menu_ButtonClickHandler(object sender, EventArgs e)
        {
            Controls.CommandBars.IMenuItem btn = (Controls.CommandBars.IMenuItem)sender;
            btn.Command.Execute();
            btn.Dispose();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing & _menu != null)
            {
                _menu.Dispose();
            }
        }

    }
}
