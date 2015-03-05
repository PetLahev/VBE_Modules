using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VBEModules.Controls.CommandBars
{
    public class MenuItem : IMenuItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int IconId { get; set; }
        public bool HasSeparator { get; set; }
        public double Order { get; set; }
        public Business.ICommand Command { get; set; }
      
    }
}
