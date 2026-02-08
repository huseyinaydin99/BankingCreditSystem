using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.HasBaseType<Customer>();

        builder.Property(x => x.IdentityNumber).HasMaxLength(20).IsRequired();
        builder.Property(x => x.DateOfBirth).IsRequired();
        builder.Property(x => x.Gender).HasMaxLength(10).IsRequired(false);
        builder.Property(x => x.Nationality).HasMaxLength(100).IsRequired(false);
        builder.Property(x => x.MaritalStatus).HasMaxLength(50).IsRequired(false);
        builder.Property(x => x.MonthlyIncome).HasColumnType("decimal(18,2)");
    }
}
