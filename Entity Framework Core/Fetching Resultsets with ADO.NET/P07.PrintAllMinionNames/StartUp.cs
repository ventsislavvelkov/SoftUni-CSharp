using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace P07.PrintAllMinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString));

            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(Queries.TakeMinionNames, connection);

                using SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                List<string> originalNames = new List<string>(sqlReader.FieldCount);

                while (sqlReader.Read())
                {
                    string name = (string)sqlReader["Name"];
                    originalNames.Add(name);
                }

                Console.WriteLine($"Original order: {Environment.NewLine + string.Join(Environment.NewLine, originalNames)}");

                Console.WriteLine("----------------");

                Console.WriteLine("New order:");

                while (originalNames.Count != 0)
                {
                    Console.WriteLine(originalNames[0]);
                    originalNames.RemoveAt(0);

                    if (originalNames.Count == 0)
                    {
                        break;
                    }

                    Console.WriteLine(originalNames.Last());
                    originalNames.RemoveAt(originalNames.Count - 1);
                }
            }
        }
    }
}
