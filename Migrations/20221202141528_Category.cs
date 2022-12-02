using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Cloth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_CategoryID",
                table: "Cloth",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_Category_CategoryID",
                table: "Cloth",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_Category_CategoryID",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_CategoryID",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Cloth");
        }
    }
}
