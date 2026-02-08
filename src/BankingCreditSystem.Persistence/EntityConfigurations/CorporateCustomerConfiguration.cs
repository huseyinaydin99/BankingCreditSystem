using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.HasBaseType<Customer>();

        builder.Property(x => x.CompanyName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.TaxNumber).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.FoundationDate).IsRequired(false);
        builder.Property(x => x.Industry).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.CompanyType).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.EmployeeCount).IsRequired(false);
        builder.Property(x => x.AnnualRevenue).HasColumnType("decimal(18,2)");
        builder.Property(x => x.ContactPersonName).HasMaxLength(200).IsRequired(false);
        builder.Property(x => x.ContactPersonEmail).HasMaxLength(200).IsRequired(false);
        builder.Property(x => x.ContactPersonPhone).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.Website).HasMaxLength(250).IsRequired(false);
    }
}
