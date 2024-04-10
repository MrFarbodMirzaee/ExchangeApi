using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddShema_AndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeTransaction_User_UserId",
                table: "ExchangeTransaction");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeTransaction_UserId",
                table: "ExchangeTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExchangeTransaction");

            migrationBuilder.EnsureSchema(
                name: "BASE");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "BASE");

            migrationBuilder.RenameTable(
                name: "ExchangeTransaction",
                newName: "ExchangeTransaction",
                newSchema: "BASE");

            migrationBuilder.RenameTable(
                name: "ExchangeRate",
                newName: "ExchangeRate",
                newSchema: "BASE");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currency",
                newSchema: "BASE");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "BASE",
                table: "Currency",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                schema: "BASE",
                table: "Currency",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 14, 42, 18, 129, DateTimeKind.Local).AddTicks(1380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_Currency",
                schema: "BASE",
                table: "Currency",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_Currency",
                schema: "BASE",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "BASE",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "ExchangeTransaction",
                schema: "BASE",
                newName: "ExchangeTransaction");

            migrationBuilder.RenameTable(
                name: "ExchangeRate",
                schema: "BASE",
                newName: "ExchangeRate");

            migrationBuilder.RenameTable(
                name: "Currency",
                schema: "BASE",
                newName: "Currency");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ExchangeTransaction",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Currency",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 14, 42, 18, 129, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTransaction_UserId",
                table: "ExchangeTransaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeTransaction_User_UserId",
                table: "ExchangeTransaction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
