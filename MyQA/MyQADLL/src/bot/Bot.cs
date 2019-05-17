using System;
using System.Collections.Generic;

namespace MyQADLL.src
{
    public class Bot : GameSource
    {
        //Fields
        private BotBrain _brain;

        //Constructor
        public Bot(QAGenerator generator) : base(generator)
        {
            _brain = new BotBrain();
        }

        //Methods

    }
}
