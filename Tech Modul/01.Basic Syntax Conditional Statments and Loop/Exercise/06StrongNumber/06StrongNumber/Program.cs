using System;

namespace _06StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string factorial = number.ToString();
            int totalSum = 0;
            int localSum = 1;
            
       
          
            

          for (int i = 0; i < factorial.Length; i++)
            {
             int currentNumber = 0;
             int.TryParse(factorial[i].ToString(), out currentNumber);
             

                for (int y = 1; y <= currentNumber; y++)
                {
                    localSum = localSum * y;
                }
                totalSum += localSum;
                localSum = 1;
            }
            if (totalSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
