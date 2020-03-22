using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Migrations
{
    public partial class HVMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haandvaerkere",
                columns: table => new
                {
                    HaandvaerkerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HVFornavn = table.Column<string>(nullable: true),
                    HVEfternavn = table.Column<string>(nullable: true),
                    HVAnsaettelsedato = table.Column<DateTime>(nullable: false),
                    HVFagomraade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haandvaerkere", x => x.HaandvaerkerID);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejskasser",
                columns: table => new
                {
                    VTKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VTKFabrikat = table.Column<string>(nullable: true),
                    VTKSerienummer = table.Column<string>(nullable: true),
                    VTKModel = table.Column<string>(nullable: true),
                    VTKFarve = table.Column<string>(nullable: true),
                    VTKEjesAf = table.Column<int>(nullable: true),
                    VTKAnskaffet = table.Column<DateTime>(nullable: false),
                    HaandvaerkerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejskasser", x => x.VTKID);
                    table.ForeignKey(
                        name: "FK_Vaerktoejskasser_Haandvaerkere_HaandvaerkerID",
                        column: x => x.HaandvaerkerID,
                        principalTable: "Haandvaerkere",
                        principalColumn: "HaandvaerkerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejer",
                columns: table => new
                {
                    VTID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VTFabrikat = table.Column<string>(nullable: true),
                    VTSerienr = table.Column<string>(nullable: true),
                    VTModel = table.Column<string>(nullable: true),
                    VTType = table.Column<string>(nullable: true),
                    VTAnskaffet = table.Column<DateTime>(nullable: false),
                    LiggerIvtk = table.Column<int>(nullable: true),
                    VaerktoejskasseVTKID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejer", x => x.VTID);
                    table.ForeignKey(
                        name: "FK_Vaerktoejer_Vaerktoejskasser_VaerktoejskasseVTKID",
                        column: x => x.VaerktoejskasseVTKID,
                        principalTable: "Vaerktoejskasser",
                        principalColumn: "VTKID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejer_VaerktoejskasseVTKID",
                table: "Vaerktoejer",
                column: "VaerktoejskasseVTKID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejskasser_HaandvaerkerID",
                table: "Vaerktoejskasser",
                column: "HaandvaerkerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaerktoejer");

            migrationBuilder.DropTable(
                name: "Vaerktoejskasser");

            migrationBuilder.DropTable(
                name: "Haandvaerkere");
        }
    }
}
