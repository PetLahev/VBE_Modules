using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VbeComponents.Business;
using Microsoft.Office.Core;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.Export;
using VbeComponents.Resources;

namespace VbeComponents.Controls.CommandBars
{
    /// <summary>
    /// Provides basic functionality for managing the Add-in menu
    /// </summary>
    internal class MainMenu
    {        
        /// <summary>
        /// Gets the name of the main menu of this Add-in
        /// </summary>
        internal const string AddinMenuName = "VBEModulesMainMenu";

        internal delegate void ButtonsClickDel(IMenuItem sender, EventArgs e);
        internal event ButtonsClickDel ButtonClickHandler;

        // Constants for names of built-in command bars of the VBA editor
        const string  StandardCommandbarName = "Standard";
        const string  MenubarCommandbarName = "Menu Bar";
        const string  ToolsCommandbarName = "Tools";

        private CommandBarPopup _addInMenu;
        private static VBE _vbe;        
        private static MainMenu _instance = null;
        private Dictionary<string, IMenuItem> _menuItems;

        /// <summary>Constructor - Singleton pattern</summary>
        private MainMenu() {}

        /// <summary>
        /// Gets the instance of the class (Singleton pattern)
        /// </summary>
        /// <param name="vbeEditor">a reference to the VB editor</param>
        /// <returns></returns>
        internal static MainMenu GetInstance(VBE vbeEditor)
        {
            if (_instance == null)
            {
                _vbe = vbeEditor;                
                _instance = new MainMenu();                
                _instance.BuildMenu();
            }
            return _instance;
        }

        /// <summary>
        /// Builds the main menu at the VBE standard command bar
        /// </summary>
        private void BuildMenu()
        {            
            CommandBar standardCommandBar, menuCommandBar, toolsCommandBar;
            CommandBarControl toolsCommandBarControl;
            
            int position = 0;

            try
            {                
                // Retrieve some built-in commandbars
                standardCommandBar = _vbe.CommandBars[StandardCommandbarName];
                menuCommandBar = _vbe.CommandBars[MenubarCommandbarName];
                toolsCommandBar = _vbe.CommandBars[ToolsCommandbarName];

                // Calculate the position of a new commandbar popup to the right of the "Tools" menu
                toolsCommandBarControl = (CommandBarControl)toolsCommandBar.Parent;
                position = toolsCommandBarControl.Index +1;                

                // Add a new AddIn menu to VBE toolbar 
                _addInMenu = (CommandBarPopup)menuCommandBar.Controls.Add(MsoControlType.msoControlPopup, System.Type.Missing, System.Type.Missing, position, true);
                _addInMenu.CommandBar.Name = AddinMenuName;
                _addInMenu.Caption = "V&BE Modules";
                _addInMenu.Visible = true;

                IList<IMenuItem> items = new List<IMenuItem>();
                items.Add(new MenuItem() { DisplayName = "About", Name = "btnAbout", IconId = 487, Order = 3, HasSeparator = true, Command = new AboutCommand() });
                items.Add(new MenuItem() { DisplayName = "Import", Name = "btnImport", IconId = 1591, Order = 2, HasSeparator = false, Command = new AboutCommand() });
                items.Add(new MenuItem() { DisplayName = "Export", Name = "btnExport", IconId = 1590, Order = 1, HasSeparator = false, Command = new ExportCommand(_vbe) });
                AddMenuItemToMainMenu(items);
            }
            catch (Exception)
            { throw; }
      
        }

        /// <summary>
        /// Removes the main menu from the VB editor
        /// </summary>
        internal void RemoveMenu()
        {
            try
            {
                _addInMenu.Delete();
            }
            catch (Exception)
            {                
                // do nothing here
            }
        }

        /// <summary>
        /// TODO: This should be more clever
        /// if I add one item to existing. it should get all existing, sorted with the new one and re-added all again
        /// </summary>
        /// <param name="items">lit of menu items to be added</param>
        internal virtual void AddMenuItemToMainMenu(IList<IMenuItem> items)
        {
            try
            {
                if (items == null) return;
                if (_menuItems == null) _menuItems = new Dictionary<string, IMenuItem>();

                List<IMenuItem> sorted =  items.OrderBy(x => x.Order).ToList();
                foreach (IMenuItem item in sorted)
                {
                    if (_menuItems.ContainsKey(item.Name)) continue;
                    _menuItems.Add(item.Name, item);
 
                    CommandBarControl commandBarControl = _addInMenu.Controls.Add(MsoControlType.msoControlButton);
                    CommandBarButton cmdBtn = (CommandBarButton)commandBarControl;
                                
                    cmdBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
                    cmdBtn.Caption = item.DisplayName;
                    cmdBtn.FaceId = item.IconId;
                    cmdBtn.BeginGroup = item.HasSeparator;
                    cmdBtn.Tag = item.Name;
                
                    cmdBtn.Click += new _CommandBarButtonEvents_ClickEventHandler(cmdBtn_Click);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Common button click handler for all buttons under main menu
        /// Raises the common click event
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="cancelDefault"></param>
        void cmdBtn_Click(CommandBarButton ctrl, ref bool cancelDefault)
        {
            if (_vbe.ActiveVBProject.Protection == vbext_ProjectProtection.vbext_pp_locked)
            {
                MessageBox.Show(string.Format(strings.ProtectedProject, _vbe.ActiveVBProject.Name), 
                    strings.ApplicationMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ButtonClickHandler == null) return;
            if ( _menuItems == null || !_menuItems.ContainsKey(ctrl.Tag) ) return;
            IMenuItem item = _menuItems[ctrl.Tag];
            ButtonClickHandler(item, new EventArgs());
        }
    }
}
