

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student.HasKey(s => s.StudentId);

            student
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

            student
                .Property(s => s.PhoneNumber)
                .HasColumnType("char(10)")
                .IsUnicode(false)
                .IsRequired(false);

            student
                .Property(s => s.Birthday)
                .HasColumnType("DATETIME2")
                .IsRequired(false);

        }
    }
}
