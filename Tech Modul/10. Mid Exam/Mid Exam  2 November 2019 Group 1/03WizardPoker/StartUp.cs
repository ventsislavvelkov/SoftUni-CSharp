using System;
using System.Collections.Generic;
using System.Linq;

namespace _03WizardPoker
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var allCards = Console.ReadLine().Split(":").ToList();
            var finalCards = new List<string>();
            var isExist = false;
            var isValidIndex = false;

            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];

                if (command == "Ready")
                {
                    break;
                }
                else
                {
                    var name = input[1];
                    if (command == "Add")
                    {
                        isExist = IsExist(allCards, name);

                        if (isExist)
                        {
                            finalCards.Add(name);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                    }
                    else if (command == "Insert")
                    {
                        var index = int.Parse(input[2]);

                        isExist = IsExist(allCards, name);
                        isValidIndex = IsValidIndex(finalCards, index);

                        if (isExist && isValidIndex)
                        {
                            finalCards.Insert(index, name);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }

                    }
                    else if (command == "Remove")
                    {
                        isExist = IsExist(finalCards, name);
                    
                        if (isExist)
                        {
                            finalCards.Remove(name);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }

                    }
                    else if (command == "Swap")
                    {
                        var secondCard = input[2];

                        finalCards = SwapCards(finalCards, name, secondCard);

                    }
                    else if (command == "Shuffle")
                    {
                         finalCards.Reverse();
                    }
                }
            }

            Console.WriteLine(string.Join(" ", finalCards));
        }

        private static bool IsValidIndex(List<string> finalCards, in int index)
        {
            var isValidIndex = false;

            if (index >= 0 && index < finalCards.Count)
            {
                isValidIndex = true;
            }

            return isValidIndex;
        }

        private static List<string> SwapCards(List<string> finalCards, string firstName, string secondCard)
        {
            
            var firstIndex = finalCards.IndexOf(firstName);
            var secondIndex = finalCards.IndexOf(secondCard);

            for (int i = 0; i < finalCards.Count; i++)
            {
                if (i == firstIndex)
                {
                    finalCards[i] = secondCard;
                    finalCards[secondIndex] = firstName;
                    break;
                }
            }


            return finalCards;
        }

        private static bool IsExist(List<string> cards, string name)
        {
            var isExists = false;

            if (cards.Contains(name))
            {
                isExists = true;
            }

            return isExists;
        }
    }
}
