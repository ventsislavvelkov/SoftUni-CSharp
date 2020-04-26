using System;
using P03Telephony.Core;

namespace P03Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
