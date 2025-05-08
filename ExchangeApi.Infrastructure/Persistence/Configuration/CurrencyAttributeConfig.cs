using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class CurrencyAttributeConfig : IEntityTypeConfiguration<CurrencyAttribute>
{
    public void Configure(EntityTypeBuilder<CurrencyAttribute> builder)
    {
        builder.HasKey(current => current.Id)
            .IsClustered(false);
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasDefaultValue(Guid.NewGuid());

        builder.Property(ca => ca.Key)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ca => ca.Value)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(ca => ca.IsActive)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(ca => ca.Description)
            .HasMaxLength(250);

        builder.Property(ca => ca.DeletedByUserId)
            .IsRequired(false);

        builder.Property(ca => ca.UpdatedByUserId)
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .IsRequired(false);
        
        builder.Property(x => x.Created)
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