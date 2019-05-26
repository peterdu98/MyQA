using System;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public class Bot : GameSource
    {
        //Fields
        private List<Neuron> _neurons;
        private BotLevel _mode;
        private IHaveGenerator _generator;

        //Constructor
        public Bot(QAGenerator generator, BotLevel mode) : base(generator)
        {
            _mode = mode;
            _neurons = new List<Neuron>();
            _generator = generator;
        }

        //Properties
        public List<Neuron> Neurons { get => _neurons; }
        public BotLevel Mode { get => _mode; }
        
        //Methods
        public void Load()
        {
            int numNeuron = 0;
            switch (_mode)
            {
                case BotLevel.Easy:
                    numNeuron = Convert.ToInt32(CalculateNeuRon(0.1f));
                    break;
                case BotLevel.Medium:
                    numNeuron = Convert.ToInt32(CalculateNeuRon(0.25f));
                    break;
                case BotLevel.Hard:
                    numNeuron = Convert.ToInt32(CalculateNeuRon(0.5f));
                    break;
            }
            RunNeuron(numNeuron);
            base.score.Value = HandleNeuronScore();
        }

        //Calculate number of neuron needed
        private float CalculateNeuRon(float perc)
        {
            float result = 4;
            for (int i = 1; i < ListQuestion.Count; i++)
            {
                result *= 4;
            }
            return result * perc;
        }

        //Create a neuron for Bot
        private void RunNeuron(int numNeuron)
        {
            List<string> storeEncodedOutput = new List<string>();
            while (_neurons.Count < numNeuron)
            {
                string text = "";
                Neuron neuron = new Neuron(ListQuestion);
                neuron.Run(_generator);

                //Processing encoded output into a string (e.g "ABCD")
                foreach(string[] choice in neuron.OutPut) {
                    text += choice[1];
                }

                //Avoid duplicate neuron
                if (!storeEncodedOutput.Contains(text)) {
                    storeEncodedOutput.Add(text);
                    _neurons.Add(neuron);
                }
            }
        }

        //Processing score in each neuron
        private int HandleNeuronScore()
        {
            int max = 0;
            foreach(Neuron neuron in _neurons)
            {
                if (neuron.Score > max) { max = neuron.Score; }
                if (max == 5) { break; }
            }
            return max;
        }
    }
}
