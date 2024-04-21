using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuki.Transactions.Api.Migrations
{
    /// <inheritdoc />
    public partial class _20242104movedtotptstrategy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                schema: "Transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "Transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Transaction",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                schema: "Transaction",
                newName: "Transactions",
                newSchema: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Type_Trace",
                schema: "Transaction",
                table: "Transactions",
                newName: "IX_Transactions_Type_Trace");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Trace",
                schema: "Transaction",
                table: "Transactions",
                newName: "IX_Transactions_Trace");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Transaction",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                schema: "Transaction",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Payments_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "Transaction",
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments",
                schema: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                schema: "Transaction",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                schema: "Transaction",
                newName: "Transaction",
                newSchema: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_Type_Trace",
                schema: "Transaction",
                table: "Transaction",
                newName: "IX_Transaction_Type_Trace");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_Trace",
                schema: "Transaction",
                table: "Transaction",
                newName: "IX_Transaction_Trace");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Transaction",
                table: "Transaction",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                schema: "Transaction",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "Transaction",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Transaction",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Transaction",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                schema: "Transaction",
                table: "Transaction",
                column: "TransactionId");
        }
    }
}
