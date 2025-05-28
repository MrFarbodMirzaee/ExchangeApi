using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id)
            .IsClustered(false);
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .HasDefaultValue(Guid.NewGuid());

        builder.Property(c => c.Name)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Name))
            .HasMaxLength(50);

        builder.Property(c => c.MetaDescription)
            .IsRequired()
            .IsUnicode(false)
            .HasComment(ResourcesComment.GetComment(DataDictionary.MetaDescription))
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Description))
            .HasMaxLength(500);

        builder.Property(c => c.Created)
            .IsRequired()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .HasDefaultValue(DateTimeOffset.Now);

        builder.Property(c => c.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);

        builder.Property(c => c.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UpdatedByUserId))
            .IsRequired(false);

        builder.Property(c => c.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId))
            .IsRequired(false);
            
        
        builder.HasMany(u => u.Currencies)
            .WithOne(et => et.Category)
            .HasForeignKey(et => et.CategoryId)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}