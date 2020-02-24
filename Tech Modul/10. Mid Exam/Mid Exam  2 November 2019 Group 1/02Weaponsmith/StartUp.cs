using System;
using System.Linq;

namespace _02Weaponsmith
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var nameOfWeapon = Console.ReadLine().Split("|");
            var isValid = false;

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                if (command == "Done")
                {
                    break;
                }
                else
                {
                    var secondComand = input[1];

                    if (command == "Move")
                    {
                        var index = int.Parse(input[2]);
                        var newIndex = 0;

                        if (secondComand == "Left")
                        {
                            isValid = IsValid(nameOfWeapon, index - 1);

                            if (isValid)
                            {
                                newIndex = -1;
                                nameOfWeapon = MoveDirection(nameOfWeapon, index, newIndex);
                            }

                        }
                        else
                        {
                            isValid = IsValid(nameOfWeapon, index + 1);

                            if (isValid)
                            {
                                newIndex = 1;
                                nameOfWeapon = MoveDirection(nameOfWeapon, index, newIndex);
                            }

                        }

                    }
                    else
                    {
                        if (secondComand == "Even")
                        {
                            for (int i = 0; i < nameOfWeapon.Length; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    Console.Write(nameOfWeapon[i] + " ");
                                }
                            }

                            Console.WriteLine();
                        }
                        else
                        {
                            for (int i = 0; i < nameOfWeapon.Length; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    Console.Write(nameOfWeapon[i] + " ");
                                }
                            }

                            Console.WriteLine();
                        }
                    }

                }
            }

            Console.WriteLine($"You crafted {string.Join("", nameOfWeapon)}!");
        }

        private static string[] MoveDirection(string[] nameOfWeapon, int index, int moveIndex)
        {

            var currentIndex = nameOfWeapon[index];
            var newIndex = nameOfWeapon[index + moveIndex];


            for (int i = 0; i < nameOfWeapon.Length; i++)
            {
                if (i == index)
                {
                    nameOfWeapon[i] = newIndex;
                    nameOfWeapon[index + moveIndex] = currentIndex;
                    break;
                }
            }

            return nameOfWeapon;
        }

        private static bool IsValid(string[] nameOfWeapon, in int index)
        {
            var isValid = false;

            if (index >= 0 && index < nameOfWeapon.Length)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
