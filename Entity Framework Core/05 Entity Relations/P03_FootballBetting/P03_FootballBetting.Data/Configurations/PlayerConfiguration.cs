using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P03_FootballBetting.Data.Configurations
{
    
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            // Property validations
            builder
                .Property(p => p.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder
                .Property(p => p.SquadNumber)
                .HasMaxLength(3)
                .IsRequired(true);

            builder
                .Property(p => p.IsInjured)
                .IsRequired(true);

            // Relationships
            builder.HasKey(p => p.PlayerId);

            builder
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Position)
                .WithMany(po => po.Players)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}