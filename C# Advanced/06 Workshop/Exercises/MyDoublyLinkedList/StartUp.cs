using System;
using System.Threading.Channels;

namespace MyDoublyLinkedList
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new DoubleLinkedList<int>();

            for (int i = 1; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 1; i < 10; i++)
            {
                list.AddLast(i);
            }

            list.ForEach(x=> Console.Write(x + " "));

            Console.WriteLine();

            list.ToArray();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
} 
 