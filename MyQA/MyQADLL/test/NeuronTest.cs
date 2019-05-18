using NUnit.Framework;
using System;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class NeuronTest
    {
        public QAGenerator SetUp()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();
            generator.SelectQuestion();
            return generator;
        }

        [Test()]
        public void TestInitNeuron()
        {
            QAGenerator generator = SetUp();
            Neuron neuron = new Neuron(generator.ListQuestion);
            int totalChoices = 0;

            foreach(Question q in neuron.Input) {
                totalChoices += q.Choice.Count;
            }

            Assert.AreEqual(0, neuron.Score);
            Assert.AreEqual(5, neuron.Input.Count);
            Assert.AreEqual(20, totalChoices);
        }

        [Test()]
        public void RunNeuronTest()
        {
            QAGenerator generator = SetUp();
            Neuron neuron = new Neuron(generator.ListQuestion);
            bool actutalOutputIndex0 = true;
            string actutalOutputIndex1 = "";

            neuron.Run();

            //Check choices in Question and Selected choice
            for(int i = 0; i < 5; i++)
            {
                if (!generator.ListQuestion[0].Choice.Contains(neuron.OutPut[0][0]))
                {
                    actutalOutputIndex0 = false;
                    break;
                }
            }

            //Check encoded choices
            foreach(string[] choice in neuron.OutPut) {
                actutalOutputIndex1 += choice[1];
            }

            Assert.IsTrue(neuron.Score >= 0);
            Assert.AreEqual(5, neuron.OutPut.Count);
            Assert.IsTrue(actutalOutputIndex0);
            Assert.AreEqual(5, actutalOutputIndex1.Length);
        }

    }
}
