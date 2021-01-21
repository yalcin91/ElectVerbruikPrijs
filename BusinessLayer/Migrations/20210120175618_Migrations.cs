using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLayer.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LEVERANCIER",
                columns: table => new
                {
                    LEVERANCIER_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAAM = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PRIJS = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MAATSCHAPPELIJKE_ZETEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TOEKENNING_LEVERINGVERGUNNING = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PUBLICATIEBESLISSING_IN_BELGIE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AUTO_TIME_CREATION = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEVERANCIER", x => x.LEVERANCIER_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LEVERANCIER_NAME",
                table: "LEVERANCIER",
                column: "NAAM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LEVERANCIER");
        }
    }
}
