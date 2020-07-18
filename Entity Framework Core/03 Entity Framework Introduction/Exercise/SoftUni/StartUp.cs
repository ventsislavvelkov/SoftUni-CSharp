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
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            var result = RemoveTown(context);
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
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var r in result)
            {
                sb.AppendLine($"{r.FirstName} {r.LastName} from {r.DepartmentName} - ${r.Salary:f2}");
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
                .FirstOrDefault();

            var sb = new StringBuilder();


            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project}");
            }


            return sb.ToString().TrimEnd();
        }

        // 10.	Departments with More Than 5 Employees

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    Name = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,

                    Employees = d.Employees
                        .Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFullName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        //11.	Find Latest 10 Projects

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate

                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var p in projects)
            {
                var startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                    CultureInfo.InvariantCulture);

                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{startDate}");
            }

            return sb.ToString().TrimEnd();
        }

        // 12.	Increase Salaries

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var salary = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" || e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            foreach (var s in salary)
            {
                s.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var s in salary)
            {
                sb.AppendLine($"{s.FirstName} {s.LastName} (${s.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Find Employees by First Name Starting with "Sa"

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //1.	Delete Project by Id

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);

            var employeesProject = context.EmployeesProjects
                .Where(ep => ep.ProjectId == project.ProjectId)
                .ToList();
            
            context.EmployeesProjects.RemoveRange(employeesProject);
            context.Projects.Remove(project);

            context.SaveChanges();

            var sb = new StringBuilder();

            var showProject = context.Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10)
                .ToList();

            foreach (var p in showProject)
            {
                sb.AppendLine(p.Name);

            }

            return sb.ToString().TrimEnd();
        }

        //14.	Remove Town

        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context.Towns
                .First(t => t.Name == "Seattle");

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == townToDelete.Name)
                .ToList();

            foreach (var a in addressesToDelete)
            {
                var employeesInCurrentAddress = context.Employees
                    .Where(e => e.Address.AddressId == a.AddressId);

                foreach (var e in employeesInCurrentAddress)
                {
                    e.AddressId = null;
                }
            }

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{addressesToDelete.Count} addresses in Seattle were deleted";
        }
    }


}