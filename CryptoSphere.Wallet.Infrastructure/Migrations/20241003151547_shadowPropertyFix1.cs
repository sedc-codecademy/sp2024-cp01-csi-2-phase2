using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shadowPropertyFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cryptos_CryptoId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CryptoId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Cryptos_WalletId1",
                table: "Cryptos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 15, 15, 46, 831, DateTimeKind.Utc).AddTicks(7578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 3, 14, 22, 31, 776, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 17, 15, 46, 828, DateTimeKind.Local).AddTicks(5505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 3, 16, 22, 31, 776, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.AddColumn<int>(
                name: "CoinId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CoinId",
                table: "Transactions",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_WalletId1",
                table: "Cryptos",
                column: "WalletId1",
                unique: true,
                filter: "[WalletId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cryptos_CoinId",
                table: "Transactions",
                column: "CoinId",
                principalTable: "Cryptos",
                principalColumn: "CoinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cryptos_CoinId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CoinId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Cryptos_WalletId1",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "CoinId",
                table: "Transactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 14, 22, 31, 776, DateTimeKind.Utc).AddTicks(8355),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 3, 15, 15, 46, 831, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 16, 22, 31, 776, DateTimeKind.Local).AddTicks(2689),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 3, 17, 15, 46, 828, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CryptoId",
                table: "Transactions",
                column: "CryptoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_WalletId1",
                table: "Cryptos",
                column: "WalletId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cryptos_CryptoId",
                table: "Transactions",
                column: "CryptoId",
                principalTable: "Cryptos",
                principalColumn: "CoinId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
