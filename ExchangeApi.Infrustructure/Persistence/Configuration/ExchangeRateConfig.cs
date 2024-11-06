using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.DataBaseConfiguration;
public class ExchangeRateConfig : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered()
            .HasName("Pk_Base_ExchangeRate");
        builder.Property(x => x.FromCurrency)
            .IsRequired();
        builder.Property(x => x.ToCurrency)
        .IsRequired();
        builder.Property(x => x.Created)
          .IsRequired()
          .HasDefaultValue(DateTime.Now);
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(false);
        builder.Property(x => x.Rate)
                .IsRequired();
    }
}
