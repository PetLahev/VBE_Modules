using System.Reflection;
using System.Windows.Forms;

namespace VbeComponents.Business.About
{
    public partial class AboutView : Form
    {
        public AboutView()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            var name = assembly.GetName();
            lblVersion.Text = name.Version.ToString();
        }
    }
}
