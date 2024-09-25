using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 25, 10, 58, 39, 930, DateTimeKind.Utc).AddTicks(2502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 22, 14, 15, 24, 416, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId1",
                table: "Cryptos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CryptoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    TransactionType = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 9, 25, 12, 58, 39, 929, DateTimeKind.Local).AddTicks(7930)),
                    TransactionStatus = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "CoinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Cryptos",
                keyColumn: "CoinId",
                keyValue: new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"),
                column: "WalletId1",
                value: null);

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CryptoId", "TransactionDate", "TransactionStatus", "TransactionType", "WalletId" },
                values: new object[] { new Guid("8418ee6b-90a9-4b0d-9da3-265dea4c590e"), 23.50m, new Guid("aa81f025-f94e-4f15-b4b8-817338c86962"), new DateTime(2024, 9, 25, 12, 58, 39, 929, DateTimeKind.Local).AddTicks(8794), 1, 0, new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c") });

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 25, 10, 58, 39, 930, DateTimeKind.Utc).AddTicks(2795), new DateTime(2024, 9, 25, 12, 58, 39, 930, DateTimeKind.Utc).AddTicks(2795), new Guid("3d90c872-d7ce-4873-82b4-c390b21193fe") });

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_WalletId1",
                table: "Cryptos",
                column: "WalletId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CryptoId",
                table: "Transactions",
                column: "CryptoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionDate",
                table: "Transactions",
                column: "TransactionDate");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_WalletId",
                table: "Transactions",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Wallets_WalletId1",
                table: "Cryptos",
                column: "WalletId1",
                principalTable: "Wallets",
                principalColumn: "WalletId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cryptos_Wallets_WalletId1",
                table: "Cryptos");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Cryptos_WalletId1",
                table: "Cryptos");

            migrationBuilder.DropColumn(
                name: "WalletId1",
                table: "Cryptos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 22, 14, 15, 24, 416, DateTimeKind.Utc).AddTicks(6987),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 25, 10, 58, 39, 930, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Wallets",
                keyColumn: "WalletId",
                keyValue: new Guid("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                columns: new[] { "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 9, 22, 14, 15, 24, 416, DateTimeKind.Utc).AddTicks(7257), new DateTime(2024, 9, 22, 16, 15, 24, 416, DateTimeKind.Utc).AddTicks(7257), new Guid("b3e8b955-b45f-411b-a29a-b7cfa849eae7") });

            migrationBuilder.AddForeignKey(
                name: "FK_Cryptos_Wallets_WalletId",
                table: "Cryptos",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
