using NUnit.Framework;
using System;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class BotTest
    {
        public QAGenerator SetUp()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();
            generator.SelectQuestion();
            return generator;
        }

        private float CalculateNeuRon(int pow, float perc)
        {
            float result = 4;
            for (int i = 1; i < pow; i++)
            {
                result *= 4;
            }
            return result * perc;
        }

        [Test()]
        public void TestInitBot()
        {
            QAGenerator generator = SetUp();

            Bot bot1 = new Bot(generator, BotLevel.Easy);
            Bot bot2 = new Bot(generator, BotLevel.Medium);
            Bot bot3 = new Bot(generator, BotLevel.Hard);

            Assert.IsEmpty(bot1.Neurons);
            Assert.IsEmpty(bot2.Neurons);
            Assert.IsEmpty(bot3.Neurons);

            Assert.AreEqual(BotLevel.Easy, bot1.Mode);
            Assert.AreEqual(BotLevel.Medium, bot2.Mode);
            Assert.AreEqual(BotLevel.Hard, bot3.Mode);
        }

        [Test()]
        public void LoadBotTest()
        {
            QAGenerator generator = SetUp();
            int numNeuronEasy = 0;
            int numNeuronMedium = 0;
            int numNeuronHard = 0;

            numNeuronEasy = (int)CalculateNeuRon(5, 0.1f);
            numNeuronMedium = (int)CalculateNeuRon(5, 0.25f);
            numNeuronHard = (int)CalculateNeuRon(5, 0.5f);

            Bot bot1 = new Bot(generator, BotLevel.Easy);
            Bot bot2 = new Bot(generator, BotLevel.Medium);
            Bot bot3 = new Bot(generator, BotLevel.Hard);

            bot1.Load();
            bot2.Load();
            bot3.Load();

            Assert.AreEqual(numNeuronEasy, bot1.Neurons.Count);
            Assert.AreEqual(numNeuronMedium, bot2.Neurons.Count);
            Assert.AreEqual(numNeuronHard, bot3.Neurons.Count);


            Assert.IsTrue(bot1.Score >= 0);
            Assert.IsTrue(bot2.Score >= 0);
            Assert.IsTrue(bot3.Score >= 0);
        }
    }
}
