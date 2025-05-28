using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.GraphQl.Migrations
{
    /// <inheritdoc />
    public partial class Firstinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Volume24h = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingPairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseAssetSymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    QuoteAssetSymbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PriceDecimals = table.Column<int>(type: "int", nullable: false),
                    AmountDecimals = table.Column<int>(type: "int", nullable: false),
                    MinTradeSize = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    MaxTradeSize = table.Column<decimal>(type: "decimal(18,8)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingPairs_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradingPairs_CurrencyId",
                table: "TradingPairs",
                column: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradingPairs");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
