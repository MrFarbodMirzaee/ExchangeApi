using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.DataBaseConfiguration;
public class ExchangeTransactionConfig : IEntityTypeConfiguration<ExchangeTransaction>
{
    public void Configure(EntityTypeBuilder<ExchangeTransaction> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered()
            .HasName("Pk_BASE_ExchangeTransaction");
        builder.Property(x => x.Amount)
            .IsRequired();
        builder.Property(x => x.ResultAmount)
            .IsRequired();
        builder.Property(x => x.FromCurrencyId)
        .IsRequired();
        builder.Property(x => x.ToCurrencyId)
        .IsRequired();
        builder.Property(x => x.Created)
        .HasDefaultValue(DateTime.Now)
        .IsRequired();
        builder.Property(x => x.TransactionDate)
        .HasDefaultValue(DateTime.Now)
        .IsRequired();
    }
}
