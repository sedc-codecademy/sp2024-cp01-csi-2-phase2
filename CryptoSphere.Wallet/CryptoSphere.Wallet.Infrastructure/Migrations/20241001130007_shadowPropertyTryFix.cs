using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoSphere.Wallet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class shadowPropertyTryFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 13, 0, 6, 598, DateTimeKind.Utc).AddTicks(5152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 1, 12, 51, 54, 446, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 15, 0, 6, 597, DateTimeKind.Local).AddTicks(7307),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 1, 14, 51, 54, 445, DateTimeKind.Local).AddTicks(8812));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Wallets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 12, 51, 54, 446, DateTimeKind.Utc).AddTicks(8879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 1, 13, 0, 6, 598, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 1, 14, 51, 54, 445, DateTimeKind.Local).AddTicks(8812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 1, 15, 0, 6, 597, DateTimeKind.Local).AddTicks(7307));
        }
    }
}
