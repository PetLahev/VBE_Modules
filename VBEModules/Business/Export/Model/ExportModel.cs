using System;
using Microsoft.Vbe.Interop;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VbeComponents.Business.Export.Model
{
    [ ComVisible(false) ]
    public class ExportModel
    {
        private readonly VBE _vbe;
        public ExportModel(VBE vbe) { _vbe = vbe;}
        public event EventHandler PathSelected;


        public void PathRequestHandler()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog { ShowNewFolderButton = true };
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.Cancel) return;
            if (PathSelected != null) PathSelected(fbd.SelectedPath, null);
        }

    }
}
