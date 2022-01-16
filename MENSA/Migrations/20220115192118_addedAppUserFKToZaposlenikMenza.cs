using Microsoft.EntityFrameworkCore.Migrations;

namespace MENSA.Migrations
{
    public partial class addedAppUserFKToZaposlenikMenza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaposlenik_Menza_Zaposlenik_ZaposlenikId",
                table: "Zaposlenik_Menza");

            migrationBuilder.AlterColumn<string>(
                name: "ZaposlenikId",
                table: "Zaposlenik_Menza",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaposlenik_Menza_AspNetUsers_ZaposlenikId",
                table: "Zaposlenik_Menza",
                column: "ZaposlenikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaposlenik_Menza_AspNetUsers_ZaposlenikId",
                table: "Zaposlenik_Menza");

            migrationBuilder.AlterColumn<int>(
                name: "ZaposlenikId",
                table: "Zaposlenik_Menza",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zaposlenik_Menza_Zaposlenik_ZaposlenikId",
                table: "Zaposlenik_Menza",
                column: "ZaposlenikId",
                principalTable: "Zaposlenik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
