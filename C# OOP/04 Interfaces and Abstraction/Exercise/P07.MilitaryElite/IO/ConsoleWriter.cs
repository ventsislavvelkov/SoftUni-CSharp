using System;
using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.IO.Constracts;

namespace P07.MilitaryElite.IO
{
    public class ConsoleWriter :IWriter
    {
        public void Write(string text)
        {
             Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
