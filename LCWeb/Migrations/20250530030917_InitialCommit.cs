using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DraftLCSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S1PONo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S1LCType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S1Confirmation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S1Enclosure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S2IssuingBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S2DateOfExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    S2Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S2PlaceOfExpiry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3DraftAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3DifferredRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3CreditAvailWith = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3CreditAvailBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3AdvisingBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S3SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S4BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S4LCAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    S4ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S5TTReimbursement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S6MannerOfShipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S6ShipmentTerms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S7BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S7LCAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    S7ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S7LatestShipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    S7Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S7ShipmentFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S7ShipmentTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S8PartialShipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S8Transhipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S9ReqDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S10BankCharges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S11TermsAndCond = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftLCSections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DraftLCSections");
        }
    }
}
