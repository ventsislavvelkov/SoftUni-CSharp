using System;
using System.Threading.Channels;

namespace MyDoublyLinkedList
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new DoubleLinkedList();

            for (int i = 1; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 1; i < 10; i++)
            {
                list.AddLast(i);
            }

            list.ForEach(x=> Console.Write(x + " "));

            for (int i = 1; i < 10; i++)
            {
                list.ForEach(x=>Console.Write(x + " "));
            }
        }
    }
} 
 