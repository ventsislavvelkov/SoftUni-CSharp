using SoftUni.Data;
using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
       public  static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = GetEmployee147(context);
            Console.WriteLine(result);


        }
       //3. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
       {
           var sb = new StringBuilder();

           var employees = context
               .Employees
               .OrderBy(e => e.EmployeeId)
               .Select(e => new
               {
                   e.FirstName, 
                   e.LastName,
                   e.MiddleName,
                   e.JobTitle,
                   e.Salary 
               });

           foreach (var e in employees)
           {
               sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
           }

           return sb.ToString().TrimEnd();
       }

        //4.	Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        { 
            var sb = new StringBuilder();

            var result = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName);

            foreach (var r in result)
            {
                sb.AppendLine($"{r.FirstName} - {r.Salary:f2}");
            }


            return sb.ToString().TrimEnd();
        }

        // 5.	Employees from Research and Development

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var result = context
                .Employees
                .Where(e=>e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName, 
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e=>e.FirstName)
                .ToList();

            foreach (var r in result)
            {
                sb.AppendLine($"{r.FirstName} {r.LastName} {r.DepartmentName} - {r.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //6.	Adding a New Address and Updating Employee

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };

            Employee foundEmployee = context.Employees
                .First(e => e.LastName == "Nakov");

            foundEmployee.Address = address;

            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    AddressText = e.Address.AddressText
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        //7.	Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    EmployeesProject = e.EmployeesProjects
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            ProjectStartDate = p.Project.StartDate,
                            ProjectEndDate = p.Project.EndDate
                        })
                        .ToList()
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.EmployeesProject)
                {
                    var projectStartDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture);

                    var projectEndDate = project.ProjectEndDate == null ?
                        "not finished" :
                        project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt",
                            CultureInfo.InvariantCulture);
                    sb.AppendLine($"--{project.ProjectName} - {projectStartDate} - {projectEndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //8.	Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(e => e.EmployeesCount)
                .ThenBy(e => e.TownName)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // 9.	Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(p => p)
                        .ToList()
                })
                .Where(e => e.Id == 147)
                .First();

            var sb = new StringBuilder();

         
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"{project}");
                }
            

            return sb.ToString().TrimEnd();
        }
    }
}