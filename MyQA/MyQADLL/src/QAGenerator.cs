using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MyQADLL.src
{
    public class QAGenerator : IHaveGenerator
    {
        //Fields
        private List<Question> _listQuestion;
        private string _textFile = "../../Resources/question.txt";
        private string _textFileOfChoice = "../../Resources/answer.txt";
        private string _textFileOfAnswer = "../../Resources/correctAnswer.txt";

        //Constructors
        public QAGenerator()
        {
            _listQuestion = new List<Question>();
        }

        //Properties
        public List<Question> ListQuestion { get => _listQuestion; }
        public string TextFile { get => _textFile; set => _textFile = value; }
        public string TextFileOfChoice { get => _textFileOfChoice; set => _textFileOfChoice = value; }
        public string TextFileOfAnswer { get => _textFileOfAnswer; set => _textFileOfAnswer = value; }

        //Methods
        public void LoadQuestion()
        {
            //Load the file and then update _answer based on FetchID
            if (File.Exists(_textFile))
            {
                string[] lines = File.ReadAllLines(_textFile);

                foreach (string line in lines)
                {
                    string[] l = line.Split(new char[] { ',' });
                    Question q = new Question(Convert.ToInt32(l[0]), l[1]);
                    q.FindChoice(_textFileOfChoice, _textFileOfAnswer);
                    _listQuestion.Add(q);
                }
            }
        }

        public void SelectQuestion()
        {
            //Using Linq framework to shuffle the whole list of ID
            _listQuestion = ListQuestion.OrderBy(a => Guid.NewGuid()).ToList();

            //Select only 5 first questions.
            if (_listQuestion.Count > 5){
                _listQuestion.RemoveRange(5, _listQuestion.Count - 5);
            }
        }

        public Boolean CheckAnswer(int answerID, string choice)
        {
            Answer answer = new Answer(answerID, _textFileOfAnswer);
            return answer.Check(choice);
        }
    }
}
