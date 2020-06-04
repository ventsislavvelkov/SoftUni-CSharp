using System;
using System.IO;
using System.Linq;

namespace P01EvenLines
{
    public class StartUp
    {
      public  static void Main(string[] args)
        {
            var reader = new StreamReader(@"..\..\..\files\input.txt"
            );

            using (reader)
            {
                var counter = 0;
                var line = reader.ReadLine();

                var symbolsToReplace = new string[] { "-", ",", ".", "!", "?" };

                using (var writer = new StreamWriter(@"..\..\..\files\output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 0)
                        {
                            foreach (var symbol in symbolsToReplace)
                            {
                                if (line.Contains(symbol))
                                {
                                    line = line.Replace(symbol, "@");
                                }
                            }

                            line = string.Join(" ", line.Split(" ").Reverse());
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
