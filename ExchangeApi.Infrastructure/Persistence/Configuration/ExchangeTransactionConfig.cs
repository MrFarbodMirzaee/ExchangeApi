using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

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
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .HasDefaultValue(Guid.NewGuid());
        
        builder.Property(x => x.Amount)
             .HasComment(ResourcesComment.GetComment(DataDictionary.Amount))
            .IsRequired();

        builder.Property(x => x.MetaDescription)
             .HasComment(ResourcesComment.GetComment(DataDictionary.MetaDescription));
            

        builder.Property(x => x.ResultAmount)
            .HasComment(ResourcesComment.GetComment(DataDictionary.ResultAmount))
            .IsRequired();
        
        builder.Property(x => x.FromCurrencyId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.FromCurrencyId))
            .IsRequired();
        
        builder.Property(x => x.ToCurrencyId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.ToCurrencyId))
            .IsRequired();
        
        builder.Property(x => x.Created)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .HasDefaultValue(DateTimeOffset.Now)
            .IsRequired();
        
        builder.Property(x => x.TransactionDate)
            .HasComment(ResourcesComment.GetComment(DataDictionary.TransactionDate))
            .IsRequired();
        
        builder.Property(ca => ca.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId))
            .IsRequired(false);

        builder.Property(ca => ca.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UpdatedByUserId))
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);
        
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