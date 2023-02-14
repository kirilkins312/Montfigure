using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class Kiri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColSep",
                table: "Cloth");

            migrationBuilder.RenameColumn(
                name: "SizeSep",
                table: "Cloth",
                newName: "SizeSeparation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeSeparation",
                table: "Cloth",
                newName: "SizeSep");

            migrationBuilder.AddColumn<int>(
                name: "ColSep",
                table: "Cloth",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
