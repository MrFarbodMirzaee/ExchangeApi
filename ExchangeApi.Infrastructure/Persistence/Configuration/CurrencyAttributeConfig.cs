using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class CurrencyAttributeConfig : IEntityTypeConfiguration<CurrencyAttribute>
{
    public void Configure(EntityTypeBuilder<CurrencyAttribute> builder)
    {
        builder.HasKey(current => current.Id)
            .IsClustered(false);

        builder.Property(p => p.Id)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .ValueGeneratedNever()
            .HasDefaultValue(Guid.NewGuid());

        builder.Property(ca => ca.Key)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Key))
            .HasMaxLength(50);

        builder.Property(ca => ca.Value)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Value))
            .HasMaxLength(50);

        builder.Property(ca => ca.IsActive)
            .HasDefaultValue(false)
            .HasComment(ResourcesComment.GetComment(DataDictionary.IsActive))
            .IsRequired();

        builder.Property(ca => ca.Description)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Description))
            .HasMaxLength(250);

        builder.Property(ca => ca.MetaDescription)
            .HasComment(ResourcesComment.GetComment(DataDictionary.MetaDescription));
    

        builder.Property(ca => ca.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId))
            .IsRequired(false);

        builder.Property(ca => ca.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UpdatedByUserId))
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);

        builder.Property(x => x.Created)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);

        builder.HasOne(current => current.User)
            .WithMany(other => other.CurrencyAttributes)
            .IsRequired(true)
            .HasForeignKey(current => current.UserId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        builder.HasOne(current => current.Currency)
            .WithMany(other => other.CurrencyAttributes)
            .IsRequired(true)
            .HasForeignKey(current => current.CurrencyId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
    }
}