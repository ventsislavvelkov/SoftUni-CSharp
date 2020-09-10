using Newtonsoft.Json.Serialization;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;

	public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OfficerPrisoner>( e =>
            {
                e.HasKey(k => new {k.PrisonerId, k.OfficerId});
            });

			builder.Entity<OfficerPrisoner>()
            .HasOne(x => x.Officer).WithMany(x => x.OfficerPrisoners)
                .HasForeignKey(x => x.OfficerId).OnDelete(DeleteBehavior.Restrict);

		}
	}
}