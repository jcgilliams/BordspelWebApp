using Microsoft.EntityFrameworkCore.Migrations;

namespace BordspelWebApp.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GebruikersId",
                schema: "BordspelWebApp",
                table: "Collectie",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Voornaam",
                schema: "BordspelWebApp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collectie_GebruikersId",
                schema: "BordspelWebApp",
                table: "Collectie",
                column: "GebruikersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collectie_AspNetUsers_GebruikersId",
                schema: "BordspelWebApp",
                table: "Collectie",
                column: "GebruikersId",
                principalSchema: "BordspelWebApp",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collectie_AspNetUsers_GebruikersId",
                schema: "BordspelWebApp",
                table: "Collectie");

            migrationBuilder.DropIndex(
                name: "IX_Collectie_GebruikersId",
                schema: "BordspelWebApp",
                table: "Collectie");

            migrationBuilder.DropColumn(
                name: "GebruikersId",
                schema: "BordspelWebApp",
                table: "Collectie");

            migrationBuilder.DropColumn(
                name: "Voornaam",
                schema: "BordspelWebApp",
                table: "AspNetUsers");
        }
    }
}
