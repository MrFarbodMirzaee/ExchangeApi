using ExchangeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("Pk_BASE_User");
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);
        
        builder.Property(x => x.UserName)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(150);
        
        builder.HasIndex(p=> p.UserName)
            .IsUnique()
            .HasDatabaseName("IX_User_UserName");
        
        builder.Property(x => x.EmailAddress)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(300);
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(x => x.Created)
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);
        
        builder.Property(x => x.Password)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(300);
        
        builder.HasMany(u => u.CurrencyAttributes)
            .WithOne(ca => ca.User)
            .HasForeignKey(ca => ca.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(u => u.ExchangeTransactions)
            .WithOne(et => et.User)
            .HasForeignKey(et => et.UserId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasMany(u => u.Files)
            .WithOne(et => et.User)
            .HasForeignKey(et => et.UserId)
            .OnDelete(DeleteBehavior.Cascade);  
    }
}