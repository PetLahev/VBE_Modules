using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sysForms = System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Forms;

namespace VBEModules.Controls.CommandBars
{
    /// <summary>
    /// Displays the 'About' dialog
    /// </summary>
    public class AboutCommand : ICommand
    {
        private ElementHost ctrlHost;
        private Forms.About wpfAbout;

        public void Execute()
        {
            ctrlHost = new ElementHost();
            ctrlHost.Dock = DockStyle.Fill;

            sysForms.Form frm = new sysForms.Form();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Height = 500;
            frm.Width = 500;
            frm.Controls.Add(ctrlHost);
            
            wpfAbout = new Forms.About();
            wpfAbout.InitializeComponent();
            ctrlHost.Child = wpfAbout;

            frm.ShowDialog();
        }
    }
}
