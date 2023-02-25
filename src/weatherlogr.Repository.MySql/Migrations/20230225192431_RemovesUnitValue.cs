using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherlogr.Repository.MySql.Migrations
{
    /// <inheritdoc />
    public partial class RemovesUnitValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_StationCollector_StationID",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_BarometricPressureId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_DewPointId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_HeatIndexId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_HumidityId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_TemperatureId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_VisibilityId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_WindChillId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_WindGustId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_UnitValues_WindSpeedId",
                table: "Observations");

            migrationBuilder.DropTable(
                name: "UnitValues");

            migrationBuilder.DropIndex(
                name: "IX_Observations_BarometricPressureId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_DewPointId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_HeatIndexId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_HumidityId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_TemperatureId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_VisibilityId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_WindChillId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_WindGustId",
                table: "Observations");

            migrationBuilder.DropIndex(
                name: "IX_Observations_WindSpeedId",
                table: "Observations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationCollector",
                table: "StationCollector");

            migrationBuilder.DropColumn(
                name: "BarometricPressureId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "DewPointId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "HeatIndexId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "HumidityId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "TemperatureId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "VisibilityId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindChillId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindGustId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindSpeedId",
                table: "Observations");

            migrationBuilder.RenameTable(
                name: "StationCollector",
                newName: "StationCollectors");

            migrationBuilder.AddColumn<decimal>(
                name: "BarometricPressure",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarometricPressureUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "DewPoint",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DewPointUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "HeatIndex",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeatIndexUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Humidity",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HumidityUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Temperature",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemperatureUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Visibility",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VisibilityUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "WindChill",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WindChillUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "WindGust",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WindGustUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "WindSpeed",
                table: "Observations",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WindSpeedUOM",
                table: "Observations",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationCollectors",
                table: "StationCollectors",
                column: "StationIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_StationCollectors_StationID",
                table: "Observations",
                column: "StationID",
                principalTable: "StationCollectors",
                principalColumn: "StationIdentifier",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_StationCollectors_StationID",
                table: "Observations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationCollectors",
                table: "StationCollectors");

            migrationBuilder.DropColumn(
                name: "BarometricPressure",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "BarometricPressureUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "DewPoint",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "DewPointUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "HeatIndex",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "HeatIndexUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "HumidityUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "TemperatureUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "VisibilityUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindChill",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindChillUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindGust",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindGustUOM",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "WindSpeedUOM",
                table: "Observations");

            migrationBuilder.RenameTable(
                name: "StationCollectors",
                newName: "StationCollector");

            migrationBuilder.AddColumn<long>(
                name: "BarometricPressureId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DewPointId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HeatIndexId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HumidityId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TemperatureId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VisibilityId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WindChillId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WindGustId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WindSpeedId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationCollector",
                table: "StationCollector",
                column: "StationIdentifier");

            migrationBuilder.CreateTable(
                name: "UnitValues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UnitCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitValues", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_BarometricPressureId",
                table: "Observations",
                column: "BarometricPressureId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_DewPointId",
                table: "Observations",
                column: "DewPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_HeatIndexId",
                table: "Observations",
                column: "HeatIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_HumidityId",
                table: "Observations",
                column: "HumidityId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_TemperatureId",
                table: "Observations",
                column: "TemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_VisibilityId",
                table: "Observations",
                column: "VisibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_WindChillId",
                table: "Observations",
                column: "WindChillId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_WindGustId",
                table: "Observations",
                column: "WindGustId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_WindSpeedId",
                table: "Observations",
                column: "WindSpeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_StationCollector_StationID",
                table: "Observations",
                column: "StationID",
                principalTable: "StationCollector",
                principalColumn: "StationIdentifier",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_BarometricPressureId",
                table: "Observations",
                column: "BarometricPressureId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_DewPointId",
                table: "Observations",
                column: "DewPointId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_HeatIndexId",
                table: "Observations",
                column: "HeatIndexId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_HumidityId",
                table: "Observations",
                column: "HumidityId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_TemperatureId",
                table: "Observations",
                column: "TemperatureId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_VisibilityId",
                table: "Observations",
                column: "VisibilityId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_WindChillId",
                table: "Observations",
                column: "WindChillId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_WindGustId",
                table: "Observations",
                column: "WindGustId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_WindSpeedId",
                table: "Observations",
                column: "WindSpeedId",
                principalTable: "UnitValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
