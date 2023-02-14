using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class FuckingStartOfKirilsMillenium : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClothSepar",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "SizeSeparation",
                table: "Cloth",
                newName: "GenSepid");

            migrationBuilder.RenameColumn(
                name: "GenSep",
                table: "Cloth",
                newName: "ClothSeparid");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ClothSeparation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothSeparation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GenderSeparations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderSeparations", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_ClothSeparid",
                table: "Cloth",
                column: "ClothSeparid");

            migrationBuilder.CreateIndex(
                name: "IX_Cloth_GenSepid",
                table: "Cloth",
                column: "GenSepid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_ClothSeparation_ClothSeparid",
                table: "Cloth");

            migrationBuilder.DropForeignKey(
                name: "FK_Cloth_GenderSeparations_GenSepid",
                table: "Cloth");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ClothSeparation");

            migrationBuilder.DropTable(
                name: "GenderSeparations");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_ClothSeparid",
                table: "Cloth");

            migrationBuilder.DropIndex(
                name: "IX_Cloth_GenSepid",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "GenSepid",
                table: "Cloth",
                newName: "SizeSeparation");

            migrationBuilder.RenameColumn(
                name: "ClothSeparid",
                table: "Cloth",
                newName: "GenSep");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ClothSepar",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
