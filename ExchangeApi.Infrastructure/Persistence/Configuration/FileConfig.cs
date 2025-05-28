using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class FileConfig : IEntityTypeConfiguration<ExchangeApi.Domain.Entities.File>
{
    public void Configure(EntityTypeBuilder<ExchangeApi.Domain.Entities.File> builder)
    {
        builder
            .HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("PK_File");
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .IsRequired();

        builder.Property(x => x.FileName)
            .HasComment(ResourcesComment.GetComment(DataDictionary.FileName))
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.ContentType)
            .HasComment(ResourcesComment.GetComment(DataDictionary.ContentType))
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.FileData)
            .HasComment(ResourcesComment.GetComment(DataDictionary.FileData))
            .IsRequired();
        
        builder.Property(x => x.Created)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);
        
        builder.Property(ca => ca.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .IsRequired(false);

        builder.Property(ca => ca.MetaDescription)
            .HasComment(ResourcesComment.GetComment(DataDictionary.MetaDescription));

        builder.Property(ca => ca.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId));

        builder.Property(x => x.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);
        
        builder.HasOne(current => current.User) 
            .WithMany(other => other.Files) 
            .HasForeignKey(current => current.UserId) 
            .OnDelete(DeleteBehavior.Restrict); 
        
        builder.HasOne(current => current.Currency) 
            .WithMany(other => other.Files) 
            .HasForeignKey(current => current.CurrencyId) 
            .OnDelete(DeleteBehavior.Restrict); 
    }
}