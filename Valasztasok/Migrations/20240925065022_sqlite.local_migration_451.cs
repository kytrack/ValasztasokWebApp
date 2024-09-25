using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valasztasok.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_451 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    RovidNev = table.Column<string>(type: "TEXT", nullable: false),
                    TeljesNev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.RovidNev);
                });

            migrationBuilder.CreateTable(
                name: "Jelolt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    PartRovidNev = table.Column<string>(type: "TEXT", nullable: false),
                    Kerulet = table.Column<int>(type: "INTEGER", nullable: false),
                    SzavazatokSzama = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jelolt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jelolt_Part_PartRovidNev",
                        column: x => x.PartRovidNev,
                        principalTable: "Part",
                        principalColumn: "RovidNev",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jelolt_PartRovidNev",
                table: "Jelolt",
                column: "PartRovidNev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jelolt");

            migrationBuilder.DropTable(
                name: "Part");
        }
    }
}
