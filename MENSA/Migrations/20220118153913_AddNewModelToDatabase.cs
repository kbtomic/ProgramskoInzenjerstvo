using Microsoft.EntityFrameworkCore.Migrations;

namespace MENSA.Migrations
{
    public partial class AddNewModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewNarudzba_Menu_Menu1Id",
                table: "NewNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NewNarudzba_Menu_Menu2Id",
                table: "NewNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NewNarudzba_Menu_Menu3Id",
                table: "NewNarudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_NewNarudzba_Menu_Menu4Id",
                table: "NewNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_NewNarudzba_Menu1Id",
                table: "NewNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_NewNarudzba_Menu2Id",
                table: "NewNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_NewNarudzba_Menu3Id",
                table: "NewNarudzba");

            migrationBuilder.DropIndex(
                name: "IX_NewNarudzba_Menu4Id",
                table: "NewNarudzba");

            migrationBuilder.DropColumn(
                name: "Menu1Id",
                table: "NewNarudzba");

            migrationBuilder.DropColumn(
                name: "Menu2Id",
                table: "NewNarudzba");

            migrationBuilder.DropColumn(
                name: "Menu3Id",
                table: "NewNarudzba");

            migrationBuilder.DropColumn(
                name: "Menu4Id",
                table: "NewNarudzba");

            migrationBuilder.CreateTable(
                name: "NewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    NewNarudzbaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewModel_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewModel_NewNarudzba_NewNarudzbaId",
                        column: x => x.NewNarudzbaId,
                        principalTable: "NewNarudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewModel_MenuId",
                table: "NewModel",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_NewModel_NewNarudzbaId",
                table: "NewModel",
                column: "NewNarudzbaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewModel");

            migrationBuilder.AddColumn<int>(
                name: "Menu1Id",
                table: "NewNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Menu2Id",
                table: "NewNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Menu3Id",
                table: "NewNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Menu4Id",
                table: "NewNarudzba",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewNarudzba_Menu1Id",
                table: "NewNarudzba",
                column: "Menu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewNarudzba_Menu2Id",
                table: "NewNarudzba",
                column: "Menu2Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewNarudzba_Menu3Id",
                table: "NewNarudzba",
                column: "Menu3Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewNarudzba_Menu4Id",
                table: "NewNarudzba",
                column: "Menu4Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewNarudzba_Menu_Menu1Id",
                table: "NewNarudzba",
                column: "Menu1Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NewNarudzba_Menu_Menu2Id",
                table: "NewNarudzba",
                column: "Menu2Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NewNarudzba_Menu_Menu3Id",
                table: "NewNarudzba",
                column: "Menu3Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NewNarudzba_Menu_Menu4Id",
                table: "NewNarudzba",
                column: "Menu4Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
