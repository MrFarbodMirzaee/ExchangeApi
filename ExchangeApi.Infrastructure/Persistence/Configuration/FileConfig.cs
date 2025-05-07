using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .ValueGeneratedNever();

        builder.Property(x => x.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.ContentType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.FileData)
            .IsRequired();
        
        builder.Property(x => x.Created)
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);
        
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