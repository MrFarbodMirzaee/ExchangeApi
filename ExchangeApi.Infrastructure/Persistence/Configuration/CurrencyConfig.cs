using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .HasDefaultValue(Guid.NewGuid());
        
        builder.Property(x => x.CurrencyCode)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(4);

        builder.HasIndex(x => x.CurrencyCode)
            .IsUnique();
        
        builder.Property(x => x.Name)
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(x => x.Created)
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);
        
        builder.Property(ca => ca.DeletedByUserId)
            .IsRequired(false);

        builder.Property(ca => ca.UpdatedByUserId)
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .IsRequired(false);

        builder.HasOne(current => current.Category)
            .WithMany(other => other.Currencies)
            .IsRequired(true)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}