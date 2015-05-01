
namespace VbeComponents.Controls.CommandBars
{
    public class MenuItem : IMenuItem
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int IconId { get; set; }
        public System.Drawing.Image Image { get; set; }
        public bool HasSeparator { get; set; }
        public double Order { get; set; }
        public Business.ICommand Command { get; set; }
      
    }
}
