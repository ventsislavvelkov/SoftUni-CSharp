using System;
using P07.MilitaryElite.Core;
using P07.MilitaryElite.IO;
using P07.MilitaryElite.IO.Constracts;

namespace P07.MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine  engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
