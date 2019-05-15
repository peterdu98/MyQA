﻿using NUnit.Framework;
using System.IO;
namespace MyQADLL.test
{
    [TestFixture()]
    public class LoadFileTest
    {
        static readonly string answerFile = "/Users/peterdu/Projects/C#/QACustomProgram/MyQA/MyQADLL/Resources/correctAnswer.txt";
        static readonly string choiceFile = "/Users/peterdu/Projects/C#/QACustomProgram/MyQA/MyQADLL/Resources/answer.txt";
        static readonly string questionFile = "/Users/peterdu/Projects/C#/QACustomProgram/MyQA/MyQADLL/Resources/question.txt";

        [Test()]
        public void TestFileExists()
        {
            bool actualResult = true;
            if (!File.Exists(answerFile)) { actualResult = false; }
            if (!File.Exists(choiceFile)) { actualResult = false; }
            if (!File.Exists(questionFile)) { actualResult = false; }
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