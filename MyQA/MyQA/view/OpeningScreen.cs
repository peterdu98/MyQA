using System;
using Gtk;

namespace MyQA.view
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class OpeningScreen : Gtk.Bin
    {
        //Fields
        private Gdk.Pixbuf _background;
        private Gdk.Pixbuf _playbtn;
        private Gdk.Pixbuf _historybtn;
        private Gdk.Pixbuf _exitbtn;
        private Gdk.Pixbuf _welcome;

        //Constructor
        public OpeningScreen()
        {
            this.Build();
            LoadImageFromFile();
            LoadImageToScreen();
            CustomUserInput();
        }

        //Methods
        public void LoadImageFromFile()
        {
            try
            {
                _background = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/background-image.png");
                _playbtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/play-btn.png");
                _historybtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/history-btn.png");
                _exitbtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/exit-btn.png");
                _welcome = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/welcome-stm.png");
            }
            catch
            {
                Console.WriteLine("Images not found");
                Environment.Exit(1);
            }
        }
        public void LoadImageToScreen()
        {
            //Load image
            background.Pixbuf = _background;
            welcome.Pixbuf = _welcome;

            //Create image for buttons
            Image play_btn_img = new Image(_playbtn);
            Image history_btn_img = new Image(_historybtn);
            Image exit_btn_img = new Image(_exitbtn);

            //Create button
            playBtn.Image = play_btn_img;
            historyBtn.Image = history_btn_img;
            exitBtn.Image = exit_btn_img;

        }
        public void CustomUserInput()
        {
            userName.ModifyFont(Pango.FontDescription.FromString("Arial 30"));
        }

        //Actions
        protected void ClickExit(object sender, EventArgs e)
        {
            Application.Quit();
        }

        protected void OnUserNameActivated(object sender, EventArgs e)
        {
            userName.Text = "Hello " + userName.Text;
        }
    }
}
