﻿using System;
using Gtk;

namespace MyQAGUI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            Application.Run();
        }
    }

}
