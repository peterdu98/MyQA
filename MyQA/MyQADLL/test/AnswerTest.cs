using NUnit.Framework;
using System;
using MyQADLL.src;

namespace MyQADLL.test
{
    [TestFixture()]
    public class AnswerTest
    {

        [Test()]
        public void CheckTrueAnswerTest()
        {
            //The correct answer for Question 1
            Answer _answer = new Answer(1);
            string textAnswer = "TAFE Building";
            bool actualResult = _answer.Check(textAnswer);
            Assert.IsTrue(actualResult);
        }

        [Test()]
        public void CheckFalseAnswerTest()
        {
            //The correct answer for Question 2, but the choice is uncorrect
            Answer _answer = new Answer(2);
            string textAnswer = "TAFE Building";
            bool actualResult = _answer.Check(textAnswer);
            Assert.IsFalse(actualResult);
        }
    }
}
