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
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "MORTALITY",
                schema: "dbo",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TEXT = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MORTALITY", x => x.ID_PK);
                });

            migrationBuilder.CreateTable(
                name: "SPECIES",
                schema: "dbo",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMMON = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SCIENTIFIC = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPECIES", x => x.ID_PK);
                });

            migrationBuilder.CreateTable(
                name: "TANK_LOG",
                schema: "dbo",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMMENT = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PERIOD_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    SPECIES_FK = table.Column<int>(type: "int", nullable: false),
                    TANK_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TANK_LOG", x => x.ID_PK);
                    table.ForeignKey(
                        name: "FK_TANK_LOG_SPECIES_SPECIES_FK",
                        column: x => x.SPECIES_FK,
                        principalSchema: "dbo",
                        principalTable: "SPECIES",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DAILY_LOG",
                schema: "dbo",
                columns: table => new
                {
                    ID_PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMMENT = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DAILY_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    LOG_FK = table.Column<int>(type: "int", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    REASON_FK = table.Column<int>(type: "int", nullable: false),
                    TANK_LOGID_PK1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAILY_LOG", x => x.ID_PK);
                    table.ForeignKey(
                        name: "FK_DAILY_LOG_TANK_LOG_LOG_FK",
                        column: x => x.LOG_FK,
                        principalSchema: "dbo",
                        principalTable: "TANK_LOG",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DAILY_LOG_MORTALITY_REASON_FK",
                        column: x => x.REASON_FK,
                        principalSchema: "dbo",
                        principalTable: "MORTALITY",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DAILY_LOG_TANK_LOG_TANK_LOGID_PK1",
                        column: x => x.TANK_LOGID_PK1,
                        principalSchema: "dbo",
                        principalTable: "TANK_LOG",
                        principalColumn: "ID_PK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DAILY_LOG_LOG_FK",
                schema: "dbo",
                table: "DAILY_LOG",
                column: "LOG_FK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DAILY_LOG_REASON_FK",
                schema: "dbo",
                table: "DAILY_LOG",
                column: "REASON_FK");

            migrationBuilder.CreateIndex(
                name: "IX_DAILY_LOG_TANK_LOGID_PK1",
                schema: "dbo",
                table: "DAILY_LOG",
                column: "TANK_LOGID_PK1");

            migrationBuilder.CreateIndex(
                name: "IX_TANK_LOG_SPECIES_FK",
                schema: "dbo",
                table: "TANK_LOG",
                column: "SPECIES_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DAILY_LOG",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TANK_LOG",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MORTALITY",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SPECIES",
                schema: "dbo");
        }
    }
}
