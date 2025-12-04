using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplyQCChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Produces",
                table: "QualityControls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QualityControlBaseInfoId",
                table: "QualityControls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QualityControlId",
                table: "QualityControlResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_QualityControlBaseInfoId",
                table: "QualityControls",
                column: "QualityControlBaseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_QualityControlId",
                table: "QualityControlResults",
                column: "QualityControlId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControlResults_QualityControls_QualityControlId",
                table: "QualityControlResults",
                column: "QualityControlId",
                principalTable: "QualityControls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControls_QualityControlBaseInfos_QualityControlBaseInfoId",
                table: "QualityControls",
                column: "QualityControlBaseInfoId",
                principalTable: "QualityControlBaseInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityControlResults_QualityControls_QualityControlId",
                table: "QualityControlResults");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityControls_QualityControlBaseInfos_QualityControlBaseInfoId",
                table: "QualityControls");

            migrationBuilder.DropIndex(
                name: "IX_QualityControls_QualityControlBaseInfoId",
                table: "QualityControls");

            migrationBuilder.DropIndex(
                name: "IX_QualityControlResults_QualityControlId",
                table: "QualityControlResults");

            migrationBuilder.DropColumn(
                name: "Produces",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "QualityControlBaseInfoId",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "QualityControlId",
                table: "QualityControlResults");
        }
    }
}
