using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStorageConditionAndQCResultTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageConditionText",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "StorageConditionText",
                table: "QualityControlBaseInfos");

            migrationBuilder.AddColumn<int>(
                name: "StorageConditionId",
                table: "QualityControls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QualityControlResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlId = table.Column<int>(type: "int", nullable: true),
                    ATCCControlOrganism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    HaloDiameter = table.Column<int>(type: "int", nullable: true),
                    PoliGroup_A = table.Column<bool>(type: "bit", nullable: true),
                    PoliGroup_B = table.Column<bool>(type: "bit", nullable: true),
                    PoliGroup_C = table.Column<bool>(type: "bit", nullable: true),
                    PoliGroup_D = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityControlResults_QualityControls_QualityControlId",
                        column: x => x.QualityControlId,
                        principalTable: "QualityControls",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "StorageConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlBaseInfoId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageConditions_QualityControlBaseInfos_QualityControlBaseInfoId",
                        column: x => x.QualityControlBaseInfoId,
                        principalTable: "QualityControlBaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StorageConditions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorageConditions_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_StorageConditionId",
                table: "QualityControls",
                column: "StorageConditionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_StorageConditions_CreatedByUserId",
                table: "StorageConditions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageConditions_ModifiedByUserId",
                table: "StorageConditions",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageConditions_QualityControlBaseInfoId",
                table: "StorageConditions",
                column: "QualityControlBaseInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityControls_StorageConditions_StorageConditionId",
                table: "QualityControls",
                column: "StorageConditionId",
                principalTable: "StorageConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityControls_StorageConditions_StorageConditionId",
                table: "QualityControls");

            migrationBuilder.DropTable(
                name: "QualityControlResults");

            migrationBuilder.DropTable(
                name: "StorageConditions");

            migrationBuilder.DropIndex(
                name: "IX_QualityControls_StorageConditionId",
                table: "QualityControls");

            migrationBuilder.DropColumn(
                name: "StorageConditionId",
                table: "QualityControls");

            migrationBuilder.AddColumn<string>(
                name: "StorageConditionText",
                table: "QualityControls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StorageConditionText",
                table: "QualityControlBaseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
