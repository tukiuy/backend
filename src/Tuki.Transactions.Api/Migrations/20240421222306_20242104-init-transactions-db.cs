using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuki.Transactions.Api.Migrations
{
    /// <inheritdoc />
    public partial class _20242104inittransactionsdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Transaction");

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Trace = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.TransactionId);
                });

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
            migrationBuilder.DropTable(
                name: "Payment",
                schema: "Transaction");
        }
    }
}
