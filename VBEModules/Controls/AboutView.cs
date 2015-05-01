using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace VbeComponents.Controls
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
