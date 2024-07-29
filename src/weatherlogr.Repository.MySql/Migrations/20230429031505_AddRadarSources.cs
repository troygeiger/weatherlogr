using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherlogr.Repository.MySql.Migrations
{
    /// <inheritdoc />
    public partial class AddRadarSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "RadarIndices");

            migrationBuilder.AddColumn<int>(
                name: "RadarSourceID",
                table: "RadarIndices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RadarSource",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadarSource", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RadarIndices_RadarSourceID",
                table: "RadarIndices",
                column: "RadarSourceID");

            migrationBuilder.AddForeignKey(
                name: "FK_RadarIndices_RadarSource_RadarSourceID",
                table: "RadarIndices",
                column: "RadarSourceID",
                principalTable: "RadarSource",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadarIndices_RadarSource_RadarSourceID",
                table: "RadarIndices");

            migrationBuilder.DropTable(
                name: "RadarSource");

            migrationBuilder.DropIndex(
                name: "IX_RadarIndices_RadarSourceID",
                table: "RadarIndices");

            migrationBuilder.DropColumn(
                name: "RadarSourceID",
                table: "RadarIndices");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "RadarIndices",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
