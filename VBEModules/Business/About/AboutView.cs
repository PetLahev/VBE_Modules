using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using VbeComponents.Resources;

namespace VbeComponents.Business.About
{
    public partial class AboutView : Form
    {
        private static readonly IDictionary<string, string> Links =
            new Dictionary<string, string>
            {
                {"RubberDuck","http://www.rubberduck-vba.com"},
                {"GitHub", "http://www.github.com/retailcoder/rubberduck"},
                {"MzTool","http://www.twitter.com/rubberduckvba"}
            };

        public AboutView()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            var name = assembly.GetName();
            lblVersion.Text = "1.1.0";  // name.Version.ToString();
            lblDesc.Text = strings.AppDescription;
            lblThanks.Text = strings.ThanksContributtors;

            picDucky.Click += new System.EventHandler(picDucky_Click);
            picMZT.Click += new System.EventHandler(picMZT_Click);
            picGit.Click += new System.EventHandler(picGit_Click);
        }

        void picGit_Click(object sender, System.EventArgs e)
        {
            VisitLink(Links["GitHub"]);
        }

        void picMZT_Click(object sender, System.EventArgs e)
        {
            VisitLink(Links["MzTool"]);
        }

        void picDucky_Click(object sender, System.EventArgs e)
        {
            VisitLink(Links["RubberDuck"]);
        }

        private void VisitLink(string url)
        {
            var info = new ProcessStartInfo(url);
            Process.Start(info);
        }

    }
}
