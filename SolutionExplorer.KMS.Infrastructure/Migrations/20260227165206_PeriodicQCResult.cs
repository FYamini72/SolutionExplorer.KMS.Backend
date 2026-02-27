using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PeriodicQCResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATCCCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinAcceptedResult = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATCCCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATCCCategories_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ATCCCategories_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeriodicQCBaseInfoExpectedResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlBaseInfoId = table.Column<int>(type: "int", nullable: false),
                    ATCCControlOrganism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATCCCategoryId = table.Column<int>(type: "int", nullable: false),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQCBaseInfoExpectedResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResults_ATCCCategories_ATCCCategoryId",
                        column: x => x.ATCCCategoryId,
                        principalTable: "ATCCCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResults_QualityControlBaseInfos_QualityControlBaseInfoId",
                        column: x => x.QualityControlBaseInfoId,
                        principalTable: "QualityControlBaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResults_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResults_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeriodicQualityControlCategoryResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodicQualityControlId = table.Column<int>(type: "int", nullable: false),
                    ATCCCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQualityControlCategoryResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlCategoryResults_ATCCCategories_ATCCCategoryId",
                        column: x => x.ATCCCategoryId,
                        principalTable: "ATCCCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlCategoryResults_PeriodicQualityControls_PeriodicQualityControlId",
                        column: x => x.PeriodicQualityControlId,
                        principalTable: "PeriodicQualityControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlCategoryResults_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlCategoryResults_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeriodicQCBaseInfoExpectedResultItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodicQCBaseInfoExpectedResultId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQCBaseInfoExpectedResultItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResultItems_PeriodicQCBaseInfoExpectedResults_PeriodicQCBaseInfoExpectedResultId",
                        column: x => x.PeriodicQCBaseInfoExpectedResultId,
                        principalTable: "PeriodicQCBaseInfoExpectedResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResultItems_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQCBaseInfoExpectedResultItems_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeriodicQualityControlResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodicQualityControlCategoryResultId = table.Column<int>(type: "int", nullable: false),
                    PeriodicQCBaseInfoExpectedResultId = table.Column<int>(type: "int", nullable: true),
                    CustomResultTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CorrectiveActions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQualityControlResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlResults_PeriodicQCBaseInfoExpectedResults_PeriodicQCBaseInfoExpectedResultId",
                        column: x => x.PeriodicQCBaseInfoExpectedResultId,
                        principalTable: "PeriodicQCBaseInfoExpectedResults",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlResults_PeriodicQualityControlCategoryResults_PeriodicQualityControlCategoryResultId",
                        column: x => x.PeriodicQualityControlCategoryResultId,
                        principalTable: "PeriodicQualityControlCategoryResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlResults_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControlResults_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATCCCategories_CreatedByUserId",
                table: "ATCCCategories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ATCCCategories_ModifiedByUserId",
                table: "ATCCCategories",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResultItems_CreatedByUserId",
                table: "PeriodicQCBaseInfoExpectedResultItems",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResultItems_ModifiedByUserId",
                table: "PeriodicQCBaseInfoExpectedResultItems",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResultItems_PeriodicQCBaseInfoExpectedResultId",
                table: "PeriodicQCBaseInfoExpectedResultItems",
                column: "PeriodicQCBaseInfoExpectedResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResults_ATCCCategoryId",
                table: "PeriodicQCBaseInfoExpectedResults",
                column: "ATCCCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResults_CreatedByUserId",
                table: "PeriodicQCBaseInfoExpectedResults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResults_ModifiedByUserId",
                table: "PeriodicQCBaseInfoExpectedResults",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCBaseInfoExpectedResults_QualityControlBaseInfoId",
                table: "PeriodicQCBaseInfoExpectedResults",
                column: "QualityControlBaseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlCategoryResults_ATCCCategoryId",
                table: "PeriodicQualityControlCategoryResults",
                column: "ATCCCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlCategoryResults_CreatedByUserId",
                table: "PeriodicQualityControlCategoryResults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlCategoryResults_ModifiedByUserId",
                table: "PeriodicQualityControlCategoryResults",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlCategoryResults_PeriodicQualityControlId",
                table: "PeriodicQualityControlCategoryResults",
                column: "PeriodicQualityControlId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlResults_CreatedByUserId",
                table: "PeriodicQualityControlResults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlResults_ModifiedByUserId",
                table: "PeriodicQualityControlResults",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlResults_PeriodicQCBaseInfoExpectedResultId",
                table: "PeriodicQualityControlResults",
                column: "PeriodicQCBaseInfoExpectedResultId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControlResults_PeriodicQualityControlCategoryResultId",
                table: "PeriodicQualityControlResults",
                column: "PeriodicQualityControlCategoryResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodicQCBaseInfoExpectedResultItems");

            migrationBuilder.DropTable(
                name: "PeriodicQualityControlResults");

            migrationBuilder.DropTable(
                name: "PeriodicQCBaseInfoExpectedResults");

            migrationBuilder.DropTable(
                name: "PeriodicQualityControlCategoryResults");

            migrationBuilder.DropTable(
                name: "ATCCCategories");
        }
    }
}
