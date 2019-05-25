using System;
using Gtk;
using System.Collections.Generic;

namespace MyQA.view
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class ResultScreen : Gtk.Bin
    {
        //Fields
        private Gdk.Pixbuf _background;
        private Gdk.Pixbuf _playagbtn;
        private Gdk.Pixbuf _quitbtn;
        private List<Label> _labels;
        private string _goString;
        private string[] _score;
        public event EventHandler ClickPlayAgain;

        //Constructor
        public ResultScreen(string goString, string[] score)
        {
            _goString = goString;
            _score = score;
            _labels = new List<Label>();
            this.Build();
            LoadImageFromFile();
            LoadImageToScreen();
            CustomLabel();
            ShowAll();
        }

        //Methods
        private void LoadImageFromFile()
        {
            try
            {
                _background = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/background-image.png");
                _playagbtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/playagain-btn.png");
                _quitbtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/exit-btn.png");
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

            //Create image for buttons
            Image playag_btn_img = new Image(_playagbtn);
            Image quit_btn_img = new Image(_quitbtn);

            //Create button
            playAgainBtn.Image = playag_btn_img;
            quitBtn.Image = quit_btn_img;
        }
        private void CustomLabel()
        {
            gameoverLabel.Text = _goString;
            playerScore.Text = String.Format("Your score: {0}",_score[0]);
            botScore.Text = String.Format("Bot score: {0}", _score[1]);

            _labels.Add(gameoverLabel);
            _labels.Add(playerScore);
            _labels.Add(botScore);

            foreach(Label l in _labels) {
                l.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
                l.ModifyFont(Pango.FontDescription.FromString("Arial 20"));
            }

        }

        //Actions
        protected void ClickToPlayAgain(object sender, EventArgs e)
        {
            ClickPlayAgain(this, e);
        }

        protected void ClickToExit(object sender, EventArgs e)
        {
            Application.Quit();
        }
    }
}
