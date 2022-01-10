using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MENSA.Migrations
{
    public partial class addEverythingToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHours = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menza_Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    MenzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Menza_Menu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menza_Menu_Menza_MenzaId",
                        column: x => x.MenzaId,
                        principalTable: "Menza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MenzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Narudzba_Menza_MenzaId",
                        column: x => x.MenzaId,
                        principalTable: "Menza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik_Menza",
                columns: table => new
                {
                    MenzaId = table.Column<int>(type: "int", nullable: false),
                    ZaposlenikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Menza_Menza_MenzaId",
                        column: x => x.MenzaId,
                        principalTable: "Menza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Menza_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba_Menu",
                columns: table => new
                {
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    NarudzbaNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Narudzba_Menu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Menu_Narudzba_NarudzbaNumber",
                        column: x => x.NarudzbaNumber,
                        principalTable: "Narudzba",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menza_Menu_MenuId",
                table: "Menza_Menu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menza_Menu_MenzaId",
                table: "Menza_Menu",
                column: "MenzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_MenzaId",
                table: "Narudzba",
                column: "MenzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_StudentId",
                table: "Narudzba",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_Menu_MenuId",
                table: "Narudzba_Menu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_Menu_NarudzbaNumber",
                table: "Narudzba_Menu",
                column: "NarudzbaNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_Menza_MenzaId",
                table: "Zaposlenik_Menza",
                column: "MenzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_Menza_ZaposlenikId",
                table: "Zaposlenik_Menza",
                column: "ZaposlenikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menza_Menu");

            migrationBuilder.DropTable(
                name: "Narudzba_Menu");

            migrationBuilder.DropTable(
                name: "Zaposlenik_Menza");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Menza");
        }
    }
}
