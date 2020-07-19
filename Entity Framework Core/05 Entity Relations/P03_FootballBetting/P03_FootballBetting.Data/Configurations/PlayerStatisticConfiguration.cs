using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P03_FootballBetting.Data.Configurations
{
    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            // Property validations
            builder
                .Property(ps => ps.ScoredGoals)
                .IsRequired(true);

            builder
                .Property(ps => ps.Assists)
                .IsRequired(true);

            builder
                .Property(ps => ps.MinutesPlayed)
                .IsRequired(true);

            // Relationships
            builder.HasKey(ps => new { ps.GameId, ps.PlayerId });

            builder
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}