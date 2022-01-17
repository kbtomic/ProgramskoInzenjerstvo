using Microsoft.EntityFrameworkCore.Migrations;

namespace MENSA.Migrations
{
    public partial class finaleChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Menu");

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Menza_Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Menu",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NewNarudzba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ready = table.Column<bool>(type: "bit", nullable: false),
                    Delivered = table.Column<bool>(type: "bit", nullable: false),
                    Menu1Id = table.Column<int>(type: "int", nullable: true),
                    Menu2Id = table.Column<int>(type: "int", nullable: true),
                    Menu3Id = table.Column<int>(type: "int", nullable: true),
                    Menu4Id = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewNarudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewNarudzba_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewNarudzba_Menu_Menu1Id",
                        column: x => x.Menu1Id,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewNarudzba_Menu_Menu2Id",
                        column: x => x.Menu2Id,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewNarudzba_Menu_Menu3Id",
                        column: x => x.Menu3Id,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewNarudzba_Menu_Menu4Id",
                        column: x => x.Menu4Id,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NewNarudzba_StudentId",
                table: "NewNarudzba",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewNarudzba");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Menza_Menu");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
