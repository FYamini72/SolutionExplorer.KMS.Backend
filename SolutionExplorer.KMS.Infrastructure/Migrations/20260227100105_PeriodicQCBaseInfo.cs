using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionExplorer.KMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PeriodicQCBaseInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodicQualityControls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlBaseInfoId = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedByUserId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PowderGramPerLiter = table.Column<float>(type: "real", nullable: false),
                    UsageStartAcceptanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediumCount = table.Column<int>(type: "int", nullable: false),
                    StorageTemperature = table.Column<int>(type: "int", nullable: false),
                    ShelfLifeDuration = table.Column<int>(type: "int", nullable: false),
                    AutoclaveConditions = table.Column<int>(type: "int", nullable: false),
                    ExtraAutoclaveCondition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediumType = table.Column<int>(type: "int", nullable: false),
                    QualityControlPeriod = table.Column<int>(type: "int", nullable: false),
                    QualityControlDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    SecondConfirmerUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQualityControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControls_QualityControlBaseInfos_QualityControlBaseInfoId",
                        column: x => x.QualityControlBaseInfoId,
                        principalTable: "QualityControlBaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControls_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControls_Users_FirstConfirmerUserId",
                        column: x => x.FirstConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControls_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControls_Users_PerformedByUserId",
                        column: x => x.PerformedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQualityControls_Users_SecondConfirmerUserId",
                        column: x => x.SecondConfirmerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QCBaseInfoAppearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityControlBaseInfoId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppearanceGroup = table.Column<int>(type: "int", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCBaseInfoAppearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCBaseInfoAppearances_QualityControlBaseInfos_QualityControlBaseInfoId",
                        column: x => x.QualityControlBaseInfoId,
                        principalTable: "QualityControlBaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QCBaseInfoAppearances_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QCBaseInfoAppearances_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeriodicQCPhysicalSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCBaseInfoPhysicalSpecificationId = table.Column<int>(type: "int", nullable: false),
                    PeriodicQualityControlId = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQCPhysicalSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQCPhysicalSpecifications_PeriodicQualityControls_PeriodicQualityControlId",
                        column: x => x.PeriodicQualityControlId,
                        principalTable: "PeriodicQualityControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCPhysicalSpecifications_QCBaseInfoPhysicalSpecifications_QCBaseInfoPhysicalSpecificationId",
                        column: x => x.QCBaseInfoPhysicalSpecificationId,
                        principalTable: "QCBaseInfoPhysicalSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCPhysicalSpecifications_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQCPhysicalSpecifications_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeriodicQCAppearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodicQualityControlId = table.Column<int>(type: "int", nullable: false),
                    QCBaseInfoAppearanceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicQCAppearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodicQCAppearances_PeriodicQualityControls_PeriodicQualityControlId",
                        column: x => x.PeriodicQualityControlId,
                        principalTable: "PeriodicQualityControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCAppearances_QCBaseInfoAppearances_QCBaseInfoAppearanceId",
                        column: x => x.QCBaseInfoAppearanceId,
                        principalTable: "QCBaseInfoAppearances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodicQCAppearances_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeriodicQCAppearances_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCAppearances_CreatedByUserId",
                table: "PeriodicQCAppearances",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCAppearances_ModifiedByUserId",
                table: "PeriodicQCAppearances",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCAppearances_PeriodicQualityControlId",
                table: "PeriodicQCAppearances",
                column: "PeriodicQualityControlId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCAppearances_QCBaseInfoAppearanceId",
                table: "PeriodicQCAppearances",
                column: "QCBaseInfoAppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCPhysicalSpecifications_CreatedByUserId",
                table: "PeriodicQCPhysicalSpecifications",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCPhysicalSpecifications_ModifiedByUserId",
                table: "PeriodicQCPhysicalSpecifications",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCPhysicalSpecifications_PeriodicQualityControlId",
                table: "PeriodicQCPhysicalSpecifications",
                column: "PeriodicQualityControlId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQCPhysicalSpecifications_QCBaseInfoPhysicalSpecificationId",
                table: "PeriodicQCPhysicalSpecifications",
                column: "QCBaseInfoPhysicalSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControls_CreatedByUserId",
                table: "PeriodicQualityControls",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControls_FirstConfirmerUserId",
                table: "PeriodicQualityControls",
                column: "FirstConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControls_ModifiedByUserId",
                table: "PeriodicQualityControls",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControls_PerformedByUserId",
                table: "PeriodicQualityControls",
                column: "PerformedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControls_QualityControlBaseInfoId",
                table: "PeriodicQualityControls",
                column: "QualityControlBaseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicQualityControls_SecondConfirmerUserId",
                table: "PeriodicQualityControls",
                column: "SecondConfirmerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoAppearances_CreatedByUserId",
                table: "QCBaseInfoAppearances",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoAppearances_ModifiedByUserId",
                table: "QCBaseInfoAppearances",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QCBaseInfoAppearances_QualityControlBaseInfoId",
                table: "QCBaseInfoAppearances",
                column: "QualityControlBaseInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodicQCAppearances");

            migrationBuilder.DropTable(
                name: "PeriodicQCPhysicalSpecifications");

            migrationBuilder.DropTable(
                name: "QCBaseInfoAppearances");

            migrationBuilder.DropTable(
                name: "PeriodicQualityControls");
        }
    }
}
