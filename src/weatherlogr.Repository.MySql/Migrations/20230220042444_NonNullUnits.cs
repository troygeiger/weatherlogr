using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherlogr.Repository.MySql.Migrations
{
    /// <inheritdoc />
    public partial class NonNullUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<long>(
                name: "WindSpeedId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WindGustId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "WindChillId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VisibilityId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TemperatureId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HumidityId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HeatIndexId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DewPointId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BarometricPressureId",
                table: "Observations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<long>(
                name: "WindSpeedId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "WindGustId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "WindChillId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "VisibilityId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TemperatureId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "HumidityId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "HeatIndexId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DewPointId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "BarometricPressureId",
                table: "Observations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_BarometricPressureId",
                table: "Observations",
                column: "BarometricPressureId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_DewPointId",
                table: "Observations",
                column: "DewPointId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_HeatIndexId",
                table: "Observations",
                column: "HeatIndexId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_HumidityId",
                table: "Observations",
                column: "HumidityId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_TemperatureId",
                table: "Observations",
                column: "TemperatureId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_VisibilityId",
                table: "Observations",
                column: "VisibilityId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_WindChillId",
                table: "Observations",
                column: "WindChillId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_WindGustId",
                table: "Observations",
                column: "WindGustId",
                principalTable: "UnitValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_UnitValues_WindSpeedId",
                table: "Observations",
                column: "WindSpeedId",
                principalTable: "UnitValues",
                principalColumn: "Id");
        }
    }
}
