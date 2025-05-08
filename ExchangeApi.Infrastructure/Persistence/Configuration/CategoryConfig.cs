using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id)
            .IsClustered(false);
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasDefaultValue(Guid.NewGuid());

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.MetaDescription)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(c => c.Created)
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);

        builder.Property(c => c.Updated)
            .IsRequired(false);

        builder.Property(c => c.UpdatedByUserId)
            .IsRequired(false);

        builder.Property(c => c.DeletedByUserId)
            .IsRequired(false);
            
        
        builder.HasMany(u => u.Currencies)
            .WithOne(et => et.Category)
            .HasForeignKey(et => et.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}