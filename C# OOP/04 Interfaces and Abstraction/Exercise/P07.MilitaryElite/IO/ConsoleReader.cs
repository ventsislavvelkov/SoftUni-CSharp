using System;
using System.Collections.Generic;
using System.Text;
using P07.MilitaryElite.IO.Constracts;

namespace P07.MilitaryElite.IO
{
   public  class ConsoleReader :IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
