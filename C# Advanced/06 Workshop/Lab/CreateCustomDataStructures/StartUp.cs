using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace CreateCustomDataStructures
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }


            Debug.Assert(list[2] == 2);
            list.RemoveAt(2);
            Debug.Assert(list[2] == 3);
            list.Reversе();
            Debug.Assert(list[1] == 8);

            Console.WriteLine(list.ToString());
        }
    }
}
