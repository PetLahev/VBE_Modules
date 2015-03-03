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
    public class AboutCommand : ICommand, IDisposable
    {
        private ElementHost ctrlHost;
        private Forms.About wpfAbout;
        private sysForms.Form frmAbout;

        /// <summary>
        /// Displays the About form of the AddIn
        /// </summary>
        public void Execute()
        {
            ctrlHost = new ElementHost();
            
            frmAbout = new sysForms.Form();
            frmAbout.Controls.Add(ctrlHost);
            

            wpfAbout = new Forms.About();
            wpfAbout.InitializeComponent();
            wpfAbout.OKPressed += new EventHandler(wpfAbout_OKPressed);
            ctrlHost.Child = wpfAbout;
            ctrlHost.Dock = DockStyle.Fill;
            
            frmAbout.ControlBox = false;
            frmAbout.ShowIcon = false;
            frmAbout.FormBorderStyle = FormBorderStyle.None;
            frmAbout.Height = 183;
            frmAbout.Width = 310;
            frmAbout.StartPosition = FormStartPosition.CenterScreen;

            frmAbout.ShowDialog();
        }

        void wpfAbout_OKPressed(object sender, EventArgs e)
        {
            frmAbout.Close();            
        }

        public void Dispose()
        {
            ctrlHost.Dispose();            
        }
    }
}
