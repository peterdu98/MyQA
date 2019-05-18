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
        static readonly string textFile = "/Users/peterdu/Projects/C#/QACustomProgram/MyQA/MyQADLL/Resources/question.txt";

        //Constructors
        public QAGenerator()
        {
            _listQuestion = new List<Question>();
        }

        //Properties
        public List<Question> ListQuestion { get => _listQuestion; }

        //Methods
        public void LoadQuestion()
        {
            //Load the file and then update _answer based on FetchID
            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);

                foreach (string line in lines)
                {
                    string[] l = line.Split(new char[] { ',' });
                    Question q = new Question(Convert.ToInt32(l[0]), l[1]);
                    q.FindChoice();
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
            Answer answer = new Answer(answerID);
            return answer.Check(choice);
        }
    }
}
