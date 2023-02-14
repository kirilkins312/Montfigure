using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class _4thMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_ClothSeps_ClothSeparId",
                table: "Cloth");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_ClothSeparId",
                table: "Cloth");

            migrationBuilder.DropColumn(
                name: "ClothSeparId",
                table: "Cloth");

            migrationBuilder.AddColumn<int>(
                name: "ClothId",
                table: "ClothSeps",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClothSeps_ClothId",
                table: "ClothSeps",
                column: "ClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothSeps_Cloth_ClothId",
                table: "ClothSeps",
                column: "ClothId",
                principalTable: "Cloth",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothSeps_Cloth_ClothId",
                table: "ClothSeps");

            migrationBuilder.DropIndex(
                name: "IX_ClothSeps_ClothId",
                table: "ClothSeps");

            migrationBuilder.DropColumn(
                name: "ClothId",
                table: "ClothSeps");

            migrationBuilder.AddColumn<int>(
                name: "ClothSeparId",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
