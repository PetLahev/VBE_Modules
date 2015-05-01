using VbeComponents.Controls;

namespace VbeComponents.Business
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
            AboutView frm = new AboutView();
            frm.ShowDialog();            
        }
    }
}
