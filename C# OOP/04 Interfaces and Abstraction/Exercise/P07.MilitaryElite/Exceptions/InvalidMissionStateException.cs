using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string DEF_STATE_EXC = "Invalid mission state!";
        public  InvalidMissionStateException()
        :base(DEF_STATE_EXC)
        {
           
        }
        public  InvalidMissionStateException(string message)
        :base()
        {
            
        }

    }
}
