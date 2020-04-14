using System;
using System.Collections.Generic;
using System.Linq;

namespace P06EqualityLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {
          var sortedSet = new SortedSet<Person>();
          var hashSet = new HashSet<Person>();

          var n = int.Parse(Console.ReadLine());

          for (int i = 0; i < n; i++)
          {
              var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
              var name = input[0];
              var age = int.Parse(input[1]);
              
              var person = new Person(name,age);

              sortedSet.Add(person);
              hashSet.Add(person);

          }

          Console.WriteLine(sortedSet.Count);
          Console.WriteLine(hashSet.Count);
        }
    }
}
