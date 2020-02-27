using System;
using System.ComponentModel.DataAnnotations;

namespace _03ExtractFile
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var file = Console.ReadLine().Split(@"\");

            var lastFile = file[file.Length - 1];

            var lastNameLenght = lastFile.IndexOf('.');

            var name = lastFile.Substring(0, lastNameLenght);
            var extension = lastFile.Substring(lastNameLenght + 1, (lastFile.Length-1 - lastNameLenght));

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");

        }
    }
}
