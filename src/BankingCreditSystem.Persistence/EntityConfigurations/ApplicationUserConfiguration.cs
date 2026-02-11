using BankingCreditSystem.Core.CrossCuttingConcerns.Security.Entities;
using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

/// <summary>
/// ApplicationUser entity'sinin database konfigürasyonu.
/// User (authentication) + Customer (domain) bilgilerinin birleşimini yönetir.
/// TPH (Table Per Hierarchy) stratejisi: Users tablosunda ek sütunlarla saklanır.
/// </summary>
public class ApplicationUserConfiguration<TId> : IEntityTypeConfiguration<ApplicationUser<TId>>
{
    public void Configure(EntityTypeBuilder<ApplicationUser<TId>> builder)
    {
        // ApplicationUser özel alanları konfigürasyonu

        builder.Property(au => au.CustomerId)
            .IsRequired();

        builder.HasIndex(au => au.CustomerId)
            .HasDatabaseName("IX_ApplicationUsers_CustomerId");

        /*builder.Property(au => au.CustomerType)
            .HasMaxLength(50)
            .IsRequired();*/

        builder.Property(au => au.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(au => au.Address)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(au => au.IsUserActive)
            .HasDefaultValue(false)
            .IsRequired();

        // OperationClaims collection property - in-memory collection, database'den saklanmaz
        // Application logic'te yüklenir, EF Core tarafından ignored edilir
    }
}