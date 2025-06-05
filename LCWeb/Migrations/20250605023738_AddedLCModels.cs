using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddedLCModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LetterOfCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DraftLCSectionId = table.Column<int>(type: "int", nullable: false),
                    OpeningBank = table.Column<int>(type: "int", nullable: false),
                    LCNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestShipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterOfCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LetterOfCredits_DraftLCSections_DraftLCSectionId",
                        column: x => x.DraftLCSectionId,
                        principalTable: "DraftLCSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LetterOfCredits_DraftLCSectionId",
                table: "LetterOfCredits",
                column: "DraftLCSectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LetterOfCredits");
        }
    }
}
