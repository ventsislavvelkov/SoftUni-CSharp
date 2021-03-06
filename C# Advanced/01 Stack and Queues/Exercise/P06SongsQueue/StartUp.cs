﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P06SongsQueue
{
    class StartUp
    {
        static void Main()
        {
            var inputSongs = Console.ReadLine().Split(", ").ToArray();
            var queue = new Queue<string>(inputSongs);

            while (true)
            {
                var commandAndSong = Console.ReadLine();

                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                if (commandAndSong.Contains("Play") && queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else if (commandAndSong.Contains("Add"))
                {
                    var songs = commandAndSong.Substring(4, commandAndSong.Length - 4);

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
            }
        }
    }
}
