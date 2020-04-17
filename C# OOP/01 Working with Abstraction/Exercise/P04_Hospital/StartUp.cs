using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
            //Dictionary<string, List<string>> doktori = new Dictionary<string, List<string>>();
            //Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            //string command = Console.ReadLine();
            //while (command != "Output")
            //{
            //    string[] tokens = command.Split();
            //    var departament = tokens[0];
            //    var doktorFirstName = tokens[1];
            //    var doctorLastName = tokens[2];
            //    var pacient = tokens[3];
            //    var doctorFullName = doktorFirstName + doctorLastName;

            //    if (!doktori.ContainsKey(doctorFullName))
            //    {
            //        doktori[doctorFullName] = new List<string>();
            //    }
            //    if (!departments.ContainsKey(departament))
            //    {
            //        departments[departament] = new List<List<string>>();
            //        for (int rooms = 1; rooms <= 20; rooms++)
            //        {
            //            departments[departament].Add(new List<string>());
            //        }
            //    }

            //    bool isFree = departments[departament].SelectMany(x => x).Count() < 60;
            //    if (isFree)
            //    {
            //        int room = 0;

            //        doktori[doctorFullName].Add(pacient);
            //        for (int st = 0; st < departments[departament].Count; st++)
            //        {
            //            if (departments[departament][st].Count < 3)
            //            {
            //                room = st;
            //                break;
            //            }
            //        }
            //        departments[departament][room].Add(pacient);
            //    }

            //    command = Console.ReadLine();
            //}
             
            //command = Console.ReadLine();

            //while (command != "End")
            //{
            //    string[] args = command.Split();

            //    if (args.Length == 1)
            //    {
            //        Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            //    }
            //    else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            //    {
            //        Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
            //    }
            //    else
            //    {
            //        Console.WriteLine(string.Join("\n", doktori[args[0] + args[1]].OrderBy(x => x)));
            //    }
            //    command = Console.ReadLine();
            //}
        }
    }
}
