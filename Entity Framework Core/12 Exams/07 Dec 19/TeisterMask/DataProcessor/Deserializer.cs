using System.Globalization;
using System.Linq;
using System.Text;
using ProductShop.XmlHelper;
using TeisterMask.Data.Models;
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

            var projectsDto = XMLConverter.Deserializer<ImportProjectsDto>(xmlString, rootElement);

            var importProject = new List<Project>();
            var sb = new StringBuilder();

            foreach (var dto in projectsDto)
            {
                if (IsValid(dto))
                {
                    var openDate = DateTime.ParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var dueDate = DateTime.ParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    // var openDateTask = DateTime.ParseExact(, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //var dueDateTask = DateTime.ParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var project = new Project
                    {
                        Name = dto.Name,
                        OpenDate = openDate,
                        DueDate = dueDate,

                        Tasks = dto.Task.Select(t => new ImportTaskDto
                        {


                            Name = t.Name,
                            OpenDate = t.OpenDate,
                            DueDate = t.DueDate,
                            ExecutionType = t.ExecutionType,
                            LabelType = t.LabelType

                        })
                    };



                    importProject.AddRange(project);
                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));

                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projects.AddRange(importProject);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}