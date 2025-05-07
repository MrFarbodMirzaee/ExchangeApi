using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Db_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BASE");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("39d2c886-e558-4a02-8a0a-80d840f1ef68")),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 512, DateTimeKind.Unspecified).AddTicks(2433), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    Password = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 537, DateTimeKind.Unspecified).AddTicks(579), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_BASE_User", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("9c381358-99cc-47a8-8c98-48786fee84a5")),
                    CurrencyCode = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 526, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base_Currency", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Currency_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BASE",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyAttribute",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("b707811c-3ada-4e57-a36b-0642862896f5")),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 522, DateTimeKind.Unspecified).AddTicks(4301), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyAttribute", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CurrencyAttribute_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BASE",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CurrencyAttribute_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "BASE",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyAttribute_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "BASE",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("f66ef84c-6c1f-427f-bfb4-24491c443173")),
                    FromCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 527, DateTimeKind.Unspecified).AddTicks(1177), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Base_ExchangeRate", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ExchangeRate_Currency_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalSchema: "BASE",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRate_Currency_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalSchema: "BASE",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 535, DateTimeKind.Unspecified).AddTicks(3242), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_File_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "BASE",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "BASE",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeTransaction",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("cf9935b6-9ebc-4ae3-9f3e-9a508d59ee00")),
                    FromCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResultAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExChangeRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 7, 21, 3, 46, 531, DateTimeKind.Unspecified).AddTicks(9653), new TimeSpan(0, 3, 30, 0, 0))),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_BASE_ExchangeTransaction", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ExchangeTransaction_Currency_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalSchema: "BASE",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeTransaction_Currency_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalSchema: "BASE",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeTransaction_ExchangeRate_ExChangeRateId",
                        column: x => x.ExChangeRateId,
                        principalSchema: "BASE",
                        principalTable: "ExchangeRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExchangeTransaction_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "BASE",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CategoryId",
                schema: "BASE",
                table: "Currency",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CurrencyCode",
                schema: "BASE",
                table: "Currency",
                column: "CurrencyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAttribute_CategoryId",
                schema: "BASE",
                table: "CurrencyAttribute",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAttribute_CurrencyId",
                schema: "BASE",
                table: "CurrencyAttribute",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAttribute_UserId",
                schema: "BASE",
                table: "CurrencyAttribute",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRate_FromCurrencyId",
                schema: "BASE",
                table: "ExchangeRate",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRate_ToCurrencyId",
                schema: "BASE",
                table: "ExchangeRate",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTransaction_ExChangeRateId",
                schema: "BASE",
                table: "ExchangeTransaction",
                column: "ExChangeRateId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTransaction_FromCurrencyId",
                schema: "BASE",
                table: "ExchangeTransaction",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTransaction_ToCurrencyId",
                schema: "BASE",
                table: "ExchangeTransaction",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeTransaction_UserId",
                schema: "BASE",
                table: "ExchangeTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_CurrencyId",
                schema: "BASE",
                table: "File",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserId",
                schema: "BASE",
                table: "File",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "BASE",
                table: "User",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyAttribute",
                schema: "BASE");

            migrationBuilder.DropTable(
                name: "ExchangeTransaction",
                schema: "BASE");

            migrationBuilder.DropTable(
                name: "File",
                schema: "BASE");

            migrationBuilder.DropTable(
                name: "ExchangeRate",
                schema: "BASE");

            migrationBuilder.DropTable(
                name: "User",
                schema: "BASE");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "BASE");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "BASE");
        }
    }
}
