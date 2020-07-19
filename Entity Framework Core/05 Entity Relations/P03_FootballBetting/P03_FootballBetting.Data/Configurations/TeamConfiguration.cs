using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P03_FootballBetting.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Property validations
            builder.HasKey(t => t.TeamId);

            builder
                .Property(t => t.Name)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(true);

            builder
                .Property(t => t.LogoUrl)
                .IsRequired(false)
                .HasMaxLength(250)
                .IsUnicode(false);

            builder
                .Property(t => t.Initials)
                .IsRequired(true)
                .HasMaxLength(4)
                .IsUnicode(true);

            builder
                .Property(t => t.Budget)
                .IsRequired(true);

            // Relationships
            builder
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Town)
                .WithMany(to => to.Teams)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}