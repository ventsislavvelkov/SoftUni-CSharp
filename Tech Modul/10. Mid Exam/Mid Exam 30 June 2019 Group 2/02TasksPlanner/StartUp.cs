using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _02TasksPlanner
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var task = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                var input = Console.ReadLine().Split();

                var command = input[0];
                var isIndexExists = false;

                if (command == "End")
                {
                    break;
                }
                else
                {
                    switch (command)
                    {
                        case "Complete":
                            var completeIndex = int.Parse(input[1]);
                            isIndexExists = IndexExists(task, completeIndex);
                            if (isIndexExists)
                            {
                                task[completeIndex] = 0;
                            }
                            break;
                        case "Change":
                            var changeIndex = int.Parse(input[1]);
                            var changeTime = int.Parse(input[2]);
                            isIndexExists = IndexExists(task, changeIndex);
                            if (isIndexExists)
                            {
                                task[changeIndex] = changeTime;
                            }
                            break;
                        case "Drop":
                            var dropIndex = int.Parse(input[1]);
                            isIndexExists = IndexExists(task, dropIndex);
                            if (isIndexExists)
                            {
                                task[dropIndex] = -1;
                            }
                            break;
                        case "Count":
                            var countCommand = input[1];
                            var number = 0;

                            if (countCommand == "Completed")
                            {
                                number = 0;
                                CountCommand(task, number);
                            }
                            else if (countCommand == "Incomplete")
                            {
                                Incompleted(task);
                            }
                            else if (countCommand == "Dropped")
                            {
                                number = -1;
                                CountCommand(task, number);
                            }
                            break;
                    }
                }
            }

            PrintIncompleteTask(task);

        }

        private static void PrintIncompleteTask(int[] task)
        {
            foreach (var tasks in task)
            {
                if (tasks > 0)
                {
                    Console.Write(tasks+ " ");
                }
            }
        }

        private static void Incompleted(int[] task)
        {
            var incompleted = 0;

            foreach (var tasks in task)
            {
                if (tasks  > 0)
                {
                    incompleted++;
                }
            }

            Console.WriteLine(incompleted);
        }

        private static void CountCommand(int[] task, in int number)
        {
            var completedTask = 0;

            foreach (var tasks in task)
            {
                if (tasks == number)
                {
                    completedTask++;
                }
            }

            Console.WriteLine(completedTask);
        }

        private static bool IndexExists(int[] task, int index)
        {
            var isIndex = false;

            if (index < task.Length && index >= 0 )
            {
                isIndex = true;
            }

            return isIndex;
        }
    }
}
