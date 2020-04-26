using System;
using System.Collections.Generic;
using System.Text;
using P03Telephony.Model;

namespace P03Telephony.Core
{
    public class Engine
    {
        private readonly Smartphone smartPhone;
        private readonly StationaryPhone stationaryPhone;
        public Engine()
        {
            this.smartPhone = new Smartphone();
            this.stationaryPhone = new StationaryPhone();
        }
        public void Run()
        {

            var phoneNumber = Console.ReadLine().Split();
            var sites = Console.ReadLine().Split();

            foreach (var currNumber in phoneNumber)
            {
                try
                {
                    if (currNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(currNumber));

                    }
                    else
                    {
                        Console.WriteLine(smartPhone.Call(currNumber));

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            foreach (var currSite in sites)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browser(currSite));
                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
              
            }

        }
    }
}
