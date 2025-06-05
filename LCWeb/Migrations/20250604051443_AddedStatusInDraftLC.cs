using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusInDraftLC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LCStatus",
                table: "DraftLCSections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LCStatus",
                table: "DraftLCSections");
        }
    }
}
