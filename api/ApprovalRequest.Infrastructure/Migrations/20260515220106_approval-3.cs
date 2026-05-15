using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApprovalRequest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class approval3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RejectionReason",
                table: "Requests",
                newName: "Remarks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "Requests",
                newName: "RejectionReason");
        }
    }
}
