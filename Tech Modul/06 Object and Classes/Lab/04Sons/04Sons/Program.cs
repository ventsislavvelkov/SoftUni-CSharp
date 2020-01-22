﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Sons
{
    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }





        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());


            List<Song> songs = new List<Song>();

            for (int i = 0; i < numSongs; i++)
            {
                string[] input = Console.ReadLine().Split("_");

                string type = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

        }
    }
}

