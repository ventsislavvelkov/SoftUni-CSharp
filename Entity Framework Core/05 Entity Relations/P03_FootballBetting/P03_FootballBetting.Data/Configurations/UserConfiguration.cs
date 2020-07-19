using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P03_FootballBetting.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder
                .Property(u => u.Username)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder
                .Property(u => u.Password)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder
                .Property(u => u.Email)
                .IsRequired(true)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder
                .Property(u => u.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder
                .Property(u => u.Balance)
                .IsRequired(true);
        }
    }
}