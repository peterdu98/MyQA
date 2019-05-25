using System;
using System.Collections.Generic;
using MyQADLL.src;
using Gtk;

namespace MyQA.view
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class QuestionScreen : Gtk.Bin
    {
        //Fields
        private Gdk.Pixbuf _background;
        private Question _q;
        private Label _label;
        private List<Button> _buttons;
        private string _selectedChoice;
        public event EventHandler ClickChoice1;
        public event EventHandler ClickChoice2;
        public event EventHandler ClickChoice3;
        public event EventHandler ClickChoice4;

        //Constructor
        public QuestionScreen(Question q)
        {
            _q = q;

            this.Build();

            LoadImageFromFile();
            LoadImageToScreen();
            CustomTimer();
            CustomQuestionText();
            CustomButton();
            ShowAll();
        }

        //Properties
        public string LabelText { get => _label.Text; set => _label.Text = value; }
        public string SelectedChoice { get => _selectedChoice; }

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
        private void CustomTimer()
        {
            _label = new Label();
            _label.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
            _label.ModifyFont(Pango.FontDescription.FromString("Arial 30"));
            _label.SetSizeRequest(200, 100);
            _label.SetUposition(300, 50);
            fixed3.Add(_label);
        }
        private void CustomQuestionText()
        {
            questionText.Buffer.Text = _q.Quest;
            questionText.ModifyBase(StateType.Normal, new Gdk.Color(255, 255, 102));
            questionText.ModifyFont(Pango.FontDescription.FromString("Arial 16"));
        }
        private void CustomButton()
        {
            _buttons = new List<Button>();
            _buttons.Add(choice1);
            _buttons.Add(choice2);
            _buttons.Add(choice3);
            _buttons.Add(choice4);

            for (int i = 0; i < _q.Choice.Count; i++){
                _buttons[i].Label = _q.Choice[i];
            }
            foreach(Button b in _buttons) {
                b.ModifyBg(StateType.Normal, new Gdk.Color(26, 83, 255));
                b.ModifyBg(StateType.Active, new Gdk.Color(0, 45, 179));
                b.ModifyBg(StateType.Prelight, new Gdk.Color(0, 45, 179));
                b.Child.ModifyFont(Pango.FontDescription.FromString("Arial 16"));
                b.Child.ModifyFg(StateType.Normal, new Gdk.Color(255, 255, 255));
                b.Child.ModifyFg(StateType.Active, new Gdk.Color(255, 255, 255));
                b.Child.ModifyFg(StateType.Prelight, new Gdk.Color(255, 255, 255));
            }
        }

        //Actions
        protected void ClickToChoice1(object sender, EventArgs e)
        {
            _selectedChoice = _q.Choice[0];
            ClickChoice1(this, e);
        }

        protected void ClickToChoice2(object sender, EventArgs e)
        {
            _selectedChoice = _q.Choice[1];
            ClickChoice2(this, e);
        }

        protected void ClickToChoice3(object sender, EventArgs e)
        {
            _selectedChoice = _q.Choice[2];
            ClickChoice3(this, e);
        }

        protected void ClickToChoice4(object sender, EventArgs e)
        {
            _selectedChoice = _q.Choice[3];
            ClickChoice4(this, e);
        }
    }
}
