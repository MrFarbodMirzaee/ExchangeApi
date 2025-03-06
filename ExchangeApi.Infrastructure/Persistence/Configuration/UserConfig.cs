using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered()
            .HasName("Pk_BASE_User");
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.Property(x => x.EmailAddress)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(x => x.Created)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);
        
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(300);
    }
}