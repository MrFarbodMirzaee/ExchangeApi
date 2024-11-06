using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrustructure.Persistence.Configuration;
public class FileCongif : IEntityTypeConfiguration<ExchangeApi.Domain.Entities.File>
{
    public void Configure(EntityTypeBuilder<ExchangeApi.Domain.Entities.File> builder)
    {
        builder
            .HasKey(x => x.Id)
            .IsClustered()
            .HasName("PK_File");

        builder.Property(x => x.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.ContentType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.FileData)
            .IsRequired();
    }
}
