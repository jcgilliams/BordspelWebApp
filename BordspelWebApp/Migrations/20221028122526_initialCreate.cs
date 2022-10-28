using Microsoft.EntityFrameworkCore.Migrations;

namespace BordspelWebApp.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BordspelWebApp");

            migrationBuilder.CreateTable(
                name: "Bordspel",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Jaar = table.Column<int>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    MinAantalSpelers = table.Column<int>(nullable: false),
                    MaxAantalSpelers = table.Column<int>(nullable: false),
                    MinSpeeltijd = table.Column<int>(nullable: false),
                    MaxSpeeltijd = table.Column<int>(nullable: false),
                    Leeftijd = table.Column<int>(nullable: false),
                    Afbeelding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bordspel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persoon",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschrijving = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uitgeverij",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: false),
                    Beschrijving = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    PersoonId = table.Column<int>(nullable: false),
                    Land = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgeverij", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collectie",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BordspelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collectie_Bordspel_BordspelId",
                        column: x => x.BordspelId,
                        principalSchema: "BordspelWebApp",
                        principalTable: "Bordspel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BordspelPersoon",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BordspelId = table.Column<int>(nullable: false),
                    PersoonId = table.Column<int>(nullable: false),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BordspelPersoon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BordspelPersoon_Bordspel_BordspelId",
                        column: x => x.BordspelId,
                        principalSchema: "BordspelWebApp",
                        principalTable: "Bordspel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BordspelPersoon_Persoon_PersoonId",
                        column: x => x.PersoonId,
                        principalSchema: "BordspelWebApp",
                        principalTable: "Persoon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BordspelPersoon_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "BordspelWebApp",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uitgave",
                schema: "BordspelWebApp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BordspelId = table.Column<int>(nullable: false),
                    UitgeverijId = table.Column<int>(nullable: false),
                    Taal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uitgave_Bordspel_BordspelId",
                        column: x => x.BordspelId,
                        principalSchema: "BordspelWebApp",
                        principalTable: "Bordspel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uitgave_Uitgeverij_UitgeverijId",
                        column: x => x.UitgeverijId,
                        principalSchema: "BordspelWebApp",
                        principalTable: "Uitgeverij",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BordspelPersoon_BordspelId",
                schema: "BordspelWebApp",
                table: "BordspelPersoon",
                column: "BordspelId");

            migrationBuilder.CreateIndex(
                name: "IX_BordspelPersoon_PersoonId",
                schema: "BordspelWebApp",
                table: "BordspelPersoon",
                column: "PersoonId");

            migrationBuilder.CreateIndex(
                name: "IX_BordspelPersoon_RolId",
                schema: "BordspelWebApp",
                table: "BordspelPersoon",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Collectie_BordspelId",
                schema: "BordspelWebApp",
                table: "Collectie",
                column: "BordspelId");

            migrationBuilder.CreateIndex(
                name: "IX_Uitgave_BordspelId",
                schema: "BordspelWebApp",
                table: "Uitgave",
                column: "BordspelId");

            migrationBuilder.CreateIndex(
                name: "IX_Uitgave_UitgeverijId",
                schema: "BordspelWebApp",
                table: "Uitgave",
                column: "UitgeverijId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BordspelPersoon",
                schema: "BordspelWebApp");

            migrationBuilder.DropTable(
                name: "Collectie",
                schema: "BordspelWebApp");

            migrationBuilder.DropTable(
                name: "Uitgave",
                schema: "BordspelWebApp");

            migrationBuilder.DropTable(
                name: "Persoon",
                schema: "BordspelWebApp");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "BordspelWebApp");

            migrationBuilder.DropTable(
                name: "Bordspel",
                schema: "BordspelWebApp");

            migrationBuilder.DropTable(
                name: "Uitgeverij",
                schema: "BordspelWebApp");
        }
    }
}
