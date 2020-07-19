using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P03_FootballBetting.Data.Configurations

{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            // Property validations
            builder.HasKey(t => t.TownId);

            builder
                .Property(t => t.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            // Relationships
            builder
                .HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}