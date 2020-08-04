using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.XmlHelper;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;
    using Data;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            const string rootElement = "Projects";

            var projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Count > 0)
                .Select(p => new ExportProjectDto
                {
                    Name = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                        .Select(t => new ExportTaskProjectDto
                        {
                            Name = t.Name,
                            LabelType = t.LabelType.ToString()

                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();

            var result = XMLConverter.Serialize(projects, rootElement);

            return result;



        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var projects = context.Employees
                .ToArray()
                .Where(e=>e.EmployeesTasks.Any(et=>et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et=>et.Task.OpenDate >= date)
                        .OrderByDescending(et=>et.Task.DueDate)
                        .ThenBy(et=>et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        }).ToArray()

                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(projects, Formatting.Indented);

            return json;
        }
    }
}