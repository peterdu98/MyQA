using System;
using MyQADLL.src;

using Gtk;

public partial class MainWindow : Gtk.Window
{
    //Fields
    private Player _p;
    private QAGenerator _generator;
    private Bot _bot;
    private MyQA.view.OpeningScreen _titleScreen;
    private MyQA.view.HistoryScreen _historyScreen;
    private MyQA.view.LevelScreen _levelScreen;
    private MyQA.view.QuestionScreen _questionScreen;

    //Constrtuctor
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        _generator = new QAGenerator();
        _generator.LoadQuestion();
        _generator.SelectQuestion();

        Build();

        _titleScreen = new MyQA.view.OpeningScreen();
        _historyScreen = new MyQA.view.HistoryScreen();
        Add(_titleScreen);
        _titleScreen.ClickHistory += (sender, e) => AddHistoryScreen();
        _titleScreen.ClickPlay += (sender, e) => AddLevelScreen();
        _historyScreen.ClickBack += (sender, e) => BackToTitleScreen();
    }

    //Methods
    private void AddHistoryScreen()
    {
        Remove(_titleScreen);
        Add(_historyScreen);
    }
    private void BackToTitleScreen()
    {
        Remove(_historyScreen);
        Add(_titleScreen);
    }
    private void AddLevelScreen()
    {
        if (_titleScreen.UserName != null)
        {
            _p = new Player(_generator, _titleScreen.UserName);
            _levelScreen = new MyQA.view.LevelScreen(_p);
            Remove(_titleScreen);
            Add(_levelScreen);
            _levelScreen.ClickEasy += (sender, e) => EasyBot();
            _levelScreen.ClickMedium += (sender, e) => MediumBot();
            _levelScreen.ClickHard += (sender, e) => HardBot();
        }
    }
    private void EasyBot() {
        _bot = new Bot(_generator, BotLevel.Easy);
        AddQuestionScreen();
    }
    private void MediumBot() {
        _bot = new Bot(_generator, BotLevel.Medium);
        AddQuestionScreen();
    }
    private void HardBot() {
        _bot = new Bot(_generator, BotLevel.Hard);
        AddQuestionScreen();
    }
    private void AddQuestionScreen() {
        _questionScreen = new MyQA.view.QuestionScreen();
        Remove(_levelScreen);
        Add(_questionScreen);
    }

    //Actions
    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }


}
