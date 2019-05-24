using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        MyQA.view.OpeningScreen titleScreen = new MyQA.view.OpeningScreen();
        Add(titleScreen);
        Remove(titleScreen);

    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
