using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TruckTour
{
    class Program
    {
        static void Main()
        {
            string[] inputSongs = Console.ReadLine().Split(", ").ToArray();

            Queue<string> queue = new Queue<string>(inputSongs);

            while (true)
            {
                string commandAndSong = Console.ReadLine();

                if (commandAndSong.Contains("Play") && queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else if (commandAndSong.Contains("Add"))
                {
                    string songs = commandAndSong.Substring(4, commandAndSong.Length - 4);

                    if (queue.Contains(songs))
                    {
                        Console.WriteLine($"{songs} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(songs);
                    }
                }
                else if (commandAndSong.Contains("Show") && queue.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                else if(queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
            }

        }
    }
}
