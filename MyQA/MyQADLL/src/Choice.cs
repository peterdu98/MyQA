using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MyQADLL.src
{
    public class Choice : Answer
    {
        //Fields
        private String _actualAnswer;
        private List<string> _listChoice;

        //Constructor
        public Choice(int id) : base(id)
        {
            _actualAnswer = base.Answ;
            _listChoice = new List<string>();
        }

        //Property
        public List<string> ListChoice { get => _listChoice; }
       
        //Method
        public void LoadChoice(string path)
        {
            //Load the file and then update _listChoice based on id
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] l = line.Split(new char[] { ',' });
                    if (Convert.ToInt32(l[0]) == FetchID)
                    {
                        ListChoice.Add(l[1]);
                    }
                }
            }

            //Add the correct answer after loading
            ListChoice.Add(_actualAnswer);

            //Shuffle ListChoice
            ShuffleListChoice();
        }

        private void ShuffleListChoice()
        {
            //Using Linq framework
            do
            {
                _listChoice = ListChoice.OrderBy(a => Guid.NewGuid()).ToList();
            } while (_listChoice.Last() == Answ);
        }
    }
}
