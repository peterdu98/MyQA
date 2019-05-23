using NUnit.Framework;
using System.IO;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class QAGeneratorTest
    {
        static readonly string questionFile = "../../Resources/question.txt";

        [Test()]
        public void QAGeneratorInitTest()
        {
            QAGenerator generator = new QAGenerator();
            Assert.IsEmpty(generator.ListQuestion);
        }

        [Test()]
        public void LoadQuestionTest()
        {
            QAGenerator generator = new QAGenerator();
            string[] lines = File.ReadAllLines(questionFile);
            bool actualResult = false;

            generator.LoadQuestion();
            if (generator.ListQuestion.Count == lines.Length) { actualResult = true; }

            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void QuestionContainsChoiceTest()
        {
            QAGenerator generator = new QAGenerator();
            string[] lines = File.ReadAllLines(questionFile);
            bool actualResult = true;

            generator.LoadQuestion();
            foreach(Question q in generator.ListQuestion) {
                if (q.Choice.Count != 4) {
                    actualResult = false;
                }
            }

            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void SelectQuestionTest()
        {
            QAGenerator generator = new QAGenerator();
            bool actualResult = false;

            generator.LoadQuestion();
            generator.SelectQuestion();
            if (generator.ListQuestion.Count <= 5) { actualResult = true; }

            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void CheckAnswerTest()
        {
            //Check the answer for question 1
            QAGenerator generator = new QAGenerator();
            bool actualResult = generator.CheckAnswer(1, "TAFE Building");

            Assert.IsTrue(actualResult);
        }
    }
}
