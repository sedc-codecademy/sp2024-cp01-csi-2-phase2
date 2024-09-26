using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewTransactionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 9, 26, 14, 30, 58, 76, DateTimeKind.Utc).AddTicks(222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 28, 9, 970, DateTimeKind.Utc).AddTicks(8343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 16, 30, 58, 75, DateTimeKind.Local).AddTicks(3414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Local).AddTicks(3185));

            migrationBuilder.InsertData(
                table: "Cryptos",
                columns: new[] { "CoinId", "CoinSymbol", "Quantity", "ValueInUSD", "WalletId", "WalletId1" },
                values: new object[] { new Guid("8301f5a1-113b-4b66-be99-abf66000f93b"), 3, 12m, 84.05m, new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"), null });

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("9e92590a-5476-4393-8875-7b4808210fe6"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 26, 14, 30, 58, 73, DateTimeKind.Utc).AddTicks(4035), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                columns: new[] { "CoinSymbol", "TransactionDate" },
                values: new object[] { 0, new DateTime(2024, 9, 26, 16, 30, 58, 75, DateTimeKind.Local).AddTicks(4494) });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CoinSymbol", "CryptoId", "TransactionDate", "TransactionStatus", "TransactionType", "WalletId" },
                values: new object[] { new Guid("1982d4e9-e6e8-4da1-8860-35d47c6ff82a"), 60.50m, 3, new Guid("630ee9d4-3ee7-4e55-a3f4-54f64bef6ed3"), new DateTime(2024, 9, 26, 16, 30, 58, 75, DateTimeKind.Local).AddTicks(4568), 0, 1, new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c") });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 14, 30, 58, 76, DateTimeKind.Utc).AddTicks(778), new DateTime(2024, 9, 26, 16, 30, 58, 76, DateTimeKind.Utc).AddTicks(779), new Guid("ff0debb6-26ff-4a75-976d-590418508ff5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cryptos",
                keyColumn: "CoinId",
                keyValue: new Guid("8301f5a1-113b-4b66-be99-abf66000f93b"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("9e92590a-5476-4393-8875-7b4808210fe6"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("1982d4e9-e6e8-4da1-8860-35d47c6ff82a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 14, 28, 9, 970, DateTimeKind.Utc).AddTicks(8343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 30, 58, 76, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Local).AddTicks(3185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 16, 30, 58, 75, DateTimeKind.Local).AddTicks(3414));

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
                columns: new[] { "CoinSymbol", "TransactionDate" },
                values: new object[] { 3, new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Local).AddTicks(4041) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 14, 28, 9, 970, DateTimeKind.Utc).AddTicks(8664), new DateTime(2024, 9, 26, 16, 28, 9, 970, DateTimeKind.Utc).AddTicks(8665), new Guid("b92bea15-344a-4f6b-b80a-61aa04ab3955") });
        }
    }
}
