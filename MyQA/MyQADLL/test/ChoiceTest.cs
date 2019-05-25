using NUnit.Framework;
using System.IO;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class ChoiceTest
    {
        static readonly string path = "../../Resources/answer.txt";

        [Test()]
        public void TestLoadChoice()
        {
            //Load choice for question 1;
            Choice choice = new Choice(1);
            choice.LoadChoice(path);
            int actualResult = choice.ListChoice.Count;
            Assert.AreEqual(4, actualResult);
        }

        [Test()]
        public void TestCorrectAnswer()
        {
            //Load choice for question 1;
            Choice choice = new Choice(1);
            Answer answer = new Answer(1);
            bool actualResult = false;

            choice.LoadChoice(path);

            foreach(string item in choice.ListChoice) {
                actualResult = answer.Check(item);
                if (actualResult)
                    break;
            }
            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void TestShuffleListChoice()
        {
            //Load choice for question 1;
            Choice choice = new Choice(1);
            Answer answer = new Answer(1);
            bool actualResult = false;

            choice.LoadChoice(path);

            foreach (string item in choice.ListChoice)
            {
                if (answer.Check(item)) {
                    if (choice.ListChoice.IndexOf(item) != 3){
                        actualResult = true;
                        break;
                    }
                }
            }
            Assert.IsTrue(actualResult);
        }

    }
}
