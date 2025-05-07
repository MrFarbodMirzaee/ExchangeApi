using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class ExchangeTransactionConfig : IEntityTypeConfiguration<ExchangeTransaction>
{
    public void Configure(EntityTypeBuilder<ExchangeTransaction> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("Pk_BASE_ExchangeTransaction");
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasDefaultValue(Guid.NewGuid());
        
        builder.Property(x => x.Amount)
            .IsRequired();
        
        builder.Property(x => x.ResultAmount)
            .IsRequired();
        
        builder.Property(x => x.FromCurrencyId)
            .IsRequired();
        
        builder.Property(x => x.ToCurrencyId)
            .IsRequired();
        
        builder.Property(x => x.Created)
            .HasDefaultValue(DateTimeOffset.Now)
            .IsRequired();
        
        builder.Property(x => x.TransactionDate)
            .IsRequired();
        
        builder.HasOne(current => current.FromCurrency) 
            .WithMany(other=> other.FromExchangeTransactions) 
            .HasForeignKey(x => x.FromCurrencyId) 
            .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(x => x.ToCurrency) 
            .WithMany(other=> other.ToExchangeTransactions)
            .HasForeignKey(x => x.ToCurrencyId) 
            .OnDelete(DeleteBehavior.Restrict); 


        builder.HasOne(current => current.User) 
            .WithMany(other => other.ExchangeTransactions) 
            .HasForeignKey(current => current.UserId) 
            .OnDelete(DeleteBehavior.Restrict); 
    }
}