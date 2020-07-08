using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(true);

            builder
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);
            }
    }
}
