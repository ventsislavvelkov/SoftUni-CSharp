namespace MiniORM.App.Data
{
    using MiniORM.App.Data.Entities;

    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Employees> Employees { get; }

        public DbSet<Departments> Departments { get; }

        public DbSet<Projects> Projects { get; }

        public DbSet<EmployeesProjects> EmployeesProjects { get; }
    }
}