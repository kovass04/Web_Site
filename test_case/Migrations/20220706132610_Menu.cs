using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_case.Migrations
{
    public partial class Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Wok",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Wok", x => x.Id);
               });
            migrationBuilder.CreateTable(
               name: "Menu",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Menu", x => x.Id);
               });
            migrationBuilder.CreateTable(
               name: "Roll",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Roll", x => x.Id);
               });
            migrationBuilder.CreateTable(
               name: "Sushi",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Sushi", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sushi");
            migrationBuilder.DropTable(
                name: "Wok");
            migrationBuilder.DropTable(
                name: "Roll");
            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
