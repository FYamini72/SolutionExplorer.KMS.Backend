using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DropQualityControlResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityControlResults");

            migrationBuilder.AddColumn<string>(
                name: "FinalResult",
                table: "QualityControls",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalResult",
                table: "QualityControls");

            migrationBuilder.CreateTable(
                name: "QualityControlResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    QualityControlId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NormalResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityControlResults_QualityControls_QualityControlId",
                        column: x => x.QualityControlId,
                        principalTable: "QualityControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControlResults_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityControlResults_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_CreatedByUserId",
                table: "QualityControlResults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_ModifiedByUserId",
                table: "QualityControlResults",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_QualityControlId",
                table: "QualityControlResults",
                column: "QualityControlId");
        }
    }
}
