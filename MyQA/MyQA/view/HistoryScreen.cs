using System;
using Gtk;
using System.IO;
using MyQADLL;

namespace MyQA.view
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class HistoryScreen : Gtk.Bin
    {
        //Fields
        private Gdk.Pixbuf _background;
        private Gdk.Pixbuf _backbtn;
        public event EventHandler ClickBack;

        //Constructor
        public HistoryScreen()
        {
            this.Build();
            LoadImageFromFile();
            LoadImageToScreen();
            LoadStaticText();
            LoadScoreFromFile();
            ShowAll();
        }

        //Methods
        private void LoadImageFromFile()
        {
            try
            {
                _background = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/background-image.png");
                _backbtn = new Gdk.Pixbuf("../../../MyQADLL/Resources/images/goback-btn.png");
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
            Image back_btn_img = new Image(_backbtn);
            backBtn.Image = back_btn_img;
        }
        private void LoadStaticText()
        {
            string[] text = new string[] { "Ranking", "Name", "Score" };
            int x = 210;
            int y = 50;

            foreach(string t in text) {
                Label label = new Label(t);
                label.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
                label.ModifyFont(Pango.FontDescription.FromString("Arial 20"));
                label.SetSizeRequest(100, 100);
                label.SetUposition(x, y);
                fixed2.Add(label);
                x += 150;
            }

            x = 210;
            y = 120;
            for(int i=1; i<=10; i++) {
                Label label = new Label(i.ToString());
                label.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
                label.ModifyFont(Pango.FontDescription.FromString("Arial 20"));
                label.SetSizeRequest(100, 30);
                label.SetUposition(x, y);
                fixed2.Add(label);
                y += 32;
            }
        }
        private void LoadScoreFromFile()
        {
            int y = 120;
            string[] scores = SortFromFile("../../../MyQADLL/Resources/player.txt");
            for (int i=0; i<10; i++)
            {
                int x = 360;
                foreach (string l in scores[i].Split(new char[] { ',' }))
                {
                    Label label = new Label(l);
                    label.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
                    label.ModifyFont(Pango.FontDescription.FromString("Arial 20"));
                    label.SetSizeRequest(100, 30);
                    label.SetUposition(x, y);
                    fixed2.Add(label);
                    x += 150;   
                }
                y += 32;
            }
        }
        private string[] SortFromFile(string path) {
            if (File.Exists("../../../MyQADLL/Resources/player.txt"))
            {
                string[] sortedScores = File.ReadAllLines("../../../MyQADLL/Resources/player.txt");
                for (int i = 0; i < sortedScores.Length - 1; i++) {
                    for (int j = 0; j < sortedScores.Length - i - 1; j++) {
                        int score1 = Convert.ToInt32(sortedScores[j].Split(new char[] { ',' })[1]);
                        int score2 = Convert.ToInt32(sortedScores[j + 1].Split(new char[] { ',' })[1]);
                        if (score1 < score2) {
                            string swapString = sortedScores[j];
                            sortedScores[j] = sortedScores[j + 1];
                            sortedScores[j + 1] = swapString;
                        }
                    }
                }
                return sortedScores;
            }
            return null;
        }


        //Actions
        protected void ClickToBack(object sender, EventArgs e)
        {
            ClickBack(this, e);
        }
    }
}