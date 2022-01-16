using Microsoft.EntityFrameworkCore.Migrations;

namespace MENSA.Migrations
{
    public partial class userToNarudzba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Student_StudentId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_StudentId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Narudzba");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Narudzba",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_UserId",
                table: "Narudzba",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_AspNetUsers_UserId",
                table: "Narudzba",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_AspNetUsers_UserId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_UserId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Narudzba");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Narudzba",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_StudentId",
                table: "Narudzba",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Student_StudentId",
                table: "Narudzba",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
