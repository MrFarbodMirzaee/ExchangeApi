using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class ExchangeRateConfig : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("Pk_Base_ExchangeRate");
        
        builder.Property(p => p.Id)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .ValueGeneratedNever()
            .HasDefaultValue(Guid.NewGuid());
        
        builder.Property(x => x.Created)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.IsActive))
            .HasDefaultValue(false);
        
        builder.Property(x => x.Rate)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Rate))
            .IsRequired();
        
        builder.Property(ca => ca.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId))
            .IsRequired(false);

        builder.Property(ca => ca.MetaDescription)
            .HasComment(ResourcesComment.GetComment(DataDictionary.MetaDescription));

        builder.Property(ca => ca.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UpdatedByUserId))
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);
        
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