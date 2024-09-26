using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransactionCoinSymbChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("354cd929-5a8a-4b89-ae8e-396192bfd28b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 13, 43, 13, 29, DateTimeKind.Utc).AddTicks(1895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 29, 15, 26, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 15, 43, 13, 28, DateTimeKind.Local).AddTicks(5597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.AddColumn<int>(
                name: "CoinSymbol",
                table: "Transactions",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoinSymbol",
                table: "Cryptos",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CoinId",
                keyValue: new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"),
                column: "CoinSymbol",
                value: 1);

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("e5e100a8-2c0c-4a7a-9cf9-71da87c7125f"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 26, 13, 43, 13, 27, DateTimeKind.Utc).AddTicks(1066), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                columns: new[] { "CoinSymbol", "TransactionDate" },
                values: new object[] { 3, new DateTime(2024, 9, 26, 15, 43, 13, 28, DateTimeKind.Local).AddTicks(6963) });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 13, 43, 13, 29, DateTimeKind.Utc).AddTicks(2229), new DateTime(2024, 9, 26, 15, 43, 13, 29, DateTimeKind.Utc).AddTicks(2230), new Guid("23f49a83-08f2-4a59-b94c-2266538a72e1") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("e5e100a8-2c0c-4a7a-9cf9-71da87c7125f"));

            migrationBuilder.DropColumn(
                name: "CoinSymbol",
                table: "Transactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 29, 15, 26, DateTimeKind.Utc).AddTicks(9306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 13, 43, 13, 29, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Local).AddTicks(5123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 15, 43, 13, 28, DateTimeKind.Local).AddTicks(5597));

            migrationBuilder.AlterColumn<string>(
                name: "CoinSymbol",
                table: "Cryptos",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CoinId",
                keyValue: new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"),
                column: "CoinSymbol",
                value: "TST");

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("354cd929-5a8a-4b89-ae8e-396192bfd28b"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 26, 12, 29, 15, 25, DateTimeKind.Utc).AddTicks(6954), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                column: "TransactionDate",
                value: new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 12, 29, 15, 26, DateTimeKind.Utc).AddTicks(9634), new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Utc).AddTicks(9634), new Guid("a6a763c3-565b-4811-a794-676cc83bc3a9") });
        }
    }
}
