using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Configurations
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource.HasKey(r => r.ResourceId);

            resource.Property(r => r.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(false);

            resource.Property(r => r.ResourceId)
                .IsUnicode(true)
                .IsRequired(false);

        }

    }
}
