using System;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public class Neuron 
    {
        //Fields
        private List<Question> _input;
        private List<string[]> _output;
        private int _score;
        private bool _isCorrect;

        //Constructor
        public Neuron(List<Question> listQ)
        {
            _input = listQ;
            _output = new List<string[]>();
            _score = 0;
            _isCorrect = false;
        }

        //Property
        public List<Question> Input { get => _input; }
        public List<string[]> OutPut { get => _output; }
        public int Score { get => _score; }

        //Methods
        public void Run(IHaveGenerator generator)
        {
            //choice index 1 is the encoded output
            Random random = new Random();
            string[] encodingOption = "A B C D".Split();

            foreach(Question q in _input){
                string[] choice = new string[2];
                int num = random.Next(0,4);
                choice[0] = q.Choice[num];
                choice[1] = encodingOption[num];

                _isCorrect = generator.CheckAnswer(q.QuestID, choice[0]);
                UpdateScore();

                _output.Add(choice);
            }
        }

        private void UpdateScore()
        {
            if (_isCorrect) {
                _score++;
            } else {
                if(_score != 0) {
                    _score--;
                }
            }
            _isCorrect = false;
        }
    }
}
