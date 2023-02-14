using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class _6thMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ClothSepar",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClothSepar",
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
    }
}
