using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    private MyQA.view.OpeningScreen titleScreen;
    private MyQA.view.HistoryScreen historyScreen;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        titleScreen = new MyQA.view.OpeningScreen();
        historyScreen = new MyQA.view.HistoryScreen();
        Add(titleScreen);
        titleScreen.ClickHistory += (sender, e) => AddHistoryScreen();
        titleScreen.ClickPlay += (sender, e) => Console.WriteLine("Hello World");
        historyScreen.ClickBack += (sender, e) => BackToTitleScreen();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void AddHistoryScreen()
    {
        Remove(titleScreen);
        Add(historyScreen);
    }
    private void BackToTitleScreen()
    {
        Remove(historyScreen);
        Add(titleScreen);
    }
}
