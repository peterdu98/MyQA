using System;
namespace MyQA
{
    public partial class Sharp : Gtk.Window
    {
        public Sharp() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
