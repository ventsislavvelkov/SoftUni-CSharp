using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace P08.IncreaseMinionAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString));

            connection.Open();

            using (connection)
            {
                List<int> minionsIds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                using SqlCommand updateCmd = new SqlCommand(Queries.UpdateMinions, connection);

                for (int i = 0; i < minionsIds.Count; i++)
                {
                    int currentId = minionsIds[i];
                    updateCmd.Parameters.AddWithValue("@Id", currentId);
                    updateCmd.ExecuteNonQuery();
                    updateCmd.Parameters.Clear();
                }

                using SqlCommand resultCmd = new SqlCommand(Queries.TakeMinionsNameAndAge, connection);
                using SqlDataReader reader = resultCmd.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} {minionAge}");
                }
            }
        }
    }
}
