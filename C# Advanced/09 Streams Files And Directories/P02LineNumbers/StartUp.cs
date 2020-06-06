using System;
using System.IO;
using System.Text;

namespace P02LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader(@"..\..\..\files\text.txt");

            using (reader)
            { 
               var counterOfLines = 1;
                var counterOfLetters = 0;
                var counterOfMarks = 0;

                var line = reader.ReadLine();
                var sb = new StringBuilder();

                    while (line != null)
                    {
                        foreach (char letter in line)
                        {
                            if (char.IsLetter(letter))
                            {
                                counterOfLetters++;
                            }
                        }

                        foreach (char symbol in line)
                        {
                            if (char.IsPunctuation(symbol))
                            {
                                counterOfMarks++;
                            }
                        }
                        sb.AppendLine($"Line {counterOfLines}:{line} ({counterOfLetters})({counterOfMarks})");

                        counterOfLines++;
                        counterOfLetters = 0;
                        counterOfMarks = 0;

                        line = reader.ReadLine();
                    }

                    Console.WriteLine(sb.ToString());
            }
        }
    }
}
