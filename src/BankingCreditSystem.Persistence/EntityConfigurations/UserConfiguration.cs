/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

/// <summary>
/// User (Authentication) entity'sinin database konfigürasyonu.
/// Sistem girişi ve authentication verilerini yönetir.
/// TPH (Table Per Hierarchy) inheritance stratejisi: Users tablosunda saklanır.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_Users_Email_Unique");

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.PasswordSalt)
            .IsRequired();

        builder.Property(u => u.Status)
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(u => u.AuthenticatorType)
            .IsRequired();

        // Timestamp properties (ITimestamp interface)
        builder.Property(u => u.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired();

        builder.Property(u => u.UpdatedDate)
            .IsRequired(false);

        builder.Property(u => u.DeletedDate)
            .IsRequired(false);

        // Relationships
        builder.HasMany(u => u.UserOperationClaims)
            .WithOne(uoc => uoc.User)
            .HasForeignKey(uoc => uoc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.OtpAuthenticators)
            .WithOne(oa => oa.User)
            .HasForeignKey(oa => oa.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.EmailAuthenticators)
            .WithOne(ea => ea.User)
            .HasForeignKey(ea => ea.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // TPH (Table Per Hierarchy) - Discriminator column
        builder.HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<ApplicationUser>("ApplicationUser");
    }
}
*/