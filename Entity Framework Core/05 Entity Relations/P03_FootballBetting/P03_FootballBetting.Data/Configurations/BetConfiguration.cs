using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configurations
{


public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            // Property validations
            builder
                .Property(b => b.Amount)
                .IsRequired(true);

            builder
                .Property(b => b.Prediction)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(b => b.DateTime)
                .HasColumnType("DATETIME2")
                .IsRequired(true);

            // Relationships
            builder.HasKey(b => b.BetId);

            builder
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}