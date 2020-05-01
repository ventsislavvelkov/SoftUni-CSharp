using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P05.ChangeTownNamesCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string nameOfCountry = Console.ReadLine();

            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString));

            connection.Open();

            using (connection)
            {
                using SqlCommand countryCommand = new SqlCommand(Queries.TakeCountryName, connection);
                countryCommand.Parameters.AddWithValue("@countryName", nameOfCountry);

                object targetCountry = countryCommand.ExecuteScalar();

                if (targetCountry != null)
                {
                    targetCountry = (string)targetCountry;

                    using SqlCommand updateCommand = new SqlCommand(Queries.UpdateTownNames, connection);
                    updateCommand.Parameters.AddWithValue("@countryName", nameOfCountry);

                    int affectedTowns = updateCommand.ExecuteNonQuery();
                    Console.WriteLine($"{affectedTowns} town names were affected.");

                    using SqlDataReader dataReader = countryCommand.ExecuteReader();

                    List<string> townNames = new List<string>(affectedTowns);

                    while (dataReader.Read())
                    {
                        string townName = (string)dataReader["TownName"];
                        townNames.Add(townName);
                    }

                    Console.WriteLine($"[{string.Join(", ", townNames)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
