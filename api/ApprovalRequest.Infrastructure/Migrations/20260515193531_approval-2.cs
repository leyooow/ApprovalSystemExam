using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApprovalRequest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class approval2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewedAt",
                table: "Requests",
                newName: "DateReviewed");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Requests",
                newName: "DateCreated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateReviewed",
                table: "Requests",
                newName: "ReviewedAt");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Requests",
                newName: "CreatedAt");
        }
    }
}
