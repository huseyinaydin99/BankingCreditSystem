using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(200).IsRequired(false);
        builder.Property(x => x.PhoneNumber).HasMaxLength(50).IsRequired(false);

        builder.Property(x => x.CreatedDate).IsRequired();
        builder.Property(x => x.UpdatedDate).IsRequired(false);
        builder.Property(x => x.DeletedDate).IsRequired(false);

        builder.UseTpcMappingStrategy();
        /*
         UseTpcMappingStrategy(), inheritance hiyerarþisinde her concrete (somut)
        entity için ayrý bir tablo oluþturarak, base sýnýfýn kolonlarýný da o tablolara
        kopyalayan Table-Per-Concrete-Type (TPC) eþleme stratejisini EF Core’a söyler.
         */

        /*
         TPC’de diðer customer türleri Customer tablosundan JOIN ile miras almaz, 
        Customer’daki kolonlarýn tamamý her alt entity’nin kendi tablosunda birebir 
        kopya olarak bulunur (fiziksel miras yok, sadece kavramsal).
        */
    }
}
