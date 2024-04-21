using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuki.Transactions.Api.Migrations
{
    /// <inheritdoc />
    public partial class _20242104addtransactionstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                schema: "Transaction",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "Transaction",
                newName: "Transaction",
                newSchema: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_Type_Trace",
                schema: "Transaction",
                table: "Transaction",
                newName: "IX_Transaction_Type_Trace");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_Trace",
                schema: "Transaction",
                table: "Transaction",
                newName: "IX_Transaction_Trace");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Transaction",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Transaction",
                table: "Transaction",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Transaction",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "Transaction",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                schema: "Transaction",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                schema: "Transaction",
                table: "Transaction",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                schema: "Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                schema: "Transaction",
                newName: "Payment",
                newSchema: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Type_Trace",
                schema: "Transaction",
                table: "Payment",
                newName: "IX_Payment_Type_Trace");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_Trace",
                schema: "Transaction",
                table: "Payment",
                newName: "IX_Payment_Trace");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Transaction",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Transaction",
                table: "Payment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Transaction",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "Transaction",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                schema: "Transaction",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                schema: "Transaction",
                table: "Payment",
                column: "TransactionId");
        }
    }
}
