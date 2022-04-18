using Microsoft.EntityFrameworkCore.Migrations;

namespace ViljaladuMVC.Migrations
{
    public partial class Viljaladu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Koormad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SisenemisMass = table.Column<int>(type: "int", nullable: false),
                    LahkumisMass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koormad", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koormad");
        }
    }
}
