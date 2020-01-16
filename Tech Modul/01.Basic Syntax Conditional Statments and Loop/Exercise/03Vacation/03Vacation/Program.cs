using System;

namespace _03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine());
            string typeOfPerson = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double sum = 0;

            if (dayOfWeek == "Friday")
            {
                if (typeOfPerson == "Students")
                {
                    if (persons >=30)
                    {
                        sum = (persons * 8.45)* 0.85;
                    }
                    else
                    {
                        sum = persons * 8.45;
                    }
                }
                else if (typeOfPerson == "Business")
                {
                    if (persons >= 100)
                    {
                        sum = (persons-10) * 10.90;
                    }
                    else
                    {
                        sum = persons * 10.90;
                    }
                }
                else if (typeOfPerson == "Regular")
                {
                    if (persons >= 10 && persons <= 20)
                    {
                        sum = (persons * 15) * 0.95;
                    }
                    else
                    {
                        sum = persons * 15;
                    }

                }
            }
            else if (dayOfWeek == "Saturday")
            {
                if (typeOfPerson == "Students")
                {
                    if (persons >= 30)
                    {
                        sum = (persons * 9.80) * 0.85;
                    }
                    else
                    {
                        sum = persons * 9.80;
                    }
                }
                else if (typeOfPerson == "Business")
                {
                    if (persons >= 100)
                    {
                        sum = (persons - 10) * 15.60;
                    }
                    else
                    {
                        sum = persons * 15.60;
                    }
                }
                else if (typeOfPerson == "Regular")
                {
                    if (persons >= 10 && persons <= 20)
                    {
                        sum = (persons * 20) * 0.95;
                    }
                    else
                    {
                        sum = persons * 20;
                    }

                }
            }
            else if (dayOfWeek == "Sunday")
            {
                if (typeOfPerson == "Students")
                {
                    if (persons >= 30)
                    {
                        sum = (persons * 10.46) * 0.85;
                    }
                    else
                    {
                        sum = persons * 10.46;
                    }
                }
                else if (typeOfPerson == "Business")
                {
                    if (persons >= 100)
                    {
                        sum = (persons - 10) * 16;
                    }
                    else
                    {
                        sum = persons * 16;
                    }
                }
                else if (typeOfPerson == "Regular")
                {
                    if (persons >= 10 && persons <= 20)
                    {
                        sum = (persons * 22.50) * 0.95;
                    }
                    else
                    {
                        sum = persons * 22.50;
                    }
                }
                
            }
            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
