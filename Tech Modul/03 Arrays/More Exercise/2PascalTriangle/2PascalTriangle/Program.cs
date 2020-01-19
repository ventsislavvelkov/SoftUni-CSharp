using System;

namespace _2PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int[] arr = new int[n];
            int[] currentArr = new int[n];

            while (counter != n)
            {
                counter++;
                currentArr = new int[counter];
                currentArr[0] = 1;
                Console.Write(currentArr[0] + " ");
                currentArr[counter - 1] = 1;

                if (currentArr.Length > 2 )
                {
                    
                    for (int i = 1; i < counter -1; i++)
                    {
                        currentArr[i] = arr[i-1] + arr[i];
                        Console.Write(currentArr[i] + " " );
                    }



                }
                if (counter > 1)
                {
                    Console.WriteLine(currentArr[counter - 1] + " ");
                    foreach (var num in currentArr)
                    {
                        arr = currentArr;
                      
                    }
                  
                }
                if (counter == 1)
                {
                    Console.WriteLine();
                }
                
            }

        }
    }
}
