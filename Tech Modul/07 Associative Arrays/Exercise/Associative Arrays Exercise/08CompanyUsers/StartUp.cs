using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _08CompanyUsers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var companyAndEmployees = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" -> ");
                var company = input[0];

                if (company == "End")
                {
                    break;
                }
                else
                {
                    var employeeId = input[1];

                    if (!companyAndEmployees.ContainsKey(company))
                    {
                        companyAndEmployees.Add(company, new List<string>());
                    }

                    if (!companyAndEmployees[company].Contains(employeeId))
                    {
                        companyAndEmployees[company].Add(employeeId);
                    }
                }
            }

            foreach (var company in companyAndEmployees.OrderBy(x => x.Key))
            {

                Console.WriteLine(company.Key);
                Console.WriteLine($"-- {string.Join(Environment.NewLine + "-- ", company.Value)}");

            }
        }
    }
}
