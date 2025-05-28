using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region SP
            var getAllSql = @"
            CREATE PROCEDURE GetAllCurrencies
            AS
            BEGIN
                SET NOCOUNT ON;
                SELECT * FROM BASE.Currency;
            END
            ";

            var getByIdSql = @"
            CREATE PROCEDURE GetCurrencyById
                @Id UNIQUEIDENTIFIER
            AS
            BEGIN
                SET NOCOUNT ON;
                SELECT * FROM BASE.Currency WHERE Id = @Id;
            END
            ";

            migrationBuilder.Sql(getAllSql);
            migrationBuilder.Sql(getByIdSql);

            #endregion

            migrationBuilder.EnsureSchema(
                name: "BASE");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("69b516d8-055a-4459-a9a1-bf4bc00a39ba"), comment: "Gets or sets the unique identifier for the entity."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description"),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who last updated the entity, if applicable."),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    MetaDescription = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "Gets or sets the meta description or summary information for the entity."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 914, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the unique identifier for the entity."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name"),
                    UserName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false, comment: "A unique username chosen by the user for login."),
                    EmailAddress = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false, comment: "The user's email address for communication and notifications."),
                    Password = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false, comment: "A hashed representation of the user's password for authentication."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "A flag indicating whether the entity is currently active."),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Description"),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who last updated the entity, if applicable."),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "A unique username chosen by the user for login."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 977, DateTimeKind.Unspecified).AddTicks(2454), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("8e7c04a2-6997-4e1b-aa71-c90415162293"), comment: "Gets or sets the unique identifier for the entity."),
                    CurrencyCode = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false, comment: "Represents the code that identifies the currency (e.g., USD, EUR)."),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false, comment: "Name"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "A flag indicating whether the entity is currently active."),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The path to an image representing the entity (e.g., flag or symbol)."),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Description"),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who last updated the entity, if applicable."),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the meta description or summary information for the entity."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 942, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("8b49b030-f9a5-4bb7-8dba-da09c9e18b88"), comment: "Gets or sets the unique identifier for the entity."),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Represents the key of the currency attribute."),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Represents the value associated with the currency attribute key."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "A flag indicating whether the entity is currently active."),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Description"),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who last updated the entity, if applicable."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the meta description or summary information for the entity."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 932, DateTimeKind.Unspecified).AddTicks(8367), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("873ba7f4-eb9f-4f8c-ac4b-0d46efe00596"), comment: "Gets or sets the unique identifier for the entity."),
                    FromCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Represents the exchange rate value between the two currencies."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "A flag indicating whether the entity is currently active."),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who last updated the entity, if applicable."),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the meta description or summary information for the entity."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 947, DateTimeKind.Unspecified).AddTicks(9534), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the unique identifier for the entity."),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "The name of the file as it was uploaded by the user."),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The MIME type of the file, indicating the format of the file's content."),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false, comment: "The binary data of the file, stored as a byte array."),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the unique identifier for the entity."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the meta description or summary information for the entity."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 970, DateTimeKind.Unspecified).AddTicks(3452), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("02a12ee5-8a0d-496f-8d67-8ade513690b2"), comment: "Gets or sets the unique identifier for the entity."),
                    FromCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Represents the identifier of the currency from which the entity is calculated"),
                    ToCurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Represents the identifier of the currency to which the entity is calculated."),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Represents the amount of currency being exchanged in the transaction."),
                    ResultAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Represents the resulting amount of currency after the exchange transaction."),
                    TransactionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Represents the date and time when the transaction occurred."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who last updated the entity, if applicable."),
                    DeletedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Gets or sets the ID of the user who marked the entity as deleted, if applicable."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExChangeRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the meta description or summary information for the entity."),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2025, 5, 27, 22, 21, 2, 962, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 3, 30, 0, 0)), comment: "Gets or sets the creation date and time of the entity."),
                    Updated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the last updated date and time of the entity, if any.")
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
            #region SP
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetAllCurrencies;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetCurrencyById;");
            #endregion

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
