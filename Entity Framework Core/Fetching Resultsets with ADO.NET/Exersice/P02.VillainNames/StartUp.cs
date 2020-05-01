using System;
using System.Data.SqlClient;

namespace P02.VillainNames
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, "master"));

            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(Queries.VillainNames, connection);

                try
                {
                    using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        string villainName = (string)sqlDataReader["Name"];
                        int minionsCount = (int)sqlDataReader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                }
            }
        }
    }
}

