using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class ExchangeRateConfig : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("Pk_Base_ExchangeRate");
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasDefaultValue(Guid.NewGuid());
        
        builder.Property(x => x.Created)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(x => x.Rate)
            .IsRequired();
        
        builder.HasOne(current => current.FromCurrency)
            .WithMany(other=> other.FromExchangeRates) 
            .IsRequired()
            .HasForeignKey(current => current.FromCurrencyId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        builder.HasOne(current => current.ToCurrency)
            .WithMany(other=> other.ToExchangeRates)
            .IsRequired()
            .HasForeignKey(current => current.ToCurrencyId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
    }
}