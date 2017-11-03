using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IMSWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MORTALITY",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TEXT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MORTALITY", x => x.ID_PK);
                });

            migrationBuilder.CreateTable(
                name: "SPECIES",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMMON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCIENTIFIC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPECIES", x => x.ID_PK);
                });

            migrationBuilder.CreateTable(
                name: "TANK_LOG",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PERIOD_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    SPECIESID_PK = table.Column<int>(type: "int", nullable: true),
                    SPECIES_FK = table.Column<int>(type: "int", nullable: false),
                    TANK_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TANK_LOG", x => x.ID_PK);
                    table.ForeignKey(
                        name: "FK_TANK_LOG_SPECIES_SPECIESID_PK",
                        column: x => x.SPECIESID_PK,
                        principalTable: "SPECIES",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DAILY_LOG",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DAILY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOG_FK = table.Column<int>(type: "int", nullable: false),
                    MORTALITYID_PK = table.Column<int>(type: "int", nullable: true),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    REASON_FK = table.Column<int>(type: "int", nullable: false),
                    TANK_LOGID_PK = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAILY_LOG", x => x.ID_PK);
                    table.ForeignKey(
                        name: "FK_DAILY_LOG_MORTALITY_MORTALITYID_PK",
                        column: x => x.MORTALITYID_PK,
                        principalTable: "MORTALITY",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DAILY_LOG_TANK_LOG_TANK_LOGID_PK",
                        column: x => x.TANK_LOGID_PK,
                        principalTable: "TANK_LOG",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DAILY_LOG_MORTALITYID_PK",
                table: "DAILY_LOG",
                column: "MORTALITYID_PK");

            migrationBuilder.CreateIndex(
                name: "IX_DAILY_LOG_TANK_LOGID_PK",
                table: "DAILY_LOG",
                column: "TANK_LOGID_PK");

            migrationBuilder.CreateIndex(
                name: "IX_TANK_LOG_SPECIESID_PK",
                table: "TANK_LOG",
                column: "SPECIESID_PK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DAILY_LOG");

            migrationBuilder.DropTable(
                name: "MORTALITY");

            migrationBuilder.DropTable(
                name: "TANK_LOG");

            migrationBuilder.DropTable(
                name: "SPECIES");
        }
    }
}
