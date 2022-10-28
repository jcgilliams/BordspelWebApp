using Microsoft.EntityFrameworkCore.Migrations;

namespace BordspelWebApp.Migrations
{
    public partial class aanpassingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersoonId",
                schema: "BordspelWebApp",
                table: "Uitgeverij");

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                schema: "BordspelWebApp",
                table: "Persoon",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinSpeeltijd",
                schema: "BordspelWebApp",
                table: "Bordspel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinAantalSpelers",
                schema: "BordspelWebApp",
                table: "Bordspel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxSpeeltijd",
                schema: "BordspelWebApp",
                table: "Bordspel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxAantalSpelers",
                schema: "BordspelWebApp",
                table: "Bordspel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Leeftijd",
                schema: "BordspelWebApp",
                table: "Bordspel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersoonId",
                schema: "BordspelWebApp",
                table: "Uitgeverij",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                schema: "BordspelWebApp",
                table: "Persoon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "MinSpeeltijd",
                schema: "BordspelWebApp",
                table: "Bordspel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinAantalSpelers",
                schema: "BordspelWebApp",
                table: "Bordspel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxSpeeltijd",
                schema: "BordspelWebApp",
                table: "Bordspel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxAantalSpelers",
                schema: "BordspelWebApp",
                table: "Bordspel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Leeftijd",
                schema: "BordspelWebApp",
                table: "Bordspel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
