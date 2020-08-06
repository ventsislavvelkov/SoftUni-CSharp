using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Core;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();

        }
    }
}
