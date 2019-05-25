using System;
using System.IO;
using Gtk;
using MyQADLL.src;

namespace MyQA.view
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class LevelScreen : Gtk.Bin
    {
        //Fields
        private Gdk.Pixbuf _background;
        private Gdk.Pixbuf _esayBtn;
        private Gdk.Pixbuf _mediumBtn;
        private Gdk.Pixbuf _hardBtn;
        private string _greet;
        public event EventHandler ClickEasy;
        public event EventHandler ClickMedium;
        public event EventHandler ClickHard;

        //Constructor
        public LevelScreen(Player p)
        {
            p.TextFile = "../../../MyQADLL/Resources/player.txt";
            _greet = p.ReadScoreFromFile();
            time = 0;

            this.Build();

            LoadImageFromFile();
            LoadImageToScreen();
            LoadStaticText();
            ShowAll();
        }

        //Methods
        private void LoadImageFromFile()
        {
            try
            {
                _background = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/background-image.png");
                _esayBtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/easy-btn.png");
                _mediumBtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/medium-btn.png");
                _hardBtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/hard-btn.png");
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

            //Load button
            Image easy_btn_img = new Image(_esayBtn);
            Image medium_btn_img = new Image(_mediumBtn);
            Image hard_btn_img = new Image(_hardBtn);

            easyBtn.Image = easy_btn_img;
            mediumBtn.Image = medium_btn_img;
            hardBtn.Image = hard_btn_img;
        }
        private void LoadStaticText()
        {
            string[] text = new string[] { _greet, "Please select the level you want to play!" };
            int y = 200;

            foreach(string t in text) {
                Label label = new Label(t);
                label.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
                label.ModifyFont(Pango.FontDescription.FromString("Arial 25"));
                label.SetSizeRequest(700, 100);
                label.SetUposition(60, y);
                fixed2.Add(label);
                y += 50;
            }
        }

        //Actions
        protected void ClickToEasy(object sender, EventArgs e)
        {
            ClickEasy(this, e);
        }

        protected void ClickToMedium(object sender, EventArgs e)
        {
            ClickMedium(this, e);
        }

        protected void ClickToHard(object sender, EventArgs e)
        {
            ClickHard(this, e);
        }
    }
}
