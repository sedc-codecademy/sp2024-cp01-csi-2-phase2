using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableExchangeRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 11, 11, 56, 427, DateTimeKind.Utc).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 10, 58, 39, 930, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 13, 11, 56, 427, DateTimeKind.Local).AddTicks(3951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 12, 58, 39, 929, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    ExchangeRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CryptoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateToUSD = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.ExchangeRateId);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "CoinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("7bf16807-a34b-4be8-a878-786a6ef2f007"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 25, 11, 11, 56, 426, DateTimeKind.Utc).AddTicks(1805), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                column: "TransactionDate",
                value: new DateTime(2024, 9, 25, 13, 11, 56, 427, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 25, 11, 11, 56, 428, DateTimeKind.Utc).AddTicks(184), new DateTime(2024, 9, 25, 13, 11, 56, 428, DateTimeKind.Utc).AddTicks(185), new Guid("276fe82f-0a91-4360-8b34-68d17bd1b65b") });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_CryptoId",
                table: "ExchangeRates",
                column: "CryptoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 10, 58, 39, 930, DateTimeKind.Utc).AddTicks(2502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 11, 56, 427, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 12, 58, 39, 929, DateTimeKind.Local).AddTicks(7930),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 13, 11, 56, 427, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                column: "TransactionDate",
                value: new DateTime(2024, 9, 25, 12, 58, 39, 929, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 25, 10, 58, 39, 930, DateTimeKind.Utc).AddTicks(2795), new DateTime(2024, 9, 25, 12, 58, 39, 930, DateTimeKind.Utc).AddTicks(2795), new Guid("3d90c872-d7ce-4873-82b4-c390b21193fe") });
        }
    }
}
