using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Magazin.Migrations
{
    public partial class Designer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designer",
                table: "Cloth");

            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Cloth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_DesignerID",
                table: "Cloth",
                column: "DesignerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_Designer_DesignerID",
                table: "Cloth",
                column: "DesignerID",
                principalTable: "Designer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_Designer_DesignerID",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_DesignerID",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Cloth");

            migrationBuilder.AddColumn<string>(
                name: "Designer",
                table: "Cloth",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
