
using ExChangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.DataBaseConfiguration;

public class CurrencyConfig : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder
            .HasKey(x => x.Id)
            .IsClustered()
            .HasName("PK_Base_Currency");
        builder.Property(x => x.CurrencyCode)
            .IsRequired()
            .HasMaxLength(3);
        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(false);
        builder.Property(x => x.Created)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);
    }
}
