using System;

namespace _01BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = int.Parse(Console.ReadLine());
            var countOfLectures = int.Parse(Console.ReadLine());
            var bonus = int.Parse(Console.ReadLine());

            var maxBonus = 0.0;
            var studentAttendance = 0.0;

            for (int i = 1; i <= students; i++)
            {
                var attendance = double.Parse(Console.ReadLine());

                var currnentbonus = Math.Ceiling((attendance / countOfLectures) * (5 + bonus));

                if (maxBonus <= currnentbonus)
                {
                    maxBonus = currnentbonus;
                    studentAttendance = attendance;
                }

            }

            Console.WriteLine($"Max Bonus: {(maxBonus)}.");
            Console.WriteLine($"The student has attended {studentAttendance} lectures.");
        }
    }
}
