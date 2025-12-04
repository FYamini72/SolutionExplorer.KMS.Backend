using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQCPeriodSettingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayIntervalCount",
                table: "QualityControlBaseInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextQualityControlTime",
                table: "QualityControlBaseInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QualityControlPeriod",
                table: "QualityControlBaseInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayIntervalCount",
                table: "QualityControlBaseInfos");

            migrationBuilder.DropColumn(
                name: "NextQualityControlTime",
                table: "QualityControlBaseInfos");

            migrationBuilder.DropColumn(
                name: "QualityControlPeriod",
                table: "QualityControlBaseInfos");
        }
    }
}
