using System;
using MyQADLL.src;
using Gtk;

namespace MyQA.view
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class QuestionScreen : Gtk.Bin
    {
        //Fields
        private Gdk.Pixbuf _background;

        //Constructor
        public QuestionScreen()
        {
            this.Build();
            LoadImageFromFile();
            LoadImageToScreen();
            ShowAll();
        }

        //Methods
        private void LoadImageFromFile()
        {
            try
            {
                _background = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/background-image.png");
            }
            catch
            {
                Console.WriteLine("Images not found");
                Environment.Exit(1);
            }
        }
        private void LoadImageToScreen()
        {
            //Load image
            background.Pixbuf = _background;
        }
    }
}
