using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class chageOfVariableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                table: "Transactions",
                newName: "SenderWalletId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 16, 1, 21, 56, 716, DateTimeKind.Utc).AddTicks(5604),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 14, 1, 25, 48, 107, DateTimeKind.Utc).AddTicks(6455));

            migrationBuilder.AddColumn<int>(
                name: "CoinSymbol",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverWalletId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverWalletId",
                table: "Transactions",
                column: "ReceiverWalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_ReceiverWalletId",
                table: "Transactions",
                column: "ReceiverWalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Wallets_ReceiverWalletId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ReceiverWalletId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CoinSymbol",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReceiverWalletId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SenderWalletId",
                table: "Transactions",
                newName: "WalletId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 14, 1, 25, 48, 107, DateTimeKind.Utc).AddTicks(6455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 16, 1, 21, 56, 716, DateTimeKind.Utc).AddTicks(5604));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Wallets_WalletId",
                table: "Transactions",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId");
        }
    }
}
