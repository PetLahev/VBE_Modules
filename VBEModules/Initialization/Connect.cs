using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VBEModules.Interop.Extensibility;
using VBEModules.Interop.Stdole;
using VBEModules.Interop.VBAExtensibility;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace VBEModules
{    
    /// <summary>
    /// The entry point of the VBE AddIn.
    /// Hooks the AddIn to the VB Editor and makes all necessary logic to run the AddIn
    /// Keep It Simple! 
    /// </summary>
    [ ComVisible(true), Guid("CD2AC52C-1DA4-4FF8-A271-1565A5D06617"), ProgId("VBEModules.Connect") ]
    public class Connect : IDTExtensibility2
    {
        private VBEModules.Interop.VBAExtensibility.VBE _vbe;
        private VBEModules.Interop.VBAExtensibility.AddIn _addIn;
        private static Controls.CommandBars.MainMenu _menu;

        public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            try
            {
                _vbe = (VBEModules.Interop.VBAExtensibility.VBE)Application;
                _addIn = (VBEModules.Interop.VBAExtensibility.AddIn)AddInInst;
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

        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            if (RemoveMode != ext_DisconnectMode.ext_dm_UserClosed && RemoveMode != ext_DisconnectMode.ext_dm_HostShutdown) return;
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
        }

    }
}
