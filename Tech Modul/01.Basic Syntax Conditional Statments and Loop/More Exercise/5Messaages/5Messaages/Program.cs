using System;

namespace _5Messaages
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string number = Console.ReadLine();
            int countNumbers = 0;
            int firstNumber = 0;
            int offset = -1;
            int sum = 0;
            int asc = 97;
            char print;


            while (counter != 0)
            {
                countNumbers = number.Length;
                firstNumber = int.Parse(number.Substring(0, 1));


                if (firstNumber == 8 || firstNumber == 9)
                {
                    sum = (asc + countNumbers + ((firstNumber - 2) * 3));
                }
                else if (firstNumber == 2)
                {
                    sum = (asc + (firstNumber - 2) + countNumbers - 1);

                }
                else if (firstNumber == 0 )
                {
                    sum = 32;
                }
                else
                {
                    sum = (asc + countNumbers - 1 + ((firstNumber - 2) * 3));
                }

                print = Convert.ToChar(sum);
                Console.Write(print);
                counter--;

                number = Console.ReadLine();
            }
        }
    }
}
