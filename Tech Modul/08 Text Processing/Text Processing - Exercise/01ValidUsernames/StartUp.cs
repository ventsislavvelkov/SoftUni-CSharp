using System;

namespace _01ValidUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var username = Console.ReadLine().Split(", ");

            for (int i = 0; i < username.Length; i++)
            {
                var currentUsername = username[i];

                var isValid = true;
                var isCondentValid = true;
                if (currentUsername.Length < 3 || currentUsername.Length > 16)
                {
                    isValid = false;
                }

                for (int j = 0; j < currentUsername.Length; j++)
                {
                    var currentSumbol = currentUsername[j];
                    if (!char.IsLetterOrDigit(currentSumbol) && currentSumbol != '-' && currentSumbol !='_')
                    {
                        isCondentValid = false;
                        break;
                    }
                }

                if (isCondentValid && isValid)
                {
                    Console.WriteLine(currentUsername);
                }
               
            }
        }
    }
}
