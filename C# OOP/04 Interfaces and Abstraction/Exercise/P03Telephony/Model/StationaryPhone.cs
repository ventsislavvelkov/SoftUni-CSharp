using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P03Telephony.Comman;

namespace P03Telephony.Model
{
    public class StationaryPhone : Interfaces.ICallable
    {
        public StationaryPhone()
        {
            
        }

        public string Call(string number)
        {
            if (number.Any(n => Char.IsLetter(n)))
            {
                throw new ArgumentException(GlobalExceptions.WrongNumberExceptionMessage);
            }

            return $"Dialing... {number}";
        }
    }
}
