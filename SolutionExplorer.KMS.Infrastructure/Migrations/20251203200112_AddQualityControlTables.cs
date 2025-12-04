using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQualityControlTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityControlBaseInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StorageConditionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlBaseInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityControlBaseInfos_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityControlBaseInfos_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QualityControlResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControlResults", x => x.Id);
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
                name: "QualityControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StorageConditionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalSpecification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformedByUserId = table.Column<int>(type: "int", nullable: true),
                    FirstConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SecondConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    FinalCondition = table.Column<bool>(type: "bit", nullable: false),
                    FinalResultNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityControls_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityControls_Users_FirstConfirmerUserId",
                        column: x => x.FirstConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityControls_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityControls_Users_PerformedByUserId",
                        column: x => x.PerformedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityControls_Users_SecondConfirmerUserId",
                        column: x => x.SecondConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlBaseInfos_CreatedByUserId",
                table: "QualityControlBaseInfos",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlBaseInfos_ModifiedByUserId",
                table: "QualityControlBaseInfos",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_CreatedByUserId",
                table: "QualityControlResults",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControlResults_ModifiedByUserId",
                table: "QualityControlResults",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_CreatedByUserId",
                table: "QualityControls",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_FirstConfirmerUserId",
                table: "QualityControls",
                column: "FirstConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_ModifiedByUserId",
                table: "QualityControls",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_PerformedByUserId",
                table: "QualityControls",
                column: "PerformedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityControls_SecondConfirmerUserId",
                table: "QualityControls",
                column: "SecondConfirmerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityControlBaseInfos");

            migrationBuilder.DropTable(
                name: "QualityControlResults");

            migrationBuilder.DropTable(
                name: "QualityControls");
        }
    }
}
