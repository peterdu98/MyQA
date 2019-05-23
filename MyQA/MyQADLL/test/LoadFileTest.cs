using NUnit.Framework;
using System.IO;
namespace MyQADLL.test
{
    [TestFixture()]
    public class LoadFileTest
    {
        static readonly string answerFile = "../../Resources/correctAnswer.txt";
        static readonly string choiceFile = "../../Resources/answer.txt";
        static readonly string questionFile = "../../Resources/question.txt";
        static readonly string playerFile = "../../Resources/player.txt";
        static readonly string playerFileTest = "../../Resources/test/player-test.txt";

        [Test()]
        public void TestFileExists()
        {
            bool actualResult = true;
            if (!File.Exists(answerFile)) { actualResult = false; }
            if (!File.Exists(choiceFile)) { actualResult = false; }
            if (!File.Exists(questionFile)) { actualResult = false; }
            if (!File.Exists(playerFile)) { actualResult = false; }
            if (!File.Exists(playerFileTest)) { actualResult = false; }

            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void TestReadableFile()
        {
            string[] answerLines = File.ReadAllLines(answerFile);
            string[] choicelines = File.ReadAllLines(choiceFile);
            string[] questionlines = File.ReadAllLines(questionFile);
            Assert.IsNotEmpty(answerLines);
            Assert.IsNotEmpty(choicelines);
            Assert.IsNotEmpty(questionlines);
        }
    }
}
