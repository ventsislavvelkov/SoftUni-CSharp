using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder.Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(false);

            builder.Property(r => r.ResourceId);

            builder.Property(r => r.Url)
                .IsUnicode(false);

            builder.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
