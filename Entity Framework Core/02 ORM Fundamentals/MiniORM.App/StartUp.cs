namespace MiniORM.App
{
    using System.Linq;
    using MiniORM.App.Data;
    using MiniORM.App.Data.Entities;

    public class StartUp
    {
        private static string connectionString = @"Server=.\VARNA-PC\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

        public static void Main(string[] args)
        {
            var context = new SoftUniDbContext(connectionString);

            context.EmployeesProjects.Add(new EmployeesProjects { ProjectId = 2, EmployeeId = 2 });

            context.SaveChanges();

            var employeesProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            var project = context.Projects
                .FirstOrDefault(p => p.Id == 2);

            context.EmployeesProjects.RemoveRange(employeesProjects);

            context.SaveChanges();

            context.Projects.Remove(project);

            context.SaveChanges();
        }
    }
}