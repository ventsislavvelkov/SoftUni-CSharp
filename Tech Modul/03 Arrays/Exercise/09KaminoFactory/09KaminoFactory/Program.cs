using System;
using System.Linq;

namespace _09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int bestSubsequence = 0;
            int[] bestDNA = new int[number];
            int bestIndex = 0;
            int bestSum = 0;

            int row = 0;
            int bestRow = 0;

            string input = "";

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] currentDNА = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int counter = 0;
                int subsequence = 0;
                int index = 0;
                int sum = 0;

                row++;

                for (int i = 0; i < currentDNА.Length; i++)
                {
                    if (currentDNА[i] == 1)
                    {
                        counter++;
                        sum++;
                        if (counter > subsequence)
                        {
                            subsequence = counter;
                            index = i;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }

                if (subsequence > bestSubsequence)
                {
                    bestSubsequence = subsequence;
                    bestDNA = currentDNА;
                    bestIndex = index;
                    bestSum = sum;
                    bestRow = row;
                }
                else if (subsequence == bestSubsequence && index < bestIndex)
                {
                    bestSubsequence = subsequence;
                    bestDNA = currentDNА;
                    bestIndex = index;
                    bestSum = sum;
                    bestRow = row;
                }
                else if (subsequence == bestSubsequence && index == bestIndex && bestSum < sum)
                {
                    bestSubsequence = subsequence;
                    bestDNA = currentDNА;
                    bestIndex = index;
                    bestSum = sum;
                    bestRow = row;
                }


            }

            Console.WriteLine($"Best DNA sample {bestRow} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDNA));

        }
    }
}
