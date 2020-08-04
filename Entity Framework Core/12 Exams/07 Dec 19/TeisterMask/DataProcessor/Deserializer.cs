using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TeisterMask.XmlHelper;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            const string rootElement = "Projects";

            var sb = new StringBuilder();
            var projects = new List<Project>();

            var projectDtos = XMLConverter.Deserializer<ImportProjectDto>(xmlString, rootElement);

            foreach (ImportProjectDto projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;
                bool isProjectOpenDataValid = DateTime.TryParseExact(projectDto.OpenDate , "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if (!isProjectOpenDataValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate;

                if (!String.IsNullOrEmpty(projectDto.DueDate))
                {
                    DateTime projectDueDateValue;
                    bool isProjectDueDataValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);

                    if (!isProjectDueDataValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;

                    }

                    projectDueDate = projectDueDateValue;
                }
                else
                {
                    projectDueDate = null;
                }

                var pr = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                foreach (ImportTaskProjectDto taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenData;
                    bool isTaskOpenDataValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenData);

                    if (!isTaskOpenDataValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool isTaskDueDataValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);


                    if (!isTaskDueDataValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenData < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.HasValue)
                    {
                        if (taskDueDate > projectDueDate.Value)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    pr.Tasks.Add(new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenData,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    });

                }

                projects.Add(pr);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, pr.Name, pr.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        //private static bool IsValidUsername(string userName)
        //{
        //    foreach (var ch in userName)
        //    {
        //        if (!Char.IsLetterOrDigit(ch))
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            foreach (ImportEmployeeDto employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee em = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks
                        .FirstOrDefault(t => t.Id == taskId);
                  
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    em.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = em,
                        Task = task
                    });
                }

                employees.Add(em);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, em.Username, em.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}