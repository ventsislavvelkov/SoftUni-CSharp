using System.Linq;
using System.Text;
using ProductShop.XmlHelper;
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
            var projectDtos = XMLConverter.Deserializer<ImportProjectDto[]>(xmlString, rootElement);

            foreach (var importProjectDto in projectDtos)
            {
                if (!IsValid(importProjectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            }

            foreach (var taskDto in )
            {
                
            }
        }

        private static bool IsValidUsername(string userName)
        {
            foreach (var ch in userName)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }

            return true;
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