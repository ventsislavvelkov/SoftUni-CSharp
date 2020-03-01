using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _07StringExplosion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var  explosion = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (explosion > 0 && input[i] != '>')
                {
                    input = input.Remove(i, 1);     
                    explosion--;        
                    i--;                          
                }
                else if (input[i] == '>')
                {
                    explosion += int.Parse(input[i + 1].ToString());     
                }
            }

            Console.WriteLine(input);
        }
    }
}
