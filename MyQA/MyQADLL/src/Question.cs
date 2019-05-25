using System;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public class Question
    {
        //Fields
        private int _id;
        private string _quest;
        private List<string> _choice;

        //Constructor
        public Question(int id, string quest)
        {
            _id = id;
            _quest = quest;
            _choice = null;
        }

        //Properties
        public string Quest { get => _quest; }
        public int QuestID { get => _id; }
        public List<string> Choice { get => _choice; }

        //Methods
        public void FindChoice(string path)
        {
            Choice choice = new Choice(QuestID);
            choice.LoadChoice(path);
            _choice = choice.ListChoice;
        }
    }
}
