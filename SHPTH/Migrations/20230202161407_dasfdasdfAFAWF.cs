using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class dasfdasdfAFAWF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_GenderSeparations_GenId",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "GenderSeparations");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ClothSeparation",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenId",
                table: "Cloth",
                newName: "SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cloth_GenId",
                table: "Cloth",
                newName: "IX_Cloth_SizeId");

            migrationBuilder.AddColumn<int>(
                name: "GenderSeparation",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SizeSeparations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeSeparations", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_SizeSeparations_SizeId",
                table: "Cloth",
                column: "SizeId",
                principalTable: "SizeSeparations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_SizeSeparations_SizeId",
                table: "Cloth");

            migrationBuilder.DropTable(
                name: "SizeSeparations");

            migrationBuilder.DropColumn(
                name: "GenderSeparation",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ClothSeparation",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Cloth",
                newName: "GenId");

            migrationBuilder.RenameIndex(
                name: "IX_Cloth_SizeId",
                table: "Cloth",
                newName: "IX_Cloth_GenId");

            migrationBuilder.CreateTable(
                name: "GenderSeparations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderSeparations", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cloth_GenderSeparations_GenId",
                table: "Cloth",
                column: "GenId",
                principalTable: "GenderSeparations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
