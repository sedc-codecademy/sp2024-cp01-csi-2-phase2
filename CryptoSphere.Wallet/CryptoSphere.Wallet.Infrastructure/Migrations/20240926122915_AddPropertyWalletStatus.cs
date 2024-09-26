using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyWalletStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("7bf16807-a34b-4be8-a878-786a6ef2f007"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 29, 15, 26, DateTimeKind.Utc).AddTicks(9306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 11, 56, 427, DateTimeKind.Utc).AddTicks(9827));

            migrationBuilder.AddColumn<int>(
                name: "WalletStatus",
                table: "Wallets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Local).AddTicks(5123),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 13, 11, 56, 427, DateTimeKind.Local).AddTicks(3951));

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
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId", "WalletStatus" },
                values: new object[] { new DateTime(2024, 9, 26, 12, 29, 15, 26, DateTimeKind.Utc).AddTicks(9634), new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Utc).AddTicks(9634), new Guid("a6a763c3-565b-4811-a794-676cc83bc3a9"), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "ExchangeRateId",
                keyValue: new Guid("354cd929-5a8a-4b89-ae8e-396192bfd28b"));

            migrationBuilder.DropColumn(
                name: "WalletStatus",
                table: "Wallets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 11, 11, 56, 427, DateTimeKind.Utc).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 29, 15, 26, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 13, 11, 56, 427, DateTimeKind.Local).AddTicks(3951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 14, 29, 15, 26, DateTimeKind.Local).AddTicks(5123));

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
        }
    }
}
