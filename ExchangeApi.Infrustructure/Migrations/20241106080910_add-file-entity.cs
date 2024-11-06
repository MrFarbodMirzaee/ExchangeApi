using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class addfileentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 23, DateTimeKind.Local).AddTicks(907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(3286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(6187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(4014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 306, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "BASE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(5272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 23, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(3286),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(2842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 307, DateTimeKind.Local).AddTicks(860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 15, 26, 42, 306, DateTimeKind.Local).AddTicks(9191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(4014));
        }
    }
}
