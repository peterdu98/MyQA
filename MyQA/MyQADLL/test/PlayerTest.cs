using NUnit.Framework;
using System;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class PlayerTest
    {
        static readonly string textFile = "../../Resources/test/player-test.txt";

        [Test()]
        public void TestInitPlayer()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");

            Assert.AreEqual(0, p.Score);
            Assert.AreEqual("Peter", p.Name);
            Assert.IsNotEmpty(p.ListQuestion);
        }

        [Test()]
        public void SelectedChoiceTest()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");
            p.SelectChoice("TAFE Building");

            Assert.AreEqual("TAFE Building", p.SelectedChoice);
        }

        [Test()]
        public void CorrectScoreTest()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");
            bool reset = false;
            p.IsCorrect = true;
            p.CountScore(reset);

            Assert.AreEqual(1, p.Score);
        }

        [Test()]
        public void InCorrectNegativeScoreTest()
        {
            // 0 - 1 = 0 (Non-negative score)
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");
            bool reset = false;
            p.CountScore(reset);

            Assert.AreEqual(0, p.Score);
        }

        [Test()]
        public void InCorrectPositiveScoreTest()
        {
            // 1 + 1 - 1 = 1
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");
            bool reset = false;
            p.IsCorrect = true;
            p.CountScore(reset);
            p.IsCorrect = true;
            p.CountScore(reset);
            p.CountScore(reset);

            Assert.AreEqual(1, p.Score);
        }

        [Test()]
        public void CheckCorrectAnswerTest()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");
            p.SelectChoice("TAFE Building");

            bool actualResult = generator.CheckAnswer(1, p.SelectedChoice);

            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void CheckInCorrectAnswerTest()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Peter");
            p.SelectChoice("Art Building");

            bool actualResult = generator.CheckAnswer(1, p.SelectedChoice);

            Assert.IsFalse(actualResult);
        }

        [Test()]
        public void SaveAndReadFileTest()
        {
            //Test Player(Wunder) - Score 1
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            bool reset = false;
            Player p = new Player(generator, "Wunder");
            p.TextFile = textFile;
            p.IsCorrect = true;
            p.CountScore(reset);
            p.SaveTo();

            string actualResult = p.ReadScoreFromFile();
            string expectedResult = "Welcome back, Wunder! Your highest score is 1";
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test()]
        public void ReadFileTest()
        {
            QAGenerator generator = new QAGenerator();
            generator.LoadQuestion();

            Player p = new Player(generator, "Bean");

            string actualResult = p.ReadScoreFromFile();
            string expectedResult = "Hello Bean! You look like new here.";
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
