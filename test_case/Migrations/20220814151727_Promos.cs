using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_case.Migrations
{
    public partial class Promos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Promos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Promo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Number = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)

            },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.Id);
                });
        }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
                name: "Promos");
    }
}
}
