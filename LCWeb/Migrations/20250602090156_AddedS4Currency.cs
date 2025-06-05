using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddedS4Currency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "S4Currency",
                table: "DraftLCSections",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "S4Figures",
                table: "DraftLCSections",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "S4ForexRate",
                table: "DraftLCSections",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "S4Currency",
                table: "DraftLCSections");

            migrationBuilder.DropColumn(
                name: "S4Figures",
                table: "DraftLCSections");

            migrationBuilder.DropColumn(
                name: "S4ForexRate",
                table: "DraftLCSections");
        }
    }
}
