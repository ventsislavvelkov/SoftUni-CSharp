using System;

namespace _04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isValidBetween6And10 = CheckLength(password);

            if (isValidBetween6And10 == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool isValidDigitsAndLetters = OnlyDigitsAndLetters(password);

            if (isValidDigitsAndLetters == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool isValidMin2Digits = CheckMinDigits(password);

            if (isValidMin2Digits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isValidBetween6And10 && isValidDigitsAndLetters && isValidMin2Digits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckMinDigits(string password)
        {
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (char.IsDigit(symbol))
                {
                    counter++;
                }
            }

            return counter >= 2 ? true : false;
        }

        private static bool OnlyDigitsAndLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;
        }
    }
}
