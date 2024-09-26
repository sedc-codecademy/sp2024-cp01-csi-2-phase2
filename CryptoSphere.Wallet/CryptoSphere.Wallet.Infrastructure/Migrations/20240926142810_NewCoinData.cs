using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewCoinData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("81e0ed27-62b8-4de8-a5fa-78087b14aa9b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 14, 28, 9, 970, DateTimeKind.Utc).AddTicks(8343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 25, 20, 811, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Local).AddTicks(3185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 16, 25, 20, 810, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.InsertData(
                table: "Cryptos",
                columns: new[] { "CoinId", "CoinSymbol", "Quantity", "ValueInUSD", "WalletId", "WalletId1" },
                values: new object[] { new Guid("630ee9d4-3ee7-4e55-a3f4-54f64bef6ed3"), 3, 12m, 84.05m, new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"), null });

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("5aa63cce-2a90-4298-a587-a848d383031f"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 26, 14, 28, 9, 969, DateTimeKind.Utc).AddTicks(3252), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                column: "TransactionDate",
                value: new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 14, 28, 9, 970, DateTimeKind.Utc).AddTicks(8664), new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Utc).AddTicks(8665), new Guid("b92bea15-344a-4f6b-b80a-61aa04ab3955") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CoinId",
                keyValue: new Guid("630ee9d4-3ee7-4e55-a3f4-54f64bef6ed3"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("5aa63cce-2a90-4298-a587-a848d383031f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 14, 25, 20, 811, DateTimeKind.Utc).AddTicks(3112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 28, 9, 970, DateTimeKind.Utc).AddTicks(8343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 16, 25, 20, 810, DateTimeKind.Local).AddTicks(3384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Local).AddTicks(3185));

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("81e0ed27-62b8-4de8-a5fa-78087b14aa9b"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 26, 14, 25, 20, 807, DateTimeKind.Utc).AddTicks(8110), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                column: "TransactionDate",
                value: new DateTime(2024, 9, 26, 16, 25, 20, 810, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 14, 25, 20, 811, DateTimeKind.Utc).AddTicks(3569), new DateTime(2024, 9, 26, 16, 25, 20, 811, DateTimeKind.Utc).AddTicks(3569), new Guid("40399f4e-7871-41f9-83d3-2e405becf874") });
        }
    }
}
