using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P05DirectoryTraversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var directory = "./";
            var files = Directory.GetFiles(directory);

            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var fileExtension = fileInfo.Extension;
                var fileName = fileInfo.Name;
                var fileLength = fileInfo.Length;

                if (dictionary.ContainsKey(fileExtension))
                {
                    dictionary[fileExtension].Add(fileName, fileLength);
                }
                else
                {
                    var secondDictionary = new Dictionary<string, double>();

                    secondDictionary.Add(fileName, fileLength);
                    dictionary.Add(fileExtension, secondDictionary);
                }
            }

            var writer = new StreamWriter("C:\\Users\\Public\\Desktop\\report.txt");
            using (writer)
            {
                var filteredDictionary = dictionary
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);

                foreach (var keyValue in filteredDictionary)
                {
                    writer.WriteLine(keyValue.Key);

                    foreach (var kvp in keyValue.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine("--" + kvp.Key + " - {0:F3}kb", kvp.Value / 1024);
                    }
                }
            }
        }
    }
}
