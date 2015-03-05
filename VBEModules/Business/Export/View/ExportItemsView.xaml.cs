using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VBEModules.Business.Export.View
{
    /// <summary>
    /// Interaction logic for ExportItemsView.xaml
    /// </summary>
    public partial class ExportItemsView : UserControl, VBEModules.Business.Export.IExport
    {
        public ExportItemsView()
        {
            InitializeComponent();
        }

        public string Path
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<VbeComponent> Items
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<VbeComponent> SelectedItems
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Windows.Forms.DialogResult ShowUI()
        {
            throw new NotImplementedException();
        }

        public void CloseForm()
        {
            throw new NotImplementedException();
        }

        public event EventHandler PathRequestHandler;
    }
}
