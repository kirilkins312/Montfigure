using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHPTH.Migrations
{
    /// <inheritdoc />
    public partial class FirstNormMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cloth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloSep = table.Column<int>(type: "int", nullable: false),
                    ColSep = table.Column<int>(type: "int", nullable: false),
                    SizeSep = table.Column<int>(type: "int", nullable: false),
                    GenSep = table.Column<int>(type: "int", nullable: false),
                    MatSep = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloth", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cloth");
        }
    }
}
