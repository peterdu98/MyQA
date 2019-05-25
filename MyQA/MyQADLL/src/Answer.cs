using System;
using System.IO;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public class Answer
    {
        //Fields
        private string _answer;
        private int _fetchID;
        private string _textFile = "../../Resources/correctAnswer.txt";
        
        //Constructor
        public Answer(int id)
        {
            _fetchID = id;
            LoadAnswer();
        }
        public Answer(int id, string path)
        {
            _textFile = path;
            _fetchID = id;
            LoadAnswer();
        }

        //Properties
        protected string Answ { get => _answer; }
        protected int FetchID { get => _fetchID; set => _fetchID = value; }

        //Methods
        private void LoadAnswer()
        {
            //Load the file and then update _answer based on FetchID
            if (File.Exists(_textFile))
            {
                string[] lines = File.ReadAllLines(_textFile);

                foreach (string line in lines)
                {
                    string[] l = line.Split(new char[] { ',' });
                    if (Convert.ToInt32(l[0]) == FetchID)
                    {
                        _answer = l[1];
                    }
                }
            }
        }

        public Boolean Check(string choice)
        {
            bool result = false;
            LoadAnswer();
            if (choice == Answ)
                result = true;
            return result;
        }
    }
}
