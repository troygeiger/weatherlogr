using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherlogr.Repository.MySql.Migrations
{
    /// <inheritdoc />
    public partial class IndexRadar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadarIndices_RadarSource_RadarSourceID",
                table: "RadarIndices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RadarSource",
                table: "RadarSource");

            migrationBuilder.RenameTable(
                name: "RadarSource",
                newName: "RadarSources");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "RadarSources",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PickupCronTabSchedule",
                table: "RadarSources",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RadarSources",
                table: "RadarSources",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_RadarIndices_RadarDate",
                table: "RadarIndices",
                column: "RadarDate");

            migrationBuilder.AddForeignKey(
                name: "FK_RadarIndices_RadarSources_RadarSourceID",
                table: "RadarIndices",
                column: "RadarSourceID",
                principalTable: "RadarSources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RadarIndices_RadarSources_RadarSourceID",
                table: "RadarIndices");

            migrationBuilder.DropIndex(
                name: "IX_RadarIndices_RadarDate",
                table: "RadarIndices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RadarSources",
                table: "RadarSources");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "RadarSources");

            migrationBuilder.DropColumn(
                name: "PickupCronTabSchedule",
                table: "RadarSources");

            migrationBuilder.RenameTable(
                name: "RadarSources",
                newName: "RadarSource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RadarSource",
                table: "RadarSource",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RadarIndices_RadarSource_RadarSourceID",
                table: "RadarIndices",
                column: "RadarSourceID",
                principalTable: "RadarSource",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
