using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOfFilesToFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Files",
                schema: "BASE",
                newName: "File",
                newSchema: "BASE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(5201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 23, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(2959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(2537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(598),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(6187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 824, DateTimeKind.Local).AddTicks(9006),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(4014));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "File",
                schema: "BASE",
                newName: "Files",
                newSchema: "BASE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 23, DateTimeKind.Local).AddTicks(907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8813),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(2959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(8321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(6187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 825, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 6, 11, 39, 10, 22, DateTimeKind.Local).AddTicks(4014),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 6, 11, 51, 20, 824, DateTimeKind.Local).AddTicks(9006));
        }
    }
}
