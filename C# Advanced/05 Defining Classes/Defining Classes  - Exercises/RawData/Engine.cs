using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public int EngineSpeed
        {
            get { return this.engineSpeed; }
            set { this.engineSpeed = value; }
        }

        public int EnginePower
        {
            get { return this.enginePower; }
            set { this.enginePower = value; }
        }

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
    }
}
