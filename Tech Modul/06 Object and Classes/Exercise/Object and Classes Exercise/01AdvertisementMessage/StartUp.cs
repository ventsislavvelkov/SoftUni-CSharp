using System;
using System.Collections.Generic;

namespace _01AdvertisementMessage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phrases = new List<string> { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            var events = new List<string> { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            var authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            var cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            var numberOfMessages = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            for (int i = 0; i < numberOfMessages; i++)
            {
                var randomIndex = rnd.Next(0, numberOfMessages + 1);
                Console.WriteLine($"{phrases[randomIndex]} {events[randomIndex]} {authors[randomIndex]} - {cities[randomIndex]}");
            }
        }
    }
}
