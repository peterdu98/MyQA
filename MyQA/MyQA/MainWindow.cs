using System;
using MyQADLL.src;
using System.Collections.Generic;

using Gtk;

public partial class MainWindow : Gtk.Window
{
    //Fields
    private Player _p;
    private QAGenerator _generator;
    private Bot _bot;
    private Counter _time;
    private int _questNo;
    private MyQA.view.OpeningScreen _titleScreen;
    private MyQA.view.HistoryScreen _historyScreen;
    private MyQA.view.LevelScreen _levelScreen;
    private List<MyQA.view.QuestionScreen> _questionScreen;

    //Constrtuctor
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        LoadFromMyQADLL();
        _questNo = 0;
        Build();
        _titleScreen = new MyQA.view.OpeningScreen();
        _historyScreen = new MyQA.view.HistoryScreen();
        Add(_titleScreen);
        _titleScreen.ClickHistory += (sender, e) => AddHistoryScreen();
        _titleScreen.ClickPlay += (sender, e) => AddLevelScreen();
        _historyScreen.ClickBack += (sender, e) => BackToTitleScreen();
        _questionScreen = new List<MyQA.view.QuestionScreen>();
    }

    //Methods
    private void LoadFromMyQADLL()
    {
        _generator = new QAGenerator();
        _generator.TextFile = "../../../MyQADLL/Resources/question.txt";
        _generator.TextFileOfChoice = "../../../MyQADLL/Resources/answer.txt";
        _generator.TextFileOfAnswer = "../../../MyQADLL/Resources/correctAnswer.txt";
        _generator.LoadQuestion();
        _generator.SelectQuestion();
        _time = new Counter();
    }
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
            _levelScreen.ClickEasy += (sender, e) => ConstructBot(BotLevel.Easy);
            _levelScreen.ClickMedium += (sender, e) => ConstructBot(BotLevel.Medium);
            _levelScreen.ClickHard += (sender, e) => ConstructBot(BotLevel.Hard);
        }
    }
    private void ConstructBot(BotLevel mode) 
    {
        _bot = new Bot(_generator, mode);
        _bot.Load();
        Remove(_levelScreen);
        AddQuestionScreen();
    }
    private void AddQuestionScreen() 
    {
        for(int i=0; i<_generator.ListQuestion.Count; i++) {
            _questionScreen.Add(new MyQA.view.QuestionScreen(_generator.ListQuestion[i]));
            _questionScreen[i].ClickChoice1 += (sender, e) => ClickChoice();
            _questionScreen[i].ClickChoice2 += (sender, e) => ClickChoice();
            _questionScreen[i].ClickChoice3 += (sender, e) => ClickChoice();
            _questionScreen[i].ClickChoice4 += (sender, e) => ClickChoice();
        }

        Add(_questionScreen[_questNo]);

        if(_questNo < 5){
            GLib.Timeout.Add(1000, new GLib.TimeoutHandler(UpdateTime));
        }
    }
    private bool UpdateTime()
    {
        if(_time.Value < 30) {
            _time.Increment();
        } else {
            //the Player chooses nothing
            if(_questionScreen[_questNo].SelectedChoice == null) {
                _p.SelectChoice("");
                _p.CountScore(false);
            }
            _time.Reset();
            _questNo++;
            Remove(_questionScreen[_questNo - 1]);
            Add(_questionScreen[_questNo]);
        }
        _questionScreen[_questNo].LabelText = _time.Value.ToString();
        _questionScreen[_questNo].ShowAll();
        return true;
    }
    private void ClickChoice()
    {
        _p.SelectChoice(_questionScreen[_questNo].SelectedChoice);
        _p.CountScore(false);
        _questNo++;
        _time.Value = 0;
        Remove(_questionScreen[_questNo - 1]);
        Add(_questionScreen[_questNo]);
    }

    //Actions
    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }


}
