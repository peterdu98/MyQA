using System;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public abstract class GameSource
    {
        //Fields
        private QAGenerator _generator;
        private bool _isCorrect;
        protected string selectedChoice;
        protected Counter score;

        //Constructor
        public GameSource(QAGenerator generator)  
        {
            _generator = generator;
            _isCorrect = false;
            score = new Counter();
            selectedChoice = null;
        }

        //Properties
        public List<Question> ListQuestion { get => _generator.ListQuestion; }
        public string SelectedChoice { get => selectedChoice; }
        public int Score { get => score.Value; }
        public bool IsCorrect { get => _isCorrect; set => _isCorrect = value; }

        //Methods
        public abstract void SelectChoice(string choice);
        public abstract void CountScore(bool reset);
    }
}
