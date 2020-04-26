using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using P03Telephony.Comman;
using P03Telephony.Interfaces;

namespace P03Telephony.Model
{
    public class Smartphone : Interfaces.ICallable, Interfaces.IBrowseble
    {


        public Smartphone()
        {

        }

       public string Browser(string url)
        {
            if (url.Any(u => Char.IsDigit(u)))
            {
                throw new ArgumentException(GlobalExceptions.WrongUrlExceptionMessage);
            }

            return $"Browsing: {url}!";
        }

        public string  Call(string number)
        {
            if (number.Any(n=>Char.IsLetter(n)))
            {
                throw new ArgumentException(GlobalExceptions.WrongNumberExceptionMessage);
            }

            return $"Calling... {number}";
        }

    }
}
