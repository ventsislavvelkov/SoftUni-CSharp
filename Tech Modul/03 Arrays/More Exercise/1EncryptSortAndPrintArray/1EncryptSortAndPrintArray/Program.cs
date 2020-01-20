using System;
using System.Linq;

namespace _1EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] output = new int[n];
            int counter = 0;

            while (counter != n)
            {             
                char[] name = Console.ReadLine().ToArray();

                int nameLenght = name.Length;
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    char check = name[i];
                  
                    if (check == 'a' || check == 'o' || check == 'e' || check == 'i' || check == 'u')
                    {
                        sum += (check * nameLenght);                     
                    }
                    else if (check == 'A' || check == 'O' || check == 'E' || check == 'I'|| check == 'U')
                    {
                        sum += (check * nameLenght);                 
                    }
                    else
                    {
                        sum += check / nameLenght;                  
                    }
                }
                output[counter] = sum;
                counter++;
                sum = 0;               
           }

            Array.Sort(output);

            foreach (var item in output)
            {
                Console.WriteLine(item + " ");
            }
        }
    }
}
