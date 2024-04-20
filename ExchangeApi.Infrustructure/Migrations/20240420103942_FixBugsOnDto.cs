using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class FixBugsOnDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "BASE",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "BASE",
                table: "User",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "BASE",
                table: "User",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "BASE",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "BASE",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "BASE",
                table: "User",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 875, DateTimeKind.Local).AddTicks(1833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 875, DateTimeKind.Local).AddTicks(57),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 151, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 874, DateTimeKind.Local).AddTicks(9657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 151, DateTimeKind.Local).AddTicks(807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 874, DateTimeKind.Local).AddTicks(7368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 150, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 874, DateTimeKind.Local).AddTicks(5982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 150, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.AddPrimaryKey(
                name: "Pk_BASE_User",
                schema: "BASE",
                table: "User",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Pk_BASE_User",
                schema: "BASE",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "BASE",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "BASE",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "BASE",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "BASE",
                table: "User",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "BASE",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 875, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 151, DateTimeKind.Local).AddTicks(1118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 875, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 151, DateTimeKind.Local).AddTicks(807),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 874, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "ExchangeRate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 150, DateTimeKind.Local).AddTicks(9019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 874, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                schema: "BASE",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 17, 22, 44, 150, DateTimeKind.Local).AddTicks(7592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 20, 14, 9, 41, 874, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "BASE",
                table: "User",
                column: "Id");
        }
    }
}
