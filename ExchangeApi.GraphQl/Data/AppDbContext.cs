using ExchangeApi.GraphQl.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExchangeApi.GraphQl.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    #region Dbsets

    public DbSet<Currency> Currencies { get; set; }
    public DbSet<TradingPair> TradingPairs { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Volume24h).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<TradingPair>(entity =>
        {
            entity.HasKey(tp => tp.Id);
            entity.Property(tp => tp.Id).ValueGeneratedOnAdd();
            entity.Property(tp => tp.BaseAssetSymbol).IsRequired().HasMaxLength(10);
            entity.Property(tp => tp.QuoteAssetSymbol).IsRequired().HasMaxLength(10);
            entity.Property(tp => tp.PriceDecimals).IsRequired();
            entity.Property(tp => tp.AmountDecimals).IsRequired();
            entity.Property(tp => tp.MinTradeSize).HasColumnType("decimal(18,8)");
            entity.Property(tp => tp.MaxTradeSize).HasColumnType("decimal(18,8)");
            entity.Property(tp => tp.Status).HasConversion<string>();
            entity.Property(tp => tp.CreatedAt).IsRequired();
            entity.Property(tp => tp.UpdatedAt).IsRequired();
        });
    }
}