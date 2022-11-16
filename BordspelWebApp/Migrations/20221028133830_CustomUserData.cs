using Microsoft.EntityFrameworkCore.Migrations;

namespace BordspelWebApp.Migrations
{
    public partial class CustomUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naam",
                schema: "BordspelWebApp",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naam",
                schema: "BordspelWebApp",
                table: "AspNetUsers");
        }
    }
}
