using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace P01_RawData
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;

        }
        public int  Speed { get; }
        public int  Power { get; }

    }
}
