using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuki.Transactions.Api.Migrations
{
    /// <inheritdoc />
    public partial class _20242104movedtotpcstrategy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Transactions_TransactionId",
                schema: "Transaction",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                schema: "Transaction",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "Transaction",
                newName: "Payment",
                newSchema: "Transaction");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Transaction",
                table: "Payment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                schema: "Transaction",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Trace",
                schema: "Transaction",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Transaction",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                schema: "Transaction",
                table: "Payment",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Trace",
                schema: "Transaction",
                table: "Payment",
                column: "Trace");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Type_Trace",
                schema: "Transaction",
                table: "Payment",
                columns: new[] { "Type", "Trace" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_Trace",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_Type_Trace",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Detail",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Trace",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "Transaction",
                newName: "Payments",
                newSchema: "Transaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                schema: "Transaction",
                table: "Payments",
                column: "TransactionId");

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trace = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Trace",
                schema: "Transaction",
                table: "Transactions",
                column: "Trace");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Type_Trace",
                schema: "Transaction",
                table: "Transactions",
                columns: new[] { "Type", "Trace" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Transactions_TransactionId",
                schema: "Transaction",
                table: "Payments",
                column: "TransactionId",
                principalSchema: "Transaction",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
