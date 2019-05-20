using System;
namespace MyQA.view
{
    public partial class TitleScreen : Gtk.Window
    {
        public TitleScreen() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
