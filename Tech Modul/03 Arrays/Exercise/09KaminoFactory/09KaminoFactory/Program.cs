using System;

using System.Linq;


namespace _09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int longestSubsequence = -1;
            int longestSubSum = -1;
            int longestSubIndex = -1;
            int indexOfSequence = 1;
            int longestIndex = 0;
            int[] printArr = new int[length];
            string command = Console.ReadLine();

            while (command != "Clone them!")
            {
                int counter = 0;
                int subSequence = 0;
                int subIndex = -1;
                int subSum = 0;
                int[] arr = command.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 1)
                    {

                        counter++;
                        subSum++;
                    }
                    else
                    {
                        if (counter > subSequence)
                        {
                            subSequence = counter;
                            subIndex = i - counter;
                        }
                        counter = 0;
                    }
                }

                if (subSequence > longestSubsequence)
                {
                    longestSubIndex = subIndex;
                    longestSubsequence = subSequence;
                    longestSubSum = subSum;
                    printArr = arr;
                    longestIndex = indexOfSequence;
                }
                else if (subSequence == longestSubsequence && longestSubIndex > subIndex)
                {
                    longestSubIndex = subIndex;
                    longestSubsequence = subSequence;
                    longestSubSum = subSum;
                    longestIndex = indexOfSequence;
                    printArr = arr;
                }
                else if (subSequence == longestSubsequence && longestSubIndex == subIndex && longestSubSum < subSum)
                {

                    longestSubSum = subSum;
                    longestIndex = indexOfSequence;
                    printArr = arr;
                }

                indexOfSequence++;
                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample { longestIndex} with sum: { longestSubSum}.");
            Console.WriteLine(String.Join(" ", printArr));
        }
    }
}