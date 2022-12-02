using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin.Migrations
{
    public partial class SizeCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Collection",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Cloth");

            migrationBuilder.AddColumn<int>(
                name: "CollectionID",
                table: "Cloth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "Cloth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_CollectionID",
                table: "Cloth",
                column: "CollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_SizeID",
                table: "Cloth",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_Collection_CollectionID",
                table: "Cloth",
                column: "CollectionID",
                principalTable: "Collection",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_Size_SizeID",
                table: "Cloth",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_Collection_CollectionID",
                table: "Cloth");

            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_Size_SizeID",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_CollectionID",
                table: "Cloth");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_SizeID",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "CollectionID",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "Cloth");

            migrationBuilder.AddColumn<string>(
                name: "Collection",
                table: "Cloth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Cloth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
