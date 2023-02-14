using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class lll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_ClothSeparation_ClothSeparid",
                table: "Cloth");

            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_GenderSeparations_GenSepid",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "GenSepid",
                table: "Cloth",
                newName: "GenId");

            migrationBuilder.RenameColumn(
                name: "ClothSeparid",
                table: "Cloth",
                newName: "CloId");

            migrationBuilder.RenameIndex(
                name: "IX_Cloth_GenSepid",
                table: "Cloth",
                newName: "IX_Cloth_GenId");

            migrationBuilder.RenameIndex(
                name: "IX_Cloth_ClothSeparid",
                table: "Cloth",
                newName: "IX_Cloth_CloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_ClothSeparation_CloId",
                table: "Cloth",
                column: "CloId",
                principalTable: "ClothSeparation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_GenderSeparations_GenId",
                table: "Cloth",
                column: "GenId",
                principalTable: "GenderSeparations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_ClothSeparation_CloId",
                table: "Cloth");

            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_GenderSeparations_GenId",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "GenId",
                table: "Cloth",
                newName: "GenSepid");

            migrationBuilder.RenameColumn(
                name: "CloId",
                table: "Cloth",
                newName: "ClothSeparid");

            migrationBuilder.RenameIndex(
                name: "IX_Cloth_GenId",
                table: "Cloth",
                newName: "IX_Cloth_GenSepid");

            migrationBuilder.RenameIndex(
                name: "IX_Cloth_CloId",
                table: "Cloth",
                newName: "IX_Cloth_ClothSeparid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_ClothSeparation_ClothSeparid",
                table: "Cloth",
                column: "ClothSeparid",
                principalTable: "ClothSeparation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_GenderSeparations_GenSepid",
                table: "Cloth",
                column: "GenSepid",
                principalTable: "GenderSeparations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
