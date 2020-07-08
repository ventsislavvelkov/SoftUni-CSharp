

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            builder
                .Property(s => s.PhoneNumber)
                .HasColumnType("char(10)")
                .IsUnicode(false)
                .IsRequired(false);

            builder
                .Property(s => s.Birthday)
                .HasColumnType("DATETIME2")
                .IsRequired(false);
        }
    }
}
