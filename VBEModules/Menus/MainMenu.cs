using System;
using System.Diagnostics;
using Microsoft.Office.Core;
using Microsoft.Vbe.Interop;
using VbeComponents.Business.About;
using VbeComponents.Business.Import;
using CommandBarButtonClickEvent = Microsoft.Office.Core._CommandBarButtonEvents_ClickEventHandler;
using VbeComponents.Business.Export;

// All the credit comes from RubberDuck - https://github.com/retailcoder/Rubberduck
namespace VbeComponents.Menus
{
    public class MainMenu : Menu
    {
        //These need to stay in scope for their click events to fire. (32-bit only?)
        private CommandBarButton _about;
        private CommandBarButton _export;
        private CommandBarButton _import;

        public MainMenu(VBE vbe, AddIn addIn) : base(vbe, addIn)
        {
        }

        public void Initialize()
        {
            const int windowMenuId = 30009;
            var menuBarControls = IDE.CommandBars[1].Controls;
            var beforeIndex = FindMenuInsertionIndex(menuBarControls, windowMenuId);
            var menu = menuBarControls.Add(MsoControlType.msoControlPopup, Before: beforeIndex, Temporary: true) as CommandBarPopup;
            Debug.Assert(menu != null, "menu != null");

            menu.Caption = "Com&ponents";

            _export = AddButton(menu, "&Export...", true, OnExportClick, Properties.Resources.import_button);
            _import = AddButton(menu, "&Import...", true, OnImportClick ,Properties.Resources.export_button);
            _about = AddButton(menu, "&About...", true, OnAboutClick, Properties.Resources.about_ico);
        }

        private void OnExportClick(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            using (var command = new ExportCommand(base.IDE))
            {
                command.Execute();
            }
        }

        private void OnImportClick(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            using (var command = new ImportCommand(base.IDE))
            {
                command.Execute();
            }
        }

        private void OnAboutClick(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            using (var command = new AboutCommand())
            {
                command.Execute();
            }
        }

        bool _disposed;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _about = null;
                _export = null;
                _import = null;
            }

            _disposed = true;

            base.Dispose(disposing);
        }

    }
}
