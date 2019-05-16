using System;
using System.IO;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public class Player : GameSource
    {
        //Fields
        private string _name;
        private string _textFile = "/Users/peterdu/Projects/C#/QACustomProgram/MyQA/MyQADLL/Resources/player.txt";
        
        //Constructor
        public Player(QAGenerator generator, string name) : base (generator) 
        {
            _name = name;
        }

        //Property
        public string Name { get => _name; }
        public string TextFile { get => _textFile; set => _textFile = value; }

        //Methods
        public override void SelectChoice(string choice)
        {
            selectedChoice = choice;
        }

        public override void CountScore(bool reset)
        {
            if (IsCorrect) { score.Increment(); }
            else { score.Decrease(); }

            if (reset) { score.Reset(); }
            base.IsCorrect = false;
        }

        public void SaveTo()
        {
            //Search existing user
            if (File.Exists(_textFile))
            {
                string[] lines = File.ReadAllLines(_textFile);
                var listName = new List<string>();
                foreach (string line in lines) {
                    string[] l = line.Split(new char[] { ',' });
                    listName.Add(l[0]);
                }

                /*
                 * If not user, then append new line.
                 * Else overwrite the array and overwrite the wholefil                
                 */               
                if (!listName.Contains(this.Name)) {
                    try {
                        StreamWriter writer = new StreamWriter(_textFile, true);
                        writer.WriteLine(this.Name+","+this.Score);
                        writer.Close();
                    } catch (Exception e) {
                        Console.WriteLine("Exception in Player: " + e.Message);
                    } finally {
                        Console.WriteLine("Executing finally block in Player.");
                    }
                } else {
                    int index = listName.IndexOf(this.Name);
                    string[] line = lines[index].Split(new char[] { ',' });

                    //Current score > previous score
                    if (this.Score > Convert.ToInt32(line[1])) {
                        lines[index] = line[0] + "," + this.Score.ToString();
                    }
                    File.WriteAllLines(_textFile, lines);
                }
            }
        }

        public string ReadScoreFromFile()
        {
            string text = String.Format("Hello {0}! You look like new here.", this.Name);

            //Load the file and then search for user information
            if (File.Exists(_textFile))
            {
                string[] lines = File.ReadAllLines(_textFile);

                foreach (string line in lines)
                {
                    string[] l = line.Split(new char[] { ',' });
                    if (l[0] == this.Name) {
                        text = string.Format("Welcome back, {0}! Your highest score is {1}", l[0], l[1]);
                        break;
                    }
                }
            }
            return text;
        }
    }
}
