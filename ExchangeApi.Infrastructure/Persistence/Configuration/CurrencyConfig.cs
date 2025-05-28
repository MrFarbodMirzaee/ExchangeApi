using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class CurrencyConfig : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder
            .HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("PK_Base_Currency");

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .HasDefaultValue(Guid.NewGuid());
        
        builder.Property(x => x.CurrencyCode)
            .IsRequired()
            .IsUnicode(false)
            .HasComment(ResourcesComment.GetComment(DataDictionary.CurrencyCode))
            .HasMaxLength(4);

        builder.HasIndex(x => x.CurrencyCode)
            .IsUnique();
        
        builder.Property(x => x.Name)
            .IsUnicode(false)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Name))
            .IsRequired();
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.IsActive))
            .HasDefaultValue(false);
        
        builder.Property(x => x.Created)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .HasDefaultValue(DateTimeOffset.Now);
        
        builder.Property(ca => ca.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId))
            .IsRequired(false);

        builder.Property(ca => ca.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UpdatedByUserId))
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);

        builder.Property(x => x.ImagePath)
            .HasComment(ResourcesComment.GetComment(DataDictionary.ImagePath));

        builder.Property(x => x.Description)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Description));

        builder.Property(x => x.MetaDescription)
            .HasComment(ResourcesComment.GetComment(DataDictionary.MetaDescription));


        builder.HasOne(current => current.Category)
            .WithMany(other => other.Currencies)
            .IsRequired(true)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}