using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin.Migrations
{
    public partial class ClothMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClothMaterial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothID = table.Column<int>(type: "int", nullable: false),
                    MaterialID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothMaterial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothMaterial_Cloth_ClothID",
                        column: x => x.ClothID,
                        principalTable: "Cloth",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothMaterial_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothMaterial_ClothID",
                table: "ClothMaterial",
                column: "ClothID");

            migrationBuilder.CreateIndex(
                name: "IX_ClothMaterial_MaterialID",
                table: "ClothMaterial",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothMaterial");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
