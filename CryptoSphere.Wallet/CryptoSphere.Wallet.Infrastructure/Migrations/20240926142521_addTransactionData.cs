using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTransactionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("e5e100a8-2c0c-4a7a-9cf9-71da87c7125f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 14, 25, 20, 811, DateTimeKind.Utc).AddTicks(3112),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 13, 43, 13, 29, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 16, 25, 20, 810, DateTimeKind.Local).AddTicks(3384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 15, 43, 13, 28, DateTimeKind.Local).AddTicks(5597));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 9, 26, 13, 43, 13, 29, DateTimeKind.Utc).AddTicks(1895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 25, 20, 811, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 15, 43, 13, 28, DateTimeKind.Local).AddTicks(5597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 16, 25, 20, 810, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "ExchangeRateId", "CryptoId", "LastUpdated", "RateToUSD" },
                values: new object[] { new Guid("e5e100a8-2c0c-4a7a-9cf9-71da87c7125f"), new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 26, 13, 43, 13, 27, DateTimeKind.Utc).AddTicks(1066), 11002.25m });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"),
                column: "TransactionDate",
                value: new DateTime(2024, 9, 26, 15, 43, 13, 28, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 26, 13, 43, 13, 29, DateTimeKind.Utc).AddTicks(2229), new DateTime(2024, 9, 26, 15, 43, 13, 29, DateTimeKind.Utc).AddTicks(2230), new Guid("23f49a83-08f2-4a59-b94c-2266538a72e1") });
        }
    }
}
