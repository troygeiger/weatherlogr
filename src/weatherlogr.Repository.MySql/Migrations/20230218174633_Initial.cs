using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherlogr.Repository.MySql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RadarIndices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RadarDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadarIndices", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    StationID = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ObsDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TemperatureId = table.Column<long>(type: "bigint", nullable: true),
                    DewPointId = table.Column<long>(type: "bigint", nullable: true),
                    HumidityId = table.Column<long>(type: "bigint", nullable: true),
                    WindSpeedId = table.Column<long>(type: "bigint", nullable: true),
                    WindGustId = table.Column<long>(type: "bigint", nullable: true),
                    BarometricPressureId = table.Column<long>(type: "bigint", nullable: true),
                    WindChillId = table.Column<long>(type: "bigint", nullable: true),
                    HeatIndexId = table.Column<long>(type: "bigint", nullable: true),
                    VisibilityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_BarometricPressureId",
                        column: x => x.BarometricPressureId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_DewPointId",
                        column: x => x.DewPointId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_HeatIndexId",
                        column: x => x.HeatIndexId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_HumidityId",
                        column: x => x.HumidityId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_VisibilityId",
                        column: x => x.VisibilityId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_WindChillId",
                        column: x => x.WindChillId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_WindGustId",
                        column: x => x.WindGustId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Observations_UnitValues_WindSpeedId",
                        column: x => x.WindSpeedId,
                        principalTable: "UnitValues",
                        principalColumn: "Id");
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "RadarIndices");

            migrationBuilder.DropTable(
                name: "UnitValues");
        }
    }
}
