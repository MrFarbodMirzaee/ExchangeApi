using ExchangeApi.Domain.Entities;
using ExchangeApi.Infrastructure.Persistence.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceApi;

namespace ExchangeApi.Infrastructure.Persistence.Configuration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id)
            .IsClustered(false)
            .HasName("Pk_BASE_User");
        
        builder.Property(p => p.Id)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Id))
            .ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .IsUnicode()
            .HasComment(ResourcesComment.GetComment(DataDictionary.Name))
            .HasMaxLength(50);
        
        builder.Property(x => x.UserName)
            .IsRequired()
            .IsUnicode(false)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UserName))
            .HasMaxLength(150);

        builder.Property(x => x.MetaDescription)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UserName));

        builder.Property(x => x.Description)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Description));

        builder.Property(x => x.DeletedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.DeletedByUserId));

        builder.HasIndex(p=> p.UserName)
            .IsUnique()
            .HasDatabaseName("IX_User_UserName");
        
        builder.Property(x => x.EmailAddress)
            .HasComment(ResourcesComment.GetComment(DataDictionary.EmailAddress))
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(300);
        
        builder.Property(x => x.IsActive)
            .HasComment(ResourcesComment.GetComment(DataDictionary.IsActive))
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(x => x.Created)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Created))
            .IsRequired()
            .HasDefaultValue(DateTimeOffset.Now);

        builder.Property(ca => ca.UpdatedByUserId)
            .HasComment(ResourcesComment.GetComment(DataDictionary.UpdatedByUserId))
            .IsRequired(false);

        builder.Property(x => x.Updated)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Updated))
            .IsRequired(false);
        
        builder.Property(x => x.Password)
            .HasComment(ResourcesComment.GetComment(DataDictionary.Password))
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(300);
        
        builder.HasMany(u => u.CurrencyAttributes)
            .WithOne(ca => ca.User)
            .HasForeignKey(ca => ca.UserId)
            .OnDelete(DeleteBehavior.NoAction); 

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