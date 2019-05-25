using NUnit.Framework;
using System;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class QuestionTest
    {
        static readonly string choicePath = "../../Resources/answer.txt";
        static readonly string answerPath = "../../Resources/correctAnswer.txt";

        [Test()]
        public void TestInitQuestion()
        {
            Question q = new Question(1, "What are TA-TB-TC-TD buildings known for?");
            bool actualResult = true;

            if(q.QuestID != 1) { actualResult = false; }
            if (q.Quest != "What are TA-TB-TC-TD buildings known for?") { actualResult = false; }
            if (q.Choice != null) { actualResult = false; }

            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void TestFindChoice()
        {
            Question q = new Question(1, "What are TA-TB-TC-TD buildings known for?");
            bool actualResult = true;

            q.FindChoice(choicePath, answerPath);

            if(q.Choice == null) { actualResult = false; }
            if (q.Choice.Count != 4) { actualResult = false; }

            Assert.IsTrue(actualResult);
        }
    }
}
