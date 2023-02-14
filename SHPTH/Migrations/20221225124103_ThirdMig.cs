using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatSeps");

            migrationBuilder.DropTable(
                name: "TypeSeps");

            migrationBuilder.DropColumn(
                name: "CloSep",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "MatSep",
                table: "Cloth",
                newName: "ClothSeparId");

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_ClothSeparId",
                table: "Cloth",
                column: "ClothSeparId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_ClothSeps_ClothSeparId",
                table: "Cloth",
                column: "ClothSeparId",
                principalTable: "ClothSeps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_ClothSeps_ClothSeparId",
                table: "Cloth");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_ClothSeparId",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "ClothSeparId",
                table: "Cloth",
                newName: "MatSep");

            migrationBuilder.AddColumn<int>(
                name: "CloSep",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatSeps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatSeps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeSeps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSeps", x => x.Id);
                });
        }
    }
}
