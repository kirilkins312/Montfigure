using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class NEWERA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeSeparation",
                table: "Cloth",
                newName: "SizeSeparationID");

            migrationBuilder.RenameColumn(
                name: "ClothSepar",
                table: "Cloth",
                newName: "ClothSeparID");

            migrationBuilder.CreateTable(
                name: "CloSepTest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloSepTest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SizeSepTest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeSepTest", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_ClothSeparID",
                table: "Cloth",
                column: "ClothSeparID");

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_SizeSeparationID",
                table: "Cloth",
                column: "SizeSeparationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_CloSepTest_ClothSeparID",
                table: "Cloth",
                column: "ClothSeparID",
                principalTable: "CloSepTest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_SizeSepTest_SizeSeparationID",
                table: "Cloth",
                column: "SizeSeparationID",
                principalTable: "SizeSepTest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_CloSepTest_ClothSeparID",
                table: "Cloth");

            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_SizeSepTest_SizeSeparationID",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "CloSepTest");

            migrationBuilder.DropTable(
                name: "SizeSepTest");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_ClothSeparID",
                table: "Cloth");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_SizeSeparationID",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "SizeSeparationID",
                table: "Cloth",
                newName: "SizeSeparation");

            migrationBuilder.RenameColumn(
                name: "ClothSeparID",
                table: "Cloth",
                newName: "ClothSepar");
        }
    }
}
