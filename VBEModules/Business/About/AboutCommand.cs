using System;

namespace VbeComponents.Business.About
{
    /// <summary>
    /// Responsible for displaying the 'About' dialog
    /// </summary>
    public class AboutCommand : ICommand
    {
        /// <summary>
        /// Displays the About form of the AddIn
        /// I didn't bother with a receiver for such simple job
        /// </summary>
        public void Execute()
        {
            using (var window = new AboutView())
            {
                window.ShowDialog();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
