using Microsoft.EntityFrameworkCore.Migrations;

namespace MENSA.Migrations
{
    public partial class addedPicturePathColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Menza",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Menza");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "Menu");
        }
    }
}
