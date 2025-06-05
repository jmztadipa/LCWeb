using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddedReportsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmendmentReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningBank1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningBank2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmendmentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonitoringReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LCNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PONo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningBank1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningBank2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenedTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmendmentReports");

            migrationBuilder.DropTable(
                name: "MonitoringReports");
        }
    }
}
