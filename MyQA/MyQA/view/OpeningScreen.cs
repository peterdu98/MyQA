using System;
using Gtk;
using System.Text.RegularExpressions;

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
        private bool _isPlay;
        private bool _isHistory;

        //Constructor
        public OpeningScreen()
        {
            _isPlay = true;
            _isHistory = false;
            this.Build();
            LoadImageFromFile();
            LoadImageToScreen();
            CustomUserInput();
            errorMsg.SetSizeRequest(0, 0);
            ShowAll();
        }

        //Property
        public bool IsPlay { get => _isPlay; }
        public bool IsHistory { get => _isHistory; }

        //Methods
        private void LoadImageFromFile()
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
        private void LoadImageToScreen()
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
        private void CustomUserInput()
        {
            userName.ModifyFont(Pango.FontDescription.FromString("Arial 30"));
        }
        private void CustomErrorMsg()
        {
            if (!_isPlay) {
                errorMsg.SetSizeRequest(410, 30);
                errorMsg.ModifyBase(StateType.Normal, new Gdk.Color(255, 77, 77));
                errorMsg.ModifyCursor(new Gdk.Color(255, 77, 77), new Gdk.Color(255, 77, 77));
                errorMsg.ModifyFont(Pango.FontDescription.FromString("Arial 10"));
            } else {
                errorMsg.Destroy();
            }
        }

        //Actions
        protected void ClickExit(object sender, EventArgs e)
        {
            Application.Quit();
        }

        protected void ClickToPlay(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d");
            if(regex.IsMatch(userName.Text) || userName.Text.Contains(",") || userName.Text == "")
            {
                if (regex.IsMatch(userName.Text)) {
                    errorMsg.Text = "Your name MUST not start with numbers";
                } else if (userName.Text.Contains(",")) {
                    errorMsg.Text = "Your name MUST not contain , (commas)";
                } else {
                    errorMsg.Text = "Your name MUST not be empty";
                }
                _isPlay = false;
            } else {
                _isPlay = true;
            }
            CustomErrorMsg();
        }

        protected void ClickToHistory(object sender, EventArgs e)
        {
            _isHistory = true;
        }
    }
}
